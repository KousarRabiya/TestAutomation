using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ExcelOperation;
using System;

namespace CometProject.PageObject
{
    class CallCenter
    {
        public IWebDriver driver;
        public CallCenter(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "LeftMenuTree")]
        public IWebElement TreeView { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='wucPackageSummary_tdEmployeeNo']/a")]
        public IWebElement EmployeeNo { get; set; }

        [FindsBy(How = How.Id, Using = "LeftMenuTreet1")]
        public IWebElement CreatePackageWithOutCard { get; set; }

        [FindsBy(How = How.Id, Using = "LeftMenuTreet2")]
        public IWebElement CreatePackageWithCard { get; set; }

        [FindsBy(How = How.Id, Using = "LeftMenuTreet3")]
        public IWebElement ProcessMenuWithoutCard { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='LeftMenuTreet13'][ Contains(Text(),'Benefit')]")]
        public IWebElement BenifitWithCard { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='LeftMenuTreet12']")]
        public IWebElement BenifitWithOutCard { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='grdBenefits']/tbody/tr[2]/td[2]/font/a")]
        public IWebElement VoucherTableFirstRow { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BenefitTreen3']/img")]
        public IWebElement PaymentInstructionExpandButton { get; set; }

        [FindsBy(How = How.Id, Using = "LeftMenuTreet16")]
        public IWebElement Amendments { get; set; }

        public void VerifyTreeViewIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.Id("LeftMenuTree")));
        }

        public void clickCreatePackage()
        {
            CreatePackageWithOutCard.Click();
        }
        public void clickOnProcessMenu()
        {
            ProcessMenuWithoutCard.Click();
        }
        public void GetEmployeeIdAndUpdateInExcel()
        {
            string EmployeeID = driver.FindElement(By.XPath(".//*[@id='wucPackageSummary_tdEmployeeNo']/a")).Text;
            ExcelOperation.AddData("TestData1", EmployeeID, "TC2_SearchTheEmployee");
            ExcelOperation.AddData("TestData1", EmployeeID, "TC3_VerifyEAMSIsConfiguredToNewEmployee");

            ExcelOperation.AddData("TestData1", EmployeeID, "TC4_AddingThePackageToTheEmployee");
            ExcelOperation.AddData("TestData1", EmployeeID, "TC5_ActivatingTheNewPackage");
            ExcelOperation.AddData("TestData1", EmployeeID, "TC6_EditPackageAndSaveTheDetails");

            ExcelOperation.AddData("TestData1", EmployeeID, "TC7_AddingAdhocPaymentInstruction");
            ExcelOperation.AddData("TestData1", EmployeeID, "TC8_AddingRegularPaymentInstruction");
            ExcelOperation.AddData("TestData1", EmployeeID, "TC9_OrderingTheCard");
        }
        public void ClickOnEmployeeNumber()
        {
            EmployeeNo.Click();
        }
        public void ClickOnBenefit()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ele = driver.FindElement(By.Id("LeftMenuTreet12"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
        public void BenefitNameInGrid()
        {
            SwitchToFrame();
            var ele = driver.FindElement(By.XPath(".//*[@id='grdBenefits']/tbody/tr[2]/td[1]/font/a"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
        public void SwitchToFrame()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.TagName("iframe")));
            driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
        }
        public bool VerifyPaymentInstructionIsCreated()
        {            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            ClickOnBenefit();
            SwitchToFrame();     
                  
            PaymentInstructionExpandButton.Click();
            string voucherStringComet = VoucherTableFirstRow.Text;
            if (voucherStringComet == PropertiesFile.Properties.PaymentDescription)
            {
                return true;
            }
            return false;
        }
        public string VerifyPackageStatus()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var text_input = driver.FindElement(By.XPath(".//*[@id='LeftMenuTreet2']")).Text;
            var result = text_input.Substring(text_input.Length - 3);           
            return result;
        }
        public bool VerifyCardIsCreatedSuccessufully()
        {
            var text_input = driver.FindElement(By.XPath(".//*[@id='LeftMenuTreet1']")).Text;

            if (text_input == "Card Screen")
            {
                return true;
            }
            return false;
        }
        public void ClickOnTheCard()
        {
            var ele = driver.FindElement(By.XPath(".//*[@id='LeftMenuTreet1']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }

        public void clickAmendments()
        {
            Amendments.Click();
        }
    }
}
