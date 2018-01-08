using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebDriver.ExcelOperation;
using System;

namespace CometProject.PageObject
{
    class ThirdPartyAccess
    {
        public IWebDriver driver;
        public ThirdPartyAccess(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        [FindsBy(How = How.XPath, Using = "//select[@id='TitleCombo']/option[2]")]
        public IWebElement TitleCombo { get; set; }

        [FindsBy(How = How.Id, Using = "GivenNameText")]
        public IWebElement GivenName { get; set; }
        
         [FindsBy(How = How.Id, Using = "SurnameText")]
        public IWebElement Surname { get; set; }        

        [FindsBy(How = How.Id, Using = "Relationshiptext")]
        public IWebElement RelationshipText { get; set; }
        
        [FindsBy(How = How.Id, Using = "PasswordText")]
        public IWebElement PasswordText { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordPrompttext")]
        public IWebElement PasswordPromptText { get; set; }
        
        [FindsBy(How = How.Id, Using = "CommandButtons_cmdSaveEnabled")]
        public IWebElement SaveButton { get; set; }
        public void FillDetails()
        {
            TitleCombo.Click();
            GivenName.Clear();
            GivenName.SendKeys(ExcelOperation.GetData[19]);

            Surname.Clear();
            Surname.SendKeys(ExcelOperation.GetData[20]);
            RelationshipText.Clear();

            RelationshipText.SendKeys(ExcelOperation.GetData[21]);
            PasswordText.Clear();
            PasswordText.SendKeys(ExcelOperation.GetData[22]);
            PasswordPromptText.Clear();

            PasswordPromptText.SendKeys(ExcelOperation.GetData[23]);
            GenericHelper.AllScreenShot(driver) ;           

        }
        public void VerifyPageLandedOnThirdParty()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='f1']/table/tbody/tr[2]/td/table/tbody/tr/td[4]/table/tbody/tr/td/div[1]")));   
        }
        public void ClickOnSaveButton()
        {
            SaveButton.Click();
        }   
    }
}
