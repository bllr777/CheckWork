using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.Lottery.Web
{
    public partial class GettingStarted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceLotteryHelloWorld.HelloWorldClient testService = new ServiceLotteryHelloWorld.HelloWorldClient();

            //notes:    call service method with parameter
            HelloWorldMessage.Text = testService.GetHelloWorld("Lottery");

            //notes:    call service method with empty value parameter
            HelloWorldMessage.Text += " <br><br>" + testService.GetHelloWorld(string.Empty);

        }
    }
}