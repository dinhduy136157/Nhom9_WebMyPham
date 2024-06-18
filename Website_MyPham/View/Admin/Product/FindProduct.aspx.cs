using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.Admin.Product
{
    public partial class FindProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Khởi tạo ProductController
                ProductController productController = new ProductController();

                // Hiển thị tất cả sản phẩm ban đầu
                DisplayProducts(productController.FindProduct());


            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm từ TextBox
            string keyword = txtKeyword.Text.Trim();

            // Khởi tạo ProductController
            ProductController productController = new ProductController();

            // Tìm kiếm sản phẩm dựa trên từ khóa và hiển thị kết quả
            DisplayProducts(productController.FindProduct(keyword));
        }

        //private void DisplayProducts(List<Product> products) 
        private void DisplayProducts(List<Website_MyPham.Models.Product> products)
        {
            // Xóa các mục hiện tại trên ListView
            lvProducts.Items.Clear();

            // Nếu không có sản phẩm nào được tìm thấy, hiển thị thông báo
            if (products.Count == 0)
            {
                lblMessage.Text = "Không tìm thấy sản phẩm phù hợp.";
                return;
            }

            // Hiển thị danh sách sản phẩm trên ListView
            lvProducts.DataSource = products;
            lvProducts.DataBind();
        }

    }
}