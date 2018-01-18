using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.Settings;
using MMSG.Automation.DBOperation;
using System;

namespace CometProject.PageObject
{
    public class CallCenterEnquirySearch
    {
        public IWebDriver driver;
        public CallCenterEnquirySearch(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "CCEmployeeSearch_txtEmployeeNumber")]
        public IWebElement EmployeeNumber { get; set; }

        [FindsBy(How = How.Id, Using = "CCEmployeeSearch_txtEmployerCode")]
        public IWebElement EmployerCode { get; set; }

        [FindsBy(How = How.Id, Using = "CCEmployeeSearch_cmdSearch")]
        public IWebElement SearchButton { get; set; }
        public void SearchEmployee()
        {
            string username = ObjectRepository.User;
            if (username == null)
            {
                //EmployeeSearch.SendKeys(ExcelOperation.GetData[1]);
                EmployeeNumber.SendKeys(DataBaseOperation.ReadData());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            }
            else
            {
                EmployeeNumber.SendKeys(username);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
        }
        public void CallCenterEnqrySearch(string searchOption)
        {
            try
            {
                switch (searchOption)
                {
                    case "EmpNum":
                        EmployeeNumber.SendKeys(DataBaseOperation.GetSearchResults(searchOption));
                        break;
                    case "EmpCode":
                        EmployerCode.SendKeys(DataBaseOperation.GetSearchResults(searchOption));
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public void ClickOnSearchButton()
        {
            SearchButton.Click();
        }
        public void NewButton()
        {
            var ele = driver.FindElement(By.Id("CCEmployeeSearch_cmdNew"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},100)", ele);
        }
        public void VerifyLandedOnCallCenterScreen()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='Form1']/table[1]/tbody/tr[1]/td/table/tbody/tr[1]/td[2]")));
        }
    }
}
