using NUnit.Framework;
using HotelSysRD.AutomationTests.Pages;
using HotelSysRD.AutomationTests.Utils;

namespace HotelSysRD.AutomationTests.Tests
{
    // Pruebas del flujo de inicio de sesión
    public class LoginTests : TestBase
    {
        [Test]
        public void Login_Exitoso_DebeRedirigirAlDashboard()
        {
            var loginPage = new LoginPage(Driver!);

            loginPage.Abrir(BaseUrl);
            loginPage.IniciarSesion("admin", "Admin123*");

            Assert.That(Driver!.Url, Does.Contain("/Home/Index").Or.Contain("/Home"));
        }
    }
}
