using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models;

namespace Website_MyPham.View.User
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        CategoryController data = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Hienthi()
        {
            //List<Category> ds = data.DsCategory();
            //category1.InnerText = ds[0].name;
            //category2.InnerText = ds[1].name;
            //category1.InnerText = ds[2].name; 
            //category4.InnerText = ds[3].name;
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            Response.Redirect("/View/User/FindProduct/Index.aspx?keyword=" + keyword);
        }

        protected static string SubmitFormRegister(string first_name, string last_name, string email, string phone_number, string password, string address)
        {
            return $"{first_name}";
        }
    }
}