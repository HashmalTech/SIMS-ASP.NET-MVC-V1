using BLL_SIMS;
using BOL_SIMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMS
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly BLLSIMS ss = new BLLSIMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblusername.Text = "username";
            lblpassword.Text = "password";
            BtnLogin.Text = "Login";
            lblvalid.Visible = false;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            TBL_account[] login = ss.Logins(txtusername.Text, txtpassword.Text);
            if (login.Count() > 0)
            {
                if (login[0].userstatus == "1")
                {
                    Session["username"] = login[0].username;
                    Session["userrole"] = login[0].password;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblvalid.Visible = true;
                    lblvalid.Text = "Please Contact Administrator";
                }
            }
            else
            {
                lblvalid.Visible = true;
                lblvalid.Text = "Wrong username or password";
            }
        }
    }
}