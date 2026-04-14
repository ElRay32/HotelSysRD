using HotelSysRD.Data;
using HotelSysRD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelSysRD.Controllers
{
    // Controlador encargado del CRUD de reservaciones
    public class ReservacionesController : Controller
    {
        private readonly HotelContext _context;

        public ReservacionesController(HotelContext context)
        {
            _context = context;
        }

        // Muestra el listado de reservaciones con cliente y habitación
        public async Task<IActionResult> Index()
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            var reservaciones = _context.Reservaciones
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion);

            return View(await reservaciones.ToListAsync());
        }

        // Muestra detalles de una reservación
        public async Task<IActionResult> Details(int? id)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservaciones
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // Muestra formulario de creación
        public IActionResult Create()
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            CargarListas();
            return View();
        }

        // Guarda una nueva reservación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservacion reservacion)
        {

            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (reservacion.FechaSalida <= reservacion.FechaEntrada)
            {
                ModelState.AddModelError("FechaSalida", "La fecha de salida debe ser mayor que la fecha de entrada.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(reservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CargarListas(reservacion.ClienteId, reservacion.HabitacionId);
            return View(reservacion);
        }

        // Muestra formulario de edición
        public async Task<IActionResult> Edit(int? id)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservaciones.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            CargarListas(reservacion.ClienteId, reservacion.HabitacionId);
            return View(reservacion);
        }

        // Guarda cambios de la reservación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservacion reservacion)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id != reservacion.Id)
            {
                return NotFound();
            }

            if (reservacion.FechaSalida <= reservacion.FechaEntrada)
            {
                ModelState.AddModelError("FechaSalida", "La fecha de salida debe ser mayor que la fecha de entrada.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionExists(reservacion.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            CargarListas(reservacion.ClienteId, reservacion.HabitacionId);
            return View(reservacion);
        }

        // Muestra confirmación de eliminación
        public async Task<IActionResult> Delete(int? id)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservaciones
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // Elimina reservación
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            var reservacion = await _context.Reservaciones.FindAsync(id);

            if (reservacion != null)
            {
                _context.Reservaciones.Remove(reservacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Carga listas de clientes y habitaciones para los dropdowns
        private void CargarListas(int? clienteId = null, int? habitacionId = null)
        {
            ViewBag.ClienteId = new SelectList(
                _context.Clientes.Select(c => new
                {
                    c.Id,
                    NombreCompleto = c.Nombre + " " + c.Apellido
                }).ToList(),
                "Id",
                "NombreCompleto",
                clienteId
            );

            ViewBag.HabitacionId = new SelectList(
                _context.Habitaciones.Select(h => new
                {
                    h.Id,
                    Descripcion = h.Numero + " - " + h.Tipo
                }).ToList(),
                "Id",
                "Descripcion",
                habitacionId
            );
        }

        // Verifica si la reservación existe
        private bool ReservacionExists(int id)
        {
            return _context.Reservaciones.Any(r => r.Id == id);
        }
        private bool UsuarioNoAutenticado()
        {
            return string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogueado"));
        }
    }
}