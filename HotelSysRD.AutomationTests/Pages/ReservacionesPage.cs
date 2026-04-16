using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotelSysRD.AutomationTests.Pages
{
    public class ReservacionesPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ReservacionesPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement ClienteSelect => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("ClienteId"));
            return el.Displayed ? el : null;
        });

        private IWebElement HabitacionSelect => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("HabitacionId"));
            return el.Displayed ? el : null;
        });

        private IWebElement FechaEntradaInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("FechaEntrada"));
            return el.Displayed ? el : null;
        });

        private IWebElement FechaSalidaInput => _wait.Until(d =>
        {
            var el = d.FindElement(By.Id("FechaSalida"));
            return el.Displayed ? el : null;
        });

        private IWebElement GuardarButton => _wait.Until(d =>
        {
            var el = d.FindElement(By.CssSelector("button[type='submit']"));
            return (el.Displayed && el.Enabled) ? el : null;
        });

        public void Abrir(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Reservaciones");
            _wait.Until(d => d.Url.Contains("/Reservaciones"));
        }

        public void IrACrearReservacion(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/Reservaciones/Create");
            _wait.Until(d => d.FindElement(By.Id("ClienteId")).Displayed);
        }

        public void CrearReservacion(string fechaEntrada, string fechaSalida)
        {
            var clienteDropdown = new SelectElement(ClienteSelect);
            var clienteOpcion = clienteDropdown.Options
                .FirstOrDefault(o => !string.IsNullOrWhiteSpace(o.GetAttribute("value")));

            if (clienteOpcion == null)
                throw new Exception("No hay clientes disponibles en el dropdown.");

            string clienteSeleccionado = clienteOpcion.Text;
            string? clienteValor = clienteOpcion.GetAttribute("value");

            if (string.IsNullOrWhiteSpace(clienteValor))
                throw new Exception("La opción de cliente no tiene un valor válido.");

            clienteDropdown.SelectByValue(clienteValor);

            var habitacionDropdown = new SelectElement(HabitacionSelect);
            var habitacionOpcion = habitacionDropdown.Options
                .FirstOrDefault(o => !string.IsNullOrWhiteSpace(o.GetAttribute("value")));

            if (habitacionOpcion == null)
                throw new Exception("No hay habitaciones disponibles en el dropdown.");

            string habitacionSeleccionada = habitacionOpcion.Text;
            string? habitacionValor = habitacionOpcion.GetAttribute("value");

            if (string.IsNullOrWhiteSpace(habitacionValor))
                throw new Exception("La opción de habitación no tiene un valor válido.");

            habitacionDropdown.SelectByValue(habitacionValor);

            FechaEntradaInput.Clear();
            FechaEntradaInput.SendKeys(fechaEntrada);

            FechaSalidaInput.Clear();
            FechaSalidaInput.SendKeys(fechaSalida);

            // Scroll hacia el botón para asegurar visibilidad
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", GuardarButton);

            // Espera corta para evitar click interceptado por animaciones/render
            Thread.Sleep(500);

            // Click usando JavaScript para evitar overlays o elementos flotantes
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", GuardarButton);

            UltimoClienteSeleccionado = clienteSeleccionado;
            UltimaHabitacionSeleccionada = habitacionSeleccionada;
        }

        public string UltimoClienteSeleccionado { get; private set; } = string.Empty;
        public string UltimaHabitacionSeleccionada { get; private set; } = string.Empty;
    }
}