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
    public class AndroidAppTest
    {
        // you have configured an access key as environment variable,
        // use the line below. Otherwise, specify the key directly.
        private string accessKey = Environment.GetEnvironmentVariable("SEETEST_IO_ACCESS_KEY");
        private string testName = "Android App Test with C#";

        protected AndroidDriver<AndroidElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability(MobileCapabilityType.App, "http://d242m5chux1g9j.cloudfront.net/eribank.apk");
            dc.SetCapability("platformName", "Android");
            dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "com.experitest.ExperiBank");
            dc.SetCapability(AndroidMobileCapabilityType.AppActivity, ".LoginActivity");
            driver = new AndroidDriver<AndroidElement>(new Uri("https://cloud.experitest.com:443/wd/hub"), dc);
        }

        [Test()]
        public void TestAndroidApp()
        {
            driver.FindElement(By.XPath("xpath=//*[@id='usernameTextField']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@id='passwordTextField']")).SendKeys("company");
            driver.FindElement(By.XPath("xpath=//*[@id='loginButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@id='makePaymentButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@id='phoneTextField']")).SendKeys("123456");
            driver.FindElement(By.XPath("xpath=//*[@id='nameTextField']")).SendKeys("Test");
            driver.FindElement(By.XPath("xpath=//*[@id='amountTextField']")).SendKeys("10");
            driver.FindElement(By.XPath("xpath=//*[@id='countryTextField']")).SendKeys("US");
            driver.FindElement(By.XPath("xpath=//*[@id='sendPaymentButton']")).Click();
            driver.FindElement(By.XPath("xpath=//*[@id='button1']")).Click();
        }

        [TearDown()]
        public void TearDown()
        {
            driver.Lock();
            driver.Quit();
        }
    }
}
