using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.Admin.Order
{
    public partial class Index : System.Web.UI.Page
    {
        OrderItemController data = new OrderItemController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienthi();
            }
        }
        public void Hienthi()
        {
            grdDs.DataSource = data.DsOrderItem();
            DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                data.xoadh(m);
                Hienthi();
            }
        }
        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Models.OrderItem orderitem = data.layra1DH(m);
                Session["dh"] = orderitem;
                Response.Redirect("Update.aspx");
            }
        }
        protected void grdDs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                if (ddlStatus != null)
                {
                    string currentStatus = DataBinder.Eval(e.Row.DataItem, "status").ToString();
                    ddlStatus.SelectedValue = currentStatus;
                }
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            if (grdDs.DataKeys != null && grdDs.DataKeys.Count > row.RowIndex)
            {
                int order_item_id = Convert.ToInt32(grdDs.DataKeys[row.RowIndex].Value);
                string newStatus = ddl.SelectedValue;

                try
                {
                    data.UpdateOrderStatus(order_item_id, newStatus);
                    Hienthi();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật trạng thái đơn hàng: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("DataKeys không được thiết lập đúng");
            }
        }

    }
}