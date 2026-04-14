using HotelSysRD.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelSysRD.Controllers
{
    // Controlador encargado del inicio y cierre de sesión
    public class AccountController : Controller
    {
        // Muestra el formulario de login
        public IActionResult Login()
        {
            return View();
        }

        // Procesa el formulario de login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Usuario y contraseña fijos para fines académicos
            if (model.Usuario == "admin" && model.Contrasena == "Admin123*")
            {
                HttpContext.Session.SetString("UsuarioLogueado", model.Usuario);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
            return View(model);
        }

        // Cierra la sesión del usuario
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}