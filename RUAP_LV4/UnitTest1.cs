using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL = "https://demo.opencart.com/";
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTestCaseTest()
        {
            Random random = new Random();

            for(int i=0;i<1;i++)
            {
                int randomNumber = random.Next(0, 10000);
                string name = "John" + randomNumber.ToString();
                string surname = "Doe" + randomNumber.ToString();
                string email = "Johnas" + randomNumber.ToString() + "@Johnny.com";
                string number = "00001";
                driver.Navigate().GoToUrl("https://demo.opencart.com/");
                driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
                driver.FindElement(By.LinkText("Register")).Click();
                driver.FindElement(By.Id("input-firstname")).Click();
                driver.FindElement(By.Id("input-firstname")).SendKeys(name);
                driver.FindElement(By.Id("input-lastname")).SendKeys(surname);
                driver.FindElement(By.Id("input-email")).SendKeys(email);
                driver.FindElement(By.Id("input-telephone")).SendKeys("0123456789");
                driver.FindElement(By.Id("input-password")).SendKeys("qwertz");
                driver.FindElement(By.Id("input-confirm")).SendKeys("qwertz");
                driver.FindElement(By.Name("newsletter")).Click();
                driver.FindElement(By.Name("agree")).Click();
                driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
                driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
            }

        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
