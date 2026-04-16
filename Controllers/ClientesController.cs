using HotelSysRD.Data;
using HotelSysRD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelSysRD.Controllers
{
    // Controlador encargado de gestionar el CRUD de clientes
    public class ClientesController : Controller
    {
        private readonly HotelContext _context;

        // Inyección del contexto de base de datos
        public ClientesController(HotelContext context)
        {
            _context = context;
        }

        // Muestra el listado de clientes
        public async Task<IActionResult> Index()
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            return View(await _context.Clientes.ToListAsync());
        }

        // Muestra el detalle de un cliente
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

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Muestra el formulario de creación
        public IActionResult Create()
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // Guarda el cliente en base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // Muestra el formulario de edición
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

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Guarda los cambios del cliente editado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // Muestra la confirmación de eliminación
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

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Elimina definitivamente el cliente
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (UsuarioNoAutenticado())
            {
                return RedirectToAction("Login", "Account");
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Verifica si el cliente existe
        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(c => c.Id == id);
        }

        private bool UsuarioNoAutenticado()
        {
            return string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogueado"));
        }

    }
}
