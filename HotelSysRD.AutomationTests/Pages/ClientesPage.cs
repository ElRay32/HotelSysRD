using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotelSysRD.AutomationTests.Pages
{
    public class ClientesPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ClientesPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement NombreInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Nombre"));
            return el.Displayed ? el : null;
        });

        private IWebElement ApellidoInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Apellido"));
            return el.Displayed ? el : null;
        });

        private IWebElement EmailInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Email"));
            return el.Displayed ? el : null;
        });

        private IWebElement TelefonoInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Telefono"));
            return el.Displayed ? el : null;
        });

        private IWebElement DocumentoInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("DocumentoIdentidad"));
            return el.Displayed ? el : null;
        });

        private IWebElement GuardarButton => _wait.Until(d =>
        {
            var el = d.FindElement(By.CssSelector("button[type='submit']"));
            return (el.Displayed && el.Enabled) ? el : null;
        });

        public void Abrir(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Clientes");
            _wait.Until(d => d.Url.Contains("/Clientes"));
        }

        public void IrACrearCliente(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Clientes/Create");
            _wait.Until(d => d.FindElement(By.Id("Nombre")).Displayed);
        }

        public void CrearCliente(string nombre, string apellido, string email, string telefono, string documento)
        {
            NombreInput.SendKeys(nombre);
            ApellidoInput.SendKeys(apellido);
            EmailInput.SendKeys(email);
            TelefonoInput.SendKeys(telefono);
            DocumentoInput.SendKeys(documento);
            GuardarButton.Click();
        }
    }
}