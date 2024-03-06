using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.list;

namespace RoleBasedAuthorization.Controllers
{
    public class HomeController : Controller
    {
        //MyDbContext db = new MyDbContext();
        private readonly Ikasecurity3pContext _db;
          private readonly ILogger<AccountController> _logger;
        public HomeController(Ikasecurity3pContext db , ILogger<AccountController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return Redirect("/Account/Login");
            }
_logger.LogInformation("khôi trần");

            return View();
        }


    }
}