using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWebProject2.dstRecipeBookTableAdapters;

namespace TheWebProject2
{

    public partial class Ingredients : System.Web.UI.Page
    {
        IngredientTableAdapter IngredientTableAdapter = new IngredientTableAdapter();
        const int MAX = 1000;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is null || Session["role"].Equals(""))
            {
                Response.Redirect("Login.aspx");
            }


            gvIngredients.DataSource = IngredientTableAdapter.GetData();
            gvIngredients.DataBind();
            lblIngredientMessage.Text = "";

        }

        protected void gvIngredients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIngredients.PageIndex = e.NewPageIndex;
            //bindGridView();
        }


        protected void tbxSearchIngredientByName_TextChanged(object sender, EventArgs e)
        {
            if (tbxSearchIngredientByName.Text == "")
            {
                bindGridView();
            }
            else
            {
                gvIngredients.DataSource = IngredientTableAdapter.GetDataByName(tbxSearchIngredientByName.Text);
                gvIngredients.DataBind();
            }
        }

        protected void gvIngredients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvIngredients.DataKeys[e.RowIndex].Value;
            try
            {
                IngredientTableAdapter.DeleteQuery(id);
                lblIngredientMessage.Text = "Record, with id " + id + " has deleted!";
                bindGridView();
            }
            catch (Exception ex)
            {
                lblIngredientMessage.Text = "Record can't be deleted: " + ex.Message;
            }

        }
        private void bindGridView()
        {
            gvIngredients.DataSource = IngredientTableAdapter.GetData();
            gvIngredients.DataBind();
        }

        protected void btnIngredientGo_Click(object sender, EventArgs e)
        {

            DataTable dt = null;
            int idParsed = -1;
            string message = "";

            idParsed = RecipeFunctions.idValidator(tbxIngredientID.Text, MAX, out message);

            lblIngredientMessage.Text = message;

            if (idParsed < 0) return;

            dt = IngredientTableAdapter.GetDataById(idParsed);

            if (dt.Rows.Count != 0)
            {
                tbxIngredientID.Text = dt.Rows[0][0].ToString();
                tbxIngredientName.Text = dt.Rows[0][1].ToString();
                tbxIngredientDesc.Text = dt.Rows[0][2].ToString();
            }
            else
            {
                lblIngredientMessage.Text = "There is no record with this id!";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbxIngredientID.Text = "";
            tbxIngredientName.Text = "";
            tbxIngredientDesc.Text = "";
            lblIngredientMessage.Text = "";
            gvIngredients.SelectedIndex = -1;
        }

        protected void btnIngredientsAdd_Click(object sender, EventArgs e)
        {
            string name, desc;

            name = tbxIngredientName.Text;
            desc = tbxIngredientDesc.Text;
            if (name == "")
            {
                lblIngredientMessage.Text = "Please, at least enter a NAME of an ingredient!";
            }
            else
            {
                if (tbxIngredientID.Text != "")
                {
                    lblIngredientMessage.Text = "The entered ID has been ignored due to the auto-increment property of the ID field! ";
                }

                IngredientTableAdapter.InsertQueryWithoutID(name, desc);
                bindGridView();
                lblIngredientMessage.Text += "OK!";

                tbxIngredientName.Text = "";
                tbxIngredientDesc.Text = "";
                tbxIngredientID.Text = "";

            }
        }

        protected void btnIngredientsUpdate_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";
            DataTable dt=null;

            idParsed = RecipeFunctions.idValidator(tbxIngredientID.Text, MAX, out message);

            string name = tbxIngredientName.Text;
            string desc = tbxIngredientDesc.Text;

            lblIngredientMessage.Text = message;

            if (idParsed < 0) return;

            if (!name.Equals(""))
            {
                dt = IngredientTableAdapter.GetDataById(idParsed);
            }

            if (dt.Rows.Count == 0)
            {
                lblIngredientMessage.Text = "This ID does not belong to an existing record, please use the add button!";
            }
            else
            {
                IngredientTableAdapter.UpdateQuery(name, desc, idParsed);
                bindGridView();
                lblIngredientMessage.Text += "OK!";
                tbxIngredientName.Text = "";
                tbxIngredientDesc.Text = "";
                tbxIngredientID.Text = "";
            }
        }

        protected void btnIngredientsDelete_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";
            DataTable dt = null;

            idParsed = RecipeFunctions.idValidator(tbxIngredientID.Text, MAX, out message);

            lblIngredientMessage.Text = message;

            if (idParsed < 0) return;

            try
            {
                IngredientTableAdapter.DeleteQuery(idParsed);
                lblIngredientMessage.Text = "Record, with id " + idParsed + " has deleted!";
                bindGridView();
            }
            catch (Exception ex)
            {
                lblIngredientMessage.Text = "Record can't be deleted: " + ex.Message;
            }
        }

        protected void gvIngredients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {       
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='GreenYellow'; this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';this.style.textDecoration='none';";
                e.Row.ToolTip = "Click name for selecting a row.";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvIngredients, "Select$" + (e.Row.RowIndex));

                
            }
        }

        protected void gvIngredients_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvIngredients.Rows[e.NewSelectedIndex];
            
            lblIngredientMessage.Text = gvIngredients.DataKeys[row.RowIndex].Value.ToString();
        }

        protected void gvIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxIngredientID.Text = HttpUtility.HtmlDecode(gvIngredients.SelectedRow.Cells[0].Text);
            tbxIngredientName.Text = HttpUtility.HtmlDecode(gvIngredients.SelectedRow.Cells[1].Text);
            tbxIngredientDesc.Text = HttpUtility.HtmlDecode(gvIngredients.SelectedRow.Cells[2].Text);
        }
    }
}