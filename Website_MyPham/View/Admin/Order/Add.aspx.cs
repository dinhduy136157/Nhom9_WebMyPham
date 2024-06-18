
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models;

namespace Website_MyPham.View.Admin.Order
{
    public partial class Add : System.Web.UI.Page
    {
        private OrderItemController orderItemController = new OrderItemController();
        private ProductController productController = new ProductController();
        private OrderController orderController = new OrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductDropDownList();
                LoadOrderDropDownList(); // Gọi hàm tải DropDownList mã đơn hàng
            }
        }

        private void LoadProductDropDownList()
        {
            try
            {
                // Tạo đối tượng ProductController để lấy danh sách sản phẩm
                var products = productController.DsProduct();

                // Gán danh sách sản phẩm vào DropDownList
                ddlProductID.DataSource = products;
                ddlProductID.DataTextField = "SKU";
                ddlProductID.DataValueField = "product_id";
                ddlProductID.DataBind();

                // Thêm một item cho DropDownList (nếu cần thiết)
                ddlProductID.Items.Insert(0, new ListItem("-- Chọn mã sản phẩm --", ""));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                lblMessage.Text = "Đã xảy ra lỗi khi tải danh sách sản phẩm: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

        private void LoadOrderDropDownList()
        {
            try
            {
                // Tạo đối tượng OrderController để lấy danh sách đơn hàng
                var  orders = orderController.DsOrder();

                // Gán danh sách đơn hàng vào DropDownList
                ddlOrderID.DataSource = orders;
                ddlOrderID.DataTextField = "order_id";
                ddlOrderID.DataValueField = "order_id";
                ddlOrderID.DataBind();

                // Thêm một item cho DropDownList (nếu cần thiết)
                ddlOrderID.Items.Insert(0, new ListItem("-- Chọn mã đơn hàng --", ""));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                lblMessage.Text = "Đã xảy ra lỗi khi tải danh sách đơn hàng: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = Convert.ToInt32(txtQuantity.Text);
                decimal price = Convert.ToDecimal(txtPrice.Text);
                int productID = Convert.ToInt32(ddlProductID.SelectedValue);
                int orderID = Convert.ToInt32(ddlOrderID.SelectedValue); // Lấy giá trị đã chọn trong DropDownList mã đơn hàng
                string status = txtStatus.Text;

                // Tạo đối tượng OrderItem từ dữ liệu nhập vào
                OrderItem newOrderItem = new OrderItem()
                {
                    quantity = quantity,
                    price = price,
                    Product_prod = productID,
                    Order_order_i = orderID, // Gán mã đơn hàng từ DropDownList
                    status = status
                };

                // Gọi phương thức AddOrderItem để thêm đơn hàng mới
                orderItemController.AddOrderItem(newOrderItem);

                // Hiển thị thông báo thành công nếu cần thiết
                lblMessage.Text = "Thêm đơn hàng thành công!";
                lblMessage.CssClass = "text-success";
            }
            catch (FormatException ex)
            {
                // Xử lý lỗi FormatException (không đúng định dạng)
                lblMessage.Text = "Đã xảy ra lỗi: Dữ liệu nhập không đúng định dạng!";
                lblMessage.CssClass = "text-danger";
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
    }
}

