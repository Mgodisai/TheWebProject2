<%@ Page Title="" Language="C#" MasterPageFile="~/theWebProject.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheWebProject2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row m-4">
            <div class="col-md-6 mx-auto">
                <div class="card m-6">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="../Images/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Email</label>
                                <div class="form-group d-grid">
                                    <asp:TextBox CssClass="form-control" ID="tbxEmail" runat="server" placeholder="Email"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong email" ControlToValidate="tbxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is missing!" ControlToValidate="tbxEmail"></asp:RequiredFieldValidator></div>
                                <label>Password</label>
                                <div class="form-group d-grid">
                                    <asp:TextBox CssClass="form-control" ID="tbxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is missing" ControlToValidate="tbxPassword"></asp:RequiredFieldValidator>
                                </div>
                               
                               <div class="form-group d-grid">
                           <asp:Button class="btn btn-primary btn-lg" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
