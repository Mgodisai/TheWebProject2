using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWebProject2.dstRecipeBookTableAdapters;

namespace TheWebProject2
{
    public partial class RecipeEditor : System.Web.UI.Page
    {
        RecipeTableAdapter recipeTableAdapter = new RecipeTableAdapter();
        CategoriesTableAdapter categoriesTableAdapter = new CategoriesTableAdapter();
        RecipeIngredientTableAdapter recipeIngredientTableAdapter = new RecipeIngredientTableAdapter();
        const int MAX = 1000;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ddlCategoryInput.DataSource = categoriesTableAdapter.GetDataToDDL();
                ddlCategoryInput.DataTextField = "name";
                ddlCategoryInput.DataValueField = "id";
                ddlCategoryInput.DataBind();
                tbxSearchRecipeByName.Text = "";

                gvRecipeEditor.DataSource = recipeTableAdapter.GetBaseData();
                gvRecipeEditor.DataBind();
                lblRecipeMessage.Text = "";
            }


            gvRecipeEditor.DataSource = recipeTableAdapter.GetBaseData();
            gvRecipeEditor.DataBind();
            lblRecipeMessage.Text = "";

        }

        protected void gvRecipeEditor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecipeEditor.PageIndex = e.NewPageIndex;
            //bindGridView();
        }


        protected void tbxSearchRecipeByName_TextChanged(object sender, EventArgs e)
        {
            if (tbxSearchRecipeByName.Text == "")
            {
                bindGridView();
            }
            else
            {
                gvRecipeEditor.DataSource = recipeTableAdapter.GetDataByNameOrDesc(tbxSearchRecipeByName.Text);
                gvRecipeEditor.DataBind();
            }
        }

        protected void gvRecipeEditor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvRecipeEditor.DataKeys[e.RowIndex].Value;
            try
            {
                recipeTableAdapter.DeleteQuery(id);
                lblRecipeMessage.Text = "Record, with id " + id + " has deleted!";
                bindGridView();
            }
            catch (Exception ex)
            {
                lblRecipeMessage.Text = "Record can't be deleted: " + ex.Message;
            }

        }
        private void bindGridView()
        {
            gvRecipeEditor.DataSource = recipeTableAdapter.GetBaseData();
            gvRecipeEditor.DataBind();
        }

        protected void btnRecipeGo_Click(object sender, EventArgs e)
        {

            DataTable dt = null;
            int idParsed = -1;
            string message = "";

            idParsed = RecipeFunctions.idValidator(tbxRecipeID.Text, MAX, out message);

            lblRecipeMessage.Text = message;

            if (idParsed < 0) return;

            dt = recipeTableAdapter.GetRecipeByID(idParsed);

            if (dt.Rows.Count != 0)
            {
                tbxRecipeID.Text = dt.Rows[0][0].ToString();
                tbxRecipeName.Text = dt.Rows[0][1].ToString();
                tbxRecipeDesc.Text = dt.Rows[0][2].ToString();
            }
            else
            {
                lblRecipeMessage.Text = "There is no record with this id!";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            populateRecipeDetails();
            lblRecipeMessage.Text = "";
            gvRecipeEditor.SelectedIndex = -1;
            tbxSearchRecipeByName.Text = "";
        }

        protected void btnRecipeAdd_Click(object sender, EventArgs e)
        {
            string name = tbxRecipeName.Text;
            string desc = tbxRecipeDesc.Text;
            string inst = tbxRecipeInst.Text;
            int hour = Int32.Parse(tbxHour.Text.Equals("") ? "0" : tbxHour.Text);
            int min = Int32.Parse(tbxMin.Text.Equals("") ? "0" : tbxMin.Text);
            int cal = Int32.Parse(tbxCalorie.Text.Equals("") ? "0" : tbxCalorie.Text);
            int catId = Int32.Parse(ddlCategoryInput.SelectedValue);

            if (name == "")
            {
                lblRecipeMessage.Text = "Please, at least enter a NAME of an ingredient!";
            }
            else
            {
                if (tbxRecipeID.Text != "")
                {
                    lblRecipeMessage.Text = "The entered ID has been ignored due to the auto-increment property of the ID field! ";
                }

                try
                {
                 recipeTableAdapter.InsertQueryWithoutIdandPic(
                 name: name,
                 inst: inst,
                 desc: desc,
                 cat_id: catId,
                 hour: hour,
                 min: min,
                 calorie: cal
                    );
                    bindGridView();
                    populateRecipeDetails();
                    lblRecipeMessage.Text = "";
                    gvRecipeEditor.SelectedIndex = -1;
                    tbxSearchRecipeByName.Text = "";
                } catch (Exception ex)
                {
                    lblRecipeMessage.Text += "Something went wrong!";
                }
            }
        }

        protected void btnRecipeUpdate_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";
            DataTable dt = null;

            idParsed = RecipeFunctions.idValidator(tbxRecipeID.Text, MAX, out message);

            string name = tbxRecipeName.Text;
            string desc = tbxRecipeDesc.Text;
            string inst = tbxRecipeInst.Text;
            int hour = Int32.Parse(tbxHour.Text.Equals("") ? "0" : tbxHour.Text);
            int min = Int32.Parse(tbxMin.Text.Equals("") ? "0" : tbxMin.Text);
            int cal = Int32.Parse(tbxCalorie.Text.Equals("") ? "0" : tbxCalorie.Text);
            int catId = Int32.Parse(ddlCategoryInput.SelectedValue);

            lblRecipeMessage.Text = message;

            if (idParsed < 0) return;

            if (!name.Equals(""))
            {
                dt = recipeTableAdapter.GetRecipeByID(idParsed);
            }

            if (dt.Rows.Count == 0)
            {
                lblRecipeMessage.Text = "This ID does not belong to an existing record, please use the add button!";
            }
            else
            {
                try
                {
                    recipeTableAdapter.UpdateQuery(
                    name: name,
                    inst: inst,
                    desc: desc,
                    catid: catId,
                    hour: hour,
                    min: min,
                    cal: cal,
                    original_id: idParsed
                    );
                    bindGridView();
                    populateRecipeDetails();
                    lblRecipeMessage.Text = "";
                    gvRecipeEditor.SelectedIndex = -1;
                    tbxSearchRecipeByName.Text = "";
                }
                catch (Exception ex)
                {
                    lblRecipeMessage.Text += "Something went wrong!";
                }

            }
        }

        protected void btnRecipeDelete_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";
            DataTable dt = null;

            idParsed = RecipeFunctions.idValidator(tbxRecipeID.Text, MAX, out message);

            lblRecipeMessage.Text = message;

            if (idParsed < 0) return;

            try
            {
                recipeTableAdapter.DeleteQuery(idParsed);
                lblRecipeMessage.Text = "Record, with id " + idParsed + " has deleted!";
                bindGridView();
            }
            catch (Exception ex)
            {
                lblRecipeMessage.Text = "Record can't be deleted: " + ex.Message;
            }
        }

        protected void gvRecipeEditor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='GreenYellow'; this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';this.style.textDecoration='none';";
                e.Row.ToolTip = "Click name for selecting a row.";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvRecipeEditor, "Select$" + (e.Row.RowIndex));


            }
        }

        protected void gvRecipeEditor_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //GridViewRow row = gvRecipeEditor.Rows[e.NewSelectedIndex];

            //lblRecipeMessage.Text = gvRecipeEditor.DataKeys[row.RowIndex].Value.ToString();
        }

        protected void gvRecipeEditor_SelectedIndexChanged(object sender, EventArgs e)
        {

            // the id of the selected Recipe
            int idParsed = Int32.Parse(gvRecipeEditor.SelectedRow.Cells[0].Text);

            // populate the ingredient list of the selected Recipe
            // DataTable td = recipeIngredientTableAdapter.GetDataByRecipeID(idParsed);
            //gvRecipeIngredients.DataSource = td;
            //gvRecipeIngredients.DataBind();

            //lblRecipeName.Text = HttpUtility.HtmlDecode(gvRecipes.SelectedRow.Cells[1].Text+" ("+gvRecipes.SelectedRow.Cells[3].Text + ")");
            //lblRecipeDescription.Text = HttpUtility.HtmlDecode(gvRecipes.SelectedRow.Cells[2].Text);

            // fill the labels with the data of the recipe
            DataTable tdRecipe = recipeTableAdapter.GetRecipeByID(idParsed);

            populateRecipeDetails(
                id: tdRecipe.Rows[0][0].ToString(),
                name: tdRecipe.Rows[0][1].ToString(),
                desc: tdRecipe.Rows[0][2].ToString(),
                inst: tdRecipe.Rows[0][4].ToString(),
                hour: tdRecipe.Rows[0][7].ToString(),
                min: tdRecipe.Rows[0][8].ToString(),
                cal: tdRecipe.Rows[0][9].ToString(),
                selectedValue: tdRecipe.Rows[0][5].ToString()

                );
        }

        private void populateDDL(string selectedValue)
        {
            ddlCategoryInput.DataSource = categoriesTableAdapter.GetDataToDDL();
            ddlCategoryInput.DataTextField = "name";
            ddlCategoryInput.DataValueField = "id";

            if (selectedValue.Equals(""))
            {
                ddlCategoryInput.SelectedIndex = 0;
            }
            else
            {
                ddlCategoryInput.SelectedValue = selectedValue;
            }
            ddlCategoryInput.DataBind();

        }

        private void populateRecipeDetails(string id = "", string name = "", string desc = "", string inst = "", string hour = "", string min = "", string cal = "", string selectedValue = "")
        {
            tbxRecipeID.Text = id;
            tbxRecipeName.Text = name;
            tbxRecipeDesc.Text = desc;
            tbxRecipeInst.Text = inst;
            tbxHour.Text = hour;
            tbxMin.Text = min;
            tbxCalorie.Text = cal;
            populateDDL(selectedValue);
        }
    }
}