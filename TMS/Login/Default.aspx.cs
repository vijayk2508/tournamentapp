using System;
using System.Web.UI;
using TMS.DataManager;
using TMS.DTO;
using TMS.Library;
using TMS.Web;

public partial class Home_Default : TMSPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void btnLogin_OnClick(object sender, EventArgs e)
    {
        PlayerDTO dtoPlayer = new PlayerDTO
        {
            Player_Email = txtEmail.Text,
            Player_Password = txtPassword.Text
        };

        bool bStatus = new PlayerDataManager(dtoPlayer).Auth();

        if (bStatus)
        {
            Session["Player_Email"] = dtoPlayer.Player_Email;
            Response.Redirect("~/Players/Dashboard");
        }

        lblMessage.Text = bStatus ? "Registration Successfully" : "Invalid Credential";
     
        ScriptManager.RegisterStartupScript(updatePnlNotificationForm, updatePnlNotificationForm.GetType(), "show", "$(function () {setTimeout(function () { $('#" + pnlNotificationForm.ClientID + "').modal('show');}, 800); });", true);
        updatePnlNotificationForm.Update();
    }

    protected void btnForgotPassword_OnClick(object sender, EventArgs e)
    {
        PlayerDTO dtoPlayer = new PlayerDTO
        {
            Player_Email = txtEmailAddress.Text,
        };

        PlayerDTO dtoPlayerData = new PlayerDataManager(dtoPlayer).isEmailOrMobileExist;

        
        if (dtoPlayerData != null)
        {
            bool bStatus=EmailSetting.SendForgotPassword(dtoPlayerData);

            lblMessage.Text = bStatus ? "Your password is sent to your mail address" : "Your password is not sent to your mail address";
        }
        else
        {
            lblMessage.Text = "Your Email id is not register with us.";
        }

        ScriptManager.RegisterStartupScript(updatePnlNotificationForm, updatePnlNotificationForm.GetType(), "show", "$(function () { $('#modalForgotPassword').modal('hide'); setTimeout(function () { $('#" + pnlNotificationForm.ClientID + "').modal('show');}, 800); });", true);

        updatePnlNotificationForm.Update();
    }
}