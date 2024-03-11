using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.list;


namespace RoleBasedAuthorization.Controllers
{
    public class AdminsController : Controller
    {

        private readonly Ikasecurity3pContext _db;
        public AdminsController(Ikasecurity3pContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _db.TblUserAccounts.ToListAsync());
        }

        public IActionResult Error()
        {

            return View();
        }



        // GET: Admins/Create
        [AuthorizedAction]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> selectList = _db.TblUserRoles.Select(x => new SelectListItem
            {
                Value = x.RoleName,
                Text = x.RoleName
            });
            ViewBag.Roles = selectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,UserName,Email,Password")] TblUserAccount userAccount, string[] roles)
        {

            _db.Add(userAccount);
            await _db.SaveChangesAsync();

            string userId = userAccount.UserName;

            foreach (var roleName in roles)
            {

                var role = _db.TblUserRoles.FirstOrDefault(r => r.RoleName == roleName);
                if (role != null)
                {
                    _db.TblUserRoles.Add(new TblUserRole {UserName = userId, RoleName = role.RoleName });
                }
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // [AuthorizedAction]
        // public IActionResult Edit()
        // {
        //     string user_name = HttpContext.Request.Query["UserName"];
        //     var userAccount = _db.TblUserAccounts.FirstOrDefaultAsync(s => s.UserName == user_name);
        //     ViewBag.UserName = user_name;
        //     return View();
        // }

        // [HttpPost]
        // public async Task<IActionResult> Edit(string user_name, [Bind("FullName,Email")] TblUserAccount userAccounts)
        // {

        //     var userAccount = await _db.TblUserAccounts.FirstOrDefaultAsync(s => s.UserName == user_name);
        //     if (userAccount == null)
        //     {
        //         return NotFound();
        //     }

        //     userAccount.FullName = userAccounts.FullName;
        //     userAccount.Email = userAccounts.Email;
        //     userAccount.TblUserRoles = userAccounts.TblUserRoles;

        //     IEnumerable<SelectListItem> selectList = _db.TblUserRoles.Select(x => new SelectListItem
        //     {
        //         Value = x.RoleName,
        //         Text = x.RoleName
        //     });
        //     ViewBag.RoleName = selectList;
        //     await _db.SaveChangesAsync();

        //     return RedirectToAction(nameof(Index));
        // }


        // // GET: Admins/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var admins = await _db.Admins
        //         .Include(a => a.Roles)
        //         .SingleOrDefaultAsync(m => m.Id == id);
        //     if (admins == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(admins);
        // }

        // POST: Admins/DeleteConfirmed/5
        // [HttpPost, ActionName("DeleteConfirmed")]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var admins = await _db.Admins.SingleOrDefaultAsync(m => m.Id == id);
        //     _db.Admins.Remove(admins);
        //     await _db.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool AdminsExists(int id)
        // {
        //     return _db.Admins.Any(e => e.Id == id);
        // }
        // }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            string userEmail = HttpContext.Request.Query["userEmail"];
            ViewBag.UserEmail = userEmail;
            return View();
        }

        [HttpPost]
        [AuthorizedAction]
        public async Task<IActionResult> ResetPassword(string userEmail, string passwordNew)
        {
            if (userEmail != null)
            {
                var user = await _db.TblUserAccounts.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (user != null)
                {
                    user.PasswordHash = HashPassword(passwordNew);
                    _db.Update(user);
                    await _db.SaveChangesAsync();
                    return Ok("Reset Password Complete");
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            else
            {
                return BadRequest("User email is required.");
            }
        }



        private string HashPassword(string password)
        {
            var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));
            hasher.Iterations = 1;
            hasher.MemorySize = 4096;
            hasher.DegreeOfParallelism = 1;
            byte[] hashByte = hasher.GetBytes(32);
            string hashString = Convert.ToBase64String(hashByte);
            return hashString;
        }
    }
}

