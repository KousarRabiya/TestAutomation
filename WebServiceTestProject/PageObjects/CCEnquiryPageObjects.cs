using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebServiceTestProject.PageObjects
{
    class CCEnquiryPageObjects
    {
        public IWebDriver driver;
        public string empNumber;
        public CCEnquiryPageObjects(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "CCEmployeeSearch_txtEmployeeNumber")]
        public IWebElement EmployeeSearch { get; set; }
        public object ObjectRepository { get; private set; }

        [FindsBy(How = How.Id, Using = "CCEmployeeSearch_cmdSearch")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='wucPackageSummary_tdEmployeeNo']")]
        public IWebElement Grid { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public void enterEmployeeID()
        {
            //TODO
            //string username = ObjectRepository.User;
            //if (username == null)
            //{
            //EmployeeSearch.SendKeys("13775301");
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(currentDir + @"\XML Test Data\CreatePackage.xml");
            XmlNode hierarchyNode = xmldoc["Request"]["CometCreatePackage"];

            empNumber = hierarchyNode.ChildNodes[1].ChildNodes[2].ChildNodes[0].InnerText;
            EmployeeSearch.SendKeys(hierarchyNode.ChildNodes[1].ChildNodes[2].ChildNodes[0].InnerText);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            //}
            //else
            //{
            //    EmployeeSearch.SendKeys(username);
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //}
        }

        public void clickOnSearchButton()
        {
            SearchButton.Click();
        }

        public void waitForGridToDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1000));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='wucPackageSummary_tdEmployeeNo']")));
        }

        public string getLabelText()
        {
            return Grid.Text;
        }
    }
}
