using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.Admin.Product
{
    public partial class Index : System.Web.UI.Page
    {
        ProductController data = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienthi();
                HienthiSanPhamBanChay();
                HienthiSanPhamKhongBanDuoc();
            }
        }
        public void Hienthi()
        {
            grdDs.DataSource = data.DsProduct();
            DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                data.xoasp(m);
                Hienthi();
            }
        }
        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Models.Product product = data.layra1SP(m);
                Session["pr"] = product;
                Response.Redirect("Update.aspx");
            }
        }
        protected void BindGridView(List<Website_MyPham.Models.Product> products)
        {
            grdDs.DataSource = products;
            grdDs.DataBind();

            if (products.Count == 0)
            {
                pnlNoResults.Visible = true;
            }
            else
            {
                pnlNoResults.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            List<Website_MyPham.Models.Product> products = data.FindProduct(keyword);
            BindGridView(products);
        }
        protected void grdDs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grdDs.Rows.Count)
            {
                int productId = Convert.ToInt32(grdDs.DataKeys[e.RowIndex].Value);
                // Gọi phương thức xóa sản phẩm từ Controller
                data.xoasp(productId);
                Hienthi(); // Gọi lại phương thức binding dữ liệu sau khi xóa
            }
         }
        protected void grdDs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                // Lấy index của dòng đang được chọn
                int rowIndex = e.NewEditIndex;

                // Lấy product_id từ dòng được chọn
                int product_id = Convert.ToInt32(grdDs.DataKeys[rowIndex].Value);

                // Tạo một đối tượng ProductController
                ProductController productController = new ProductController();

                // Gọi phương thức trong ProductController để lấy thông tin sản phẩm
                Website_MyPham.Models.Product productToEdit = productController.layra1SP(product_id);

                // Kiểm tra xem sản phẩm có tồn tại không
                if (productToEdit != null)
                {
                    // Lưu thông tin sản phẩm vào Session để sử dụng trên trang Update.aspx
                    Session["pr"] = productToEdit;

                    // Chuyển hướng sang trang Update.aspx để sửa sản phẩm
                    Response.Redirect("~/View/Admin/Product/Update.aspx");
                }
                else
                {
                    // Xử lý khi không tìm thấy sản phẩm
                    Response.Write("Không tìm thấy sản phẩm để sửa.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                Response.Write("Lỗi: " + ex.Message);
            }
        }

        public void HienthiSanPhamBanChay()
        {
            // Lấy top 3 sản phẩm bán chạy
            List<Website_MyPham.Models.Product> topSellingProducts = data.GetTopSellingProducts(3); // Thay đổi số lượng top sản phẩm tại đây

            // Binding dữ liệu lên GridView
            grdTopSellingProducts.DataSource = topSellingProducts;
            grdTopSellingProducts.DataBind();
        }

        public void HienthiSanPhamKhongBanDuoc()
        {
            // Lấy top 3 sản phẩm không bán được (hoặc số lượng mong muốn)
            List<Website_MyPham.Models.Product> lowSellingProducts = data.GetLowSellingProducts(3); // Thay đổi số lượng top sản phẩm tại đây

            // Binding dữ liệu lên GridView
            grdLowSellingProducts.DataSource = lowSellingProducts;
            grdLowSellingProducts.DataBind();
        }

    }
}