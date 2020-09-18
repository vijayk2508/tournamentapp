using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.DataManager;
using TMS.DTO;
using TMS.Library;
using TMS.Web;

public partial class Players_Event_Default : TMSPlayerPage
{
    #region Global Variable
    Collection<EventRegisterDTO> collEventRegister = EventRegisterDataManager.EventRegisterCollection;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rptEvent_Bind();
        }
    }

    private void rptEvent_Bind()
    {
        rptEvent.DataSource = new EventDataManager().EventCollection;
        rptEvent.DataBind();
        updatePnlEventRegistered.Update();
    }

    protected void rptEvent_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;

            EventDTO dtoCurrentEvent = (EventDTO)item.DataItem;

            HiddenField hdnEventID = (HiddenField)item.FindControl("hdnEventID");
            Label lblEventName = (Label)item.FindControl("lblEventName");
            Image imgEvent = (Image)item.FindControl("imgEvent");
            Button btnRegister = (Button)item.FindControl("btnRegister");
            HyperLink hypLnkViewMatch = (HyperLink)item.FindControl("hypLnkViewMatch");

            hdnEventID.Value = dtoCurrentEvent.Event_ID.ToString();
            lblEventName.Text = dtoCurrentEvent.Event_Title;
            imgEvent.ImageUrl = dtoCurrentEvent.Event_Image;
            btnRegister.CommandArgument = dtoCurrentEvent.Event_ID.ToString();
            hypLnkViewMatch.NavigateUrl = "/Players/Event/Match/?EventID=" + dtoCurrentEvent.Event_ID.ToString();
           
            if (collEventRegister.Count > 0 && collEventRegister != null)
            {
                EventRegisterDTO dtoEventRegister = collEventRegister.Where(x => x.EventRegister_PlayerID == CurrentPlayer.Player_ID && x.EventRegister_EventID == dtoCurrentEvent.Event_ID).FirstOrDefault();

                if (dtoEventRegister != null)
                {
                    switch ((ePlayerEventRegisterationStatus)dtoEventRegister.EventRegister_Status)
                    {
                        case ePlayerEventRegisterationStatus.Open:
                            btnRegister.Text = "Your registeration is under verification";
                            btnRegister.Enabled = false;
                            break;
                        case ePlayerEventRegisterationStatus.Approved:
                            btnRegister.Text = "Registerd Successfully";
                            btnRegister.Enabled = false;
                            hypLnkViewMatch.Visible = true;
                            break;
                    }

                }
            }

        }
    }

    protected void btnRegister_OnClick(object sender, EventArgs e)
    {
        //int.TryParse((sender as Anthem.Button).CommandArgument.ToString(), out Id);

        RepeaterItem item = (sender as Button).Parent as RepeaterItem;

        hdnEventRegisterID.Value = ((HiddenField)item.FindControl("hdnEventID")).Value;

        lblTitleEventName.Text = ((Label)item.FindControl("lblEventName")).Text;

        ScriptManager.RegisterStartupScript(updatePnlEventRegistered, updatePnlEventRegistered.GetType(), "show", "$(function () { $('#" + pnlEventRegistered.ClientID + "').modal('show'); });", true);
        updatePnlEventRegistered.Update();
    }

    protected void btnEventRegister_OnClick(object sender, EventArgs e)
    {
        int Id = 0;
        bool bStatus = false;

        int.TryParse(hdnEventRegisterID.Value.ToString(), out Id);

        EventRegisterDTO dtoEventRegister = new EventRegisterDTO
        {
            EventRegister_EventID = Id,
            EventRegister_PlayerID = CurrentPlayer.Player_ID,
            EventRegister_PlayerUsername = txtRegisteredUsername.Text,
            EventRegister_Status = (int)ePlayerEventRegisterationStatus.Open
        };

        bStatus = new EventRegisterDataManager(dtoEventRegister).Save();

        lblMessage.Text = bStatus ? "Registered Succesfully." : "Error.";

        ScriptManager.RegisterStartupScript(updatePnlNotificationForm, updatePnlNotificationForm.GetType(), "show", "$(function () { $('#" + pnlEventRegistered.ClientID + "').modal('hide'); setTimeout(function () { $('#" + pnlNotificationForm.ClientID + "').modal('show');}, 800); });", true);
        updatePnlNotificationForm.Update();

        rptEvent_Bind();
    }
}