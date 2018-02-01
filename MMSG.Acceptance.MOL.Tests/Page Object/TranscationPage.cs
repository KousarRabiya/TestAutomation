using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace MOLProject.Page_Object
{
    /// <summary>
    /// Contains the object of the Trasnsaction page and opertion on the page method
    /// </summary>
    class TranscationPage
    {
        private IWebDriver driver;
        public TranscationPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.XPath, Using = "//ul[@id='tabs']/li[4]/a")]
        public IWebElement AdvanceFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[@class='date-picker-container'])[1]/img")]
        public IWebElement FromDatePickerImg { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submit-form']")]
        public IWebElement Submit { get; set; }

        public void ClickOnAdvanceFilter()
        {
            var waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            waitWindows.Until(d => AdvanceFilter.Displayed);
            AdvanceFilter.Click();
        }
        public void DatePickerFrom()
        {
            FromDatePickerImg.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1500));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title='Prev']")));

            for (int j = 1; j <= 18; j++)
            {
                IWebElement element = driver.FindElement(By.XPath("//a[@title='Prev']"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click()", element);
            }

            string toDate = DateTime.Now.ToString("dd");
            string firstLetter = toDate[0].ToString();
            if (firstLetter == "0")
            {
                string a = toDate.Remove(0, 1);
                WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1500));
                waitWindows.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + a + "')]")));

                IWebElement element = driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + a + "')]"));
                element.Click();
            }
            else
            {
                WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1500));
                waitWindows.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + toDate + "')]")));

                IWebElement element = driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + toDate + "')]"));
                element.Click();
            }
        }
        public void DatePickerTo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1500));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//span[@class='date-picker-container'])[2]/img")));
            IWebElement element = driver.FindElement(By.XPath("(//span[@class='date-picker-container'])[2]/img"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);

            string toDate = DateTime.Now.ToString("dd");
            string firstLetter = toDate[0].ToString();
            if (firstLetter == "0")
            {
                string a = toDate.Remove(0, 1);
                WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1500));
                waitWindows.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + a + "')]")));

                driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + a + "')]")).Click();
            }
            else
            {
                WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1500));
                waitWindows.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + toDate + "')]")));

                driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//tr//td/a[contains(text(),'" + toDate + "')]")).Click();
            }
        }
        public void ClickSubmit()
        {
            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            waitWindows.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='submit-form']")));
            Submit.Click();
        }
        public int IsTransactionExist()
        {
            int transaction = driver.FindElements(By.XPath("//table[@id='transactions-table-0']/tbody/tr")).Count;
            return transaction;
        }
        public void ListofTransaction()
        {
            int transaction = driver.FindElements(By.XPath("//table[@id='transactions-table-0']/tbody/tr")).Count;
            for (int i = 1; i <= transaction; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    string a = driver.FindElement(By.XPath("//table[@id='transactions-table-0']/tbody/tr[" + i + "]/td[" + j + "]")).Text;
                    Console.Write(a);
                }
            }
        }
        public void CaptureScreenTransaction()
        {
            Actions dragger = new Actions(driver);
            IWebElement draggablePartOfScrollbar = driver.FindElement(By.XPath(".//*[@id='main ']/div[2]/div[1]/div/ul/li[1]/a/span[2]"));

            // Drag downwards
            int numberOfPixelsToDragTheScrollbarDown = 50;
            for (int i = 5; i < 100; i = i + numberOfPixelsToDragTheScrollbarDown)
            {
                try
                {
                    // This causes a gradual drag of the scroll bar, 5 units at a time
                    dragger.MoveToElement(draggablePartOfScrollbar).ClickAndHold().MoveByOffset(0, numberOfPixelsToDragTheScrollbarDown).Release().Perform();
                }
                catch (Exception e1)
                {
                    throw e1;
                }
            }
        }
    }
}
