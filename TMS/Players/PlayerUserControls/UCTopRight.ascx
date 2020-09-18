<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCTopRight.ascx.cs" Inherits="Players_PlayerUserControls_UCTopRight" %>
<ul class="nav navbar-top-links navbar-right">

    <li class="dropdown">
        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
            <i class="fa fa-user fa-fw"></i><i class="fa fa-caret-down"></i>
        </a>
        <ul class="dropdown-menu dropdown-user">
            <li>
                <asp:HyperLink ID="lnkProfile" runat="server">
                    <i class="fa fa-user fa-fw"></i>User Profile
                </asp:HyperLink> 
            </li>
            <li class="divider"></li>
            <li>
                <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_OnClick">
                    <i class="fa fa-sign-out fa-fw"></i>Logout
                </asp:LinkButton>
            </li>
        </ul>
        <!-- /.dropdown-user -->
    </li>
    <!-- /.dropdown -->
</ul>
<!-- /.navbar-top-links -->
