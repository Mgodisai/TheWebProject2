<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/theWebProject.Master" AutoEventWireup="true" CodeBehind="RecipeEditor.aspx.cs" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" Inherits="TheWebProject2.RecipeEditor" %>

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
                                <h4>Recipe Editor</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <label for="tbxSearchRecipeByName">Search by Name:</label>
                            <asp:TextBox ID="tbxSearchRecipeByName" class="form-control" runat="server" OnTextChanged="tbxSearchRecipeByName_TextChanged" TextMode="Search"></asp:TextBox>

                            <hr>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="gvRecipeEditor" runat="server" AllowPaging="True" EmptyDataText="Empty table" EnableSortingAndPagingCallbacks="True" HorizontalAlign="Center" OnPageIndexChanging="gvRecipeEditor_PageIndexChanging" OnRowDeleting="gvRecipeEditor_RowDeleting" DataKeyNames="id" EnablePersistedSelection="True" OnRowDataBound="gvRecipeEditor_RowDataBound" OnSelectedIndexChanged="gvRecipeEditor_SelectedIndexChanged" OnSelectedIndexChanging="gvRecipeEditor_SelectedIndexChanging" AutoGenerateColumns="False" PageSize="15">
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

                </div>

            </div>
        </div>

        <div class="col-md-6">

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
                                    <asp:Button class="btn btn-primary" ID="btnRecipeGo" type="button" runat="server" Text="Go" OnClick="btnRecipeGo_Click" CausesValidation="false" />
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
                                <asp:DropDownList ID="ddlCategoryInput" runat="server" Width="100%" CssClass="btn dropdown-toggle btn-outline-secondary" AutoPostBack="True">
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
                            <asp:Button ID="btnRecipeAdd" class="btn btn-md btn-block btn-success" runat="server" Text="Add" OnClick="btnRecipeAdd_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnRecipeUpdate" class="btn btn-md btn-block btn-warning" runat="server" Text="Update" OnClick="btnRecipeUpdate_Click" />
                        </div>
                        <div class="col-3" align="center">
                            <asp:Button ID="btnRecipeDelete" class="btn btn-md btn-block btn-danger" runat="server" Text="Delete" OnClick="btnRecipeDelete_Click" />
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
                                <asp:Label ID="lblRecipeMessage" runat="server" Text=""></asp:Label>
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
