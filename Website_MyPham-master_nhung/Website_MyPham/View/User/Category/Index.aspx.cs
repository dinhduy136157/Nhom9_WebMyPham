using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.User.Category
{
    public partial class Index : System.Web.UI.Page
    {
        ProductController data = new ProductController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienthi();
            }
        }

        public void Hienthi()
        {
            int product_id = Convert.ToInt32(Request.QueryString["category_id"]);

            ProductRepeater.DataSource = data.ProductCategory(product_id);
            ProductRepeater.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Bỏ trống hoặc thêm mã xử lý nếu cần thiết
        }
    }
}
