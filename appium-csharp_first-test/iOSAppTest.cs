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
    public class IOSAppTest
    {
        // you have configured an access key as environment variable,
        // use the line below. Otherwise, specify the key directly.
        private string accessKey = Environment.GetEnvironmentVariable("SEETEST_IO_ACCESS_KEY");
        private string testName = "iOS App Test with C#";
        protected IOSDriver<IOSElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability(MobileCapabilityType.PlatformName, "iOS");
            dc.SetCapability(MobileCapabilityType.App, "http://d242m5chux1g9j.cloudfront.net/EriBank.ipa");
            dc.SetCapability(IOSMobileCapabilityType.BundleId, "com.experitest.ExperiBank");
            driver = new IOSDriver<IOSElement>(new Uri("https://cloud.experitest.com:443/wd/hub"), dc);           
        }

        [Test()]
        public void TestiOSApp()
        {
            driver.FindElement(By.XPath("xpath=//*[@text='Username']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@text='Password']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@text='loginButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='makePaymentButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='Phone']")).SendKeys("123456");
            driver.FindElement(By.XPath("xpath=//*[@text='Name']")).SendKeys("Test");
            driver.FindElement(By.XPath("xpath=//*[@text='Amount']")).SendKeys("10");
            driver.FindElement(By.XPath("xpath=//*[@text='Country']")).SendKeys("US");
            driver.FindElement(By.XPath("xpath=//*[@text='sendPaymentButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='Yes']")).Click();

        }

        [TearDown()]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}