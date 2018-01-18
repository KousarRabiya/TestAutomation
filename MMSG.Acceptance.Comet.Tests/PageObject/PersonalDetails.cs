using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.ExcelOperation;
using System;

namespace CometProject.PageObject
{
    class PersonalDetails
    {
        private IWebDriver driver;
        public PersonalDetails(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.XPath, Using = "//select[@id='TitleCombo']/option[3]")]
        public IWebElement SelelctTitle { get; set; }

        [FindsBy(How = How.Id, Using = "GivenNameText")]
        public IWebElement GivenName { get; set; }

        [FindsBy(How = How.Id, Using = "OtherNamesText")]
        public IWebElement OtherName { get; set; }

        [FindsBy(How = How.Id, Using = "SurnameText")]
        public IWebElement Surname { get; set; }

        [FindsBy(How = How.Id, Using = "PreferredNameText")]
        public IWebElement PreferenceName { get; set; }

        [FindsBy(How = How.Id, Using = "DateOfBirthText")]
        public IWebElement DateOfBirth { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='GenderCombo']/option[2]")]
        public IWebElement Gender { get; set; }

        [FindsBy(How = How.Id, Using = "PhoneNumberMobileText")]
        public IWebElement MobNumber { get; set; }

        [FindsBy(How = How.Id, Using = "EmailAddressText")]
        public IWebElement EmailID { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='EmployeePreferredMethodCombo']/option[3]")]
        public IWebElement PerferedMethodToContact { get; set; }

        [FindsBy(How = How.Id, Using = "CommandButtons_cmdNextEnabled")]
        public IWebElement NextButtonPersonScreen { get; set; }

        public void FillPersonalDetails()
        {
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("TitleCombo")));
            oSelect.SelectByText(ExcelOperation.GetData[1]);
            GivenName.Clear();

            string GivenNameString = GenericHelper.RandomString(5);
            ExcelOperation.AddData("TestData2", GivenNameString, "TC1_CreateAnEmployee");
            GivenName.SendKeys(GivenNameString);
            OtherName.Clear();

            OtherName.SendKeys(ExcelOperation.GetData[3]);
            Surname.Clear();
            Surname.SendKeys(ExcelOperation.GetData[4]);
            PreferenceName.Clear();

            PreferenceName.SendKeys(ExcelOperation.GetData[5]);
            DateOfBirth.Clear();
            DateOfBirth.SendKeys(ExcelOperation.GetData[6]);
            Gender.Click();

            MobNumber.Clear();
            // MobNumber.SendKeys(ExcelOperation.GetData[7]);
            MobNumber.SendKeys("9999 999999");
            EmailID.Clear();
            EmailID.SendKeys(ExcelOperation.GetData[8]);

            PerferedMethodToContact.Click();
            GenericHelper.AllScreenShot(driver);
            var ele = driver.FindElement(By.Id("CommandButtons_cmdNextEnabled"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},100)", ele);
        }
        public void VerifyLandedOnPersonalDetailsPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Employee"));
        }
    }
}
