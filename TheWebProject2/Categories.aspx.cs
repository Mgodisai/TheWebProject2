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
    public partial class Categories : System.Web.UI.Page
    {
        CategoriesTableAdapter categoriesTableAdapter = new CategoriesTableAdapter();
        const int MAX = 1000;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is null || Session["role"].Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            gvCat.DataSource = categoriesTableAdapter.GetData();
            gvCat.DataBind();
            lblCatMessage.Text = "";
        }

        protected void gvCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCat.PageIndex = e.NewPageIndex;
            bindGridView();
        }

        private void bindGridView()
        {
            gvCat.DataSource = categoriesTableAdapter.GetData();
            gvCat.DataBind();
        }

        protected void btnCatGo_Click(object sender, EventArgs e)
        {

            DataTable dt = null;
            int idParsed = -1;
            string message = "";

            idParsed = RecipeFunctions.idValidator(tbxCatID.Text, MAX, out message);

            lblCatMessage.Text = message;

            if (idParsed < 0) return;

            dt = categoriesTableAdapter.GetDataById(idParsed);

            if (dt.Rows.Count != 0)
            {
                setDetailsFileds(
                    id: dt.Rows[0][0].ToString(),
                    name: dt.Rows[0][1].ToString(),
                    desc: dt.Rows[0][2].ToString()
                    );
            }
            else
            {
                lblCatMessage.Text = "There is no record with this id!";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            setDetailsFileds();
            lblCatMessage.Text = "";
            gvCat.SelectedIndex = -1;
        }

        protected void btnCatAdd_Click(object sender, EventArgs e)
        {
            string name, desc;

            name = tbxCatName.Text;
            desc = tbxCatDesc.Text;
            if (name == "")
            {
                lblCatMessage.Text = "Please, at least enter a NAME of an Mu!";
            }
            else
            {
                if (tbxCatID.Text != "")
                {
                    lblCatMessage.Text = "The entered ID has been ignored due to the auto-increment property of the ID field! ";
                }

                categoriesTableAdapter.InsertQueryWithoutID(name, desc);
                bindGridView();
                lblCatMessage.Text = "OK!";

                setDetailsFileds();
            }
        }

        protected void btnCatUpdate_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";
            DataTable dt = null;

            idParsed = RecipeFunctions.idValidator(tbxCatID.Text, MAX, out message);

            string name = tbxCatName.Text;
            string desc = tbxCatDesc.Text;

            lblCatMessage.Text = message;

            if (idParsed < 0) return;

            if (!name.Equals(""))
            {
                dt = categoriesTableAdapter.GetDataById(idParsed);
            }

            if (dt.Rows.Count == 0)
            {
                lblCatMessage.Text = "This ID does not belong to an existing record, please use the add button!";
            }
            else
            {
                categoriesTableAdapter.UpdateQuery(name, desc, idParsed);
                bindGridView();
                lblCatMessage.Text = "OK!";
            }
        }

        protected void btnCatDelete_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";

            idParsed = RecipeFunctions.idValidator(tbxCatID.Text, MAX, out message);

            lblCatMessage.Text = message;

            if (idParsed < 0) return;

            try
            {
                categoriesTableAdapter.DeleteQuery(idParsed);
                lblCatMessage.Text = "Record, with id " + idParsed + " has deleted!";
                bindGridView();
                setDetailsFileds();
            }
            catch (Exception ex)
            {
                lblCatMessage.Text = "Record can't be deleted: " + ex.Message;
            }
        }

        protected void gvCat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='GreenYellow'; this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';this.style.textDecoration='none';";
                e.Row.ToolTip = "Click name for selecting a row.";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvCat, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvCat_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvCat.Rows[e.NewSelectedIndex];
            lblCatMessage.Text = gvCat.DataKeys[row.RowIndex].Value.ToString();
        }

        protected void gvCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idParsed = Int32.Parse(gvCat.SelectedDataKey.Value.ToString());
            DataTable tdCategories = categoriesTableAdapter.GetDataById(idParsed);

            setDetailsFileds(
                id: tdCategories.Rows[0][0].ToString(),
                name: tdCategories.Rows[0][1].ToString(),
                desc: tdCategories.Rows[0][2].ToString()
                );
        }

        protected void btnHideMessage_Click(object sender, EventArgs e)
        {
            panelMessage.Visible = !panelMessage.Visible;
        }

        private void setDetailsFileds(string id="", string name="", string desc = "")
        {
            tbxCatID.Text = id;
            tbxCatName.Text = name;
            tbxCatDesc.Text = desc;
            
        }
    }
}