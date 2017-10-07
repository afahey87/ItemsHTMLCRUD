using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Alerts_and_Windows
{

    [TestFixture]
    class WebDriverTestAlertsandWindows
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://webapps3.tylertech.com/int_dev/qa/munis/adam.fahey/AppHost/items/");
        }
        [TearDown]
        public void teardown()
        {
            driver.Close();
            driver.Quit();
        }
        [Test]
        public void checkItemsPageHasLoaded()
        {

        }
    }
}