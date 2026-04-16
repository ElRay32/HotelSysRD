using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotelSysRD.AutomationTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement UsuarioInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Usuario"));
            return el.Displayed ? el : null;
        });

        private IWebElement ContrasenaInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Contrasena"));
            return el.Displayed ? el : null;
        });

        private IWebElement EntrarButton => _wait.Until(d =>
        {
            var el = d.FindElement(By.CssSelector("button[type='submit']"));
            return (el.Displayed && el.Enabled) ? el : null;
        });

        public void Abrir(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Account/Login");
        }

        public void IniciarSesion(string usuario, string contrasena)
        {
            UsuarioInput.Clear();
            UsuarioInput.SendKeys(usuario);

            ContrasenaInput.Clear();
            ContrasenaInput.SendKeys(contrasena);

            EntrarButton.Click();

            _wait.Until(d => d.Url.Contains("/Home") || d.PageSource.Contains("Dashboard") || d.PageSource.Contains("Bienvenido"));
        }
    }
}