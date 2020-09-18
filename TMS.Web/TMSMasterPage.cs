using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TMS.Web
{
    public class TMSMasterPage : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            //base.OnInit(e);
            if (HttpContext.Current.Session["Player_Email"] != null)
            {
                Response.Redirect("~/Players/Dashboard");
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception Ex = Server.GetLastError();
            Server.ClearError();
            Server.Transfer("~/Error/OOPs/");
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Exception Ex = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("~/Error/");
        }
    }
}
