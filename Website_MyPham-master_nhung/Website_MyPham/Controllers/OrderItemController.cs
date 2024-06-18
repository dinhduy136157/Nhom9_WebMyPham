using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
   
    public class OrderItemController
    {
        SqlConnection con;

        public OrderItemController()
        {
            string sqlCon = "Data Source=Nhung\\SQLEXPRESS;Initial Catalog=ptud;Integrated Security=True;Trust Server Certificate=True";
            con = new SqlConnection(sqlCon);

        }
        public List<OrderItem> DsOrderItem()
        {
            List<OrderItem> ds = new List<OrderItem>();
            string sql = "select Order_Item.order_item_id, Customer.first_name, Customer.last_name, Customer.phone_number, Product.SKU, Order_Item.quantity, Orders.total_price, Order_Item.status from Order_Item\r\nJOIN Product ON Order_Item.Product_prod = Product.product_id\r\nJOIN Orders ON Order_Item.Order_order_i = Orders.order_id\r\nJOIN Customer ON Orders.Customer_custo = Customer.customer_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                OrderItem ot = new OrderItem();
                ot.order_item_id = (int)rd["order_item_id"];
                ot.Customer = new Customer()
                {
                    first_name = rd["first_name"].ToString(),
                    last_name = rd["last_name"].ToString(),
                    phone_number = rd["phone_number"].ToString()
                };
                ot.Product = new Product()
                {
                    SKU = rd["SKU"].ToString(),
                };
                ot.quantity = (int)rd["quantity"];
                ot.Orders = new Orders()
                {
                    total_price = (decimal)rd["total_price"]
                };
                ot.status = rd["status"].ToString();
                ds.Add(ot);
            }
            con.Close();
            return ds;
        }
    }
}