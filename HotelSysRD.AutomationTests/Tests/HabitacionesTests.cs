using NUnit.Framework;
using HotelSysRD.AutomationTests.Pages;
using HotelSysRD.AutomationTests.Utils;
using System.Linq;

namespace HotelSysRD.AutomationTests.Tests
{
    public class HabitacionesTests : TestBase
    {
        [Test]
        public void Crear_Habitacion_DebeGuardarseEnBaseDeDatos()
        {
            var loginPage = new LoginPage(Driver!);
            var habitacionesPage = new HabitacionesPage(Driver!);

            loginPage.Abrir(BaseUrl);
            loginPage.IniciarSesion("admin", "Admin123*");

            habitacionesPage.IrACrearHabitacion(BaseUrl);

            string tipoHabitacion = "Suite Test " + DateTime.Now.Ticks;
            habitacionesPage.CrearHabitacion(tipoHabitacion, "3500", "2");

            Assert.That(
                habitacionesPage.SigueEnCreate(),
                Is.False,
                $"La habitación no se guardó desde la UI. Errores: {habitacionesPage.ObtenerErroresValidacion()}"
            );

            bool creada = false;

            for (int i = 0; i < 10; i++)
            {
                using var context = DbHelper.CrearContexto();

                creada = context.Habitaciones.Any(h => h.Tipo == tipoHabitacion);

                if (creada)
                    break;

                Thread.Sleep(500);
            }

            Assert.That(creada, Is.True, $"La habitación '{tipoHabitacion}' no quedó guardada en la base de datos.");
        }
    }
}