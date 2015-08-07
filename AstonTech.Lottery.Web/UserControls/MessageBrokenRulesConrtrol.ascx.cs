using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AstonTech.Lottery.Common;
using AstonTech.Lottery.Common.Extensions;

namespace AstonTech.Lottery.Web.UserControls
{
    public partial class MessageBrokenRulesConrtrol : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region PUBLIC PROPERTIES   
        /// <summary>
        /// Sets the generic message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Sets and binds to ListView if rules exist.
        /// </summary>
        public BrokenRuleCollection BrokenRules { get; set; }
        #endregion

        #region BIND CONTROLS

        private void BindMessageArea()
        {
            if (!string.IsNullOrEmpty(this.Message))
                PageMessage.Text = this.Message;

            if (this.BrokenRules !=null && this.BrokenRules.Count() > 0)
            {
                MessageList.DataSource = this.BrokenRules;
                MessageList.DataBind();
            }
        }

        #endregion

        #region PUBLIC METHODS

        public void Display()
        {
            this.BindMessageArea();
        }

        #endregion
    }
}