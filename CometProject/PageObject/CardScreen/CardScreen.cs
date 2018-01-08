using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CometProject.PageObject.CardScreen
{
    class CardScreen
    {
        public IWebDriver driver;
        public CardScreen(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public bool VerifyCardStatuesIsOrderPending()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));// logic need to change
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='grdCards_lblCardStatus_0']")));
            var text_input = driver.FindElement(By.XPath(".//*[@id='grdCards_lblCardStatus_0']")).Text;

            if (text_input == "Order Pending")
            {
                return true;
            }
            return false;
        }
    }
}
