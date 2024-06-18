using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Website_MyPham.Controllers;
using Website_MyPham.Models;
namespace Website_MyPham.View.Admin.Customer
{
    public partial class Update : System.Web.UI.Page
    {
        CustomerController data=new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Models.Customer customer = (Models.Customer)Session["kh"];
                txtcustomer_id.Text = customer.customer_id.ToString();
                txthodem.Text = customer.first_name;
                txttenkh.Text = customer.last_name;
                txtemail.Text = customer.email;
                txtmatkhau.Text = customer.password;
                txtdiachi.Text = customer.address;
                txtsodienthoai.Text = customer.phone_number;


                //ddlproduct_id.DataSource = productController.DsProduct();
                //ddlproduct_id.DataTextField = "SKU"; // Hiển thị SKU của sản phẩm
                //ddlproduct_id.DataValueField = "product_id"; // Giá trị lưu trữ là product_id
                //ddlproduct_id.DataBind();

            }
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Customer customer = new Models.Customer();
                customer.customer_id = int.Parse(txtcustomer_id.Text);
                customer.first_name = txthodem.Text;
                customer.last_name = txttenkh.Text;
                customer.email = txtemail.Text;
                customer.password = txtmatkhau.Text;
                customer.address = txtdiachi.Text;
                customer.phone_number = txtsodienthoai.Text;
                // category.product_id = int.Parse(ddlproduct_id.SelectedValue);
                data.capNhat(customer);
                msg.Text = "Sua thanh cong";

            }
            catch (Exception ex)
            {
                msg.Text = "Co loi khi sua" + ex.Message;
            }
        }

    }
}