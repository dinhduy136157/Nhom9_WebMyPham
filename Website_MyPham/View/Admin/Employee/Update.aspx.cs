using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models;

namespace Website_MyPham.View.Admin.Employee
{
    public partial class Update : System.Web.UI.Page
    {
        EmployeeController data=new EmployeeController();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy thông tin nhân viên từ Session và hiển thị lên các điều khiển
                if (Session["nv"] != null)
                {
                    Models.Employee employee = (Models.Employee)Session["nv"];
                    txtemployee_id.Text = employee.employee_id.ToString();
                    txthoten.Text = employee.fullName;
                    txtmotaanh.Text = employee.avatar;
                    txtdiachi.Text = employee.address;
                    txtngaysinh.Text = employee.birthDate.ToString("yyyy-MM-dd");
                    ddlGioiTinh.SelectedValue = employee.gender; // Chỉnh sửa thành SelectedValue
                    txtsodienthoai.Text = employee.phone;
                    txtemail.Text = employee.email;
                    txtmatkhau.Text = employee.password;
                }
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Employee employee = new Models.Employee();
                employee.employee_id = int.Parse(txtemployee_id.Text);
                employee.fullName = txthoten.Text;
                employee.avatar = txtmotaanh.Text;
                employee.address = txtdiachi.Text;
                employee.birthDate = DateTime.Parse(txtngaysinh.Text);
                employee.gender = ddlGioiTinh.SelectedValue; // Chỉnh sửa thành SelectedValue
                employee.phone = txtsodienthoai.Text;
                employee.email = txtemail.Text;
                employee.password = txtmatkhau.Text;

                data.capNhat(employee);

                // Cập nhật thành công, thông báo cho người dùng
                msg.Text = "Cập nhật thành công";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                msg.Text = "Có lỗi khi cập nhật: " + ex.Message;
            }
        }

    }
}