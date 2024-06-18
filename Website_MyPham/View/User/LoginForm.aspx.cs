using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.User
{
    public partial class LoginForm : System.Web.UI.Page
    {
        LoginCustomerController data = new LoginCustomerController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginUser(object sender, EventArgs e)
        {
            string DataEmail = Request.Form["email"];
            string DataPassword = Request.Form["password"];
            Website_MyPham.Models.Customer cus = data.checkLogin(DataEmail, DataPassword);
            if (cus != null)
            {

                // Lưu thông tin đăng nhập vào session
                Session["CustomerEmail"] = cus.email;
                Session["customer_id"] = cus.customer_id;
                Session["CustomerPassword"] = cus.password;
                Session["CustomerFullName"] = cus.first_name + " " + cus.last_name;
                // Chuyển hướng đến trang chủ
                string redirectScript = "<script type='text/javascript'>window.top.location.href = 'Index.aspx';</script>";
                Response.Write(redirectScript);
            }
            else
            {
                // Hiển thị thông báo lỗi
                lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
        }
    }
}