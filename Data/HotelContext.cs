using Microsoft.EntityFrameworkCore;
using HotelSysRD.Models;

namespace HotelSysRD.Data
{
    // Contexto de base de datos principal del sistema
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        // Tabla de habitaciones en la base de datos
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
    }
}