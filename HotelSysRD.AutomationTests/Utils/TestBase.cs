using NUnit.Framework;
using HotelSysRD.AutomationTests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotelSysRD.AutomationTests.Utils
{
    public class TestBase
    {
        protected IWebDriver? Driver;
        protected WebDriverWait? Wait;
        protected string BaseUrl = "http://localhost:5254";

        [SetUp]
        public void SetUp()
        {
            Driver = WebDriverFactory.CreateChromeDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
            Driver?.Dispose();
            Driver = null;
        }
    }
}