<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/theWebProject.Master" AutoEventWireup="true" CodeBehind="RecipeEditor.aspx.cs" EnableEventValidation="false" Inherits="TheWebProject2.RecipeEditor" %>

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
                                <h4>Recipe Editor</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <label for="tbxSearchRecipeByName">Search by Name:</label>
                            <div class="input-group">
                                <asp:TextBox ID="tbxSearchRecipeByName" class="form-control" runat="server" OnTextChanged="tbxSearchRecipeByName_TextChanged" TextMode="Search"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" class="btn btn-outline-primary" Text="Search" UseSubmitBehavior="True" CausesValidation="false" />
                                <hr>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="gvRecipeEditor" runat="server" AllowPaging="True" EmptyDataText="Empty table" HorizontalAlign="Center" OnRowDeleting="gvRecipeEditor_RowDeleting" DataKeyNames="id" EnablePersistedSelection="True" OnRowDataBound="gvRecipeEditor_RowDataBound" OnSelectedIndexChanged="gvRecipeEditor_SelectedIndexChanged" AutoGenerateColumns="False" PageSize="15">
                            <PagerStyle HorizontalAlign="Center" />
                            <SelectedRowStyle BorderColor="#CC0099" BorderStyle="Solid" BorderWidth="2px" />
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
                            <asp:Button ID="btnSwap" class="btn btn-outline-primary" runat="server" Text="Change Details/Ingredients" OnClick="btnSwap_Click" UseSubmitBehavior="False" />
                        </center>
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
                            <asp:Label ID="lblRecipeMessage" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    <div class="col-md-7">
        <asp:Panel ID="panelDetails" runat="server" Visible="true">
            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Recipe Details</h4>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img class="img-fluid" width="200" src="images/recipe.jpg" />

                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 p-2">
                            <label>Recipe ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="tbxRecipeID" runat="server" placeholder="ID" TextMode="Number"></asp:TextBox>
                                    <asp:Button class="btn btn-primary" ID="btnRecipeGo" type="button" runat="server" Text="Go" OnClick="btnRecipeGo_Click" CausesValidation="false" UseSubmitBehavior="False" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 p-2">
                            <label>Recipe Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxRecipeName" runat="server" placeholder="Recipe Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 p-2">
                            <label>Recipe Category</label>
                            <div class="form-group">
                                <!--<asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Recipe Name"></asp:TextBox> -->
                                <asp:DropDownList ID="ddlCategoryInput" runat="server" Width="100%" CssClass="btn dropdown-toggle btn-outline-secondary" AutoPostBack="False">
                                    <asp:ListItem Value="-1">Choose a category</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12 p-2">
                            <label>Recipe Description</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxRecipeDesc" runat="server" placeholder="Description" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>
                        </div>


                        <div class="col-md-4 p-2">
                            <label>Hour</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxHour" runat="server" placeholder="Hour" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4 p-2">
                            <label>Min</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxMin" runat="server" placeholder="Min" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4 p-2">
                            <label>Calorie</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxCalorie" runat="server" placeholder="Calorie" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>



                        <div class="col-md-12 p-2">
                            <label>Recipe Instruction</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbxRecipeInst" runat="server" placeholder="Instructions" TextMode="MultiLine" Rows="10"></asp:TextBox>
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
                            <asp:Button ID="btnRecipeAdd" class="btn btn-md btn-block btn-success" runat="server" Text="Add" OnClick="btnRecipeAdd_Click" UseSubmitBehavior="False" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnRecipeUpdate" class="btn btn-md btn-block btn-warning" runat="server" Text="Update" OnClick="btnRecipeUpdate_Click" UseSubmitBehavior="False" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnRecipeDelete" class="btn btn-md btn-block btn-danger" runat="server" Text="Delete" OnClick="btnRecipeDelete_Click" UseSubmitBehavior="False" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnClear" class="btn btn-md btn-block btn-info" type="button" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" UseSubmitBehavior="False" />

                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="panelIngredients" runat="server" Visible="false">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col-md-12 pb-2">
                            <asp:Label ID="lblRecipeName" CssClass="h3" runat="server"></asp:Label>
                        </div>

                        <div class="col-md-12 pb-2">

                            <asp:Label ID="lblRecipeDescription" CssClass="h6 text-muted" runat="server"></asp:Label>

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
                                            <asp:GridView class="table table-striped table-bordered" ID="gvRecipeIngredients" runat="server" AutoPostBack="true" AllowPaging="False" EmptyDataText="Empty table" HorizontalAlign="Center" GridLines="None" HeaderStyle-BorderStyle="NotSet" ShowHeader="False" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" DataKeyNames="recipe_id,ingredient_id,measure_id" OnRowDeleting="gvRecipeIngredients_RowDeleting">
                                                <PagerStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="a" DataField="Amount" ItemStyle-Width="10%" />
                                                    <asp:BoundField HeaderText="b" DataField="Unit" ItemStyle-Width="10%" />
                                                    <asp:BoundField HeaderText="c" DataField="Ingredient Name" ItemStyle-Width="25%" />
                                                    <asp:BoundField HeaderText="d" DataField="Descr" ItemStyle-Width="45%" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>





                                    <div class="row p-2">
                                        <div class="col form-group">
                                            <label for="ddlCategorySelector">Ingredient</label>
                                            <asp:DropDownList ID="ddlIngredientSelector" runat="server" AutoPostBack="True" CssClass="btn-outline-secondary dropdown-toggle">
                                                <asp:ListItem Value="-1">Choose a category</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="row p-2">
                                        <div class="col form-group">
                                            <label for="ddlMuSelector">Measuring Unit</label>
                                            <asp:DropDownList ID="ddlMuSelector" runat="server" AutoPostBack="True" CssClass="btn-outline-secondary dropdown-toggle">
                                                <asp:ListItem Value="-1">Choose a category</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="row p-2">
                                        <div class="col form-group">
                                            <label for="tbxAmount">Amount</label>
                                            <asp:TextBox ID="tbxAmount" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                            <hr>
                                        </div>
                                    </div>
                                    <div class="row p-2">
                                        <div class="col form-group" align="center">
                                            <asp:Button ID="btnAddNewIngredient" runat="server" Text="Add" CssClass="btn btn-info" Width="80%" OnClick="btnAddNewIngredient_Click" />
                                            <hr>
                                        </div>
                                    </div>
                                    <div class="row p-2">
                                        <div class="col form-group" align="center">
                                            <asp:Button ID="btnDeleteAll" runat="server" Text="Delete All!" CssClass="btn btn-danger" Width="80%" OnClick="btnDeleteAll_Click" />
                                            <hr>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
        </div>
</asp:Content>
