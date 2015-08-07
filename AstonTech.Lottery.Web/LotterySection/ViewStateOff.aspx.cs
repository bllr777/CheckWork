using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.Lottery.Web.LotterySection
{
    public partial class ViewStateOff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object Sender, EventArgs e)
        {
            TestingPage.Text = TestingPage.Text + "  Event  " + PrizeAmount.Text;
        }
    }

}