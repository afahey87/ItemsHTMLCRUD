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
            Assert.True(driver.Url.Contains("items"));      // Verify page is loaded
           
        }

        [Test]
        public void ItemsCRUD()
        {
            //      Create
            waitForPageUntillElementIsVissable(By.XPath("/html/body/div/div[2]/search-results/div/div[2]/div/div[1]/table/thead/tr[1]/th[3]"), 10); // Wait for element to load before test starts.
            driver.FindElement(By.XPath("/html/body/div/div[1]/app-ribbon/div/div[2]/ul/li[3]/button[1]/div")).Click();     // Click Add button
            Assert.True(driver.Url.Contains("Add"));
            waitOnPage(1);
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/form/app-item-info-bar/div/div[1]/input")).SendKeys(Keys.Return);   // Press return key, This auto generates next number for the Item
            waitOnPage(1);
            driver.FindElement(By.Name("itemDescription")).SendKeys("Autom8");
            waitOnPage(1);
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/app-footer/div/div/div/button[1]")).Click();    // Click save
            waitOnPage(1);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/form/div/input")).SendKeys("Autom8");     // Reason for save
            waitForPageUntillElementIsVissable(By.XPath("/html/body/div[1]/div/div/div/div[1]/div/div"), 10);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div/button")).Click();    // Confirm Save
            //      Update
            waitOnPage(1);
            driver.FindElement(By.Name("ManufacturerId")).SendKeys("Dell"); // Type in Dell
            waitOnPage(1);
            driver.FindElement(By.Name("ManufacturerId")).SendKeys(Keys.Return); // Press return key
            driver.FindElement(By.Name("IsTangible")).Click(); // Click IsTangiable Radio button
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/app-footer/div/div/div/button[1]")).Click();    // Click Save
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div/button")).Click();    // Confrim Save
            //      Delete
            waitOnPage(2);
            driver.FindElement(By.XPath("/html/body/div/div[1]/app-ribbon/div/div[2]/ul/li[3]/button[2]")).Click(); //Click Delet button
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/button[1]")).Click(); //Confirm delete

        }

        public IWebElement waitForPageUntillElementIsVissable(By locator, int maxseconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxseconds))
                .Until(ExpectedConditions.ElementExists((locator)));
        }

        public void waitOnPage(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

    }
}