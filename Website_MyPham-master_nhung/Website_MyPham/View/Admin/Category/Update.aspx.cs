using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models; // Import the namespace where Category class is defined


namespace Website_MyPham.View.Admin.Category
{
    public partial class Update : System.Web.UI.Page
    {
        
        ProductController productController = new ProductController();
        CategoryController controller = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                Models.Category category= (Models.Category)Session["loai"];
                txtcategory_id.Text = category.category_id.ToString();
                txtname.Text = category.name;

               
                ddlproduct_id.DataSource = productController.DsProduct();
                ddlproduct_id.DataTextField = "SKU"; // Hiển thị SKU của sản phẩm
                ddlproduct_id.DataValueField = "product_id"; // Giá trị lưu trữ là product_id
                ddlproduct_id.DataBind();

            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Category category = new Models.Category();
                category.category_id = int.Parse(txtcategory_id.Text);
                category.name = txtname.Text;
               // category.product_id = int.Parse(ddlproduct_id.SelectedValue);
                controller.UpdateCategory(category);
                msg.Text = "Sua thanh cong";

            }
            catch (Exception ex)
            {
                msg.Text = "Co loi khi sua" + ex.Message;
            }
        }
    }
}