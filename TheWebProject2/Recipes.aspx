<%@ Page Title="Recipe List" Language="C#" MasterPageFile="~/theWebProject.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Recipes.aspx.cs" Inherits="TheWebProject2.Recipes" MaintainScrollPositionOnPostback="true" %>

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
                                <h4>Recipe List</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col form-group">
                            <label for="ddlCategorySelector">Search by Category</label>
                            <asp:DropDownList ID="ddlCategorySelector" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategorySelector_SelectedIndexChanged">
                                <asp:ListItem Value="-1">Choose a category</asp:ListItem>
                            </asp:DropDownList>
                            <hr>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col form-group">
                            <label for="tbxSearchRecipeByName">Search by Name:</label>
                            <asp:TextBox ID="tbxSearchRecipeByName" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="tbxSearchRecipeByName_TextChanged"></asp:TextBox>

                            <hr>
                        </div>
                    </div>


                    <div class="row p-2">
                        <div class="col form-group" align="center">
                            <asp:Button ID="btnFullRecipeList" runat="server" Text="Reset List and Filters" CssClass="btn btn-primary" OnClick="btnFullRecipeList_Click" Width="80%" />
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="gvRecipes" runat="server" AllowPaging="True" EmptyDataText="Empty table" EnableSortingAndPagingCallbacks="True" HorizontalAlign="Center" OnPageIndexChanging="gvRecipes_PageIndexChanging" OnSorting="gvRecipes_Sorting" DataKeyNames="id" OnRowDataBound="gvRecipes_RowDataBound" OnSelectedIndexChanged="gvRecipes_SelectedIndexChanged" PageSize="15" OnSelectedIndexChanging="gvRecipes_SelectedIndexChanging" AutoGenerateColumns="False">
                                <PagerStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="id" ItemStyle-Width="15%" >
<ItemStyle Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Name" DataField="name" ItemStyle-Width="30%" >
<ItemStyle Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Description" DataField="description" ItemStyle-Width="40%" >
<ItemStyle Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Category" DataField="Category" ItemStyle-Width="30%" >
<ItemStyle Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <SelectedRowStyle BorderColor="#6699FF" BorderStyle="Double" BorderWidth="2pt" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>

            </div>
        </div>


        <div class="col-md-7">
            <asp:Panel ID="panelRecipeDetails" runat="server" Visible="false">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-md-12 pb-4">

                                <!--  <asp:TextBox CssClass="form-control" ID="tbxRecipeName" runat="server" placeholder="Ingredient Name"></asp:TextBox> -->
                                <asp:Label ID="lblRecipeName" CssClass="h3" runat="server"></asp:Label>

                            </div>

                            <div class="col-md-3 text-primary">
                                <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3 text-secondary">
                                <asp:Label ID="lblCal" runat="server" Text=""></asp:Label>
                            </div>


                            <div class="col-md-12 pb-2 pt-4">

                                <!-- <asp:TextBox CssClass="form-control" ID="tbxRecipeDescription" runat="server" placeholder="Description" TextMode="SingleLine"></asp:TextBox> -->
                                <asp:Label ID="lblRecipeDescription" CssClass="h6 text-muted" runat="server"></asp:Label>

                            </div>
                            <div class="col-md-12 mb-5">
                                <div class="form-group">

                                    <!-- <asp:TextBox CssClass="form-control" ID="tbxRecipeInstructions" runat="server" placeholder="Description" AutoPostBack="true" TextMode="MultiLine" Rows="10"></asp:TextBox>  -->
                                    <asp:Label ID="lblRecipeInstructions" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md">
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
                                            <div class="col">
                                                <asp:GridView class="table table-striped table-bordered" ID="gvRecipeIngredients" runat="server" AutoPostBack="true" AllowPaging="False" EmptyDataText="Empty table" HorizontalAlign="Center" GridLines="None" HeaderStyle-BorderStyle="NotSet" ShowHeader="False" AutoGenerateColumns="False">
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="a" DataField="Amount" ItemStyle-Width="15%" />
                                                        <asp:BoundField HeaderText="b" DataField="Unit" ItemStyle-Width="15%" />
                                                        <asp:BoundField HeaderText="c" DataField="Ingredient Name" ItemStyle-Width="25%" />
                                                        <asp:BoundField HeaderText="d" DataField="Descr" ItemStyle-Width="45%" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col pt-2 pb-4">
                                    <center>
                                        <asp:Image ID="imgRecipe" runat="server" Width="400" ImageUrl="~/images/rpics/default.jpg" />
                                    </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

    </div>
</asp:Content>
