using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Website_MyPham.Controllers;
using Website_MyPham.Models;

namespace Website_MyPham.View.User.Pay
{
    public partial class Index : System.Web.UI.Page
    {
        CustomerController data = new CustomerController();
        CartController dataCart = new CartController();
        protected decimal grandTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer_id"] == null)
            {
                Response.Redirect("~/View/User/Index.aspx");
            }
            if (!IsPostBack)
            {
                Hienthi();
            }
        }
        public void Hienthi()
        {
            //------------------FILL DATA CUSTOMER--------------------------

            int customerId = (int)HttpContext.Current.Session["customer_id"];
            var customer = data.takeFirstCustomer(customerId);
            var dataCus = customer[0];
            customer_name.Value = dataCus.first_name + " " + dataCus.last_name;
            customer_address.Value = dataCus.address;
            customer_phone.Value = dataCus.phone_number;
            //-------------------FILL DATA CART--------------------------------
            var carts = dataCart.DsCart(customerId);
            for (int i = 0; i < carts.Count; i++)
            {
                var cart = carts[i];
                grandTotal += cart.totalPrice;
            }
            ProductRepeater.DataSource = carts;
            tongTien1.InnerText = grandTotal.ToString();
            ProductRepeater.DataBind();
        }
        public List<string> AddOrderItem()
        {
            List<string> orderDetails = new List<string>();
            try
            {
                int customerId = (int)HttpContext.Current.Session["customer_id"];
                var carts = dataCart.DsCart(customerId);
                decimal grandTotal = 0;

                foreach (var cart in carts)
                {
                    grandTotal += cart.totalPrice;
                }

                int orderId = dataCart.AddOrder(grandTotal, customerId);

                foreach (var cart in carts)
                {
                    string detail = $"Quantity: {cart.quantity}, TotalPrice: {cart.totalPrice}, ProductID: {cart.Product.product_id}, OrderID: {orderId}";
                    orderDetails.Add(detail);

                    dataCart.AddOrderDetail(cart.quantity, cart.totalPrice, cart.Product.product_id, orderId);
                }

                // Xóa giỏ hàng sau khi đặt hàng thành công
                dataCart.ClearCart(customerId);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi và thêm vào danh sách chi tiết
                Console.WriteLine("Lỗi khi thêm sản phẩm vào đơn hàng: " + ex.Message);
                orderDetails.Add("Lỗi khi thêm sản phẩm vào đơn hàng: " + ex.Message);
            }
            return orderDetails;
        }



        [WebMethod]
        public static string AddOrderItemWeb()
        {
            try
            {
                var page = new Index();
                var orderDetails = page.AddOrderItem();
                return new JavaScriptSerializer().Serialize(new { success = true, details = orderDetails ?? new List<string>() });
            }
            catch (Exception ex)
            {
                return new JavaScriptSerializer().Serialize(new { success = false, details = new List<string> { "Lỗi khi thêm sản phẩm vào đơn hàng: " + ex.Message } });
            }
        }



        protected void btnDatHang_Click(object sender, EventArgs e)
        {
            AddOrderItem();
            // Sau khi thêm đơn hàng, có thể chuyển hướng hoặc xử lý các logic tiếp theo tại đây
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}