using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace ElectricityProject
{
    public partial class AddBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");

            }
        }
        protected void btnCalculate_Click(object sender, EventArgs e)

        {

            string consumerNo = txtConsumerNo.Text;
            string consumerName = txtName.Text;

            int units;

            if (!int.TryParse(txtUnits.Text, out units))
            {
                lblResult.Text = "Please enter valid units";
                return;
            }

            decimal billAmount = CalculateBill(units);

            lblResult.Text =
                "Consumer No: " + consumerNo +
                "<br/>Name: " + consumerName +
                "<br/>Units: " + units +
                "<br/>Bill Amount: Rs." + billAmount;

            try
            {


                string connstr = ConfigurationManager.ConnectionStrings["EBConnection"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connstr))
                {

                    string query = $@"Insert into ElectricityBill(consumer_number,consumer_name,units_consumed,bill_amount)" +
                        "values(@cno,@cname,@units,@amount)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@cno", consumerNo);
                        cmd.Parameters.AddWithValue("@cname", consumerName);
                        cmd.Parameters.AddWithValue("@units", units);
                        cmd.Parameters.AddWithValue("@amount", billAmount);

                        con.Open();
                        cmd.ExecuteNonQuery();


                    }



                }
            }
            catch (Exception ex)
            {
                lblResult.Text += "<br/> Error Saving bill: " + ex.Message;
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(txtN.Text, out n))
            {
                lblResult.Text = "Enter a valid number";
                return;
            }

            try
            {



                string conn = ConfigurationManager.ConnectionStrings["EBConnection"].ConnectionString;

                using (SqlConnection con = new SqlConnection(conn))

                {

                    string query = $@"Select Top({n}) * from ElectricityBill order by consumer_number Desc";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@N", n);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            da.Fill(dt);
                            gvBills.DataSource = dt;
                            gvBills.DataBind();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error retrieving bills: " + ex.Message;
            }
        }

        private decimal CalculateBill(int units)
        {
            decimal amount = 0;

            if (units <= 100)
                amount = units * 1.5m;
            else if (units <= 300)
                amount = (100 * 1.5m) + ((units - 100) * 2.5m);
            else
                amount = (100 * 1.5m) + (200 * 2.5m) + ((units - 300) * 4m);



            return amount;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();      
            Session.Abandon();    

            Response.Redirect("Login.aspx");
        }
    }
}