using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class CartController
    {
        SqlConnection con;
        string connectionString = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
        public CartController()
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);

        }
        public List<Cart> DsCart(int customerId)
        {
            List<Cart> ds = new List<Cart>();
            string sql = "SELECT product_id, SKU, image, quantity, price from Cart\r\nJOIN Product ON Cart.Product_product_id = Product.product_id\r\nWHERE Customer_customer_id = @customer_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("customer_id", customerId);

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Cart cart = new Cart();
                cart.Product = new Product()
                {
                    product_id = (int)rd["product_id"],
                    SKU = rd["SKU"].ToString(),
                    image = rd["image"].ToString(),
                    price = (decimal)rd["price"],
                };
                cart.quantity = (int)rd["quantity"];
                cart.totalPrice = cart.Product.price * Convert.ToInt32(rd["quantity"]);
                ds.Add(cart);
            }
            con.Close();
            return ds;
        }
        public void AddCart(int product_id, int customer_id, int quantity)
        {
            con.Open();
            string sql = "insert into Cart values(@quantity,@Customer_customer_id,@Product_product_id)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("quantity", quantity);
            cmd.Parameters.AddWithValue("Customer_customer_id", customer_id);
            cmd.Parameters.AddWithValue("Product_product_id", product_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ClearCart(int customer_id)
        {
            con.Open();
            string sql = "DELETE FROM Cart WHERE Customer_customer_id = @customer_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("customer_id", customer_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int AddOrder(decimal total_price, int Customer_custo)
        {
            con.Open();
            string sql = "INSERT INTO Orders (order_date, total_price, Customer_custo, Payment_payme, Shipment_shipm) " +
                         "VALUES (@order_date, @total_price, @Customer_custo, @Payment_payme, @Shipment_shipm); " +
                         "SELECT SCOPE_IDENTITY();"; // Sử dụng SCOPE_IDENTITY() để lấy ID vừa insert

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@order_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@Customer_custo", Customer_custo);
            cmd.Parameters.AddWithValue("@Payment_payme", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipment_shipm", DBNull.Value);

            // Thực thi câu lệnh và lấy ID của đơn hàng vừa insert
            int orderId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            return orderId;
        }

        public void AddOrderDetail(int quantity, decimal price, int Product_prod, int Order_order_i)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "INSERT INTO Order_Item (quantity, price, Product_prod, Order_order_i, status) VALUES (@quantity, @price, @Product_prod, @Order_order_i, @status)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@Product_prod", Product_prod);
                        cmd.Parameters.AddWithValue("@Order_order_i", Order_order_i);
                        cmd.Parameters.AddWithValue("@status", DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine("Lỗi khi thêm chi tiết đơn hàng: " + ex.Message);
            }
        }



    }
}