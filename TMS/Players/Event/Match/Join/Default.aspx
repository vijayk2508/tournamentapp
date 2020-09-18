<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Player.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Players_Event_Match_Join_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Join
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            Rules:
                        </div>

                        <div class="col-lg-6">
                            <div role="form">
                                <div class="form-group">
                                    <label>Amount</label>
                                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" placeholder="Enter Amount"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer" style="background-color: white; height: 56px;">
                    <div class="text-right">
                        <asp:UpdatePanel ID="updateProceed" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnProceed" CssClass="btn btn-primary" Text="Proceed" runat="server" OnClientClick="this.disabled='true';this.value = 'Please Wait...';" OnClick="btnProceed_OnClick" UseSubmitBehavior="False" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%---------Modal-------%>
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
                            <div class="text-center">
                                <button type="button" class="close" data-dismiss="modal" aria-label="close">
                                    <span aria-hidden="true">OK</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <%---------Modal-------%>
</asp:Content>

