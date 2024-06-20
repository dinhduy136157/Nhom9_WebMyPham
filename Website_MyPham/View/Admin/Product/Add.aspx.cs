using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;

namespace Website_MyPham.View.Admin.Product
{
    public partial class Add : System.Web.UI.Page
    {
        CategoryController dataCategory = new CategoryController();
        ProductController data = new ProductController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienthi();
            }
        }
        public void Hienthi()
        {
            CategoryRepeater.DataSource = dataCategory.DsCategory();
            CategoryRepeater.DataBind();
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string maVach = Request.Form["maVach"];
            string moTa = Request.Form["moTa"];
            decimal donGia = decimal.Parse( Request.Form["donGia"]);
            int trangThai =int.Parse( Request.Form["trangThai"]);
            int maLoai = int.Parse(Request.Form["maLoai"]);
            string anh = "product1.jpg";
            Website_MyPham.Models.Product pr = new Website_MyPham.Models.Product
            {
                SKU = maVach,
                description = moTa,
                price = donGia,
                stock = trangThai,
                Category_catego = maLoai,
                image = anh

            };
            data.Addproduct(pr);
            Response.Write("Khách hàng mới đã được thêm: " + pr.SKU);
        }
    }
}