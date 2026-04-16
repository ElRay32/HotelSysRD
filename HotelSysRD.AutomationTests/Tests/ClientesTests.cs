using HotelSysRD.AutomationTests.Pages;
using HotelSysRD.AutomationTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotelSysRD.AutomationTests.Tests
{
    // Pruebas del módulo de clientes
    public class ClientesTests : TestBase
    {
        [Test]
        public void Crear_Cliente_DebeMostrarseEnElListado()
        {
            var loginPage = new LoginPage(Driver!);
            var clientesPage = new ClientesPage(Driver!);

            loginPage.Abrir(BaseUrl);
            loginPage.IniciarSesion("admin", "Admin123*");

            clientesPage.Abrir(BaseUrl);
            clientesPage.IrACrearCliente(BaseUrl);

            string nombre = "ClienteAuto" + DateTime.Now.Ticks;
            string email = $"cliente{DateTime.Now.Ticks}@test.com";
            string documento = DateTime.Now.Ticks.ToString().Substring(5, 9);

            clientesPage.CrearCliente(nombre, "Prueba", email, "8095551234", documento);
            Assert.That(Driver!.PageSource, Does.Contain(nombre));
        }
    }
}