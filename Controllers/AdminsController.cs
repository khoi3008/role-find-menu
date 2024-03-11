using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.list;


namespace RoleBasedAuthorization.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly Ikasecurity3pContext _db;
        public AdminsController(Ikasecurity3pContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;

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
        public async Task<IActionResult> Create(string Password, [Bind("FullName,UserName,Email")] TblUserAccount userAccount, string[] roles)
        {
            string passwordHash = HashPassword(Password);

            userAccount.PasswordHash = passwordHash;

            _db.TblUserAccounts.Add(userAccount);
            await _db.SaveChangesAsync();
            string userId = userAccount.UserName;

            foreach (var roleName in roles)
            {
                var role = _db.TblUserRoles.FirstOrDefault(r => r.RoleName == roleName);
                if (role != null)
                {
                    _db.TblUserRoles.Add(new TblUserRole { UserName = userId, RoleName = role.RoleName });
                }
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }

        [AuthorizedAction]
        public IActionResult Edit()
        {
            string user_name = HttpContext.Request.Query["UserName"]!;
            var userAccount = _db.TblUserAccounts.FirstOrDefaultAsync(s => s.UserName == user_name);
            ViewBag.UserName = user_name;
            return View();
        }

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
            string userEmail = _httpContextAccessor.HttpContext.Session.GetString("email");
            Console.WriteLine($" email cua session la :{userEmail}");
            ViewBag.Email = userEmail;
            return View();
        }


        [HttpPost]
        [AuthorizedAction]
        public async Task<IActionResult> ResetPassword(string passwordOld, string passwordNew, string userEmail, TblUserAccount userAccount)
        {
            if (string.IsNullOrWhiteSpace(passwordOld) || string.IsNullOrWhiteSpace(passwordNew) || string.IsNullOrWhiteSpace(userEmail))
            {
                return BadRequest("Password, new password, and user email cannot be null or empty");
            }

            var user = await _db.TblUserAccounts.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user != null && VerifyPasswordHash(passwordOld, user.PasswordHash))
            {
                user.PasswordHash = HashPassword(passwordNew);
                await _db.SaveChangesAsync();
                return Ok("Reset Password Completed");
            }

            return BadRequest("Invalid Email or Password");
        }


        private string HashPassword(string password)
        {
            var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));
            hasher.Iterations = 1;
            hasher.MemorySize = 4096;
            hasher.DegreeOfParallelism = 1;
            byte[] hashBytes = hasher.GetBytes(32);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }

        private bool VerifyPasswordHash(string password, string storedPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(storedPasswordHash))
            {
                return false;
            }

            byte[] storedHashBytes = Convert.FromBase64String(storedPasswordHash);
            var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));
            hasher.Iterations = 1;
            hasher.MemorySize = 4096;
            hasher.DegreeOfParallelism = 1;
            byte[] inputHashBytes = hasher.GetBytes(32);
            return storedHashBytes.SequenceEqual(inputHashBytes);
        }


    }
}

