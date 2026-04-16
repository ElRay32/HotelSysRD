using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotelSysRD.AutomationTests.Drivers
{
    // Fábrica encargada de crear la instancia del navegador
    public static class WebDriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();

            // Puedes comentar esto si quieres ver el navegador siempre abierto
            // options.AddArgument("--headless=new");

            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }
    }
}