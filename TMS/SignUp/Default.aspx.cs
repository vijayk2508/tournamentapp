using System;
using System.Web.UI;
using TMS.DataManager;
using TMS.DTO;
using TMS.Web;

public partial class SignUp_Default : TMSPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void btnSignUp_OnClick(object sender, EventArgs e)
    {
        bool bStatus = false;

        PlayerDTO dtoPlayer = new PlayerDTO
        {
            Player_Name = txtName.Text.Trim(),
            Player_Email = txtEmail.Text.Trim(),
            Player_MobileNo = txtMobileNo.Text.Trim(),
            Player_Password = txtPassword.Text.Trim()
        };

        PlayerDTO dtoPlayerData = new PlayerDataManager(dtoPlayer).isEmailOrMobileExist;

        if (dtoPlayerData != null)
        {
            if (dtoPlayerData.Player_ID > 0)
            {
                if (dtoPlayerData.Player_Email.Equals((dtoPlayer.Player_Email)))
                {
                    lblMessage.Text = "Email ID is already exist !!";
                }
                else if (dtoPlayerData.Player_MobileNo.Equals((dtoPlayer.Player_MobileNo)))
                {
                    lblMessage.Text = "Mobile No is already exist !!";
                }
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
            bStatus = new PlayerDataManager(dtoPlayer).Save();

            if (bStatus)
            {
                Response.Redirect("~/Login/");
            }
            else
            {
                lblMessage.Text = "Error !!";
            }
        }

        ScriptManager.RegisterStartupScript(updatePnlNotificationForm, updatePnlNotificationForm.GetType(), "show", "$(function () { $('#modalForgotPassword').modal('hide'); setTimeout(function () { $('#" + pnlNotificationForm.ClientID + "').modal('show');}, 800); });", true);

        updatePnlNotificationForm.Update();
    }
}