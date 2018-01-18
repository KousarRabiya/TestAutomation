using MMSG.Automation;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class DashboardDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(DashboardDefinition));

    }
}
