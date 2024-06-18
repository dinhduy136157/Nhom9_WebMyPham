using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.User
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        CustomerController data = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void RegisterUser(object sender, EventArgs e)
        {
            string first_name = Request.Form["first_name"];
            string last_name = Request.Form["last_name"];
            string email = Request.Form["email"];
            string phone_number = Request.Form["phone_number"];
            string address = Request.Form["address"];
            string password = Request.Form["password"];
            Website_MyPham.Models.Customer cus = new Website_MyPham.Models.Customer
            {
                first_name = first_name,
                last_name = last_name,
                email = email,
                phone_number = phone_number,
                password = password,
                address = address,
            };
            data.AddCustomer(cus);
        }
    }
}