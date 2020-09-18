<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Player.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Players_Event_Match_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <h1 class="page-header" style="margin-top: 10px; text-align: center">Join Match</h1>
        <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatePnlEvent" runat="server">
            <ContentTemplate>
                <div class="flex-repeater">
                    <asp:Repeater ID="rptMatch" OnItemDataBound="rptMatch_OnItemDataBound" runat="server">
                        <ItemTemplate>
                            <div class="flex-repeater-item">
                                <div class="col-sm-12 col-md-12">
                                    <div class="EventBox">
                                        <asp:HiddenField ID="hdnMatchID" runat="server" />
                                        <div class="img" style="margin-top: -56px; width: 262px; height: 262px; margin-top: 0px;">
                                            <asp:Image ID="imgMatch" class="img-event" runat="server" />
                                        </div>
                                        <div class="Title">
                                            <i class="fa fa-flag Orange_textColor" style="font-size: 16px; margin-right: 5px;"></i>
                                            <asp:Label ID="lblMatchTitle" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <div class="btn btn-block">
                                            <asp:HyperLink ID="lnkJoin" CssClass="btn btn-success place shake btna" Text="Join" runat="server" OnClientClick="this.disabled='true';this.value = 'Please Wait...';" UseSubmitBehavior="False" />
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
    <script type='text/javascript'>
        $(document).on('hidden.bs.modal', function (e) {
            $('#modalEventRegistered .modal-body input,.modal-body textarea').each(function () {
                $(this).val('');
            });
        });

        $("input[type='submit']").on('click', function (e) {
            $("#notification").css('display', block);
        });
    </script>
</asp:Content>

