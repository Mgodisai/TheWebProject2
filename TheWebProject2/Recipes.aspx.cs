using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWebProject2.dstRecipeBookTableAdapters;

namespace TheWebProject2
{
    public partial class Recipes : System.Web.UI.Page
    {
        const string recipePicPath = "~/images/rpics/";

        RecipeTableAdapter recipeTableAdapter = new RecipeTableAdapter();
        CategoriesTableAdapter categoriesTableAdapter = new CategoriesTableAdapter();
        RecipeIngredientTableAdapter recipeIngredientTableAdapter = new RecipeIngredientTableAdapter();
        static bool isFilteredByText=false;
        static bool isFilteredByDDL=false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is null || Session["role"].Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            if (!this.IsPostBack)
            {
                ddlCategorySelector.DataSource = categoriesTableAdapter.GetDataToDDL();
                ddlCategorySelector.DataTextField = "name";
                ddlCategorySelector.DataValueField = "id";
                ddlCategorySelector.SelectedIndex = -1;
                ddlCategorySelector.DataBind();


                gvRecipes.DataSource = recipeTableAdapter.GetBaseData();
                gvRecipes.DataBind();
                gvRecipes.SelectedIndex = -1;
                tbxSearchRecipeByName.Text = "";
                gvRecipeIngredients.DataSource = recipeIngredientTableAdapter.GetDataByRecipeID(-1);
                gvRecipeIngredients.DataBind();
            }


        }
    

        protected void ddlCategorySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = Int32.Parse(ddlCategorySelector.SelectedValue);

            if (selectedID == -1)
            {
                if (isFilteredByText)
                {
                    gvRecipes.DataSource = recipeTableAdapter.GetDataByNameOrDesc(tbxSearchRecipeByName.Text);
                } else
                {
                    gvRecipes.DataSource = recipeTableAdapter.GetBaseData();
                }
                gvRecipes.DataBind();    
                isFilteredByDDL = false;
            }
            else
            {
                if (isFilteredByText)
                {
                    gvRecipes.DataSource = recipeTableAdapter.GetDataByNameOrDescAndCat(tbxSearchRecipeByName.Text, selectedID);
                } else
                {
                    gvRecipes.DataSource = recipeTableAdapter.GetDataByCategories(selectedID);
                }
                isFilteredByDDL = true;
                gvRecipes.DataBind();
            }
            panelRecipeDetails.Visible = false;
        }

        protected void gvRecipes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='GreenYellow'; this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';this.style.textDecoration='none';";
                e.Row.ToolTip = "Click for selecting a row.";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvRecipes, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // the id of the selected Recipe
            int idParsed = Int32.Parse(gvRecipes.SelectedDataKey.Value.ToString());
            // populate the ingredient list of the selected Recipe
            DataTable td = recipeIngredientTableAdapter.GetDataByRecipeID(idParsed);
            gvRecipeIngredients.DataSource = td;
            gvRecipeIngredients.DataBind();

            //lblRecipeName.Text = HttpUtility.HtmlDecode(gvRecipes.SelectedRow.Cells[1].Text+" ("+gvRecipes.SelectedRow.Cells[3].Text + ")");
            //lblRecipeDescription.Text = HttpUtility.HtmlDecode(gvRecipes.SelectedRow.Cells[2].Text);

            // fill the labels with the data of the recipe
            DataTable tdRecipe = recipeTableAdapter.GetRecipeByID(idParsed);
            lblRecipeName.Text = tdRecipe.Rows[0][1].ToString()+" ("+ tdRecipe.Rows[0][3].ToString()+")";
            lblRecipeDescription.Text = tdRecipe.Rows[0][2].ToString();
            lblRecipeInstructions.Text = tdRecipe.Rows[0][4].ToString();

            string timeHour = tdRecipe.Rows[0][7].ToString();
            string timeMin = tdRecipe.Rows[0][8].ToString();
            string timeFull;

            if (timeHour is null || timeHour.Equals(""))
            {
                timeFull = timeMin + " min.";
            } else
            {
                timeFull = timeHour + " h and " + timeMin + " min.";
            }


            lblTime.Text = timeFull;
            lblCal.Text = tdRecipe.Rows[0][9].ToString()+" kcal/100g";

            string recipePicFileName = tdRecipe.Rows[0][6].ToString();

            if (recipePicFileName is null || recipePicFileName.Equals(""))
            {
                recipePicFileName = "default.jpg";
            }

            if (File.Exists(Server.MapPath(recipePicPath + recipePicFileName)))
            {
                imgRecipe.ImageUrl = recipePicPath + recipePicFileName;
            }
            else
            {
                imgRecipe.ImageUrl = recipePicPath + "default.jpg";
            }
            panelRecipeDetails.Visible = true;

            gvRecipeIngredients.DataSource = recipeIngredientTableAdapter.GetDataByRecipeID(idParsed);
            gvRecipeIngredients.DataBind();
        }

        protected void gvRecipes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            // GridViewRow row = gvRecipes.Rows[e.NewSelectedIndex];
            // gvRecipeIngredients.DataSource = recipeIngredientTableAdapter.GetDataByRecipeID((int)gvRecipes.DataKeys[row.RowIndex].Value);
            // gvRecipeIngredients.DataBind();
        }

        protected void tbxSearchRecipeByName_TextChanged(object sender, EventArgs e)
        {
            panelRecipeDetails.Visible = false;
            if (tbxSearchRecipeByName.Text == "")
            {
                if (isFilteredByDDL)
                {
                    gvRecipes.DataSource = recipeTableAdapter.GetDataByCategories(Int32.Parse(ddlCategorySelector.SelectedValue));
                } else
                {
                    gvRecipes.DataSource = recipeTableAdapter.GetBaseData();
                }
                isFilteredByText = false;
                gvRecipes.DataBind();
            }
            else
            {
                if (isFilteredByDDL)
                {
                    gvRecipes.DataSource = recipeTableAdapter.GetDataByNameOrDescAndCat(tbxSearchRecipeByName.Text, Int32.Parse(ddlCategorySelector.SelectedValue));
                    Debug.WriteLine(Int32.Parse(ddlCategorySelector.SelectedValue));
                } else
                {
                    DataTable dt = recipeTableAdapter.GetDataByNameOrDesc(tbxSearchRecipeByName.Text);
                    gvRecipes.DataSource = dt;

                }
                
                gvRecipes.DataBind();
                isFilteredByText = true;
            }
        }

        protected void btnFullRecipeList_Click(object sender, EventArgs e)
        {
            gvRecipes.DataSource = recipeTableAdapter.GetBaseData();
            gvRecipes.DataBind();
            ddlCategorySelector.SelectedIndex = -1;
            tbxSearchRecipeByName.Text = "";
            panelRecipeDetails.Visible = false;
            gvRecipes.SelectedIndex = -1;
            gvRecipes.PageIndex = 0;
            isFilteredByText = false;
            isFilteredByDDL = false;
        }

        protected void gvRecipes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Debug.WriteLine(e.NewPageIndex);
            gvRecipes.PageIndex = e.NewPageIndex;

            if (isFilteredByDDL&&isFilteredByDDL)
            {
                gvRecipes.DataSource = recipeTableAdapter.GetDataByNameOrDescAndCat(tbxSearchRecipeByName.Text, Int32.Parse(ddlCategorySelector.SelectedValue));
            } else if (isFilteredByDDL)
            {
                gvRecipes.DataSource = recipeTableAdapter.GetDataByCategories(Int32.Parse(ddlCategorySelector.SelectedValue));
            } else if (isFilteredByText)
            {
               gvRecipes.DataSource = recipeTableAdapter.GetDataByNameOrDesc(tbxSearchRecipeByName.Text);
            } else
            {
                gvRecipes.DataSource = recipeTableAdapter.GetBaseData();
            }
            gvRecipes.DataBind();
        }
    }
}