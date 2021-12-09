using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheWebProject2
{
    public partial class theWebProject : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] is null || Session["role"].Equals(""))
                {
                    lbtLogin.Visible = true;
                    lbtLogout.Visible = false;
                    lbtCategories.Visible = false;
                    lbtMeasures.Visible = false;
                    lbtIngredients.Visible = false;
                    lbtRecipes.Visible = false;
                    lbtRecipeEditor.Visible = false;
                    lbtHome.Visible = false;
                    siteMapMain.Visible = false;
                    lbtLogout.Text = "Logout";
                    panelMenuHider.Visible = false;
                    
                }
                else
                {
                    lbtLogin.Visible = false; 
                    lbtLogout.Visible = true; 
                    lbtLogout.Text = "Logout (" + Session["fullname"] + ")";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void LbtIngredients_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingredients.aspx");
        }

        protected void LbtHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void LbtRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recipes.aspx");
        }

        protected void LbtMeasures_Click(object sender, EventArgs e)
        {
            Response.Redirect("Measures.aspx");
        }

        protected void lbtRecipeEditor_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecipeEditor.aspx");
        }

        protected void lbtCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }

        protected void lbtLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            Session["email"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            lbtLogin.Visible = true;
            lbtLogout.Visible = false;

            Response.Redirect("Default.aspx");
        }
    }
}