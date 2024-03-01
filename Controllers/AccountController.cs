using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoleBasedAuthorization.Models;

namespace RoleBasedAuthorization.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        // ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Login()
        {
            return View();
        }

        public ActionResult Validate(Admins admin)
        {
            var _admin = _db.Admins.Where(s => s.Email == admin.Email).FirstOrDefault();
            if (_admin != null)
            {
                if (_admin.Password == admin.Password)
                {
                    HttpContext.Session.SetString("email", _admin.Email);
                    HttpContext.Session.SetInt32("id", _admin.Id);
                    HttpContext.Session.SetInt32("role_id", (int)_admin.RolesId!);
                    HttpContext.Session.SetString("name", _admin.FullName);


                    int roleId = (int)HttpContext.Session.GetInt32("role_id")!;
                    List<Menus> menus = _db.LinkRolesMenus.Where(s => s.RolesId == roleId).Select(s => s.Menus).ToList();

                    DataSet ds = new DataSet();
                    ds = ToDataSet(menus);
                    DataTable table = ds.Tables[0];
                    DataRow[] parentMenus = table.Select("ParentId909= 0");

                    var sb = new StringBuilder();
                    string menuString = GenerateUL(parentMenus, table, sb);

                    HttpContext.Session.SetString("menuString", menuString);
                    HttpContext.Session.SetString("menus", JsonConvert.SerializeObject(menus));

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = true, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
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
                    if (subMenu.Length > 0)
                    {

                    }
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