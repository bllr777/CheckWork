using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AstonTech.Lottery;
using AstonTech.Lottery.Common.Extensions;



namespace AstonTech.Lottery.Web.UserControls
{
    public partial class LotteryNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindLotteryNavigation();
                this.BindLotteryDropDown();
            }
            
        }

        #region Properties

        public LotteryNavigation CurrentNavigationLink { get; set; }

        public int LotteryGameId { get; set;}
        
        #endregion

        #region BIND CONTROLS   

        private void BindLotteryNavigation()
        {
            ListItemCollection navigationList = new ListItemCollection();

            bool isBasicInfo = true;
            bool isDrawing = true;
            bool isWinningNumber = true;
            bool isState = true;
            bool isWin = true;
            string lotteryIdQueryString = "LotteryId=" + this.LotteryGameId.ToString();

            if (this.LotteryGameId > 0)
            {
                switch (this.CurrentNavigationLink)
                {
                    case LotteryNavigation.LotteryBasic:
                        isBasicInfo = false;
                        break;
                    case LotteryNavigation.Drawing:
                        isDrawing = false;
                        break;
                    case LotteryNavigation.WinningNumber:
                        isWinningNumber = false;
                        break;
                    case LotteryNavigation.State:
                        isState = false;
                        break;
                    case LotteryNavigation.Win:
                        isWin = false;
                        break;
                }
            }

            else
            {
                isBasicInfo = false;
                isDrawing = false;
                isWinningNumber = false;
                isState = false;
                isWin = false;
            }

            navigationList.Add(new ListItem { Text = "Basic Info", Value ="/LotterySection/LotteryBasic.aspx?" + lotteryIdQueryString, Enabled = isBasicInfo });
            navigationList.Add(new ListItem { Text = "Drawing", Value = "/LotterySection/Drawing.aspx?" + lotteryIdQueryString, Enabled = isDrawing });
            navigationList.Add(new ListItem { Text = "Winning Numbers", Value = "/LotterySection/WinningNumber.aspx?" + lotteryIdQueryString, Enabled = isWinningNumber });
            navigationList.Add(new ListItem { Text = "State", Value = "/LotterySection/State.aspx?" + lotteryIdQueryString, Enabled = isState });

            navigationList.Add(new ListItem { Text = "Win", Value = "/LotterySection/Win.aspx?" + lotteryIdQueryString, Enabled = isWin });

            LotteryNavigationList.DataSource = navigationList;
            LotteryNavigationList.DataBind();
        }
        private void BindLotteryDropDown()
        {
            LotteryGameCollection gameCollection = LotteryGameManager.GetCollection();

            LotterySelectList.DataSource = gameCollection;
            LotterySelectList.DataBind();

            // notes:       Default value at the top of the dropdown list
            LotterySelectList.Items.Insert(0, new ListItem { Text = "(Select Game to Update)", Value = "0" });

            //notes:        set the drop-down select to the Game by Id
            if (this.LotteryGameId > 0)
                LotterySelectList.SelectedValue = this.LotteryGameId.ToString();
        }
       
        #endregion

        #region EVENT HANDLERS
        protected void LotterySelectList_Selected(object sender, EventArgs e)
        {
            if (LotterySelectList.SelectedValue.ToInt() > 0)
                Response.Redirect(this.CurrentNavigationLink.ToString() + ".aspx?LotteryId=" + LotterySelectList.SelectedValue);
            else
                Response.Redirect("LotteryBasic.aspx");
        }
        #endregion
    }
}