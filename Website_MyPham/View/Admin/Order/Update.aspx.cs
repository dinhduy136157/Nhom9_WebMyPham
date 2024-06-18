using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models;

namespace Website_MyPham.View.Admin.Order
{
    public partial class Update : System.Web.UI.Page
    {
        private OrderItemController orderItemController = new OrderItemController();
        private ProductController productController = new ProductController();
        private OrderController orderController = new OrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductDropDownList();
                LoadOrderDropDownList();

                Models.OrderItem orderItem = (Models.OrderItem)Session["dh"];
                if (orderItem != null)
                {
                    txtOrderID.Text= orderItem.order_item_id.ToString();
                    txtQuantity.Text = orderItem.quantity.ToString();
                    txtPrice.Text = orderItem.price.ToString();
                    ddlProductID.SelectedValue = orderItem.Product_prod.ToString();
                    ddlOrderID.SelectedValue = orderItem.Order_order_i.ToString();
                    txtStatus.Text = orderItem.status;
                }
            }
        }


        //private void LoadProductDropDownList()
        //{
        //    try
        //    {
        //        // Tạo đối tượng ProductController để lấy danh sách sản phẩm
        //        var products = productController.DsProduct();

        //        // Gán danh sách sản phẩm vào DropDownList
        //        ddlProductID.DataSource = products;
        //        ddlProductID.DataTextField = "SKU";
        //        ddlProductID.DataValueField = "product_id";
        //        ddlProductID.DataBind();

        //        // Thêm một item cho DropDownList (nếu cần thiết)
        //        ddlProductID.Items.Insert(0, new ListItem("-- Chọn mã sản phẩm --", ""));
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý lỗi nếu có
        //        msg.Text = "Đã xảy ra lỗi khi tải danh sách sản phẩm: " + ex.Message;
        //        msg.CssClass = "text-danger";
        //    }
        //}
        //private void LoadOrderDropDownList()
        //{
        //    try
        //    {
        //        // Tạo đối tượng OrderController để lấy danh sách đơn hàng
        //        var orders = orderController.DsOrder();

        //        // Gán danh sách đơn hàng vào DropDownList
        //        ddlOrderID.DataSource = orders;
        //        ddlOrderID.DataTextField = "order_id";
        //        ddlOrderID.DataValueField = "order_id";
        //        ddlOrderID.DataBind();

        //        // Thêm một item cho DropDownList (nếu cần thiết)
        //        ddlOrderID.Items.Insert(0, new ListItem("-- Chọn mã đơn hàng --", ""));
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý lỗi nếu có
        //        msg.Text = "Đã xảy ra lỗi khi tải danh sách đơn hàng: " + ex.Message;
        //        msg.CssClass = "text-danger";
        //    }
        //}

        private void LoadProductDropDownList()
        {
            try
            {
                var products = productController.DsProduct();

                ddlProductID.DataSource = products;
                ddlProductID.DataTextField = "SKU";
                ddlProductID.DataValueField = "product_id";
                ddlProductID.DataBind();

                // Thêm một item cho DropDownList (nếu cần thiết)
             
            }
            catch (Exception ex)
            {
                msg.Text = "Đã xảy ra lỗi khi tải danh sách sản phẩm: " + ex.Message;
                msg.CssClass = "text-danger";
            }
        }


        private void LoadOrderDropDownList()
        {
            try
            {
                // Tạo đối tượng OrderController để lấy danh sách đơn hàng
                var orders = orderController.DsOrder();

                // Gán danh sách đơn hàng vào DropDownList
                ddlOrderID.DataSource = orders;
                ddlOrderID.DataTextField = "order_id";
                ddlOrderID.DataValueField = "order_id";
                ddlOrderID.DataBind();

                // Thêm một item cho DropDownList (nếu cần thiết)
              
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                msg.Text = "Đã xảy ra lỗi khi tải danh sách đơn hàng: " + ex.Message;
                msg.CssClass = "text-danger";
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin mã đơn hàng từ người dùng và xử lý
                string orderIdInput = txtOrderID.Text.Trim();

                if (string.IsNullOrEmpty(orderIdInput))
                {
                    msg.Text = "Mã đơn hàng không được để trống!";
                    msg.CssClass = "text-warning";
                    return;
                }

                int orderId;
                if (!int.TryParse(orderIdInput, out orderId))
                {
                    msg.Text = "Mã đơn hàng không hợp lệ!";
                    msg.CssClass = "text-warning";
                    return;
                }

                // Lấy thông tin từ giao diện người dùng và cập nhật vào đối tượng OrderItem
                OrderItem orderItem = new OrderItem();
                orderItem.order_item_id = orderId;
                orderItem.quantity = int.Parse(txtQuantity.Text.Trim());
                orderItem.price = decimal.Parse(txtPrice.Text.Trim());

                // Kiểm tra và gán giá trị cho Product_prod
                int selectedProductID;
                if (int.TryParse(ddlProductID.SelectedValue, out selectedProductID))
                {
                    orderItem.Product_prod = selectedProductID;
                }
                else
                {
                    msg.Text = "Mã sản phẩm không hợp lệ!";
                    msg.CssClass = "text-warning";
                    return;
                }

                // Kiểm tra và gán giá trị cho Order_order_i
                int selectedOrderID;
                if (int.TryParse(ddlOrderID.SelectedValue, out selectedOrderID))
                {
                    orderItem.Order_order_i = selectedOrderID;
                }
                else
                {
                    msg.Text = "Mã đơn hàng không hợp lệ!";
                    msg.CssClass = "text-warning";
                    return;
                }

                orderItem.status = txtStatus.Text.Trim();

                // Gọi phương thức cập nhật từ OrderItemController
                orderItemController.capNhatOrderItem(orderItem);

                // Hiển thị thông báo thành công
                msg.Text = "Thông tin đơn hàng đã được cập nhật thành công!";
                msg.CssClass = "text-success";

                // Sau khi cập nhật thành công, gọi lại phương thức layra1DH để cập nhật lại các textbox
                orderItem = orderItemController.layra1DH(orderId);
                if (orderItem != null)
                {
                    txtQuantity.Text = orderItem.quantity.ToString();
                    txtPrice.Text = orderItem.price.ToString();
                    ddlProductID.SelectedValue = orderItem.Product_prod.ToString();
                    ddlOrderID.SelectedValue = orderItem.Order_order_i.ToString();
                    txtStatus.Text = orderItem.status;
                }
                else
                {
                    msg.Text = "Không tìm thấy đơn hàng sau khi cập nhật!";
                    msg.CssClass = "text-warning";
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                //msg.Text = "Có lỗi khi cập nhật đơn hàng: " + ex.Message;
                msg.CssClass = "text-danger";
            }
        }
    }
}
