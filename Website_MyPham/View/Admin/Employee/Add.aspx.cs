using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Models;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.Admin.Employee
{
    public partial class Add : System.Web.UI.Page
    {
        EmployeeController data = new EmployeeController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = Request.Form["hoTen"];
            string gioiTinh = Request.Form["gioiTinh"];
            string email = Request.Form["email"];
            string diaChi = Request.Form["diaChi"];
            string soDienThoai = Request.Form["soDienThoai"];
            DateTime ngaySinh;
            DateTime.TryParse(Request.Form["ngaySinh"], out ngaySinh);
            string password = Request.Form["password"];
            Website_MyPham.Models.Employee nv = new Website_MyPham.Models.Employee
            {
                fullName = hoTen,
                avatar = "default.png",
                gender = gioiTinh,
                email = email,
                address = diaChi,
                phone = soDienThoai,
                birthDate = ngaySinh,
                password = password
            };
            data.AddEmployee(nv);
            Response.Write("Nhân viên mới đã được thêm: " + nv.fullName);
        }
    }
}