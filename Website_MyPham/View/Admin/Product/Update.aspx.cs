using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models;
namespace Website_MyPham.View.Admin.Product
{
    public partial class Update : System.Web.UI.Page
    {
        ProductController data=new ProductController();
        CategoryController data1 = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Models.Product product = (Models.Product)Session["pr"];
                txtproduct_id.Text = product.product_id.ToString();
                txtmavach.Text = product.SKU;
                txtmota.Text = product.description;
                txtgia.Text = product.price.ToString();
                txttrangthai.Text = product.stock.ToString();

                ddlCategory.DataSource = data1.DsCategory();
                ddlCategory.DataTextField = "name";
                ddlCategory.DataValueField = "category_id";
                ddlCategory.DataBind();
                ddlCategory.SelectedValue = product.Category_catego.ToString();              
                txtanh.Text = product.image;
            }
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Product product = new Models.Product();
                product.product_id = int.Parse(txtproduct_id.Text);
                product.SKU = txtmavach.Text;
                product.description = txtmota.Text;
                product.price =decimal.Parse( txtgia.Text);
                product.stock = int.Parse(txttrangthai.Text);
                product.Category_catego = int.Parse(ddlCategory.SelectedValue);
                product.image = txtanh.Text;
                // category.product_id = int.Parse(ddlproduct_id.SelectedValue);
                data.capNhat(product);
                msg.Text = "Sua thanh cong";

            }
            catch (Exception ex)
            {
                msg.Text = "Co loi khi sua" + ex.Message;
            }
        }
    }
}