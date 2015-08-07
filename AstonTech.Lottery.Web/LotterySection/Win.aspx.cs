using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AstonTech.Lottery.Common.Extensions;
using AstonTech.Lottery;



namespace AstonTech.Lottery.Web.LotterySection
{
    public partial class Win : BasePage
    {

        #region LOCAL VARIABLES

        private int _lotteryGameId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _lotteryGameId = base.LotteryId;

            this.BindLotteryNavigation();

            if (!IsPostBack)
            {

                // notes:    check if in UPDATE mode
                this.BindUpdateInfo();
            }

        }
        #region LOTTERY NAVIGATION
        private void BindLotteryNavigation()
        {
            CustomLotteryNavigation.CurrentNavigationLink = LotteryNavigation.Win;

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
                        //LotteryGameId.Value = detailToUpdate.LotteryGameId.ToString();

                        //notes:    string fields
                        if (!string.IsNullOrEmpty(gameUpdate.GameName))
                            //GameName.Text = gameUpdate.GameName;

                        if (!string.IsNullOrEmpty(gameUpdate.GameNameAbbrev))
                            //GameNameAbbrev.Text = gameUpdate.GameNameAbbrev;

                        if (!string.IsNullOrEmpty(detailToUpdate.GameDescription))
                            //GameDescription.Text = detailToUpdate.GameDescription;

                        if (!string.IsNullOrEmpty(detailToUpdate.HowToPlay))
                           // HowToPlay.Text = detailToUpdate.HowToPlay;

                            if (!string.IsNullOrEmpty(detailToUpdate.Cost)) { }
                            //Cost.Text = detailToUpdate.Cost;

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
        private void ProcessForm()
        {
            StringBuilder formControlValues = new StringBuilder();

            string Win = Win1.Text;
            string odd = Odd.Text;
            string match = Match.Text;

            //notes:    set Game properties
            LotteryGameDetail detailToSave = new LotteryGameDetail();



            //notes:    game specific info
            //detailToSave.GameName = gameName;
           // detailToSave.GameNameAbbrev = gameNameAbbrev;

            //notes:    detail specific info
            //detailToSave.HowToPlay = howToPlay;
            //detailToSave.GameDescription = gameDescription;
            //detailToSave.Cost = cost;

            //notes:    call middle tier to save details
            DetailsManager.Save(detailToSave);


            //notes:    set Id's from hidden fields
            //detailToSave.LotteryGameId = LotteryGameId.Value.ToInt();

            // Output
            if (detailToSave.LotteryGameId > 0)
            {
                base.DisplayPageMessage(PageMessage, "Update was successful.");

            }
            else
            {
                //notes:    INSERT was successful - redirect back 
                Response.Redirect("LotteryBasic.aspx?LotteryId=" + detailToSave.LotteryGameId.ToString());
            }
        }

        #region EVENT HANDLERS
        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessForm();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            //int lotteryGameId = LotteryGameId.Value.ToInt();
            int lotteryGameId = 0;
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