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

            driver = new IOSDriver<IOSElement>(new Uri("https://beta.seetest.io:443/wd/hub"), dc);           
        }

        [Test()]
        public void TestiOSApp()
        {
            driver.Navigate().GoToUrl("https://amazon.com");
            if (driver.Capabilities.GetCapability("reportUrl").Equals("TABLET"))
            {
                driver.FindElement(By.XPath("//*[@name='field-keywords']")).SendKeys("iPhone");
                driver.FindElement(By.XPath("//*[@text='Go']")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//*[@name='k']")).SendKeys("iPhone");
                driver.FindElement(By.XPath("//*[@value='Go']")).Click();
            }
        }

        [TearDown()]
        public void TearDown()
        {
            if (driver != null)
            {
                Console.WriteLine(driver.Capabilities.GetCapability("reportUrl"));
                driver.Quit();
            }
        }
    }
}