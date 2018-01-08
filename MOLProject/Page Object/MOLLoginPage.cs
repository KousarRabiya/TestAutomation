using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MOLProject.Page_Object
{
    class MOLLoginPage
    {
        private IWebDriver driver;
        /// <summary>
        ///Login Page Page Objects
        /// </summary>
        /// <param name="_driver"></param>
        public MOLLoginPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement usernameMOL { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement passwordMOL { get; set; }

        [FindsBy(How = How.XPath, Using = "//button")]
        public IWebElement loginButton { get; set; }

        /// <summary>
        /// Entering the Username field
        /// </summary>
        /// <param name="username"></param>
        public void EnterUsername(string username)
        {
            usernameMOL.SendKeys(username);
        }
        /// <summary>
        /// Entering the password field
        /// </summary>
        /// <param name="Password"></param>
        public void EnterPassword(string Password)
        {
            passwordMOL.SendKeys(Password);
        }
        /// <summary>
        /// Clicking on Login button
        /// </summary>
        public void ClickLoginButton()
        {
            loginButton.Click();
        }
    }
}
