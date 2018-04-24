using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RUAP_LV4
{
    [TestFixture]
    public class UnitTest1
    {
        
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
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
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheLogoutTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=account/success");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.FindElement(By.LinkText("PC (0)")).Click();
            driver.FindElement(By.LinkText("Laptops & Notebooks (5)")).Click();
            driver.FindElement(By.LinkText("MacBook")).Click();
            driver.FindElement(By.LinkText("MacBook Air")).Click();
            driver.FindElement(By.XPath("(//img[@alt='MacBook Air'])[3]")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
            driver.FindElement(By.Id("cart-total")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();
            driver.FindElement(By.XPath("//a[@id='wishlist-total']/span")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
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
