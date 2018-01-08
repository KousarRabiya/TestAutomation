using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.ExcelOperation;
using System;

namespace ROLProject.Page_Object
{
    /// <summary>
    /// Contains the elements og the Contact page and the logic og the operation involved in this page
    /// </summary>
    class ROLContactPage
    {
        private IWebDriver driver;
        public ROLContactPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        /// <summary>
        /// Following are the object elements present in the Contact page
        /// </summary>
       
        [FindsBy(How = How.XPath, Using = "//div[@id='contact']//h1/span")]
        public IWebElement ContactPageHeader { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailID { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='contactForm']/div[4]/div[1]/div[2]/div/div[1]/button")]
        public IWebElement IWantToDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='contactForm']/div[4]/div[1]/div[2]/div/div[1]/div/ul/li[2]/a/span[.='Make a change to my package']")]
        public IWebElement IWantToDropDownOption { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='contactForm']/div[4]/div[2]/div[2]/div/div[1]/button")]
        public IWebElement ChangeButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='contactForm']/div[4]/div[2]/div[2]/div/div[1]/div/ul/li[5]/a/span[.='Change deduction for a benefit in my package']")]
        public IWebElement ChangeButtonOption { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='contactForm']/div[4]/div[4]/div[2]/div/div[1]/button")]
        public IWebElement CurrentBenifitButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='contactForm']/div[4]/div[4]/div[2]/div/div[1]/div/ul/li[2]/a/span[.='Administration Fee']")]
        public IWebElement CurrentBenifitButtonOption { get; set; }

        [FindsBy(How = How.Id, Using = "deduction-amount")]
        public IWebElement DedutioPerDay { get; set; }

        [FindsBy(How = How.Id, Using = "change-date-next")]
        public IWebElement PayDatePerChange { get; set; }

        [FindsBy(How = How.Id, Using = "Message")]
        public IWebElement MessageBox { get; set; }

        [FindsBy(How = How.Id, Using = "preferred-phone")]
        public IWebElement PreferedContact { get; set; }

        [FindsBy(How = How.Id, Using = "contact-submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "contact-submit")]
        public IWebElement SubmitMessage { get; set; }

        [FindsBy(How = How.Id, Using = "//div[@class='success-content']")]
        public IWebElement SubmitSuccesMessage { get; set; }

        /// <summary>
        /// Verifying the system landed in Contact page
        /// </summary>
        public void VerifyLandedInContactPage()
        {            
            if (ContactPageHeader.Text != "Contact us")
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Filling the details in the conatct page 
        /// </summary>
        public void FillTheDetails()
        {
            IWantToDropDown.Click();
            IWantToDropDownOption.Click();
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='contactForm']/div[4]/div[2]/div[2]/div/div[1]/button")));
            
            ChangeButton.Click();
            ChangeButtonOption.Click();
            CurrentBenifitButton.Click();
            CurrentBenifitButtonOption.Click();

            DedutioPerDay.SendKeys(ExcelOperation.GetData[3]);
            PayDatePerChange.Click();
            EmailID.Clear();
            EmailID.SendKeys(ExcelOperation.GetData[4]);

            PreferedContact.Click();
            MessageBox.SendKeys(ExcelOperation.GetData[5]);

            if (SubmitMessage.Text != "Submit")
            {
                throw new Exception();
            }
        }       
        public void ClickSubmitButton()
        {
            SubmitButton.Click();
            
        }
        public void VerifySubmitSuccessFull()
        {
            if (SubmitSuccesMessage.Displayed)
            {
                Console.WriteLine("Request submitted");
            }
        }
    }
}
