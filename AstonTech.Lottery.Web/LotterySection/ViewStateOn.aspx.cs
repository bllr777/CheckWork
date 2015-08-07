using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.Lottery.Web.LotterySection
{
    public partial class ViewStateOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TestingPage.Text = TestingPage.Text + "This is the code behind" + PrizeAmount.Text; 
        }
    }
}