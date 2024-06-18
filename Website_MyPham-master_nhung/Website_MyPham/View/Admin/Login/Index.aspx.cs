using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models;

namespace Website_MyPham.View.Admin.Login
{
    public partial class Index : System.Web.UI.Page
    {
        LoginEmployeeController data = new LoginEmployeeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["logout"] == "true")
            {
                // Xóa tất cả các session
                Session.Clear();
            }
        }
        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string DataEmail = txtEmail.Text.Trim();
            string DataPassword = txtPassword.Text.Trim();
            Website_MyPham.Models.Employee emp = data.checkLogin(DataEmail, DataPassword);
            if (emp != null)
            {
                
                // Lưu thông tin đăng nhập vào session
                Session["EmployeeEmail"] = emp.email;
                Session["EmployeeFullName"] = emp.fullName;
                Session["EmployeeAvatar"] = emp.avatar;

                // Chuyển hướng đến trang quản lý bán hàng
                Response.Redirect("../Index.aspx");
            }
            else
            {
                // Hiển thị thông báo lỗi
                lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
        }
    }
}