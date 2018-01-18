using OpenQA.Selenium;
using System.Linq;

namespace CometProject.PageObject.ReviewAndActivate
{
    class ReviewAndActiveatePage
    {
        public IWebDriver driver;
        public ReviewAndActiveatePage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public void ClickOnSaveButton()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            var ele = driver.FindElement(By.Id("CommandButtons_cmdSaveEnabled"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
    }
}
