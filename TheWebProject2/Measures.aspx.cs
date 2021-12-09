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
    public partial class Measures : System.Web.UI.Page
    {
        MeasureTableAdapter measureTableAdapter = new MeasureTableAdapter();
        const int MAX = 1000;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is null || Session["role"].Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            gvMu.DataSource = measureTableAdapter.GetData();
            gvMu.DataBind();
            lblMuMessage.Text = "";

        }

        protected void gvMu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMu.PageIndex = e.NewPageIndex;
            bindGridView();
        }

        private void bindGridView()
        {
            gvMu.DataSource = measureTableAdapter.GetData();
            gvMu.DataBind();
        }

        protected void btnMuGo_Click(object sender, EventArgs e)
        {

            DataTable dt = null;
            int idParsed = -1;
            string message = "";

            idParsed = RecipeFunctions.idValidator(tbxMuID.Text, MAX, out message);

            lblMuMessage.Text = message;

            if (idParsed < 0) return;

            dt = measureTableAdapter.GetDataById(idParsed);

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
                lblMuMessage.Text = "There is no record with this id!";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            setDetailsFileds();
            lblMuMessage.Text = "";
            gvMu.SelectedIndex = -1;
        }

        protected void btnMuAdd_Click(object sender, EventArgs e)
        {
            string name, desc;

            name = tbxMuName.Text;
            desc = tbxMuDesc.Text;
            if (name == "")
            {
                lblMuMessage.Text = "Please, at least enter a NAME of an Mu!";
            }
            else
            {
                if (tbxMuID.Text != "")
                {
                    lblMuMessage.Text = "The entered ID has been ignored due to the auto-increment property of the ID field! ";
                }

                measureTableAdapter.InsertQueryWithoutID(name, desc);
                bindGridView();
                lblMuMessage.Text = "OK!";
                setDetailsFileds();

            }
        }

        protected void btnMuUpdate_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";
            DataTable dt = null;

            idParsed = RecipeFunctions.idValidator(tbxMuID.Text, MAX, out message);

            string name = tbxMuName.Text;
            string desc = tbxMuDesc.Text;

            lblMuMessage.Text = message;

            if (idParsed < 0) return;

            if (!name.Equals(""))
            {
                dt = measureTableAdapter.GetDataById(idParsed);
            }

            if (dt.Rows.Count == 0)
            {
                lblMuMessage.Text = "This ID does not belong to an existing record, please use the add button!";
            }
            else
            {
                measureTableAdapter.UpdateQuery(name, desc, idParsed);
                bindGridView();
                lblMuMessage.Text = "OK!";
            }
        }

        protected void btnMuDelete_Click(object sender, EventArgs e)
        {
            int idParsed = -1;
            string message = "";

            idParsed = RecipeFunctions.idValidator(tbxMuID.Text, MAX, out message);

            lblMuMessage.Text = message;

            if (idParsed < 0) return;

            try
            {
                measureTableAdapter.DeleteQuery(idParsed);
                lblMuMessage.Text = "Record, with id " + idParsed + " has deleted!";
                bindGridView();
                setDetailsFileds();
            }
            catch (Exception ex)
            {
                lblMuMessage.Text = "Record can't be deleted: " + ex.Message;
            }
        }

        protected void gvMu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='GreenYellow'; this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';this.style.textDecoration='none';";
                e.Row.ToolTip = "Click name for selecting a row.";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvMu, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvMu_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvMu.Rows[e.NewSelectedIndex];

            lblMuMessage.Text = gvMu.DataKeys[row.RowIndex].Value.ToString();
        }

        protected void gvMu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idParsed = Int32.Parse(gvMu.SelectedDataKey.Value.ToString());
            DataTable tdMu = measureTableAdapter.GetDataById(idParsed);

            setDetailsFileds(
                id: tdMu.Rows[0][0].ToString(),
                name: tdMu.Rows[0][1].ToString(),
                desc: tdMu.Rows[0][2].ToString()
            );
        }

        protected void btnHideMessage_Click(object sender, EventArgs e)
        {

            panelMessage.Visible = !panelMessage.Visible;
        }

        private void setDetailsFileds(string id = "", string name = "", string desc = "")
        {
            tbxMuID.Text = id;
            tbxMuName.Text = name;
            tbxMuDesc.Text = desc;
        }
    }
}