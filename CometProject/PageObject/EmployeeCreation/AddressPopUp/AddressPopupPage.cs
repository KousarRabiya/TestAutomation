using OpenQA.Selenium;

namespace CometProject.PageObject.EmployeeCreation.AddressPopUp
{
    class AddressPopupPage
    {
        private IWebDriver driver;
        public AddressPopupPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public void AddressPostman()
        {
            var element = driver.FindElement(By.XPath(".//*[@id='grdSearchResults']/tbody/tr[2]/td[2]"));
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
            executor1.ExecuteScript("var element=arguments[0];setTimeout(function(){element.click();},150)", element);
        }      
    }
}
