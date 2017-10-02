using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;


namespace appium
{
    [TestFixture]
    public class iOS
    {
        private string projectName = "reports";
        private string accessKey = "";
        protected IOSDriver<IOSElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability("projectName", projectName);
            dc.SetCapability(MobileCapabilityType.PlatformName, "iOS");
            dc.SetCapability(MobileCapabilityType.App, "cloud:<BUNDLE_ID>");
            dc.SetCapability(IOSMobileCapabilityType.BundleId, "<BUNDLE_ID>");
            driver = new IOSDriver<IOSElement>(new Uri("https://cloud.experitest.com:443/wd/hub"), dc);

        }
        [Test()]
        public void TestUntitled()
        {


        }

        [TearDown()]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}