using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AstonTech.Lottery.Common.Extensions;
using AstonTech.Lottery.Common;
using AstonTech.Lottery;


namespace AstonTech.Lottery.Web.LotterySection
{
    public partial class LotteryBasic : BasePage
    {

        #region LOCAL VARIABLES

        private int _lotteryGameId;

        #endregion

        #region PAGE LOAD & NAVIGATION
        protected void Page_Load(object sender, EventArgs e)
        {
            _lotteryGameId = base.LotteryId;

            
            this.BindLotteryNavigation();

            if (!IsPostBack)
            {
                base.SetMasterPageNavigation(MasterNavigation.LotteryGames);
                // notes:    check if in UPDATE mode
                this.BindUpdateInfo();
            }

        }
        private void BindLotteryNavigation()
        {
            CustomLotteryNavigation.CurrentNavigationLink = LotteryNavigation.LotteryBasic;

            CustomLotteryNavigation.LotteryGameId = _lotteryGameId;

        }
        #endregion

        #region UPDATE INFO
        private void BindUpdateInfo()
        {
            if (_lotteryGameId > 0)
            {

                LotteryGameDetail detailToUpdate = DetailsManager.GetItem(_lotteryGameId);
                LotteryGameValue gameUpdate = LotteryGameManager.GetItem2(_lotteryGameId);

                if (detailToUpdate != null)
                {

                    if (detailToUpdate.LotteryGameId > 0 && gameUpdate.LotteryGameId > 0)
                    {
                        //notes:    first change the text of the button to indicate that we're updating
                        SaveButton.Text = "Save Changes";

                        //notes:    display delete button
                        DeleteButton.Visible = true;

                        //notes:    set hidden form values for LotteryGameId
                        LotteryGameId.Value = detailToUpdate.LotteryGameId.ToString();

                        //notes:    string fields
                        if (!string.IsNullOrEmpty(gameUpdate.GameName))
                            GameName.Text = gameUpdate.GameName;

                        if (!string.IsNullOrEmpty(gameUpdate.GameNameAbbrev))
                            GameNameAbbrev.Text = gameUpdate.GameNameAbbrev;

                        if (!string.IsNullOrEmpty(detailToUpdate.GameDescription))
                            GameDescription.Text = detailToUpdate.GameDescription;

                        if (!string.IsNullOrEmpty(detailToUpdate.HowToPlay))
                            HowToPlay.Text = detailToUpdate.HowToPlay;

                        if (!string.IsNullOrEmpty(detailToUpdate.Cost))
                            Cost.Text = detailToUpdate.Cost;

                    }
                    else
                    {
                        //notes:    the necessary Id's to UPDATE are missing
                        Response.Redirect("LotteryBasic.aspx");
                    }
                }
                else
                {
                    Response.Redirect("LotteryBasic.aspx");
                }

            }
        }


        #endregion

        #region VALIDATION
        private void DisplayLocalMessage(string message)
        {
            PageMessageArea.Visible = true;
            PageMessage.Text = message;
        }
        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            //notes: validate form controls
            //notes: required fields
            if (string.IsNullOrEmpty(GameName.Text.Trim()))
                brokenRules.Add("GameName", "Required field.");

            if (string.IsNullOrEmpty(GameNameAbbrev.Text.Trim()))
                brokenRules.Add("Game Abbreviation", "Required field.");

            //notes:    check if broken rules collection has any items
            if (brokenRules.Count() > 0)
            {
                //notes:    bind the collection to the list control
                MessageList.DataSource = brokenRules;
                MessageList.DataBind();

                //notes:    check to see if there were multiple errors - diplay message
                if (brokenRules.Count() ==1)
                {
                    //notes:    display main error message to user
                    this.DisplayLocalMessage("There was an error processing your form. Please correct and try saving again.");
                }
                else
                {
                    //notes:    display main error message to user
                    this.DisplayLocalMessage("There were some errors processing your form. Please correct and try saving again.");
                }
                returnValue = false;
            }

            //notes:    return the value of the variable
            return returnValue;
        }
        #endregion

        #region PROCESS FORM
        private void ProcessForm()
        {
            StringBuilder formControlValues = new StringBuilder();

            string gameName = GameName.Text;
            string gameNameAbbrev = GameNameAbbrev.Text;
            string howToPlay = HowToPlay.Text;
            string gameDescription = GameDescription.Text;
            string cost = Cost.Text;



            //notes:    set Game properties
            LotteryGameDetail detailToSave = new LotteryGameDetail();



            //notes:    game specific info
            detailToSave.GameName = gameName;
            detailToSave.GameNameAbbrev = gameNameAbbrev;

            //notes:    detail specific info
            detailToSave.HowToPlay = howToPlay;
            detailToSave.GameDescription = gameDescription;
            detailToSave.Cost = cost;

            //notes:    call middle tier to save details
            DetailsManager.Save(detailToSave);


            //notes:    set Id's from hidden fields
            detailToSave.LotteryGameId = LotteryGameId.Value.ToInt();

            // Output
            if (detailToSave.LotteryGameId > 0)
            {
                this.DisplayLocalMessage("Update was successful.");

            }
            else
            {
                //notes:    INSERT was successful - redirect back 
                Response.Redirect("LotteryBasic.aspx?LotteryId=" + detailToSave.LotteryGameId.ToString());
            }
        }
        #endregion

        #region EVENT HANDLERS
        protected void Save_Click(object sender, EventArgs e)
        {
            if(this.ValidateForm())
            this.ProcessForm();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            int lotteryGameId = LotteryGameId.Value.ToInt();

            if (lotteryGameId > 0)
            {
                //notes:    call middle tier to delete detail record
                if (DetailsManager.Delete(lotteryGameId))
                {
                    //notes:    redirect to the basic page
                    Response.Redirect("LotteryBasic.aspx");
                }
                else
                {
                    //notes:    display a friendly error message
                    base.DisplayPageMessage(PageMessage, "Delete failed.");
                }
            }
        }
        #endregion
    }
}