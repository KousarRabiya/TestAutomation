using MMSG.Automation;
using MMSG.Automation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.MOL.Home.Dashboard
{
   public class PayrollDeductionsAndTransfersPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PayrollDeductionsAndTransfersPage));


        /// <summary>
        /// Verying the test landed on the Payroll Deductions And Transfers Page
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public bool VerifyThepageLandedOnPayrollDeductionsAndTransfers(string pageName)
        {
            Logger.LogMethodEntry("PayrollDeductionsAndTransfersPage", "VerifiThepageLandedOnPayrollDeductionsAndTransfers", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string a = PayrollDeductionsAndTransfersPageResource.PayrollDeductionsAndTransfers_PayrollDeductionsAndTransfersTitle_Xpath_Locator;
              if (base.GetElementInnerTextByXPath(a)== pageName)
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
        /// Cliking on the tab tab present in the transaction page
        /// </summary>
        /// <param name="tabName"></param>

        public void ClickOnTheTab(string tabName)
        {
            Logger.LogMethodEntry("PayrollDeductionsAndTransfersPage", "ClickOnTheAdvanceFilterTab", base.IsTakeScreenShotDuringEntryExit);
            try
            {
               switch (tabName)
                {
                    case "Advanced Filter":
                        base.ClickButtonByXPath(PayrollDeductionsAndTransfersPageResource.PayrollDeductionsAndTransfers_AdvanceFilterTab_Xpath_Locator);
                        break;                  
                }                  


            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("DashboardPage", "ClickOnTheAdvanceFilterTab", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
