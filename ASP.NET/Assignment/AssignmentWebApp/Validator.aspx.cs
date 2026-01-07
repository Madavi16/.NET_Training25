using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace AssignmentWebApp
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if(txtName.Text==txtFamily.Text)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Name and Family name must be different";
                return;
            }
            else
            {
                lblResult.ForeColor=System.Drawing.Color.Green;
                lblResult.Text = "All Validations passed successfully!";
            }
        }
    }
}