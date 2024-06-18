using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MyPham.Models;


namespace Website_MyPham.Controllers
{
    public class CustomerController
    {
        SqlConnection con;

        public CustomerController()
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);

        }
        public List<Customer> takeFirstCustomer(int customer_id)
        {
            List<Customer> ds = new List<Customer>();
            string sql = "select * from Customer Where customer_id = @customer_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("customer_id", customer_id);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Customer customer = new Customer();
                customer.customer_id = (int)rd["customer_id"];
                customer.first_name = (string)rd["first_name"];
                customer.last_name = (string)rd["last_name"];
                customer.email = (string)rd["email"];
                customer.password = (string)rd["password"];
                customer.address = (string)rd["address"];
                customer.phone_number = (string)rd["phone_number"];
                ds.Add(customer);
            }
            con.Close();
            return ds;
        }
        public List<Customer> DsCustomer()
        {
            List<Customer> ds = new List<Customer>();
            string sql = "select * from Customer";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Customer customer = new Customer();
                customer.customer_id = (int)rd["customer_id"];
                customer.first_name = (string)rd["first_name"];
                customer.last_name = (string)rd["last_name"];
                customer.email = (string)rd["email"];
                customer.password = (string)rd["password"];
                customer.address = (string)rd["address"];
                customer.phone_number = (string)rd["phone_number"];
                ds.Add(customer);
            }
            con.Close();
            return ds;
        }
        public void AddCustomer(Customer customer)
        {
            con.Open();
            string sql = "insert into Customer values(@first_name,@last_name,@email,@password, @address, @phone_number)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("first_name", customer.first_name);
            cmd.Parameters.AddWithValue("last_name", customer.last_name);
            cmd.Parameters.AddWithValue("email", customer.email);
            cmd.Parameters.AddWithValue("password", customer.password);
            cmd.Parameters.AddWithValue("address", customer.address);
            cmd.Parameters.AddWithValue("phone_number", customer.phone_number);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void xoakh(int customer_id)
        {
            try
            {
                con.Open();
                string sql = "delete from customer where customer_id = @customer_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Xóa thành công
                    Console.WriteLine("Xóa khách hàng thành công");
                }
                else
                {
                    // Không có khách hàng nào được xóa
                    Console.WriteLine("Không tìm thấy khách hàng cần xóa");
                }
            }
            catch (Exception ex)
            {
                // Xảy ra lỗi khi xóa
                Console.WriteLine("Lỗi khi xóa khách hàng: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public Customer layra1KH(int customer_id)
        {
            List<Customer> ds = new List<Customer>();
            string sql = "select * from customer where customer_id=@customer_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("customer_id", customer_id);

            Customer c = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                c = new Customer();
                c.customer_id = (int)rd["customer_id"];
                c.first_name = (string)rd["first_name"];
                c.last_name = (string)rd["last_name"];
                c.email = (string)rd["email"];
                c.password = (string)rd["password"];
                c.address = (string)rd["address"];
                c.phone_number = (string)rd["phone_number"];
            }
            con.Close();
            return c;
        }
        public void capNhat(Customer c)
        {
            con.Open();
            string sql = "update Customer set first_name=@first_name, last_name=@last_name, email=@email, password=@password, address=@address, phone_number=@phone_number where customer_id=@customer_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@first_name", c.first_name);
            cmd.Parameters.AddWithValue("@last_name", c.last_name);
            cmd.Parameters.AddWithValue("@email", c.email);
            cmd.Parameters.AddWithValue("@password", c.password);
            cmd.Parameters.AddWithValue("@address", c.address);
            cmd.Parameters.AddWithValue("@phone_number", c.phone_number);
            cmd.Parameters.AddWithValue("@customer_id", c.customer_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
