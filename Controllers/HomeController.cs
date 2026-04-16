using HotelSysRD.Data;
using HotelSysRD.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelSysRD.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelContext _context;

        public HomeController(HotelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogueado")))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new DashboardViewModel
            {
                TotalHabitaciones = _context.Habitaciones.Count(),
                TotalClientes = _context.Clientes.Count(),
                TotalReservaciones = _context.Reservaciones.Count(),
                HabitacionesDisponibles = _context.Habitaciones.Count(h => h.Estado == "Disponible"),
                HabitacionesOcupadas = _context.Habitaciones.Count(h => h.Estado == "Ocupada"),
                HabitacionesMantenimiento = _context.Habitaciones.Count(h => h.Estado == "Mantenimiento")
            };

            return View(model);
        }
    }
}