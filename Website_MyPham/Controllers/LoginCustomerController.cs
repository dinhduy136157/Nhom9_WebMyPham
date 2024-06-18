using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class LoginCustomerController
    {
        SqlConnection con;

        public LoginCustomerController()
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);

        }
        public Customer checkLogin(string email, string password)
        {
            con.Open();
            string sql = "SELECT customer_id, first_name, last_name, email, password, address, phone_number FROM Customer WHERE email = @Email AND password = @Password";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Customer customer = new Customer
                {
                    customer_id = (int)reader["customer_id"],
                    first_name = reader["first_name"].ToString(),
                    last_name = reader["last_name"].ToString(),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString(),
                    address = reader["address"].ToString(),
                    phone_number = reader["phone_number"].ToString(),
                };
                con.Close();
                return customer;
            }
            else
            {
                con.Close();
                return null;
            }
        }

    }
}
