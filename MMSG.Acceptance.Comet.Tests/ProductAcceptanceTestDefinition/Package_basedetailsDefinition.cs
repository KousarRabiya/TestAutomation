using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class Package_basedetailsDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(Package_basedetailsDefinition));

        /// <summary>
        /// Entering the data to fields while creating the Package 
        /// </summary>
        /// <param name="packageType"></param>
        [When(@"I enter new ""(.*)"" package details")]
        public void EnterNewPackageDetails(Package.PackageTypeEnum packageType)
        {

            Logger.LogMethodEntry("Employee_personaldetailsDefinition", "ValidatePageName",
                base.IsTakeScreenShotDuringEntryExit);
            new Package_basedetailsPage().FillNewPackageDetails(packageType);
            Logger.LogMethodExit("Employee_personaldetailsDefinition", "ValidatePageName",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
