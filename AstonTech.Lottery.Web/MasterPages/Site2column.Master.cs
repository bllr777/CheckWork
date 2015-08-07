using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.Lottery.Web
{
    public partial class Site2column : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindMasterNavigation();
        }
        #region PROPERTIES
        public MasterNavigation SelectedMasterPageNavigation { get; set; }

        #endregion

        private void BindMasterNavigation()
        {
            //notes:    bind navigation from enum
            switch (this.SelectedMasterPageNavigation)
            {
                case MasterNavigation.LotteryGames:
                    LotteryGameListItem.Attributes.Add("class", "Selected");
                    break;
            
                case MasterNavigation.Maintenance:
                    MaintenanceListItem.Attributes.Add("class", "Selected");
                    break;
                
            }
        }
    }
}