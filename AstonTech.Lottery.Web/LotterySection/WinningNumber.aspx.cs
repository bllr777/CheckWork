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
    public partial class WinningNumber : BasePage
    {

        #region LOCAL VARIABLES

        private int _lotteryGameId;
        public int DrawingTypeId { get; set; }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _lotteryGameId = base.LotteryId;

            this.BindLotteryNavigation();
           // this.BindUpdateInfo(_lotteryGameId);

            if (!IsPostBack)
            {
                this.DrawingDropDown();
                this.BindBallTypeDropDown();
                this.BindNumberList();
          
                 
            }

        }
        #region LOTTERY NAVIGATION
        private void BindLotteryNavigation()
        {
            CustomLotteryNavigation.CurrentNavigationLink = LotteryNavigation.WinningNumber;

            CustomLotteryNavigation.LotteryGameId = _lotteryGameId;

        }
        #endregion
        private void BindNumberList()
        {
            DrawingNumberCollection n = DrawingNumberManager.GetCollection(_lotteryGameId);
            NumberList.DataSource = n;
            //DrawingList.DataSource = drawing;
            NumberList.DataBind();
        }
        private void DrawingDropDown()
        {
            LotteryDrawingCollection drawingCollection = DrawingManager.GetCollection(_lotteryGameId);

            DrawingList.DataSource = drawingCollection;
            DrawingList.DataBind();

            // notes:       Default value at the top of the dropdown list
            DrawingList.Items.Insert(0, new ListItem { Text = "(Select Drawing Date)", Value = "0" });
        }
        #region BIND BALLTYPE
        private void BindBallTypeDropDown()
        {
            DrawingTypeCollection ballCollection = DrawingTypeManager.GetCollection(DrawingTypeEnum.BallType);

            BallList.DataSource = ballCollection;
            BallList.DataBind();

            // notes:       Default value at the top of the dropdown list
            BallList.Items.Insert(0, new ListItem { Text = "(Select Ball Type)", Value = "0" });
        }
        #endregion

        #region UPDATE INFO
        private void BindUpdateInfo(int lotteryDrawingId)
        {
            DrawingNumber number = DrawingNumberManager.GetItem(lotteryDrawingId);
            LotteryDrawing drawing = DrawingManager.GetItem(lotteryDrawingId);
           

            if (number != null)
            {
                if (number.LotteryDrawingId > 0 && drawing.LotteryGameId > 0)
                {
                    //notes:    set hidden field so page knows to update
                    LotteryGameId.Value = number.LotteryDrawingId.ToString();

                    //notes:    set textbox for drawing
                    if (number.DrawingNumberValue != null)
                        Number.Text = number.DrawingNumberValue.ToString();

                    if (number.BallType != null)
                        BallList.SelectedValue = number.BallType.ToString();

                    //notes:    Set the display text of the button to indicate its an UPDATE
                    SaveButton.Text = "Save Winning Number";
                }
            }
            else
                base.DisplayPageMessage(PageMessage, "Winning Number could not be retrieved. Contact an administrator.");
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
                base.DisplayPageMessage(PageMessage, "Delete of drawing failed. Contact an administrator." );
            }
        }
          private void ProcessForm()
          {
              StringBuilder formControlValues = new StringBuilder();


              int number = Number;
              string ballTypeText = BallList.SelectedItem.Text;
              int ballTypeValue = BallList.SelectedValue.ToInt();



              //notes:    set Game properties
              DrawingNumber numberToSave = new DrawingNumber();
              LotteryDrawing h = new LotteryDrawing();


              //notes:    game specific info
              numberToSave.DrawingNumberValue = number;
              numberToSave.BallType =  ballTypeValue.ToString();
             

              //notes:    detail specific info


              //notes:    call middle tier to save details
              DrawingNumberManager.Save(numberToSave);


              //notes:    set Id's from hidden fields
              h.LotteryGameId = LotteryGameId.Value.ToInt();

              //Output
              if (numberToSave.DrawingNumberId > 0)
              {
                  base.DisplayPageMessage(PageMessage, "Update was successful.");

              }
              else
              {
                  //notes:    INSERT was successful - redirect back 
                  Response.Redirect("Drawing.aspx?LotteryId=" + numberToSave.DrawingNumberId.ToString());
              }
          }
        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessForm();
        }
                     
        protected void NumberList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DrawingNumber Drawing = (DrawingNumber)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = Drawing.DrawingNumberId.ToString();
                deleteButton.CommandArgument = Drawing.DrawingNumberId.ToString();

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