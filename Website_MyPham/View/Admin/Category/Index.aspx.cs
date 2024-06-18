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
    public partial class Index : System.Web.UI.Page
    {
        CategoryController data = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienthi();
            }
        }
        public void Hienthi()
        {
            grdDs.DataSource = data.DsCategory();
            DataBind();
        }
       
        protected void Xoa_Click(object sender, CommandEventArgs e) {
           if(e.CommandName == "xoa")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                data.DeleteCategory(m);
                Hienthi();
            }

        }
        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Models.Category category = data.layma(m);
                Session["loai"] = category;
                Response.Redirect("Update.aspx");
            }

            }


        }
}