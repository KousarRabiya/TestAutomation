using MMSG.Automation;
using MMSG.Automation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.MOL.Home.Dashboard
{
  public  class DashboardPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(DashboardPage));

        /// <summary>
        /// Verifying the page landed on the Dashbord 
        /// </summary>
        /// <param name="benefitNane"></param>
        /// <returns></returns>
        public bool VerifyTheBenefitIsPresent(string benefitNane)
        {
            Logger.LogMethodEntry("DashboardPage", "VerifyTheBenefitIsPresent", base.IsTakeScreenShotDuringEntryExit);
            try
            {               
                if (base.IsElementDisplayedByPartialLinkText(benefitNane))
                {
                    return true;                         
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("DashboardPage", "VerifyTheBenefitIsPresent", base.IsTakeScreenShotDuringEntryExit);
            return false;
        }

        /// <summary>
        /// clicking on the link present in the dashbord
        /// </summary>
        /// <param name="linkName"></param>

        public void ClickOnTheLink(string linkName)
        {
            Logger.LogMethodEntry("DashboardPage", "ClickOnTheLink", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.ClickButtonByPartialLinkText(linkName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("DashboardPage", "ClickOnTheLink", base.IsTakeScreenShotDuringEntryExit);

        }        

    }
}
