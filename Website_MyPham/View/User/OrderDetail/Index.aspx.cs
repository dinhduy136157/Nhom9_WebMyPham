using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.User.OrderDetail
{
    public partial class Index : System.Web.UI.Page
    {
        OrderItemController data = new OrderItemController();

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
        protected string GetStatus(object status)
        {
            string statusStr = status.ToString();

            if (status == null || string.IsNullOrEmpty(status.ToString()))
            {
                return "<span style='color: orange;'>Đang chờ xác nhận đơn</span>";
            }
            if (statusStr == "Đã giao")
            {
                return "<span style='color: green;'>Đơn đã được giao</span>";
            }
            if (statusStr == "Đã hủy")
            {
                return "<span style='color: red;'>Đơn đã bị hủy</span>";
            }
            else
            {
                return status.ToString();
            }
        }
        public void Hienthi()
        {
            int customerId = (int)HttpContext.Current.Session["customer_id"];
            var orders = data.firstOrderItem(customerId);

            ProductRepeater.DataSource = orders;
            ProductRepeater.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}