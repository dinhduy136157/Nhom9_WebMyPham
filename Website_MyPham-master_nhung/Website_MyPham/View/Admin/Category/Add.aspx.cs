using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models; // Import the namespace where Category class is defined

namespace Website_MyPham.View.Admin.Category
{
    public partial class Add : System.Web.UI.Page
    {
        CategoryController controller = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtcategory_id.DataBind();
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Category category = new Models.Category();
                category.category_id = int.Parse(txtcategory_id.Text);
                category.name = txtname.Text;
                controller.AddCategory(category);
                msg.Text = "Them thanh cong";

            }
            catch (Exception ex)
            {
                msg.Text = "Co loi khi Them" + ex.Message;
            }
        }
    }
}