using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace AstonTech.Lottery.Web
{

    public class BasePage : System.Web.UI.Page
    {
        #region PROPERTIES
        /// <summary>
        /// Gets Id from the LotteryId QueryStrinhg. If not found, returns 0.
        /// </summary>
        public int LotteryId
        {
            get
            {
                return this.GetQueryStringNumber("LotteryId");
            }
        }
        
        public int LotteryDrawingId
        {
            get
            {
                return this.GetQueryStringNumber("LotteryDrawingId");
            }
        }
        public int DrawingNumberId
        {
            get
            {
                return this.GetQueryStringNumber("DrawingNumberId");
            }
        }
        #endregion
        /// <summary>
        /// Attempt to retrieve a numeric value from the querystring.
        /// If invalid querystring name or value is not an integer, return 0.
        /// </summary>
        /// <param name="queryStringName">Name of the Querystring name/value pair. </param>
        /// <returns></returns>
        public int GetQueryStringNumber(string queryStringName)
        {
            if (Request.QueryString[queryStringName] == null)
            {
                //notes:        return 0 if invalid querystring
                return 0;
            }
            else
            {
                string tempValue = Request.QueryString[queryStringName];
                int intOutValue;

                //notes:      attempt to  parse into an integer value
                if (int.TryParse(tempValue, out intOutValue))
                    return intOutValue;
                else
                    return 0;
            }
          
        }

        public void DisplayPageMessage(Label LabelControl, string messageToDisplay)
        {
            this.DisplayPageMessage(LabelControl, messageToDisplay, false);
        }
        public void DisplayPageMessage(Label LabelControl, string messageToDisplay, bool isAppend)
        {
            if (isAppend)
                LabelControl.Text += messageToDisplay;
            else
                LabelControl.Text = messageToDisplay;
        }

        public void SetMasterPageNavigation(MasterNavigation masterNavigationEnum)
        {
            Site2column myMasterPage = (Site2column)Page.Master;
            myMasterPage.SelectedMasterPageNavigation = masterNavigationEnum;
        }

        public void ValidateLottery(string redirectPage)
        {
            if(this.LotteryId > 0)
            {
                //notes:    LotteryId exists - check if its a valid record in the database
            }
            else
            {
                //notes:    redirect to specified page since LotteryId is missing
                Response.Redirect(redirectPage);
            }
        }
    }


}