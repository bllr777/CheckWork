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
    public partial class Drawing : BasePage
    {

        #region LOCAL VARIABLES

        private int _lotteryGameId;
 

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //notes:    check for LotteryId
            base.ValidateLottery("LotteryBasic.aspx");
            _lotteryGameId = base.LotteryId;

            this.BindLotteryNavigation();
          

            if (!IsPostBack)
            {
                base.SetMasterPageNavigation(MasterNavigation.Drawings);
                // notes:    check if in UPDATE mode
                
                this.BindDrawingList();
              
            }

        }
        #region LOTTERY NAVIGATION
        private void BindLotteryNavigation()
        {
            CustomLotteryNavigation.CurrentNavigationLink = LotteryNavigation.Drawing;

            CustomLotteryNavigation.LotteryGameId = _lotteryGameId;

        }
        #endregion
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
            if (string.IsNullOrEmpty(DrawingDate.Text.Trim()))
                brokenRules.Add("Drawing Date", "Required field.");

            if (string.IsNullOrEmpty(PrizeAmount.Text.Trim()))
                brokenRules.Add("Jackpot Amount", "Required field.");

            //notes:    check if broken rules collection has any items
            if (brokenRules.Count() > 0)
            {
                //notes:    bind the collection to the list control
                MessageList.DataSource = brokenRules;
                MessageList.DataBind();

                //notes:    check to see if there were multiple errors - diplay message
                if (brokenRules.Count() == 1)
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

        #region UPDATE INFO
        private void BindUpdateInfo(int lotteryDrawingId)
        {
            LotteryDrawing drawing = DrawingManager.GetItem(lotteryDrawingId);

            if (drawing != null)
            {
                
               
                    //notes:    set hidden field so page knows to update
                    LotteryGameId.Value = drawing.LotteryGameId.ToString();

                    //notes:    set textbox for drawing
                    if (drawing.DrawingDate != null)
                        DrawingDate.Text = drawing.DrawingDate.ToShortDateString();

                    if (!string.IsNullOrEmpty(drawing.PrizeAmount))
                        PrizeAmount.Text = drawing.PrizeAmount.ToString();

                    //notes:    Set the display text of the button to indicate its an UPDATE
                    SaveButton.Text = "Save Drawing";
               
            }
            else
                base.DisplayPageMessage(PageMessage, "Drawing could not be retrieved. Contact an administer.");
        }
        private void DeleteDrawing(int lotteryDrawingId)
        {
            if (DrawingManager.Delete(lotteryDrawingId))
            {
                //notes:    redirect back to page
                Response.Redirect("Drawing.aspx?LotteryId=" + base.LotteryId.ToString());
            }
            else
            {
                //notes:    display a message to user
               this.DisplayLocalMessage("Delete of drawing failed. Contact an administrator." );
            }
            
        }


        #endregion
        private void BindDrawingList()
        {
            LotteryDrawingCollection drawing = DrawingManager.GetCollection(_lotteryGameId);
            DrawingList.DataSource = drawing;
            //DrawingList.DataSource = drawing;
            DrawingList.DataBind();
        }
        private void ProcessForm()
        {
            StringBuilder formControlValues = new StringBuilder();

            
            DateTime date = DrawingDate.Text.ToDate();
            string prize = PrizeAmount.Text;



            //notes:    set Game properties
            LotteryDrawing drawingToSave = new LotteryDrawing();



            //notes:    game specific info
            drawingToSave.DrawingDate = date;
            drawingToSave.PrizeAmount = prize;
            drawingToSave.LotteryGameId = _lotteryGameId;

            //notes:    detail specific info
           

            //notes:    call middle tier to save details
            DrawingManager.Save(drawingToSave);


            //notes:    set Id's from hidden fields
            drawingToSave.LotteryGameId = LotteryGameId.Value.ToInt();

             //Output
            if (drawingToSave.LotteryGameId > 0)
            {
                 base.DisplayPageMessage(PageMessage, "Update was successful.");

            }
            else
            {
                //notes:    INSERT was successful - redirect back 
                Response.Redirect("Drawing.aspx?LotteryId=" + drawingToSave.LotteryGameId.ToString());
            }
        }

        private void ProcessDrawing()
        {
         
        }


        #region EVENT HANDLERS
        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
            this.ProcessForm();
        }
                     
        protected void DrawingList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LotteryDrawing Drawing = (LotteryDrawing)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = Drawing.LotteryDrawingId.ToString();
                deleteButton.CommandArgument = Drawing.LotteryDrawingId.ToString();

            }
        }

        protected void DrawingButton_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    this.BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;

                case"Delete":
                    this.DeleteDrawing(e.CommandArgument.ToString().ToInt());
                    break;
            }
        }
      
        #endregion
    }
}