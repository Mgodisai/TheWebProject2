using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWebProject2.dstRecipeBookTableAdapters;

namespace TheWebProject2
{
    public partial class Login : System.Web.UI.Page
    {
        
        UsersTableAdapter uta = new UsersTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = uta.GetData(tbxEmail.Text, tbxPassword.Text);
                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('Successful login');</script>");
                    Session["email"] = dt.Rows[0][0].ToString();
                    Session["fullname"] = dt.Rows[0][2].ToString();
                    Session["role"] = "user";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid login');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
            Response.Redirect("Login.aspx");
        }
    }
}