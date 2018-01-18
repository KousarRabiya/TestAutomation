using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace MOLProject.Page_Object
{
    /// <summary>
    /// Contains the elements og the Dashbord page and the logic og the operation involved in this page
    /// </summary>
    class DashBoardPage
    {
        private IWebDriver driver;
        public DashBoardPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        /// <summary>
        /// Following are the object elements present in the dashboard page
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'View payroll deductions & transfers')]")]
        public IWebElement viewPayrollDeductionTransaction { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='content']//h1/span")]
        public IWebElement DashBoardTextExist { get; set; }

        /// <summary>
        /// Verifying the system is in the dashboard screen
        /// </summary>
        public void VerifySystemLandedOnDashboard()
        {
            if (DashBoardTextExist.Text != "Dashboard")
            {
                MMSG.Automation.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :" + "System is not in Dashbord page");
                throw new Exception();
            }
        }

        /// <summary>
        /// Clicking on the View and payroll link in dashboard page
        /// </summary>
        public void ClickOnViewPayroll()
        {
            // checking the View Payroll and transaction link appears      
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30000));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'View payroll deductions & transfers')]")));
            viewPayrollDeductionTransaction.Click();
        }

        /// <summary>
        /// Checking the list of Benefits
        /// </summary>
        public void ListOfBenefits()
        {
            // Counting the Number of Benefits
            int numBenifts = driver.FindElements(By.XPath("//div[@id='content']/div[1]/div/div")).Count;
            Console.WriteLine(numBenifts);
            if (numBenifts != 0)
            {
                // Reading benefits 
                for (int i = 3; i <= numBenifts; i++)
                {
                    string benifit = driver.FindElement(By.XPath("//div[@id='content']/div[1]/div/div[" + i + "]/div[1]/div[2]/div[1]/a")).Text;
                    Console.WriteLine(benifit);
                }
            }
        }
        public void IfErrorScrollDown()
        {
            Actions dragger = new Actions(driver);
            IWebElement draggablePartOfScrollbar = driver.FindElement(By.XPath(".//*[@id='login']/div[5]/div/ul/li"));

            // Drag downwards
            int numberOfPixelsToDragTheScrollbarDown = 50;
            for (int i = 10; i < 500; i = i + numberOfPixelsToDragTheScrollbarDown)
            {
                try
                {
                    // This causes a gradual drag of the scroll bar, 10 units at a time
                    dragger.MoveToElement(draggablePartOfScrollbar).ClickAndHold().MoveByOffset(0, numberOfPixelsToDragTheScrollbarDown).Release().Perform();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
