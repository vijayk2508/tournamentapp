<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SignUp_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RegistrationForm">
        <br>
        <span id="form-heading">
            <center><b>Registration Form </b></center>
        </span>
        <br>

        <asp:TextBox ID="txtName" placeholder="Name" runat="server" required="true"></asp:TextBox>

        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Address" required="true" TextMode="Email"></asp:TextBox>

        <asp:TextBox ID="txtMobileNo" runat="server" placeholder="Mobile No." TextMode="Phone" required="true"></asp:TextBox>

        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required="true"></asp:TextBox>

        <br>
        <div class="text-center">
            <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="pnlUpdate" runat="server">
                <ContentTemplate>
                    <asp:Button CssClass="btn btn-success place shake btna" runat="server" Text="Register" ID="btnSignUp" OnClick="btnSignUp_OnClick" OnClientClick="this.disabled='true';this.value = 'Please Wait...';" UseSubmitBehavior="False" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <br />
    </div>
    <asp:Panel ID="pnlNotificationForm" runat="server" class="modal fade"
        TabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <asp:UpdatePanel ID="updatePnlNotificationForm" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:Label ID="lblMessage" CssClass="form-control" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="close" data-dismiss="modal" aria-label="close">
                                <span aria-hidden="true">OK</span>
                            </button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

</asp:Content>

