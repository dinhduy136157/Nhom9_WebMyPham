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
        CategoryController data = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string ten = Request.Form["ten"];
            Website_MyPham.Models.Category ca = new Website_MyPham.Models.Category
            {
                name = ten
        };
            data.AddCategory(ca);
            Response.Write("Loại hàng mới đã được thêm: " + ca.name);
        }
    }
}