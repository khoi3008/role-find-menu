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
using Newtonsoft.Json;
using RoleBasedAuthorization.list;


namespace RoleBasedAuthorization.Controllers
{
    public class AccountController : Controller
    {
        private readonly Ikasecurity3pContext _db;
        private readonly ILogger<AccountController> _logger;
        public AccountController(Ikasecurity3pContext db, ILogger<AccountController> logger)
        {
            _db = db;
            _logger = logger;
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

            // Kiểm tra nếu không có menu nào được trả về từ cơ sở dữ liệu
            if (menus.Any())
            {
                var sb = new StringBuilder();
                foreach (var menu in menus)
                {
                    List<TblMenu> menu1 = _db.TblMenuRoles.Where(u => u.RoleName == menu.RoleName).Select(u => u.Menu).ToList();
                    DataSet ds = ToDataSet(menu1);
                    DataTable table = ds.Tables[0];
                    DataRow[] parentMenus = table.Select("ParentId = 0");

                    string menuString = GenerateUL(parentMenus, table, sb);
                    _logger.LogInformation("Before setting menuString in session: " + HttpContext.Session.GetString("menuString"));
                    if (!string.IsNullOrEmpty(menuString))
                    {
                        HttpContext.Session.SetString("menuString", menuString);
                    }
                    _logger.LogInformation("After setting menuString in session: " + HttpContext.Session.GetString("menuString"));

                    HttpContext.Session.SetString("menus", JsonConvert.SerializeObject(menu1));
                }
            }
            else
            {
                HttpContext.Session.Remove("menuString"); // Xóa menuString nếu không có menu nào
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


        private string GenerateUL(DataRow[] menu, DataTable table, StringBuilder sb)
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
                    if (url != "#")
                    {
                        string line = String.Format(@"<li><a href=""{0}""><i class=""{2}""></i> <span>{1}</span></a></li>", url, menuText, icon);
                        sb.Append(line);
                    }

                    string pid = dr["Id"].ToString()!;
                    string parentId = dr["ParentId"].ToString()!;


                    DataRow[] subMenu = table.Select(String.Format("ParentId = '{0}'", pid));
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {
                        string line = String.Format(@"<li class=""treeview""><a href=""#""><i class=""{0}""></i> <span style=""color: #a6bab8;:"">{1}</span><span class=""pull-right-container""><i class=""fa fa-angle-left pull-right""></i></span></a><ul class=""treeview-menu"">", icon, menuText);
                        var subMenuBuilder = new StringBuilder();
                        sb.AppendLine(line);
                        sb.Append(GenerateUL(subMenu, table, subMenuBuilder));
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
                string url = dr["Url"].ToString()!;
                string icon = dr["Icon"].ToString()!;
                string id = dr["Id"].ToString()!;

                DataRow[] childMenus = table.Select($"ParentId = '{id}'");
                if (childMenus.Length > 0)
                {
                    foreach (var childMenus1 in childMenus)
                    {
                        string name = childMenus1["Name"].ToString()!;
                        string line = $" <li style='padding : 20px '><a href='{url}'><i class='{icon}'></i> <span>{name}</span></a></li>";
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
                //Setting column names as Property names
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

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}