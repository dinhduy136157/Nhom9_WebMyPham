using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;



namespace Website_MyPham.View.Admin.Employee
{
    public partial class Index : System.Web.UI.Page
    {
        EmployeeController data = new EmployeeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienthi();
            }
        }
        public void Hienthi()
        {
            grdDs.DataSource = data.DsEmployee();
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
                data.xoanv(m);
                Hienthi();
            }

        }
        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Models.Employee employee = data.layra1NV(m);
                Session["nv"] = employee;
                Response.Redirect("Update.aspx");
            }
        }
        protected void ExportToPdf_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Employees.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            PdfDocument doc = new PdfDocument();

            try

            {
                PdfPage page = doc.AddPage();
               
                XGraphics gfx = XGraphics.FromPdfPage(page);
                //XFont font = new XFont("Verdana", 10);
                XFont font = new XFont("Arial", 8);
                int yPoint = 100;
                int xPoint = 40;

                // Vẽ tiêu đề của các cột
                gfx.DrawString("Mã nhân viên", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 60;
                gfx.DrawString("Họ tên", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 60;
                gfx.DrawString("Ảnh", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 60;
                gfx.DrawString("Địa chỉ", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 60;
                gfx.DrawString("Ngày sinh", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 60;
                gfx.DrawString("Giới tính", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 40;
                gfx.DrawString("Số điện thoại", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 60;
                gfx.DrawString("Email", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);
                xPoint += 110;
                gfx.DrawString("Mật khẩu", font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft);

                yPoint += 20;

                // Vẽ dữ liệu từ GridView
                foreach (GridViewRow row in grdDs.Rows)
                {
                    xPoint = 40;

                    // Vẽ từng cột theo chỉ mục tương ứng
                    gfx.DrawString(row.Cells[0].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Mã nhân viên
                    xPoint += 60;
                    gfx.DrawString(row.Cells[1].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Họ tên
                    xPoint += 60;
                    string imageUrl = Server.MapPath("~/Image/" + row.Cells[2].Text);

                    if (File.Exists(imageUrl))
                    {
                        XImage ximg = XImage.FromFile(imageUrl);
                        gfx.DrawImage(ximg, xPoint, yPoint, 100, 100);
                    }
                    else
                    {
                        gfx.DrawString("Image Not Found", font, XBrushes.Red, new XRect(xPoint, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    }

                    xPoint += 60;
                    gfx.DrawString(row.Cells[3].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Địa chỉ
                    xPoint += 60;
                    gfx.DrawString(row.Cells[4].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Ngày sinh
                    xPoint += 60;
                    gfx.DrawString(row.Cells[5].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Giới tính
                    xPoint += 40;
                    gfx.DrawString(row.Cells[6].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Số điện thoại
                    xPoint += 60;
                    gfx.DrawString(row.Cells[7].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Email
                    xPoint += 110;
                    gfx.DrawString(row.Cells[8].Text, font, XBrushes.Black, new XRect(xPoint, yPoint, 100, 20), XStringFormats.TopLeft); // Mật khẩu

                    yPoint += 40; // Chuyển xuống dòng tiếp theo
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ hoặc ghi log tại đây
                Response.Write(ex.Message);
            }
            finally
            {
                // Gửi tài liệu PDF về client và giải phóng tài nguyên
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);
                Response.BinaryWrite(stream.ToArray());
                Response.End();

                doc.Close();
                stream.Close();
                stream.Dispose();
            }
        }


    }
}



