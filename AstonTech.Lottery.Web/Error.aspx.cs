using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.Lottery.Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.ServerVariables["HTTP_REFERER"]))
                PreviousPageLink.NavigateUrl = Request.ServerVariables["HTTP_REFERER"];
        }
    }
}