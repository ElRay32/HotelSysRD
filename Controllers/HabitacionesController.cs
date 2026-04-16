using HotelSysRD.Data;
using HotelSysRD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelSysRD.Controllers
{
    // Controlador encargado de gestionar las operaciones CRUD de habitaciones
    public class HabitacionesController : Controller
    {
        private readonly HotelContext _context;

        // Inyección del contexto de base de datos
        public HabitacionesController(HotelContext context)
        {
            _context = context;
        }

        // Muestra el listado completo de habitaciones
        public async Task<IActionResult> Index()
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            return View(await _context.Habitaciones.ToListAsync());
        }

        // Muestra el detalle de una habitación específica
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

            var habitacion = await _context.Habitaciones
                .FirstOrDefaultAsync(h => h.Id == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // Muestra el formulario para crear una nueva habitación
        public IActionResult Create()
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            var habitacion = new Habitacion
            {
                Numero = GenerarSiguienteNumeroHabitacion(),
                Estado = "Disponible"
            };

            return View(habitacion);
        }

        // Procesa los datos enviados desde el formulario de creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Habitacion habitacion)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            // Genera valores controlados por el servidor
            habitacion.Numero = GenerarSiguienteNumeroHabitacion();
            habitacion.Estado = "Disponible";

            // Limpia valores de ModelState para los campos que controla el backend
            ModelState.Remove(nameof(Habitacion.Numero));
            ModelState.Remove(nameof(Habitacion.Estado));

            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(habitacion);
        }

        // Muestra el formulario para editar una habitación existente
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

            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // Procesa los cambios realizados a una habitación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Habitacion habitacion)
        {

            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id != habitacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(habitacion);
        }

        // Muestra la vista de confirmación para eliminar una habitación
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

            var habitacion = await _context.Habitaciones
                .FirstOrDefaultAsync(h => h.Id == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // Elimina definitivamente la habitación seleccionada
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            var habitacion = await _context.Habitaciones.FindAsync(id);

            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Verifica si una habitación existe en base de datos
        private bool HabitacionExists(int id)
        {
            return _context.Habitaciones.Any(h => h.Id == id);
        }
        private bool UsuarioNoAutenticado()
        {
            return string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogueado"));
        }
        private string GenerarSiguienteNumeroHabitacion()
        {
            var ultimaHabitacion = _context.Habitaciones
                .OrderByDescending(h => h.Id)
                .FirstOrDefault();

            if (ultimaHabitacion == null || string.IsNullOrWhiteSpace(ultimaHabitacion.Numero))
            {
                return "101";
            }

            if (int.TryParse(ultimaHabitacion.Numero, out int numeroActual))
            {
                return (numeroActual + 1).ToString();
            }

            return "101";
        }
    }
}