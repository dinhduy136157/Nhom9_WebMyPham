using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.User.HienThiTheoGia
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
            string gia = Request.QueryString["gia"];
            switch (gia)
            {
                case "default":
                    ProductRepeater.DataSource = data.DsProduct();
                    break;
                case "less500":
                    ProductRepeater.DataSource = data.DsProduct().Where(p => p.price <= 500000).ToList();
                    break;
                case "than500":
                    ProductRepeater.DataSource = data.DsProduct().Where(p => p.price > 500000).ToList();
                    break;
            }
            ProductRepeater.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}