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
    public class CreateBugTestFunctionalProjectSpecific
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://ifdefined.com/";
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
        public void TheCreateBugTestFunctionalProjectSpecificTest()
        {
            driver.Navigate().GoToUrl("http://ifdefined.com/btnet/bugs.aspx");
            try
            {
                Assert.AreEqual("BugTracker.NET - bugs", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("add new bug")).Click();
            try
            {
                Assert.AreEqual("BugTracker.NET - Create Bug", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Project:" == driver.FindElement(By.Id("project_label")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            try
            {
                Assert.AreEqual("Project:", driver.FindElement(By.Id("project_label")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ReferenceError: selectLocator is not defined]
            driver.FindElement(By.CssSelector("option[value=\"3\"]")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("[no project] DemoProject HasCustomFieldsProject HasDifferentPermissionsProject" == driver.FindElement(By.Id("project")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            try
            {
                Assert.AreEqual("[no project] DemoProject HasCustomFieldsProject HasDifferentPermissionsProject", driver.FindElement(By.Id("project")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Project-specific" == driver.FindElement(By.Id("label_pcd1")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            try
            {
                Assert.AreEqual("Project-specific", driver.FindElement(By.Id("label_pcd1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("short_desc")).Clear();
            driver.FindElement(By.Id("short_desc")).SendKeys("Out-of-frame Telerik Rad Rotator contol");
            // ERROR: Caught exception [ReferenceError: selectLocator is not defined]
            // ERROR: Caught exception [ReferenceError: selectLocator is not defined]
            // ERROR: Caught exception [ReferenceError: selectLocator is not defined]
            // ERROR: Caught exception [ReferenceError: selectLocator is not defined]
            driver.FindElement(By.Id("Samplecustomfield")).Clear();
            driver.FindElement(By.Id("Samplecustomfield")).SendKeys("When selected the Rad rotator in vertical position shows the pictures out of frame with wifth 600 and height 150px");
            // ERROR: Caught exception [ReferenceError: selectLocator is not defined]
            driver.FindElement(By.Id("comment")).Clear();
            driver.FindElement(By.Id("comment")).SendKeys("Get over it!");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            driver.FindElement(By.Id("submit_button")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Bug ID:" == driver.FindElement(By.Id("bugid_label")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            try
            {
                Assert.AreEqual("Bug ID:", driver.FindElement(By.Id("bugid_label")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("[no project] DemoProject HasCustomFieldsProject HasDifferentPermissionsProject" == driver.FindElement(By.Id("project")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            try
            {
                Assert.AreEqual("[no project] DemoProject HasCustomFieldsProject HasDifferentPermissionsProject", driver.FindElement(By.Id("project")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Project-specific" == driver.FindElement(By.Id("label_pcd1")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            try
            {
                Assert.AreEqual("Project-specific", driver.FindElement(By.Id("label_pcd1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
