using System;
using System.Collections.Generic;
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
            string sqlCon = "Data Source=Nhung\\SQLEXPRESS;Initial Catalog=ptud;Integrated Security=True;Trust Server Certificate=True";
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
                product.CategoryId = (int)rd["Category_catego"];
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
                        CategoryId = (int)rd["Category_catego"],
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
                        CategoryId = (int)rd["Category_catego"],
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
                        CategoryId = (int)rd["Category_catego"],
                        stock = (int)rd["stock"],
                        description = (string)rd["description"]
                    };
                    ds.Add(product);
                }
            }
            return ds;
        }

        //---------CHỈNH LẠI CODE
        //public void AddEmployee(Employee nv)
        //{
        //    con.Open();
        //    string sql = "insert into Employee values(@fullName,@avatar,@address,@birthDate, @gender, @phone, @email, @password)";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("fullName", nv.fullName);
        //    cmd.Parameters.AddWithValue("avatar", nv.avatar);
        //    cmd.Parameters.AddWithValue("address", nv.address);
        //    cmd.Parameters.AddWithValue("birthDate", nv.birthDate);
        //    cmd.Parameters.AddWithValue("gender", nv.gender);
        //    cmd.Parameters.AddWithValue("phone", nv.phone);
        //    cmd.Parameters.AddWithValue("email", nv.email);
        //    cmd.Parameters.AddWithValue("password", nv.password);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

    }
}