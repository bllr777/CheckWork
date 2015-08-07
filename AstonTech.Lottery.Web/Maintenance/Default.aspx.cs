using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.Text;
using AstonTech.Lottery.Common;
using AstonTech.Lottery.Common.Extensions;

namespace AstonTech.Lottery.Web.Maintenance
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetMasterPageNavigation(MasterNavigation.Maintenance);
            this.BindNavigation();

            if (!IsPostBack)
            {
                this.BindLotteryDropDown();

                //notes:    determine if we should display form for submission
                if (base.LotteryId > 0)
                {
                    this.DisplayFormSave(true);

                }
            }
        }

        #region PROCESS

        private void DeleteItem(int lotteryGameId)
        {
            using (ServiceLotteryLookup.LotteryLookupServiceClient lotteryLookupService = new ServiceLotteryLookup.LotteryLookupServiceClient())
            {
                try
                {
                    //notes:    call service method to delete item
                    lotteryLookupService.DeleteLotteryGame(lotteryGameId);

                    //notes:    redirect with LotterGameId in Querystring
                    this.ReloadPage(GameList.SelectedValue.ToInt());
                }
                catch (FaultException<ServiceLotteryLookup.LotteryLookupServiceFault> ex)
                {
                    this.DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMessage);
                }
            }
        }

        private void DisplayFormSave(bool isVisible)
        {
            GameNameRow.Visible = isVisible;
            SaveButton.Visible = isVisible;
            LookupList.Visible = isVisible;
        }

        private void ProcessForm()
        {
            ServiceLotteryLookup.LotteryGameDTO itemToSave = new ServiceLotteryLookup.LotteryGameDTO();

            itemToSave.LotteryGameId = GameList.SelectedValue.ToInt();
            itemToSave.GameName = GameList.Text.Trim();

            //notes:    check hidden value to see if we need to update or insert
            if (HiddenLotteryGameId.Value.ToInt() > 0)
                itemToSave.LotteryGameId = HiddenLotteryGameId.Value.ToInt();

            //notes:    call service to save
            using (ServiceLotteryLookup.LotteryLookupServiceClient lotteryLookupService = new ServiceLotteryLookup.LotteryLookupServiceClient())
            {
                try
                {
                    lotteryLookupService.SaveLotteryGame(itemToSave);

                    //notes:    redirect with LotteryGameId in QueryString
                    this.ReloadPage(GameList.SelectedValue.ToInt());
                }
                catch (FaultException<ServiceLotteryLookup.LotteryLookupServiceFault> ex)
                {

                    this.DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMessage);
                }
            }
        }

        private void ReloadPage()
        {
            this.ReloadPage(0);
        }

        private void ReloadPage(int lotteryGameId)
        {
            if (lotteryGameId > 0)
                Response.Redirect("Default.aspx?LotteryId=" + lotteryGameId.ToString());
            else
                Response.Redirect("Default.aspx");
        }

        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            if (GameList.SelectedValue.Trim().ToInt() == 0)
            {
                brokenRules.Add("Lottery Game", "Please select a valid Lottery Game from the drop-down list.");
                returnValue = false;
            }

            if(string.IsNullOrEmpty(GameValueField.Text.Trim()))
            {
                brokenRules.Add("Lookup Value", "Required field.");
                    returnValue = false;
            }

            if (!returnValue)
            {
                if(brokenRules.Count() == 1)
                    this.DisplayLocalMessage("There is an error with your submission. Please correct and try again.", brokenRules);
                else
                    this.DisplayLocalMessage("There were some errors with your submission. Please correct and try again.", brokenRules);
            }

            return returnValue;
        }
         
        #endregion

        #region BIND CONTROLS

        private void BindLotteryDropDown()
        {
            using (ServiceLotteryLookup.LotteryLookupServiceClient lotteryLookupService = new ServiceLotteryLookup.LotteryLookupServiceClient())
            {
                ServiceLotteryLookup.LotteryGameDTOCollection lotteryCollection = lotteryLookupService.GetLotteryGameCollection();
                if (lotteryCollection != null && lotteryCollection.Count() > 0)
                {
                    GameList.DataSource = lotteryCollection;
                    GameList.DataBind();

                    GameList.Items.Insert(0, new ListItem { Text = "(Select Game Abbreviation)", Value = "0" });

                    //notes:    set default value if LotteryGameId exists in QueryString
                    GameList.SelectedValue = base.LotteryId.ToString();
                }

                else
                    GameList.Items.Add(new ListItem { Text = "Not Available", Value = "0" });
            }
        }

        private void BindGameNameAbbrev(int lotteryGameId)
        {

        }

        private void BindNavigation()
        {
            CustomLotteryMaintenanceNavigation.CurrentNavigationLink = LotteryMaintenanceNavigation.LotteryLookup;
        }
        private void BindUpdateIntfo(int lotteryGameId)
        {
            using (ServiceLotteryLookup.LotteryLookupServiceClient lotteryLookupService = new ServiceLotteryLookup.LotteryLookupServiceClient())
            {
                try
                {
                    //notes:    call service to get item
                    ServiceLotteryLookup.LotteryGameDTO itemToUpdate = lotteryLookupService.GetLotteryGame(lotteryGameId);

                    if (itemToUpdate !=null)
                    {
                        //notes:    sert hidden value to Id of item so code knows to update instead of insert
                        HiddenLotteryGameId.Value = itemToUpdate.LotteryGameId.ToString();

                        //notes:    display text in textbox
                        if (!string.IsNullOrEmpty(itemToUpdate.GameName))
                            GameValueField.Text = itemToUpdate.GameName;

                        //notes:    change text on button to update
                        SaveButton.Text = "Update Lookup Value";

                       //notes:     display cancel button
                       CancelButton.Visible = true;
                    }
                    else
                        this.DisplayLocalMessage("Update failed. Couldn't find record.");
                }
                catch (FaultException<ServiceLotteryLookup.LotteryLookupServiceFault> ex)
                {
                    
                    this.DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMessage);
                }
            }
        }

        private void DisplayLocalMessage(string message)
        {
            this.DisplayLocalMessage(message, new BrokenRuleCollection());
        }

        private void DisplayLocalMessage(string message, BrokenRuleCollection brokenRules)
        {
            CustomMessageArea.Visible = true;
            CustomMessageArea.Message = message;

            if (brokenRules.Count() > 0)
                CustomMessageArea.BrokenRules = brokenRules;

            //notes:    execute Display() method to render to screen
            CustomMessageArea.Display();
        }
        #endregion

        #region EVENT HANDLERS

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.ReloadPage(GameList.SelectedValue.ToInt());
        }

        protected void GameList_Selected(object sender, EventArgs e)
        {
            if (GameList.SelectedValue.ToInt() > 0)
            {
                //notes:    show submission form controls and display repeater
                this.DisplayFormSave(true);
               
            }
            else
            {
                //notes:    user selected the default list item - didn't select a valid Lottery item
                //          hide all possible form submission
                this.DisplayFormSave(false);
            }
        }

        protected void GameAbbrev_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    this.BindUpdateIntfo(e.CommandArgument.ToString().ToInt());
                    break;

                case "Delete":
                    this.DeleteItem(e.CommandArgument.ToString().ToInt());
                    break;
            }
        }

        protected void LookupList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ServiceLotteryLookup.LotteryGameDTO lotteryGame = (ServiceLotteryLookup.LotteryGameDTO)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = lotteryGame.LotteryGameId.ToString();
                deleteButton.CommandArgument = lotteryGame.LotteryGameId.ToString();

            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
                this.ProcessForm();
        }
        #endregion
    }
}