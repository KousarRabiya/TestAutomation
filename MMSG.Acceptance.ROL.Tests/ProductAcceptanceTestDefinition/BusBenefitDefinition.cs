using MMSG.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class BusBenefitDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(BusBenefitDefinition));
    }
}
