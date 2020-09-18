<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Player.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Players_Event_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <h1 class="page-header" style="margin-top: 10px; text-align: center">Join Tournament</h1>
        <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatePnlEvent" runat="server">
            <ContentTemplate>
                <div class="flex-repeater">
                    <asp:Repeater ID="rptEvent" OnItemDataBound="rptEvent_OnItemDataBound" runat="server">
                        <ItemTemplate>
                            <div class="flex-repeater-item">
                                <div class="col-sm-12 col-md-12">
                                    <div class="EventBox">
                                        <asp:HiddenField ID="hdnEventID" runat="server" />
                                        <div class="img" style="margin-top: -56px; width: 262px; height: 262px; margin-top: 0px;">
                                            <asp:Image ID="imgEvent" class="img-event" runat="server" />
                                        </div>
                                        <div class="Title">
                                            <i class="fa fa-flag Orange_textColor" style="font-size: 16px; margin-right: 5px;"></i>
                                            <asp:Label ID="lblEventName" runat="server" Text="Label"></asp:Label>

                                            <asp:HyperLink ID="hypLnkViewMatch" runat="server" CssClass="pull-right" Visible="False" Style="text-decoration: none !important;">
                                                <i class="fa fa-eye" aria-hidden="true" style="color:green"></i>
                                                View & Join Match
                                            </asp:HyperLink>
                                        </div>
                                        <div class="btn btn-block">
                                            <asp:Button ID="btnRegister" CssClass="btn btn-success place shake btna" Text="Register" runat="server" OnClick="btnRegister_OnClick" OnClientClick="this.disabled='true';this.value = 'Please Wait...';" UseSubmitBehavior="False" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%---------Modal-------%>

    <asp:Panel ID="pnlEventRegistered" class="modal fade"
        TabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" runat="server" data-backdrop="static" data-keyboard="false">
        <div id="modalEventRegistered" class="modal-dialog" role="document">
            <asp:UpdatePanel ID="updatePnlEventRegistered" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:HiddenField ID="hdnEventRegisterID" runat="server" />

                            <h5 class="modal-title" id="exampleModalLabel">Registeration Form :
                            <asp:Label ID="lblTitleEventName" runat="server" />
                            </h5>
                            <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>--%>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label for="username" class="col-form-label">
                                    Your Registered Username:</label>
                                <asp:TextBox ID="txtRegisteredUsername" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnEventRegister" runat="server" Text="Submit" CssClass="btn btn-success place shake btna" OnClick="btnEventRegister_OnClick" OnClientClick="this.disabled='true';this.value = 'Please Wait...';" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

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
                            <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                            <button type="button" class="close" data-dismiss="modal" aria-label="close">
                                <span aria-hidden="true">OK</span>
                            </button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <script type='text/javascript'>
        $(document).on('hidden.bs.modal', function (e) {
            $('#modalEventRegistered .modal-body input,.modal-body textarea').each(function () {
                $(this).val('');
            });
        });
    </script>
</asp:Content>

