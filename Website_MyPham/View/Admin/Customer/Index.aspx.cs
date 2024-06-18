using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.Admin.Customer
{
    public partial class Index : System.Web.UI.Page
    {
        CustomerController data = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienthi();
            }
        }
        public void Hienthi()
        {
            grdDs.DataSource = data.DsCustomer();
            DataBind();
        }
        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                data.xoakh(m);
                Hienthi();
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Models.Customer customer = data.layra1KH(m);
                Session["kh"] = customer;
                Response.Redirect("Update.aspx");
            }

        }

    }
}