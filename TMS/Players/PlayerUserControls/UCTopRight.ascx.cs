using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Players_PlayerUserControls_UCTopRight : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lnkProfile.NavigateUrl = "~/Players/Profile/"; 
    }

    protected void lnkLogout_OnClick(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Player_Email"] != null)
        {
            HttpContext.Current.Session["Player_Email"] = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            HttpContext.Current.Response.Redirect("~/Login/");
        }
    }
}