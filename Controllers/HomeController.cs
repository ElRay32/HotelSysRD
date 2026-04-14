using Microsoft.AspNetCore.Mvc;

namespace HotelSysRD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogueado")))
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}