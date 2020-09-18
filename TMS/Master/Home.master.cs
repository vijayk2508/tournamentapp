using System;
using System.Web;
using System.Web.UI;
using TMS.Web;

public partial class Master_Home : TMSMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }

        img1.ImageUrl = Page.ResolveUrl("~/Resources/img/loader.gif");
        logo1.ImageUrl = Page.ResolveUrl("~/Resources/img/pubg-6.png");
        logo3.ImageUrl = Page.ResolveUrl("~/Resources/img/log.png");

        string pageName = ContentPlaceHolder1.Page.GetType().Name;
        lnkRegistration.Visible = pageName.Equals("signup_default_aspx") ? false : true;
        lnkJoinGame.Visible = pageName.Equals("signup_default_aspx") ? true : false;
    }
}
