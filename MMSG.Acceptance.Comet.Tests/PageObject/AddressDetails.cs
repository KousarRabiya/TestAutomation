using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.ExcelOperation;
using System;

namespace CometProject.PageObject
{
    class AddressDetails
    {
        private IWebDriver driver;
        public AddressDetails(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        
        [FindsBy(How = How.Id, Using = "HomeAddressLine1Text")]
        public IWebElement Addressline1 { get; set; }

        [FindsBy(How = How.Id, Using = "HomeAddressLine2Text")]
        public IWebElement AddressLine2 { get; set; }

        [FindsBy(How = How.Id, Using = "HomeSuburbText")]
        public IWebElement SuburbText { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='HomeStateCombo']/option[3]")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "HomePostCodeText")]
        public IWebElement PostCode { get; set; }      

        [FindsBy(How = How.Id, Using = "CommandButtons_cmdNextEnabled")]
        public IWebElement Nextbutton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='grdSearchResults']/tbody/tr[2]/td[2]")]
        public IWebElement PostmanAddress { get; set; }

        [FindsBy(How = How.Id, Using = "Addressvalidation1_cmdShowAlternatives")]
        public IWebElement SearchBar { get; set; }
        
        [FindsBy(How = How.Id, Using = "PostalAddressLine1Text")]
        public IWebElement PostalAddressLine1 { get; set; }        

        [FindsBy(How = How.Id, Using = "PostalAddressLine2Text")]
        public IWebElement PostalAddressLine2 { get; set; }
        
        [FindsBy(How = How.Id, Using = "PostalSuburbText")]
        public IWebElement PostalSuburbText { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='PostalStateCombo']/option[3]")]
        public IWebElement PostalStateCombo { get; set; }
        
        [FindsBy(How = How.Id, Using = "PostalPostCodeText")]
        public IWebElement PostalPostCode { get; set; }
        
        [FindsBy(How = How.Id, Using = "Addressvalidation2_cmdShowAlternatives")]
        public IWebElement PostaSearchBar { get; set; }
        
        public void fillAddress()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Addressline1.Clear();
            Addressline1.SendKeys(ExcelOperation.GetData[9]);

            SuburbText.Clear();
            AddressLine2.Clear();
            AddressLine2.SendKeys(ExcelOperation.GetData[10]);
            SuburbText.SendKeys(ExcelOperation.GetData[11]);

            State.Click();
            PostCode.Clear();
            PostCode.SendKeys(ExcelOperation.GetData[12]);
            PostalAddressLine1.Clear();

            PostalAddressLine1.SendKeys(ExcelOperation.GetData[13]);
            PostalAddressLine2.Clear();
            PostalAddressLine2.SendKeys(ExcelOperation.GetData[14]);
            PostalSuburbText.Clear();
            PostalSuburbText.SendKeys(ExcelOperation.GetData[15]);

            PostalStateCombo.Click();
            PostalPostCode.Clear();
            PostalPostCode.SendKeys(ExcelOperation.GetData[16]);
            GenericHelper.AllScreenShot(driver);
            Nextbutton.Click();           
        }
        public void VerifyLandedOnAddressDetailsPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='form1']/table/tbody/tr[2]/td/table/tbody/tr/td[4]/table/tbody/tr/td/div")));            
        }
    }
}
