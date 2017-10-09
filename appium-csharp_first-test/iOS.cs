using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.iOS;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumCsharpFirstTest
{
    [TestFixture]
    public class IOS
    {
        private string accessKey = Environment.GetEnvironmentVariable("accessKey");
        private string testName = "iOS App Test";
        protected IOSDriver<IOSElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability(MobileCapabilityType.PlatformName, "iOS");
            dc.SetCapability(MobileCapabilityType.App, "cloud:com.experitest.ExperiBank");
            dc.SetCapability(IOSMobileCapabilityType.BundleId, "com.experitest.ExperiBank");
            driver = new IOSDriver<IOSElement>(new Uri("https://cloud.experitest.com:443/wd/hub"), dc);           
        }

        [Test()]
        public void TestUntitled()
        {
            driver.FindElement(By.XPath("xpath=//*[@text='Username']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@text='Password']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@text='loginButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='Make Payment']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='Phone']")).SendKeys("123456");
            driver.FindElement(By.XPath("xpath=//*[@text='Name']")).SendKeys("Test");
            driver.FindElement(By.XPath("xpath=//*[@text='Amount']")).SendKeys("10");
            driver.FindElement(By.XPath("xpath=//*[@text='Country']")).SendKeys("US");
            driver.FindElement(By.XPath("xpath=//*[@text='Send Payment']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='Yes']")).Click();

        }

        [TearDown()]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}