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
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);

        }
        public List<OrderItem> DsOrderItem()
        {
            List<OrderItem> ds = new List<OrderItem>();
            string sql = "select Order_Item.order_item_id, Product.image, Customer.first_name, Customer.last_name, Customer.phone_number, Product.SKU, Order_Item.quantity, Orders.total_price, Order_Item.status from Order_Item\r\nJOIN Product ON Order_Item.Product_prod = Product.product_id\r\nJOIN Orders ON Order_Item.Order_order_i = Orders.order_id\r\nJOIN Customer ON Orders.Customer_custo = Customer.customer_id";
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
                    image = rd["image"].ToString(),

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
        public List<OrderItem> firstOrderItem(int customer_id)
        {
            List<OrderItem> ds = new List<OrderItem>();
            string sql = "\r\nselect Order_Item.order_item_id, Customer.first_name, Customer.address, Customer.last_name, Customer.phone_number, " +
                "Product.image, Product.price, Product.SKU, Order_Item.quantity,\r\nOrders.total_price, Order_Item.status from Order_Item\r\nJOIN Product ON " +
                "Order_Item.Product_prod = Product.product_id\r\nJOIN Orders ON Order_Item.Order_order_i = Orders.order_id\r\nJOIN " +
                "Customer ON Orders.Customer_custo = Customer.customer_id\r\nWhere Customer.customer_id = @customer_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                OrderItem ot = new OrderItem();
                ot.order_item_id = (int)rd["order_item_id"];
                ot.Customer = new Customer()
                {
                    first_name = rd["first_name"].ToString(),
                    last_name = rd["last_name"].ToString(),
                    phone_number = rd["phone_number"].ToString(),
                    address = rd["address"].ToString()
                };
                ot.Product = new Product()
                {
                    SKU = rd["SKU"].ToString(),
                    image = rd["image"].ToString(),
                    price = (decimal)rd["price"],

                };
                ot.quantity = (int)rd["quantity"];
                ot.Orders = new Orders()
                {
                    total_price = (decimal)rd["total_price"],
                };
                ot.status = rd["status"].ToString();
                ds.Add(ot);
            }
            con.Close();
            return ds;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            string sql = @"INSERT INTO Order_Item (quantity, price, Product_prod, Order_order_i, status)
                           VALUES (@quantity, @price, @Product_prod, @Order_order_i, @status)";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@quantity", orderItem.quantity);
                cmd.Parameters.AddWithValue("@price", orderItem.price);
                cmd.Parameters.AddWithValue("@Product_prod", orderItem.Product_prod);
                cmd.Parameters.AddWithValue("@Order_order_i", orderItem.Order_order_i);
                cmd.Parameters.AddWithValue("@status", orderItem.status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void xoadh(int order_item_id)
        {
            try
            {
                con.Open();
                string sql = "delete from Order_item where order_item_id = @order_item_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@order_item_id", order_item_id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Xóa thành công
                    Console.WriteLine("Xóa đơn hàng thành công");
                }
                else
                {
                    // Không có khách hàng nào được xóa
                    Console.WriteLine("Không tìm thấy đơn hàng cần xóa");
                }
            }
            catch (Exception ex)
            {
                // Xảy ra lỗi khi xóa
                Console.WriteLine("Lỗi khi xóa đơn hàng: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public OrderItem layra1DH(int order_item_id)
        {
            OrderItem orderItem = null;
            string sql = @"SELECT Order_Item.order_item_id, 
                          Order_Item.quantity, 
                          Order_Item.price, 
                          Order_Item.status,
                          Product.SKU, 
                          Orders.total_price, 
                          Customer.first_name, 
                          Customer.last_name, 
                          Customer.phone_number
                   FROM Order_Item
                   JOIN Product ON Order_Item.Product_prod = Product.product_id
                   JOIN Orders ON Order_Item.Order_order_i = Orders.order_id
                   JOIN Customer ON Orders.Customer_custo = Customer.customer_id
                   WHERE Order_Item.order_item_id = @order_item_id";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@order_item_id", order_item_id);
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                orderItem = new OrderItem();
                orderItem.order_item_id = (int)rd["order_item_id"];
                orderItem.quantity = (int)rd["quantity"];
                orderItem.price = (decimal)rd["price"];
                orderItem.status = rd["status"].ToString();
                orderItem.Product = new Product()
                {
                    SKU = rd["SKU"].ToString(),
                };
                orderItem.Orders = new Orders()
                {
                    total_price = (decimal)rd["total_price"]
                };
                orderItem.Customer = new Customer()
                {
                    first_name = rd["first_name"].ToString(),
                    last_name = rd["last_name"].ToString(),
                    phone_number = rd["phone_number"].ToString()
                };
            }

            con.Close();
            return orderItem;
        }


        public void capNhatOrderItem(OrderItem orderItem)
        {
            try
            {
                con.Open();
                string sql = @"UPDATE Order_Item 
               SET quantity = @quantity, 
                   price = @price, 
                   status = @status 
               WHERE order_item_id = @order_item_id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@quantity", orderItem.quantity);
                cmd.Parameters.AddWithValue("@price", orderItem.price);
                cmd.Parameters.AddWithValue("@status", orderItem.status);
                cmd.Parameters.AddWithValue("@order_item_id", orderItem.order_item_id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Cập nhật đơn hàng thành công");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy đơn hàng cần cập nhật");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật đơn hàng: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateOrderStatus(int order_item_id, string newStatus)
        {
            string sql = "UPDATE Order_Item SET status = @Status WHERE order_item_id = @order_item_id";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@order_item_id", order_item_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<DailyOrderStatistics> GetDailyOrderStatistics()
        {
            List<DailyOrderStatistics> statistics = new List<DailyOrderStatistics>();
            string sql = @"SELECT 
                            CAST(Orders.order_date AS DATE) AS OrderDate, 
                            COUNT(*) AS OrderCount, 
                            SUM(Order_Item.price * Order_Item.quantity) AS TotalRevenue 
                           FROM Orders 
                           JOIN Order_Item ON Orders.order_id = Order_Item.Order_order_i
                           GROUP BY CAST(Orders.order_date AS DATE)
                           ORDER BY OrderDate";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DailyOrderStatistics stat = new DailyOrderStatistics
                    {
                        OrderDate = (DateTime)rd["OrderDate"],
                        OrderCount = (int)rd["OrderCount"],
                        TotalRevenue = (decimal)rd["TotalRevenue"]
                    };
                    statistics.Add(stat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thống kê ngày: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return statistics;
        }

        public List<MonthlyOrderStatistics> GetMonthlyOrderStatistics()
        {
            List<MonthlyOrderStatistics> statistics = new List<MonthlyOrderStatistics>();
            string sql = @"SELECT 
                            YEAR(Orders.order_date) AS OrderYear, 
                            MONTH(Orders.order_date) AS OrderMonth, 
                            COUNT(*) AS OrderCount, 
                            SUM(Order_Item.price * Order_Item.quantity) AS TotalRevenue 
                           FROM Orders 
                           JOIN Order_Item ON Orders.order_id = Order_Item.Order_order_i
                           GROUP BY YEAR(Orders.order_date), MONTH(Orders.order_date)
                           ORDER BY OrderYear, OrderMonth";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    MonthlyOrderStatistics stat = new MonthlyOrderStatistics
                    {
                        OrderYear = (int)rd["OrderYear"],
                        OrderMonth = (int)rd["OrderMonth"],
                        OrderCount = (int)rd["OrderCount"],
                        TotalRevenue = (decimal)rd["TotalRevenue"]
                    };
                    statistics.Add(stat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thống kê tháng: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return statistics;
        }

        public List<YearlyOrderStatistics> GetYearlyOrderStatistics()
        {
            List<YearlyOrderStatistics> statistics = new List<YearlyOrderStatistics>();
            string sql = @"SELECT 
                            YEAR(Orders.order_date) AS OrderYear, 
                            COUNT(*) AS OrderCount, 
                            SUM(Order_Item.price * Order_Item.quantity) AS TotalRevenue 
                           FROM Orders 
                           JOIN Order_Item ON Orders.order_id = Order_Item.Order_order_i
                           GROUP BY YEAR(Orders.order_date)
                           ORDER BY OrderYear";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    YearlyOrderStatistics stat = new YearlyOrderStatistics
                    {
                        OrderYear = (int)rd["OrderYear"],
                        OrderCount = (int)rd["OrderCount"],
                        TotalRevenue = (decimal)rd["TotalRevenue"]
                    };
                    statistics.Add(stat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thống kê năm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return statistics;
        }

    }
}