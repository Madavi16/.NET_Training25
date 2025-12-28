using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricityBillWebApp.App_Code
{
    public class ElectricityBoard
    {
        DBHandler db = new DBHandler();

        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units <= 100)
                amount = 0;
            else if (units <= 300)
                amount = (units - 100) * 1.5;
            else if (units <= 600)
                amount = (200 * 1.5) + (units - 300) * 3.5;
            else if (units <= 1000)
                amount = (200 * 1.5) + (300 * 3.5) + (units - 600) * 5.5;
            else
                amount = (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (units - 1000) * 7.5;

            ebill.BillAmount = amount;
        }

        public void AddBill(ElectricityBill ebill)
        {
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO ElectricityBill VALUES (@cn,@name,@units,@bill)", con);

            cmd.Parameters.AddWithValue("@cn", ebill.ConsumerNumber);
            cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
            cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
            cmd.Parameters.AddWithValue("@bill", ebill.BillAmount);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            List<ElectricityBill> list = new List<ElectricityBill>();

            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(
                "SELECT TOP (@n) * FROM ElectricityBill ORDER BY consumer_number DESC", con);
            cmd.Parameters.AddWithValue("@n", n);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ElectricityBill eb = new ElectricityBill();
                eb.ConsumerNumber = dr[0].ToString();
                eb.ConsumerName = dr[1].ToString();
                eb.UnitsConsumed = Convert.ToInt32(dr[2]);
                eb.BillAmount = Convert.ToDouble(dr[3]);

                list.Add(eb);
            }

            con.Close();
            return list;
        }
    }
}