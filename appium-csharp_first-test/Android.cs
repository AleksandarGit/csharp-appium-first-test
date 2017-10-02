using System;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;

namespace AppiumCsharpFirstTest
{
    [TestFixture]
    public class Android
    {
        private string projectName = "<PROJECT_NAME>";
        private string accessKey = "<ACCESS_KEY>";
        private string testName = "<TEST_NAME>";

        protected AndroidDriver<AndroidElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability("projectName", projectName);
            dc.SetCapability(MobileCapabilityType.App, "cloud:<BUNDLE_ID>");
            dc.SetCapability("platformName", "Android");
            dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "<BUNDLE_ID>");
            dc.SetCapability(AndroidMobileCapabilityType.AppActivity, "<ACTIVITY>");
            driver = new AndroidDriver<AndroidElement>(new Uri("https://cloud.experitest.com:443/wd/hub"), dc);
        }

        [Test()]
        public void TestUntitled()
        {

        }

        [TearDown()]
        public void TearDown()
        {
            driver.Lock();
            driver.Quit();
        }
    }
}
