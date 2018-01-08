using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace ROLProject.Page_Object
{
    /// <summary>
    /// Contains the elements og the Dashbord page and the logic og the operation involved in this page
    /// </summary>
    class ROLDashboard
    {
        private IWebDriver driver;
        public ROLDashboard(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        /// <summary>
        /// Following are the objectelements present in the dashboard page
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//ul[@id='lg-menu']/li/a/span[contains(text(),'Contact')]")]
        public IWebElement Contact { get; set; }

        /// <summary>
        /// Clicking On the Contact page
        /// </summary>
        public void ClickOnTheContact()
        {
            Contact.Click();
        }
        public void VerifyLandedOnContactPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//ul[@id='lg-menu']/li/a/span[contains(text(),'Contact')]")));
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
                catch (Exception e1) { throw e1; }
            }
        }
    }
}
