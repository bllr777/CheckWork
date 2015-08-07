using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.Lottery.Web.UserControls
{
    public partial class LotteryMaintenanceNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindLotteryMaintenanceNavigation();
            }
        }

        #region PROPERTIES

        /// <summary>
        /// Set the current Lottery Maintenance page. Link will be disabled for the current subheader link of current page.
        /// </summary>
        public LotteryMaintenanceNavigation CurrentNavigationLink { get; set; }

        #endregion

        #region BIND CONTROLS

        private void BindLotteryMaintenanceNavigation()
        {
            //notes:    set up collection of list items
            ListItemCollection navigationList = new ListItemCollection();

            //notes:    set local variables and set default values
            bool isLotteryLookupLinkable = true;

            string lotteryLookupQueryString = string.Empty;

            switch (this.CurrentNavigationLink)
            {
                case LotteryMaintenanceNavigation.LotteryLookup:
                    isLotteryLookupLinkable = false;
                    break;
               
            }

            //notes:    add each item to the collection
            navigationList.Add(new ListItem { Text = "Lottery Game Lookup", Value = "/LotteryMaintenance/Default/aspx", Enabled = isLotteryLookupLinkable });

            //notes:    bind list object to front-end control
            LotteryMaintenanceNavigationList.DataSource = navigationList;
            LotteryMaintenanceNavigationList.DataBind();
        }

        #endregion
    }
}