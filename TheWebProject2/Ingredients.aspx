<%@ Page Title="" Language="C#" MasterPageFile="~/theWebProject.Master" AutoEventWireup="true" CodeBehind="Ingredients.aspx.cs" EnableEventValidation="false" Inherits="TheWebProject2.Ingredients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div class="row p-4">
        <div class="col-md-6">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Ingredient List</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <label for="tbxSearchIngredientByName">Search by Name:</label>
                            <div class="input-group">
                                <asp:TextBox ID="tbxSearchIngredientByName" class="form-control" runat="server" OnTextChanged="tbxSearchIngredientByName_TextChanged" TextMode="Search"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" class="btn btn-outline-primary" Text="Search" UseSubmitBehavior="True" CausesValidation="false" />
                                <hr>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="gvIngredients" runat="server" AllowPaging="True" EmptyDataText="Empty table" EnableSortingAndPagingCallbacks="True" HorizontalAlign="Center" OnPageIndexChanging="gvIngredients_PageIndexChanging" DataKeyNames="id" EnablePersistedSelection="True" OnRowDataBound="gvIngredients_RowDataBound" OnSelectedIndexChanged="gvIngredients_SelectedIndexChanged" OnSelectedIndexChanging="gvIngredients_SelectedIndexChanging">
                                <PagerStyle HorizontalAlign="Center" />
                                <SelectedRowStyle BorderColor="#CC0099" BorderStyle="Solid" BorderWidth="2px" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>

            </div>
        </div>

        <div class="col-md-6">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Ingredient Details</h4>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img class="img-fluid" width="200" src="images/ingredients.jpg" />

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
                            <label>Ingredient ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="tbxIngredientID" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-primary" ID="btnIngredientGo" type="button" runat="server" Text="Go" OnClick="btnIngredientGo_Click" CausesValidation="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>Ingredient Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxIngredientName" runat="server" placeholder="Ingredient Name"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-12">
                            <label>Ingredient Description</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxIngredientDesc" runat="server" placeholder="Description" TextMode="MultiLine" Rows="5"></asp:TextBox>

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
                            <asp:Button ID="btnIngredientsAdd" class="btn btn-md btn-block btn-success" runat="server" Text="Add" OnClick="btnIngredientsAdd_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnIngredientsUpdate" class="btn btn-md btn-block btn-warning" runat="server" Text="Update" OnClick="btnIngredientsUpdate_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnIngredientsDelete" class="btn btn-md btn-block btn-danger" runat="server" Text="Delete" OnClick="btnIngredientsDelete_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnClear" class="btn btn-md btn-block btn-info" type="button" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />

                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <label>Messages:</label>
                            <div class="form-groups small">
                                <asp:Label ID="lblIngredientMessage" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
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
