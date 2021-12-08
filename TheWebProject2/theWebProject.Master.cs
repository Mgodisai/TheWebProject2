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
    }
}