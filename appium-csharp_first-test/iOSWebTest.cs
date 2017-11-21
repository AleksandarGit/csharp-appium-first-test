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
    public class IOSWebTest
    {
        // you have configured an access key as environment variable,
        // use the line below. Otherwise, specify the key directly.
        private string accessKey = Environment.GetEnvironmentVariable("SEETEST_IO_ACCESS_KEY");
        private string testName = "iOS Safari Web Test";
        protected IOSDriver<IOSElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability(MobileCapabilityType.PlatformName, "iOS");
            dc.SetCapability(MobileCapabilityType.BrowserName, "safari");
            driver = new IOSDriver<IOSElement>(new Uri("https://stage.experitest.com:443/wd/hub"), dc);           
        }

        [Test()]
        public void TestiOSApp()
        {
            driver.Navigate().GoToUrl("https://google.com");
            driver.FindElement(By.XPath("//*[@name='q']")).SendKeys("mobile automation testing");
            driver.FindElement(By.XPath("//*[@name='btnG']")).Click();
        }

        [TearDown()]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Capabilities.GetCapability("reporterUrl");
                driver.Quit();
            }
        }
    }
}
