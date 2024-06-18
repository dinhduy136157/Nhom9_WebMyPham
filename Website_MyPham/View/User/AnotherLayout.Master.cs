using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_MyPham.View.User
{
    public partial class AnotherLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            Response.Redirect("/View/User/FindProduct/Index.aspx?keyword=" + keyword);
        }
    }
}