using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using MMSG.Automation.ComponentHelper;
using TechTalk.SpecFlow;
using WebServiceTestProject.PageObjects;

namespace WebServiceTestProject
{
    [Binding]
    public class CreateEmployeeFeatureSteps
    {
        public IWebDriver driverIE;
        private readonly CCEnquiryPageObjects ccEnquiryObject;

        public CreateEmployeeFeatureSteps()
        {
            
            var options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            driverIE = new InternetExplorerDriver(options);
            ccEnquiryObject = new CCEnquiryPageObjects(driverIE);
        }

        [Given(@"Opens the browser and launch Comet Website")]
        public void GivenOpensTheBrowserAndLaunchCometWebsite()
        {
            GenericFolder.ValidateCometWebservice.BeforeClass();
            GenericFolder.ValidateCometWebservice.BeforeTest();
            driverIE.Navigate().GoToUrl("http://mslmcopreprod01/comet");
            driverIE.SwitchTo().Window(driverIE.WindowHandles[driverIE.WindowHandles.Count - 1]);
            driverIE.Manage().Window.Maximize();
        }

        [When(@"User Enters the newly created Employee number in Search Bar")]
        public void WhenUserEntersTheNewlyCreatedEmployeeNumberInSearchBar()
        {
            PageFactory.InitElements(driverIE, ccEnquiryObject);
            ccEnquiryObject.enterEmployeeID();
        }

        [Then(@"User clicks on the search button")]
        public void ThenUserClicksOnTheSearchButton()
        {
            ccEnquiryObject.clickOnSearchButton();
        }

        [Then(@"Wait until employee search grid is displayed")]
        public void ThenWaitUntilEmployeeSearchGridIsDisplayed()
        {
            ccEnquiryObject.waitForGridToDisplay();
            GenericFolder.ValidateCometWebservice.TakeScreenShot("");
        }

        [Then(@"Verify whether employee grid is displayed")]
        public void ThenVerifyWhetherEmployeeGridIsDisplayed()
        {
            Assert.IsTrue(ccEnquiryObject.getLabelText().Contains(ccEnquiryObject.empNumber));
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            driverIE.Close();
        }
    }
}
