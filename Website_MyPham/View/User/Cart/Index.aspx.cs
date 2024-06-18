using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.User.Cart
{
    public partial class Index : System.Web.UI.Page
    {
        CartController data = new CartController();
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
            int customerId = (int)HttpContext.Current.Session["customer_id"];
            var carts = data.DsCart(customerId);
            for (int i = 0; i < carts.Count; i++)
            {
                var cart = carts[i];
                grandTotal += cart.totalPrice;
            }
            ProductRepeater.DataSource = carts;
            tongTien1.InnerText = grandTotal.ToString();
            tongTien2.InnerText = grandTotal.ToString();
            ProductRepeater.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}
