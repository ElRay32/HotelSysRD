using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotelSysRD.AutomationTests.Pages
{
    public class HabitacionesPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HabitacionesPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement TipoInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Tipo"));
            return el.Displayed ? el : null;
        });

        private IWebElement PrecioInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("PrecioPorNoche"));
            return el.Displayed ? el : null;
        });

        private IWebElement CapacidadInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("Capacidad"));
            return el.Displayed ? el : null;
        });

        private IWebElement GuardarButton => _wait.Until(d =>
        {
            var el = d.FindElement(By.CssSelector("button[type='submit']"));
            return (el.Displayed && el.Enabled) ? el : null;
        });

        public void Abrir(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Habitaciones");
            _wait.Until(d => d.Url.Contains("/Habitaciones"));
        }

        public void IrACrearHabitacion(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Habitaciones/Create");
            _wait.Until(d => d.FindElement(By.Id("Tipo")).Displayed);
        }

        public void CrearHabitacion(string tipo, string precio, string capacidad)
        {
            TipoInput.SendKeys(tipo);
            PrecioInput.SendKeys(precio);
            CapacidadInput.SendKeys(capacidad);
            GuardarButton.Click();
        }
    }
}