using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssignmentWebApp
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedValue == "Laptop")
                imgProduct.ImageUrl = "~/Images/laptop.jpg";
            else if (ddlProducts.SelectedValue == "Mobile")
                imgProduct.ImageUrl = "~/Images/mobile.jpg";
            else if (ddlProducts.SelectedValue == "Tablet")
                imgProduct.ImageUrl = "~Images/tablet.jpg";
            else
                Console.WriteLine("No product Found"); 
        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            switch(ddlProducts.SelectedValue)
            {
                case "Laptop":
                    lblPrice.Text = "Price: Rs.60,000";
                    break;
                case "Mobile":
                    lblPrice.Text = "Price Rs.1,00,000";
                    break;
                case "Tablet":
                    lblPrice.Text = "Price Rs.1,50,000";
                    break;
                default:
                    lblPrice.Text = "Select a product";
                    break;
            }
        }
    }
}