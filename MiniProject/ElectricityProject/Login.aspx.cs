using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ElectricityProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (username == "Madavi" && password == "67845")
            {
                Session["user"] = username;

                Response.Redirect("AddBill.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid Username or Password";
            }
        }
    }
}