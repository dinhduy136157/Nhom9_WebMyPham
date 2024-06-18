using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.User
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
            ProductRepeater.DataSource = data.DsProduct();
            ProductRepeater.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}