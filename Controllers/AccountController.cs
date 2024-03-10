using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RoleBasedAuthorization.list;


namespace RoleBasedAuthorization.Controllers
{
    public class AccountController : Controller
    {
        private readonly Ikasecurity3pContext _db;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        public AccountController(Ikasecurity3pContext db, ILogger<AccountController> logger, IConfiguration configuration)
        {
            _db = db;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Account/Login"); ;
        }
        public IActionResult Login()

        {
            return View();
        }

        public ActionResult Validate(string email, string password)
        {
            var _admin = _db.TblUserAccounts.FirstOrDefault(s => s.Email == email);
            if (_admin != null)
            {

                if (VerifyPassword(password, _admin.PasswordHash!))
                {
                    HttpContext.Session.SetString("email", _admin.Email!);
                    HttpContext.Session.SetString("UserName", _admin.UserName);
                    HttpContext.Session.SetString("name", _admin.FullName!);
                    string UserName = HttpContext.Session.GetString("UserName")!;
                    List<TblUserRole> menus = _db.TblUserRoles.Where(u => u.UserName == UserName).ToList();
                    if (menus.Any())
                    {
                        var sb = new StringBuilder();
                        foreach (var menu in menus)
                        {
                            List<TblMenu> menu1 = _db.TblMenuRoles.Where(u => u.RoleName == menu.RoleName).Select(u => u.Menu).ToList();
                            DataSet ds = ToDataSet(menu1);
                            DataTable table = ds.Tables[0];
                            DataRow[] parentMenus = table.Select("ParentId = 0");

                            string menuString = GenerateUL(parentMenus, table, sb, ref UserName);

                            if (!string.IsNullOrEmpty(menuString))
                            {
                                HttpContext.Session.SetString("menuString", menuString);
                            }
                            HttpContext.Session.SetString("menus", JsonConvert.SerializeObject(menu1));
                        }
                    }
                    else
                    {
                        HttpContext.Session.Remove("menuString");
                        _logger.LogInformation("No menu found for user.");
                    }

                    return Json(new { status = true, message = "Login Successful!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
            }
        }

        public IActionResult CheckAccessSP(string UserName, string FunctionName, string PermissionType, string url)
        {
            _logger.LogInformation(url);
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[st_CheckFunctionPermission]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số cho Stored Procedure
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@FunctionName", FunctionName);
                        command.Parameters.AddWithValue("@PermissionType", PermissionType);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string permissionType = reader["PermissionType"]!.ToString()!;
                                string[] permissions = permissionType.Split(';');
                                if (permissions.Contains(PermissionType))
                                {
                                    _logger.LogInformation("Có quyền truy cập.");
                                    return Redirect(url);

                                }
                                else
                                {
                                    return RedirectToAction("AccessDenied", "Home");
                                }
                            }
                            else
                            {
                                return NotFound(); // Không tìm thấy bản ghi phù hợp
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                _logger.LogError(ex, "Error checking access.");
                return StatusCode(500, "Error occurred while checking access"); // Trả về mã lỗi 500 và thông báo lỗi
            }
        }
        private bool VerifyPassword(string inputPassword, string storedPasswordHash)
        {
            try
            {

                byte[] storedHashBytes = Convert.FromBase64String(storedPasswordHash);
                var hasher = new Argon2id(Encoding.UTF8.GetBytes(inputPassword));
                hasher.Iterations = 1;
                hasher.MemorySize = 4096;
                hasher.DegreeOfParallelism = 1;

                byte[] inputHashBytes = hasher.GetBytes(32);
                return storedHashBytes.SequenceEqual(inputHashBytes);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GenerateUL(DataRow[] menu, DataTable table, StringBuilder sb, ref string UserName)
        {

            if (menu.Length > 0)
            {
                StringBuilder quickAccessBuilder = new StringBuilder();
                GenerateQuickAccess(menu, table, quickAccessBuilder);
                sb.Append("<ul class='quick-access-menu'>");
                sb.Append(quickAccessBuilder.ToString());
                sb.Append("</ul>");
                foreach (DataRow dr in menu)
                {
                    string url = dr["Url"].ToString()!;
                    string menuText = dr["Name"].ToString()!;
                    string icon = dr["Icon"].ToString()!;
                    string functionName = dr["FunctionName"].ToString()!;
                    string NameEng = dr["NameEng"].ToString()!;
                    if (url != "#")
                    {
                        string line = String.Format(@"<li><a  data-username=""{5}"" data-url=""{0}""  data-function=""{3}""  data-type=""{4}""><i class=""{2}""></i> <span>{1}</span></a></li>", url, menuText, icon, functionName, NameEng, UserName);
                        sb.Append(line);
                    }

                    string pid = dr["Id"].ToString()!;
                    string parentId = dr["ParentId"].ToString()!;


                    DataRow[] subMenu = table.Select(String.Format("ParentId = '{0}'", pid));
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {
                        string line = String.Format(@"<li class=""treeview""><a href=""{0}""><i class=""{1}""></i> <span style=""color: #a6bab8;:"">{2}</span><span class=""pull-right-container""><i class=""fa fa-angle-left pull-right""></i></span></a><ul class=""treeview-menu"">", url, icon, menuText);
                        var subMenuBuilder = new StringBuilder();
                        sb.AppendLine(line);
                        sb.Append(GenerateUL(subMenu, table, subMenuBuilder, ref UserName));
                        sb.Append("</ul></li>");
                    }
                }
            }
            return sb.ToString();
        }
        private void GenerateQuickAccess(DataRow[] menu, DataTable table, StringBuilder quickAccessBuilder)
        {
            foreach (DataRow dr in menu)
            {


                string id = dr["Id"].ToString()!;

                DataRow[] childMenus = table.Select($"ParentId = '{id}'");
                if (childMenus.Length > 0)
                {
                    foreach (var childMenus1 in childMenus)
                    {
                        string name = childMenus1["Name"].ToString()!;
                        string url = childMenus1["Url"].ToString()!;
                        string icon = childMenus1["Icon"].ToString()!;
                        string line = $" <li style='padding : 20px '><a href='{url}'><i class='{icon}'></i> <span style='color:  #525f5e'>{name}</span></a></li>";
                        quickAccessBuilder.Append(line);
                    }
                }
                GenerateQuickAccess(childMenus, table, quickAccessBuilder);
            }
        }

        public DataSet ToDataSet<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {

                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null)!;
                }
                dataTable.Rows.Add(values);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dataTable);
            return ds;
        }


    }

}