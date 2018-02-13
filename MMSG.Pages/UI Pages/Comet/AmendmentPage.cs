using MMSG.Automation;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.Comet
{
   public class AmendmentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Employee_personaldetailsPage));

        /// <summary>
        /// Verify the page landed on the Amendment Screen
        /// </summary>
        /// <returns></returns>
       public  bool VerifyThepageLandedOnAmendment()
        {
            Logger.LogMethodEntry("AmendmentPage", "VerifyThepageLndedOnAmendment",
                base.IsTakeScreenShotDuringEntryExit);
            bool pageLandedOnAmendment = false;
            try
            {
                base.WaitForElement(By.XPath("//span[@id='lblPageTitle']"));
                //geting the amendment Page heading
                string amendmentPage = base.GetElementInnerTextByXPath("//span[@id='lblPageTitle']");
                if (amendmentPage== "Amendments")
                {
                    return true;
                }
            }           
             catch (Exception e)
            {
                    ExceptionHandler.HandleException(e);
             }
                Logger.LogMethodEntry("AmendmentPage", "VerifyThepageLandedOnAmendment",
                    base.IsTakeScreenShotDuringEntryExit);
            return pageLandedOnAmendment;
            } 

        public void ClickOnOption(string optionName)
        {

            Logger.LogMethodEntry("AmendmentPage", "ClickOnOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (optionName)
                {
                    case "New":
                        bool asd= base.IsElementPresent(By.Id("btnNew"));
                        base.WaitForElement(By.Id("btnNew"));
                        IWebElement newButtonProperty = base.GetWebElementProperties(By.Id("btnNew"));
                        base.ClickByJavaScriptExecutor(newButtonProperty);                  
                        
                      
                        ////
                       
                       
                        //base.FillTextBoxById("txtActivationDate_0", "03/12/2017");
                       // base.SelectDropDownOptionById("ddlNextPayDateForChange_0", "04/01/2018");


                        //////base.SelectDropDownOptionById("ddlBudgetCalcMethod_0", "Per Annum");
                        //////base.ClearTextById("txtBudgetAmount_0");
                        //////base.FillTextBoxById("txtBudgetAmount_0", "10");
                        //////base.ClickButtonById("btnSave");
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("AmendmentPage", "ClickOnOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
