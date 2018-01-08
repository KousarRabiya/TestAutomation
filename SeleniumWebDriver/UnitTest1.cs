using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumWebDriver.Settings;

namespace SeleniumWebDriver
{

    [TestClass]
    public class UnitTest1
    {

     //   [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://demo.nopcommerce.com");
            driver.Close();
            driver.Quit();
        }
    }
}
