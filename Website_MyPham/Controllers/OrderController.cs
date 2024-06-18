using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class OrderController
    {
        SqlConnection con;

        public OrderController()
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);
        }

        public List<Orders> DsOrder()
        {
            List<Orders> ds = new List<Orders>();
            string sql = "SELECT order_id FROM Orders";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Orders order = new Orders()
                {
                    order_id = (int)rd["order_id"]
                };
                ds.Add(order);
            }
            con.Close();
            return ds;
        }
    }
}
