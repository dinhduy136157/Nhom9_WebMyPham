using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class ProductController
    {
        SqlConnection con;

        public ProductController()
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);

        }
        public List<Product> DsProduct()
        {
            List<Product> ds = new List<Product>();
            string sql = "select * from Product";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.product_id = (int)rd["product_id"];
                product.SKU = (string)rd["SKU"];
                product.description = (string)rd["description"];
                product.price = (decimal)rd["price"];
                product.stock = (int)rd["stock"];
                //product.Category_catego = (int)rd["Category_catego"];
                product.Category_catego = (int)rd["Category_catego"];
                product.image = (string)rd["image"];
                ds.Add(product);
            }
            con.Close();
            return ds;
        }
        public List<Product> DsBanChay()
        {
            List<Product> ds = new List<Product>();
            string sql = "WITH SalesCounts AS (\r\n    SELECT od.Product_prod, COUNT(*) AS SalesCount\r\n    FROM Order_Item od\r\n    GROUP BY od.Product_prod\r\n)\r\nSELECT p.product_id, p.SKU, p.image, p.price, sc.SalesCount\r\nFROM SalesCounts sc\r\nJOIN Product p ON sc.Product_prod = p.product_id\r\nORDER BY sc.SalesCount DESC;\r\n";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.product_id = (int)rd["product_id"];
                product.SKU = (string)rd["SKU"];
                product.price = (decimal)rd["price"];
                //product.Category_catego = (int)rd["Category_catego"];
                product.image = (string)rd["image"];
                ds.Add(product);
            }
            con.Close();
            return ds;
        }
        public List<Product> DsBanMoi()
        {
            List<Product> ds = new List<Product>();
            string sql = "SELECT * FROM Product\r\nORDER BY product_id DESC;";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.product_id = (int)rd["product_id"];
                product.SKU = (string)rd["SKU"];
                product.price = (decimal)rd["price"];
                //product.Category_catego = (int)rd["Category_catego"];
                product.image = (string)rd["image"];
                ds.Add(product);
            }
            con.Close();
            return ds;
        }
        public List<Product> ProductDetail(int product_id)
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";

            List<Product> ds = new List<Product>();
            string sql = "SELECT * FROM Product WHERE product_id = @product_id";

            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@product_id", product_id);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Product product = new Product
                    {
                        product_id = (int)rd["product_id"],
                        SKU = (string)rd["SKU"],
                        description = (string)rd["description"],
                        price = (decimal)rd["price"],
                        stock = (int)rd["stock"],
                        //Category_catego = (int)rd["Category_catego"],
                        Category_catego = (int)rd["Category_catego"],
                        image = (string)rd["image"]
                    };
                    ds.Add(product);
                }
            }
            return ds;
        }
        public List<Product> ProductCategory(int category_id)
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";

            List<Product> ds = new List<Product>();
            string sql = "SELECT * FROM Product WHERE Category_catego = @category_id";

            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@category_id", category_id);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Product product = new Product
                    {
                        product_id = (int)rd["product_id"],
                        SKU = (string)rd["SKU"],
                        description = (string)rd["description"],
                        price = (decimal)rd["price"],
                        stock = (int)rd["stock"],
                        //Category_catego = (int)rd["Category_catego"],
                        Category_catego = (int)rd["Category_catego"],
                        image = (string)rd["image"]
                    };
                    ds.Add(product);
                }
            }
            return ds;
        }
        public List<Product> FindProduct(string keyword = "")
        {
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";

            List<Product> ds = new List<Product>();
            string sql = "SELECT * FROM Product";
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " WHERE SKU LIKE @keyword";
            }

            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(keyword))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                }

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Product product = new Product
                    {
                        product_id = (int)rd["product_id"],
                        SKU = (string)rd["SKU"],
                        image = (string)rd["image"],
                        price = (decimal)rd["price"],
                        //Category_catego = (int)rd["Category_catego"],
                        Category_catego = (int)rd["Category_catego"],
                        stock = (int)rd["stock"],
                        description = (string)rd["description"]
                    };
                    ds.Add(product);
                }
            }
            return ds;
        }


        public void Addproduct(Product product)
        {

            con.Open();
            string sql = "insert into Product values(@SKU,@description,@price,@stock,@Category_catego,@image)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("SKU", product.SKU);
            cmd.Parameters.AddWithValue("description", product.description);
            cmd.Parameters.AddWithValue("price", product.price);
            cmd.Parameters.AddWithValue("stock", product.stock);
            cmd.Parameters.AddWithValue("Category_catego", product.Category_catego);
            cmd.Parameters.AddWithValue("image", product.image);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void xoasp(int product_id)
        {
            try
            {
                con.Open();
                string sql = "DELETE FROM Product WHERE product_id = @product_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@product_id", product_id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Xóa thành công
                    Console.WriteLine("Xóa sản phẩm thành công");
                }
                else
                {
                    // Không có khách hàng nào được xóa
                    Console.WriteLine("Không tìm thấy sản phẩm cần xóa");
                }
            }
            catch (Exception ex)
            {
                // Xảy ra lỗi khi xóa
                Console.WriteLine("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        //public Product layra1SP(int product_id)
        //{
        //    List<Product> ds = new List<Product>();
        //    string sql = "select * from Product where product_id=@product_id";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("product_id",product_id);

        //    Product c = null;
        //    SqlDataReader rd = cmd.ExecuteReader();
        //    if (rd.Read())
        //    {
        //        c = new Product();
        //        c.product_id = (int)rd["product_id"];
        //        c.SKU = (string)rd["SKU"];
        //        c.description = (string)rd["description"];
        //        c.price = (decimal)rd["price"];
        //        c.stock = (int)rd["stock"];
        //        c.CategoryId = (int)rd["CategoryId"];
        //        c.image = (string)rd["image"];
        //    }
        //    con.Close();
        //    return c;
        //}
        public Product layra1SP(int product_id)
        {
            Product c = null;
            string sql = "select * from Product where product_id=@product_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("product_id", product_id);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                c = new Product();
                c.product_id = (int)rd["product_id"];
                c.SKU = (string)rd["SKU"];
                c.description = (string)rd["description"];
                c.price = (decimal)rd["price"];
                c.stock = (int)rd["stock"];
                // Đảm bảo tên cột trong cơ sở dữ liệu khớp với tên trường trong mã C#
                c.Category_catego = (int)rd["Category_catego"]; // Đây là nơi sửa đổi tên cột
                c.image = (string)rd["image"];
            }
            con.Close();
            return c;
        }

        public void capNhat(Product c)
        {
            con.Open();
            string sql = "update Product set SKU=@SKU, description=@description, price=@price, stock=@stock, Category_catego=@Category_catego, image=@image where product_id=@product_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SKU", c.SKU);
            cmd.Parameters.AddWithValue("@description", c.description);
            cmd.Parameters.AddWithValue("@price", c.price);
            cmd.Parameters.AddWithValue("@stock", c.stock);
            cmd.Parameters.AddWithValue("@Category_catego", c.Category_catego);
            cmd.Parameters.AddWithValue("@image", c.image);
            cmd.Parameters.AddWithValue("@product_id", c.product_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private Product MapProductFromDataReader(SqlDataReader reader)
        {
            Product product = new Product
            {
                product_id = (int)reader["product_id"],
                SKU = (string)reader["SKU"],
                description = (string)reader["description"],
                price = (decimal)reader["price"],
                stock = (int)reader["stock"],
                Category_catego = (int)reader["Category_catego"],
                image = (string)reader["image"]
            };

            return product;
        }
        string connectionString = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";

        public List<Product> GetTopSellingProducts(int count)
        {
            List<Product> topProducts = new List<Product>();
            string sql = "SELECT TOP (@count) * FROM Product ORDER BY stock DESC"; // Sắp xếp theo số lượng bán giảm dần

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@count", count);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Product product = MapProductFromDataReader(rd);
                    topProducts.Add(product);
                }
            }

            return topProducts;
        }

        public List<Product> GetLowSellingProducts(int count)
        {
            List<Product> lowSellingProducts = new List<Product>();
            string sql = "SELECT TOP (@count) * FROM Product ORDER BY stock ASC"; // Sắp xếp theo số lượng tồn tăng dần

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@count", count);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Product product = MapProductFromDataReader(rd);
                    lowSellingProducts.Add(product);
                }
            }

            return lowSellingProducts;
        }


    }
}