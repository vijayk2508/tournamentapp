using System;
using System.Web.UI;

public partial class Players_Event_Match_Join_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bStatus = false;
        if (!Page.IsPostBack)
        {
            int nMatchId = -1;
            bStatus = Request.QueryString["MatchID"] != null ? false : true;

            if (!bStatus)
            {
                int.TryParse(Request.QueryString["MatchID"].ToString(), out nMatchId);
                bStatus = nMatchId > 0 ? false : true;
            }

            if (bStatus)
            {
                Response.Redirect("~/Players/Event/Match/");
            }
        }
    }

    protected void btnProceed_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Players/Payment/Default.aspx");
    }
}