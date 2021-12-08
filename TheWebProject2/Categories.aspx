<%@ Page Title="" Language="C#" MasterPageFile="~/theWebProject.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" EnableEventValidation="false" Inherits="TheWebProject2.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div class="row p-4">
        <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Recipe Categories</h4>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="gvCat" runat="server" AllowPaging="True" EmptyDataText="Empty table" EnableSortingAndPagingCallbacks="True" HorizontalAlign="Center" OnPageIndexChanging="gvCat_PageIndexChanging" OnRowDeleting="gvCat_RowDeleting" DataKeyNames="id" EnablePersistedSelection="True" OnRowDataBound="gvCat_RowDataBound" OnSelectedIndexChanged="gvCat_SelectedIndexChanged" OnSelectedIndexChanging="gvCat_SelectedIndexChanging" AutoGenerateColumns="False">
                                <PagerStyle HorizontalAlign="Center" />
                                <SelectedRowStyle BorderColor="#FA8072" BorderStyle="Solid" BorderWidth="2px" />
                                <Columns>
                                     <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-Width="10%" />
                                     <asp:BoundField HeaderText="Name" DataField="name" ItemStyle-Width="45%" />
                                     <asp:BoundField HeaderText="Description" DataField="description" ItemStyle-Width="45%" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col p-4">
                            <center>
                                <asp:Button ID="btnHideMessage" class="btn btn-outline-primary" runat="server" Text="Hide/Show Message panel" OnClick="btnHideMessage_Click" />
                            </center>
                        </div>
                    </div>

                </div>

            </div>
        </div>

        <div class="col-md-7">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Category details</h4>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img class="img-fluid" width="200" src="images/category.jpg" />

                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <label>Category ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="tbxCatID" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-primary" ID="btnCatGo" type="button" runat="server" Text="Go" OnClick="btnCatGo_Click" CausesValidation="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>Category Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxCatName" runat="server" placeholder="Category Name"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-12">
                            <label>Category Description</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxCatDesc" runat="server" placeholder="Description" TextMode="MultiLine" Rows="3"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row w-100">
                        <div class="col-3" align="center">
                            <asp:Button ID="btnCatAdd" class="btn btn-md btn-block btn-success" runat="server" Text="Add" OnClick="btnCatAdd_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnCatUpdate" class="btn btn-md btn-block btn-warning" runat="server" Text="Update" OnClick="btnCatUpdate_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnCatDelete" class="btn btn-md btn-block btn-danger" runat="server" Text="Delete" OnClick="btnCatDelete_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnClear" class="btn btn-md btn-block btn-info" type="button" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />

                        </div>
                    </div>
                     <asp:Panel ID="panelMessage" runat="server">
                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>
                   
                        <div class="row">
                            <div class="col-sm-12">
                                <label>Messages:</label>
                                <div class="form-groups small">
                                    <asp:Label ID="lblCatMessage" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
