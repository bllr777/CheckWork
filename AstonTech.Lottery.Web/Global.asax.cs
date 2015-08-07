using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using log4net;

namespace AstonTech.Lottery.Web
{
    public partial class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //notes:    set up log4net on start of the application
            log4net.Config.XmlConfigurator.Configure();
        }
        
        protected void Application_Error(object sender, EventArgs e)
        {
            ILog logger = log4net.LogManager.GetLogger(typeof(ILog));
            Exception ex = Server.GetLastError();

            if (ex != null)
                logger.Error(ex.Message, ex);
            else
                logger.Error("Application_Error() executed, but the Exception object was not available.");
        }
    }

    
}