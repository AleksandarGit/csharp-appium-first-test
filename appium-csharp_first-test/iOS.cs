using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;


namespace AppiumCsharpFirstTest
{
    [TestFixture]
    public class IOS
    {
        private string projectName = "";
        private string accessKey = "eyJ4cC51IjoxNjUwLCJ4cC5wIjoxNDM1LCJ4cC5tIjoiTVRRNU5UQXhOelV3T0RreE1BIiwiYWxnIjoiSFMyNTYifQ.eyJleHAiOjE4MTY0MzI4MDcsImlzcyI6ImNvbS5leHBlcml0ZXN0In0.JBVpm1JBc8AEHSJm3nY8qv-7Orx0MfSN6D9BsxmfcSA";

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