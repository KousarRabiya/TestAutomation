using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ROLProject.Page_Object
{
    class LoginPage
    {
        private IWebDriver driver;
        /// <summary>
        /// Page object of the Login page
        /// </summary>
        /// <param name="_driver"></param>
        public LoginPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement usernameROL { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement passwordROL { get; set; }

        [FindsBy(How = How.XPath, Using = "//button")]
        public IWebElement loginButton { get; set; }
        /// <summary>
        /// Username field is been  username fronm the excel
        /// </summary>
        /// <param name="username"></param>
        public void EnterUsername(string username)
        {
            usernameROL.SendKeys(username);
        }
        /// <summary>
        /// Password field is been  password fronm the excel
        /// </summary>
        /// <param name="Password"></param>
        public void EnterPassword(string Password)
        {
            passwordROL.SendKeys(Password);
        }
        /// <summary>
        /// Clicking on the Login button
        /// </summary>
        public void ClickLoginButton()
        {
            loginButton.Click();
        }
    }
}
