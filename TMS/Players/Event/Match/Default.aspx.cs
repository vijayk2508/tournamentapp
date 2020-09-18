using System;
using System.Collections.ObjectModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.DataManager;
using TMS.DTO;
using TMS.Library;
using TMS.Web;

public partial class Players_Event_Match_Default : TMSPlayerPage
{
    #region Global Variable
    private Collection<MatchDTO> collMatch = new Collection<MatchDTO>();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bStatus = false;
        if (!Page.IsPostBack)
        {
            int nEventId = -1;
            if (Request.QueryString["EventID"] != null)
            {
                int.TryParse(Request.QueryString["EventID"].ToString(), out nEventId);
                if (nEventId > 0)
                {
                    MatchDTO dtoCurrentEvent = new MatchDTO
                    {
                        Match_EventID = nEventId
                    };
                    collMatch = new MatchDataManager(dtoCurrentEvent).MatchByEventIDCollection;
                }
                else
                {
                    bStatus = true;
                }
            }
            else
            {
                bStatus = true;
            }

            if (bStatus)
            {
                collMatch = MatchDataManager.MatchCollection;
            }

            rptEvent_Bind();
        }
    }

    private void rptEvent_Bind()
    {
        rptMatch.DataSource = collMatch;
        rptMatch.DataBind();
    }

    protected void rptMatch_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;

            MatchDTO dtoMatch = item.DataItem as MatchDTO;

            HiddenField hdnMatchID = (HiddenField)item.FindControl("hdnMatchID");
            Label lblMatchTitle = (Label)item.FindControl("lblMatchTitle");
            Image imgMatch = (Image)item.FindControl("imgMatch");
            HyperLink lnkJoin = (HyperLink)item.FindControl("lnkJoin");
            
            hdnMatchID.Value = dtoMatch.Match_ID.ToString();
            lblMatchTitle.Text = dtoMatch.Match_Title;
            imgMatch.ImageUrl = dtoMatch.Match_Image;
            lnkJoin.NavigateUrl = "/Players/Event/Match/Join/?MatchID=" + dtoMatch.Match_ID.ToString();
        }
    }
}