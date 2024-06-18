//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace Website_MyPham.View.Admin
//{
//    public partial class Index : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Website_MyPham.Controllers;
using Website_MyPham.Models;


namespace Website_MyPham.View.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatistics();
            }
        }

        private void LoadStatistics()
        {
            OrderItemController data = new OrderItemController();

            // Lấy dữ liệu thống kê theo ngày và gán vào GridView
            List<DailyOrderStatistics> dailyStats = data.GetDailyOrderStatistics();
            grdDailyStatistics.DataSource = dailyStats;
            grdDailyStatistics.DataBind();

            // Lấy dữ liệu thống kê theo tháng và gán vào GridView
            List<MonthlyOrderStatistics> monthlyStats = data.GetMonthlyOrderStatistics();
            grdMonthlyStatistics.DataSource = monthlyStats;
            grdMonthlyStatistics.DataBind();

            // Lấy dữ liệu thống kê theo năm và gán vào GridView
            List<YearlyOrderStatistics> yearlyStats = data.GetYearlyOrderStatistics();
            grdYearlyStatistics.DataSource = yearlyStats;
            grdYearlyStatistics.DataBind();
        }

        protected void ExportToPdf_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Statistics Report";

            // Export each GridView to the PDF document
            ExportGridViewToPdf(grdDailyStatistics, document, "Daily Statistics");
            ExportGridViewToPdf(grdMonthlyStatistics, document, "Monthly Statistics");
            ExportGridViewToPdf(grdYearlyStatistics, document, "Yearly Statistics");

            // Save the PDF document to a file
            string filename = "StatisticsReport.pdf";
            string folderPath = Server.MapPath("~/Reports/");
            string filePath = Path.Combine(folderPath, filename);

            // Create the folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save the PDF document
            document.Save(filePath);
            document.Close();

            // Transmit the PDF file to the client for download
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.TransmitFile(filePath);
            Response.End();
        }

        private void ExportGridViewToPdf(GridView gridView, PdfDocument document, string title)
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Arial", 18);
            XFont headerFont = new XFont("Arial", 12);
            XFont rowFont = new XFont("Arial", 10);

            int xPoint = 40;
            int yPoint = 40;
            int columnWidth = 100;
            int columnMargin = 10; // Khoảng cách giữa các cột

            // Draw title
            XRect titleRect = new XRect(xPoint, yPoint, gridView.Columns.Count * columnWidth, 40);
            gfx.DrawString(title, titleFont, XBrushes.Black, titleRect, XStringFormats.TopCenter);
            yPoint += 40;

            // Draw headers
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                XRect headerRect = new XRect(xPoint, yPoint, columnWidth, 20);
                gfx.DrawRectangle(XBrushes.LightGray, headerRect);
                gfx.DrawString(gridView.Columns[i].HeaderText, headerFont, XBrushes.Black, headerRect, XStringFormats.Center);
                xPoint += columnWidth + columnMargin; // Thêm khoảng cách giữa các cột
            }
            yPoint += 20;

            // Draw rows
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                xPoint = 40;
                for (int j = 0; j < gridView.Columns.Count; j++)
                {
                    XRect rowRect = new XRect(xPoint, yPoint, columnWidth, 20);
                    gfx.DrawString(gridView.Rows[i].Cells[j].Text, rowFont, XBrushes.Black, rowRect, XStringFormats.Center);
                    xPoint += columnWidth + columnMargin; // Thêm khoảng cách giữa các cột
                }
                yPoint += 20;
            }
        }



    }
}

