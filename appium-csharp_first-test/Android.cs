using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
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
        //private string accessKey = Environment.GetEnvironmentVariable("accessKey");
        private string accessKey = "eyJ4cC51IjoxNjUwLCJ4cC5wIjoxNDM1LCJ4cC5tIjoiTVRRNU5UQXhOelV3T0RreE1BIiwiYWxnIjoiSFMyNTYifQ.eyJleHAiOjE4MTY0MzI4MDcsImlzcyI6ImNvbS5leHBlcml0ZXN0In0.JBVpm1JBc8AEHSJm3nY8qv-7Orx0MfSN6D9BsxmfcSA";
        private string testName = "Android App Test";

        protected AndroidDriver<AndroidElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability(MobileCapabilityType.App, "cloud:com.experitest.ExperiBank/.LoginActivity");
            dc.SetCapability("platformName", "Android");
            dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "com.experitest.ExperiBank");
            dc.SetCapability(AndroidMobileCapabilityType.AppActivity, ".LoginActivity");
            driver = new AndroidDriver<AndroidElement>(new Uri("https://cloud.experitest.com:443/wd/hub"), dc);
        }

        [Test()]
        public void TestUntitled()
        {
            driver.FindElement(By.XPath("xpath=//*[@id='usernameTextField']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@id='passwordTextField']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@text='loginButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='Make Payment']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@id='phoneTextField']")).SendKeys("123456");
            driver.FindElement(By.XPath("xpath=//*[@id='nameTextField']")).SendKeys("Test");
            driver.FindElement(By.XPath("xpath=//*[@id='amountTextField']")).SendKeys("10");
            driver.FindElement(By.XPath("xpath=//*[@id='countryTextField']")).SendKeys("US");
            driver.FindElement(By.XPath("xpath=//*[@text='Send Payment']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@text='Yes']")).Click();
        }

        [TearDown()]
        public void TearDown()
        {
            driver.Lock();
            driver.Quit();
        }
    }
}
