using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class LoginEmployeeController
    {
        SqlConnection con;

        public LoginEmployeeController()
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);

        }
        public Employee checkLogin(string email, string password)
        {
            con.Open();
            string sql = "SELECT employee_id, fullName, avatar, address, birthDate, gender, phone, email, password FROM Employee WHERE email = @Email AND password = @Password";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Employee employee = new Employee
                {
                    employee_id = (int)reader["employee_id"],
                    fullName = reader["fullName"].ToString(),
                    avatar = reader["avatar"].ToString(),
                    address = reader["address"].ToString(),
                    birthDate = (DateTime)reader["birthDate"],
                    gender = reader["gender"].ToString(),
                    phone = reader["phone"].ToString(),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString()
                };
                con.Close();
                return employee;
            }
            else
            {
                con.Close();
                return null;
            }
        }
        
    }
}
