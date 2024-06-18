using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.Admin.Customer
{
    public partial class Add : System.Web.UI.Page
    {
        CustomerController data = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string hoDem = Request.Form["hoDem"];
            string ten = Request.Form["ten"];
            string email = Request.Form["email"];
            string matKhau = Request.Form["matKhau"];
            string diaChi = Request.Form["diaChi"];
            string soDienThoai = Request.Form["soDienThoai"];
            Website_MyPham.Models.Customer kh = new Website_MyPham.Models.Customer
            {
                first_name = hoDem,
                last_name = ten,
                email = email,
                password = matKhau,
                address = diaChi,
                phone_number = soDienThoai

            };
            data.AddCustomer(kh);
            Response.Write("Khách hàng mới đã được thêm: " + kh.first_name);
        }
    }
}