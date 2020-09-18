using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Web;

public partial class Players_Profile_Default : TMSPlayerPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtEmail.Text = CurrentPlayer.Player_Email;
            txtName.Text= CurrentPlayer.Player_Name;
        } 
    }

    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        
    }
}