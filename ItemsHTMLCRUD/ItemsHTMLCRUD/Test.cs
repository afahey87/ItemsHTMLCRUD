using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Alerts_and_Windows
{

    [TestFixture]
    class ItemsHTMLTEST
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://webapps3.tylertech.com/int_dev/qa/munis/adam.fahey/AppHost/items/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
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
            waitForPageUntillElementIsVissable(By.Id("walkme-proxy-iframe"), 10);
            Assert.True(driver.Url.Contains("items"));
           
        }

        [Test]
        public void clickTheAddButton()
        {
            
            driver.FindElement(By.XPath("/html/body/div/div[1]/app-ribbon/div/div[2]/ul/li[3]/button[1]/div")).Click();
            Assert.True(driver.Url.Contains("Add"));
            waitForPageUntillElementIsVissable(By.Name("$ctrl.itemForm"), 10);
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/form/app-item-info-bar/div/div[1]/input")).SendKeys(Keys.Return);
            driver.FindElement(By.Name("itemDescription")).SendKeys("Autom8");
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/app-footer/div/div/div/button[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/form/div/input")).SendKeys("Autom8");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div/button")).Click();

        }


        public IWebElement waitForPageUntillElementIsVissable(By locator, int maxseconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxseconds))
                .Until(ExpectedConditions.ElementExists((locator)));
        }

    }
}