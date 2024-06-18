using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class CategoryController
    {
        SqlConnection con;

        public CategoryController()
        {
            string sqlCon = "Data Source=Nhung\\SQLEXPRESS;Initial Catalog=ptud;Integrated Security=True";
            con = new SqlConnection(sqlCon);

        }
        public List<Category> DsCategory()
        {
            List<Category> ds = new List<Category>();
            string sql = "select * from Category";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category category = new Category();
                category.category_id = (int)rd["category_id"];
                category.name = (string)rd["name"];
                //category.product_id = (int)rd["product_id"];
                ds.Add(category);
            }
            con.Close();
            return ds;
        }
        //them
        public void AddCategory(Category category)
        {
            con.Open();
            string sql = "insert into Category values(@name,@product_id)";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("category_id", category.category_id);
            cmd.Parameters.AddWithValue("name", category.name);
            //cmd.Parameters.AddWithValue("product_id", category.product_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //xoa

        public void DeleteCategory(int category_id)
        {
            // Xóa các sản phẩm liên quan đến loại này trước
            DeleteProductsByCategory(category_id);

            // Sau đó xóa loại
            con.Open();
            string sql = "delete from Category where category_id=@category_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("category_id", category_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Phương thức xóa các sản phẩm thuộc về một loại
        private void DeleteProductsByCategory(int category_id)
        {
            // Xóa các dòng trong bảng Cart liên quan đến các sản phẩm thuộc loại này
            con.Open();
            string deleteCartSql = "delete from Cart where Product_product_id in (select product_id from Product where Category_catego=@category_id)";
            SqlCommand deleteCartCmd = new SqlCommand(deleteCartSql, con);
            deleteCartCmd.Parameters.AddWithValue("category_id", category_id);
            deleteCartCmd.ExecuteNonQuery();
            con.Close();

            // Xóa các sản phẩm thuộc loại này
            con.Open();
            string deleteProductsSql = "delete from Product where Category_catego=@category_id";
            SqlCommand deleteProductsCmd = new SqlCommand(deleteProductsSql, con);
            deleteProductsCmd.Parameters.AddWithValue("category_id", category_id);
            deleteProductsCmd.ExecuteNonQuery();
            con.Close();
        }



        //lay ma de sua
        public Category layma(int category_id)
        {
            string sql = "select * from Category where category_id=@category_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("category_id", category_id);
            Category category = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                category = new Category();
                category.category_id = (int)rd["category_id"];
                category.name = (string)rd["name"];
                //category.product_id = (int)rd["product_id"];
            }
            con.Close();
            return category;
        }
        ////sua
        public void UpdateCategory(Category category)
        {
            con.Open();
            string sql = "update Category set name=@name where category_id=@category_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("category_id", category.category_id);
            cmd.Parameters.AddWithValue("name", category.name);
            
            //cmd.Parameters.AddWithValue("product_id", category.product_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}