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


        public IWebElement waitForPageUntillElementIsVissable(By locator, int maxseconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxseconds))
                .Until(ExpectedConditions.ElementExists((locator)));
        }

        public void waitOnPage(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }


        [Test]
        public void checkItemsPageHasLoaded()
        {
            waitForPageUntillElementIsVissable(By.Id("walkme-proxy-iframe"), 10);
            // Verify page is loaded
            Assert.True(driver.Url.Contains("items"));

        }

        [Test]
        public void ItemsCRUD()
        {
            //   ***   Create   ***

            // Wait for element to load before test starts.
            waitForPageUntillElementIsVissable(By.XPath("/html/body/div/div[2]/search-results/div/div[2]/div/div[1]/table/thead/tr[1]/th[3]"), 10);
            // Click Add button
            driver.FindElement(By.XPath("/html/body/div/div[1]/app-ribbon/div/div[2]/ul/li[3]/button[1]/div")).Click();
            Assert.True(driver.Url.Contains("Add"));
            waitOnPage(1);
            // Press return key, This auto generates next number for the Item
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/form/app-item-info-bar/div/div[1]/input")).SendKeys(Keys.Return);
            waitOnPage(2);
            driver.FindElement(By.Name("itemDescription")).SendKeys(" Test123");
            waitOnPage(1);
            // Click save
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/app-footer/div/div/div/button[1]")).Click();
            waitOnPage(1);
            // Reason for save
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/form/div/input")).SendKeys("Test123");
            waitForPageUntillElementIsVissable(By.XPath("/html/body/div[1]/div/div/div/div[1]/div/div"), 10);
            // Confirm Save
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div/button")).Click();
            //   ***   Update   ***
            waitOnPage(1);
            // Type in Dell
            driver.FindElement(By.Name("ManufacturerId")).SendKeys("Dell");
            waitOnPage(1);
            // Press return key
            driver.FindElement(By.Name("ManufacturerId")).SendKeys(Keys.Return);
            // Click IsTangiable Radio button
            driver.FindElement(By.Name("IsTangible")).Click();
            // Click Save
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/app-footer/div/div/div/button[1]")).Click();
            // Confrim Save
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div/button")).Click();

            // *** Update Again***
            // Wint on page
            waitOnPage(3);
            // Click on dropdown for status of Item. 
            driver.FindElement(By.XPath("//div[@class='container-flex-vertical']//button[.='New ']")).Click();
            // wait on page 1 sec. 
            waitOnPage(1);
            // Click on Active status. 
            driver.FindElement(By.XPath("//div[@class='container-flex-vertical']//span[.='Active']")).Click();
            // Click Save
            driver.FindElement(By.XPath("/html/body/div/div[2]/item-manager/app-footer/div/div/div/button[1]")).Click();
            // Confrim Save
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div/button")).Click();

            //   ***   Delete   ***
            waitOnPage(2);
            // Click Delete button
            driver.FindElement(By.XPath("/html/body/div/div[1]/app-ribbon/div/div[2]/ul/li[3]/button[2]")).Click();
            // Confirm delete
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/button[1]")).Click();





        }
    }
}