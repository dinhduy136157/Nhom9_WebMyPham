using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_MyPham.View.Admin
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["EmployeeEmail"] == null)
            {
                Response.Redirect("~/View/Admin/Login/Index.aspx");
            }
        }
        protected void LogoutAndRedirect(object sender, EventArgs e)
        {
            // Xóa tất cả các session
            Session.Clear();

            // Chuyển hướng đến trang đăng nhập
            Response.Redirect("~/View/Admin/Login/Index.aspx");
        }
    }
}