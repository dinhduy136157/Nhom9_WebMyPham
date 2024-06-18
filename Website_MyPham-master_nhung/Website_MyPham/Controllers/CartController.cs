using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class CartController
    {
        SqlConnection con;

        public CartController()
        {
            string sqlCon = "Data Source=Nhung\\SQLEXPRESS;Initial Catalog=ptud;Integrated Security=True;Trust Server Certificate=True";
            con = new SqlConnection(sqlCon);

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
        public void AddOrders(Orders ord)
        {
            con.Open();
            string sql = "insert into Orders values(@order_date,@total_price,@Customer_custo,@Payment_payme, @Shipment_shipm)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("order_date", ord.order_date);
            cmd.Parameters.AddWithValue("total_price", ord.total_price);
            cmd.Parameters.AddWithValue("Customer_custo", ord.Customer_custo);
            cmd.Parameters.AddWithValue("Payment_payme", ord.Payment_payme);
            cmd.Parameters.AddWithValue("Shipment_shipm", ord.Shipmen_shipm);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddCartDetail(OrderItem ord)
        {
            con.Open();
            string sql = "insert into Order_Item values(@quantity,@price,@Product_prod,@Order_order_i, @status)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("quantity", ord.quantity);
            cmd.Parameters.AddWithValue("price", ord.price);
            cmd.Parameters.AddWithValue("Product_prod", ord.Product_prod);
            cmd.Parameters.AddWithValue("Order_order_i", ord.Order_order_i);
            cmd.Parameters.AddWithValue("status", "Chờ xác nhận");
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}