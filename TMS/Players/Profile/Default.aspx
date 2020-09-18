<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Player.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Players_Profile_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Profile</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Edit Profile
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div role="form"> 
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Enter Name"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Enter email"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Mobile No</label>
                                    <asp:TextBox ID="txtMob" CssClass="form-control" runat="server" placeholder="Mobile" MaxLength="10" TextMode="Phone" ValidateRequestMode="Enabled"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Status</label>
                                    <asp:DropDownList ID="drpStatus" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Select" Value="None"></asp:ListItem>
                                        <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                        <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <div role="form">
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Enter Name"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Enter email"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Mobile No</label>
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Mobile" MaxLength="10" TextMode="Phone" ValidateRequestMode="Enabled"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Status</label>
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Select" Value="None"></asp:ListItem>
                                        <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                        <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="panel-footer" style="background-color: white">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnUpdate_OnClick" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

