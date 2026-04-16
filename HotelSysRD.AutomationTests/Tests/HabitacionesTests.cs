using NUnit.Framework;
using HotelSysRD.AutomationTests.Pages;
using HotelSysRD.AutomationTests.Utils;


namespace HotelSysRD.AutomationTests.Tests
{
    // Pruebas del módulo de habitaciones
    public class HabitacionesTests : TestBase
    {
        [Test]
        public void Crear_Habitacion_DebeMostrarseEnElListado()
        {
            var loginPage = new LoginPage(Driver!);
            var habitacionesPage = new HabitacionesPage(Driver!);

            loginPage.Abrir(BaseUrl);
            loginPage.IniciarSesion("admin", "Admin123*");

            habitacionesPage.Abrir(BaseUrl);
            habitacionesPage.IrACrearHabitacion(BaseUrl);

            string tipoHabitacion = "Suite Test " + DateTime.Now.Ticks;
            habitacionesPage.CrearHabitacion(tipoHabitacion, "3500", "2");
            Assert.That(Driver!.PageSource, Does.Contain(tipoHabitacion));
        }
    }
}