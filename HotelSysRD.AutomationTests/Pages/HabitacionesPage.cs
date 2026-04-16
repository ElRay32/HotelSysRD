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

        private IWebElement TipoInput => _wait.Until(d => d.FindElement(By.Id("Tipo")));
        private IWebElement PrecioInput => _wait.Until(d => d.FindElement(By.Id("PrecioPorNoche")));
        private IWebElement CapacidadInput => _wait.Until(d => d.FindElement(By.Id("Capacidad")));
        private IWebElement Formulario => _driver.FindElement(By.CssSelector("form"));

        public void Abrir(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Habitaciones");
            _wait.Until(d => d.Url.Contains("/Habitaciones"));
        }

        public void IrACrearHabitacion(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Habitaciones/Create");
            _wait.Until(d => d.Url.Contains("/Habitaciones/Create"));
            _wait.Until(d => d.FindElement(By.Id("Tipo")).Displayed);
        }

        public void CrearHabitacion(string tipo, string precio, string capacidad)
        {
            TipoInput.Clear();
            TipoInput.SendKeys(tipo);

            PrecioInput.Clear();
            PrecioInput.SendKeys(Keys.Control + "a");
            PrecioInput.SendKeys(Keys.Backspace);
            PrecioInput.SendKeys(precio);

            CapacidadInput.Clear();
            CapacidadInput.SendKeys(Keys.Control + "a");
            CapacidadInput.SendKeys(Keys.Backspace);
            CapacidadInput.SendKeys(capacidad);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].submit();", Formulario);

            // Espera a que realmente salga de Create
            _wait.Until(d => !d.Url.Contains("/Habitaciones/Create"));
            _wait.Until(d => d.Url.Contains("/Habitaciones"));
        }

        public bool ExisteHabitacionPorTipo(string tipo)
        {
            _wait.Until(d => d.PageSource.Contains("Habitaciones"));
            return _driver.PageSource.Contains(tipo);
        }

        public bool SigueEnCreate()
        {
            return _driver.Url.Contains("/Habitaciones/Create");
        }

        public string ObtenerErroresValidacion()
        {
            var errores = _driver.FindElements(By.CssSelector(".text-danger, .validation-summary-errors"));
            return string.Join(" | ", errores
                .Select(e => e.Text)
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Distinct());
        }
    }
}