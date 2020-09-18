<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #note {
            z-index: 101;
            right: 0;
            background: #fde073;
            text-align: center;
            line-height: 2.5;
            overflow: hidden;
            -webkit-box-shadow: 0 0 5px black;
            -moz-box-shadow: 0 0 5px black;
            box-shadow: 0 0 5px black;
        }

        @-webkit-keyframes slideDown {
            0%, 100% {
                -webkit-transform: translateY(-50px);
            }

            10%, 90% {
                -webkit-transform: translateY(0px);
            }
        }

        @-moz-keyframes slideDown {
            0%, 100% {
                -moz-transform: translateY(-50px);
            }

            10%, 90% {
                -moz-transform: translateY(0px);
            }
        }

        .cssanimations.csstransforms #note {
            -webkit-transform: translateY(-50px);
            -webkit-animation: slideDown 2.5s 1.0s 1 ease forwards;
            -moz-transform: translateY(-50px);
            -moz-animation: slideDown 2.5s 1.0s 1 ease forwards;
        }

        .cssanimations.csstransforms #close {
            display: none;
        }
    </style>
    <div class="loginform">
        <br>
        <span id="form-heading">
            <center><b>Login</b></center>
        </span>
        <br>
        <asp:TextBox ID="txtEmail" placeholder="Email" runat="server" required="true"></asp:TextBox>

        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required="true"></asp:TextBox>

        <div class="text-center">
            <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="pnlUpdate" runat="server">
                <ContentTemplate>
                    <asp:Button CssClass="btn btn-success place shake btna" runat="server" Text="Login" ID="btnLogin" OnClick="btnLogin_OnClick" OnClientClick="this.disabled='true';this.value = 'Please Wait...';" UseSubmitBehavior="False" Style="width: 100%;" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalForgotPassword" data-backdrop="static" data-keyboard="false">
                Forgot Password
            </button>
        </div>
        <br>
        <br>
    </div>

    <!-- Forgot Password -->
    <div class="modal fade" id="modalForgotPassword" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="Email" class="col-form-label">
                            Email Address:</label>
                        <asp:TextBox ID="txtEmailAddress" CssClass="form-control" runat="server" Style="margin-left: 0;"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            <asp:Button ID="btnForgotPassword" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnForgotPassword_OnClick" OnClientClick="this.disabled='true';this.value = 'Please Wait...';" UseSubmitBehavior="False" Style="width: 14%; margin-top: 0;" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
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
    <script type="text/javascript">
        $(document).on('hidden.bs.modal', function (e) {
            $('#modalForgotPassword .modal-body input').each(function () {
                $(this).val('');
            });
        });
    </script>

    <div id="note" style="background-color: orangered; height: 50px; width: 25%; position: fixed; bottom: 0px; right: 0; margin-bottom: 8px; margin-right: 0px; display: none">
        You smell good. <a id="close">close</a>
    </div>
    <%--<script type='text/javascript'>
        $("input[type='button']").on('click', function (e) {
            $("#notification").css('display', block);
        });
    </script>--%>
    <script>
        close = document.getElementById("close");
        close.addEventListener('click', function () {
            note = document.getElementById("note");
            note.style.display = 'none';
        }, false);
    </script>
</asp:Content>

