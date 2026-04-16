using NUnit.Framework;
using HotelSysRD.AutomationTests.Pages;
using HotelSysRD.AutomationTests.Utils;

namespace HotelSysRD.AutomationTests.Tests
{
    public class ReservacionesTests : TestBase
    {
        [Test]
        public void Crear_Reservacion_DebeMostrarseEnElListado()
        {
            var loginPage = new LoginPage(Driver!);
            var reservacionesPage = new ReservacionesPage(Driver!);

            loginPage.Abrir(BaseUrl);
            loginPage.IniciarSesion("admin", "Admin123*");

            reservacionesPage.Abrir(BaseUrl);
            reservacionesPage.IrACrearReservacion(BaseUrl);

            string fechaEntrada = "2026-04-15T14:00";
            string fechaSalida = "2026-04-17T11:00";

            reservacionesPage.CrearReservacion(fechaEntrada, fechaSalida);

            Assert.That(Driver!.PageSource, Does.Contain(reservacionesPage.UltimoClienteSeleccionado));
        }
    }
}