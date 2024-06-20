using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_MyPham.Controllers;
using Website_MyPham.Models;

namespace Website_MyPham.View.User.Product
{
    public partial class Index : System.Web.UI.Page
    {
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
            int productID;
            if (int.TryParse(Request.QueryString["ProductID"], out productID))
            {
                var products = data.ProductDetail(productID);
                var categoryId = products[0].Category_catego;
                var dataProCate = data.ProductCategory(categoryId); // Giả sử đây là phương thức để lấy danh sách sản phẩm

                foreach (var product in dataProCate)
                {
                string productHtml = $@"
                <div>
                    <a href='#' class='product'>
                        <div class='product__avt' style='background-image: url(../assets/img/product/{product.image})'></div>
                        <div class='product__info'>
                            <h3 class='product__name'>{product.SKU}</h3>
                            <div class='product__price'>
                                <div class='price__old'>340.000 <span class='price__unit'>đ</span></div>
                                <div class='price__new'>{product.price} <span class='price__unit'>đ</span></div>
                            </div>
                        </div>
                        <div class='product__sale'>
                            <span class='product__sale-percent'>22%</span>
                            <span class='product__sale-text'>Giảm</span>
                        </div>
                    </a>
                </div>";

                    ProductPlaceHolder.Controls.Add(new Literal { Text = productHtml });
                }
                if (products != null && products.Count > 0)
                {
                    //ProductCateRepeater.DataSource = data.ProductCategory(productID); ;
                    //ProductCateRepeater.DataBind();

                    var product = products[0];
                    // Gán dữ liệu vào các control
                    productName.InnerText = product.SKU;
                    productPrice.InnerText = product.price.ToString("N0") + ".000đ";
                    productDescription.InnerText = product.description;
                    productImage.Style["background-image"] = "url(../assets/img/product/" + product.image + ")";
                }
                else
                {
                    // Xử lý khi không có sản phẩm nào được tìm thấy
                    productName.InnerText = "Sản phẩm không tồn tại";
                    productPrice.InnerText = string.Empty;
                    productDescription.InnerText = string.Empty;
                    productImage.Style["background-image"] = "none";
                }
            }
            else
            {
                // Xử lý khi tham số ProductID không hợp lệ
                productName.InnerText = "ID sản phẩm không hợp lệ";
                productPrice.InnerText = string.Empty;
                productDescription.InnerText = string.Empty;
                productImage.Style["background-image"] = "none";
            }
        }
        private void DisplayProducts()
        {

        }
        [WebMethod]
        public static string AddToCart(int productID, int quantity)
        {
            if (HttpContext.Current.Session["customer_id"] != null)
            {
                int customerId = (int)HttpContext.Current.Session["customer_id"];
                CartController dataCart = new CartController();
                dataCart.AddCart(productID, customerId, quantity);
                return "Sản phẩm đã được thêm vào giỏ hàng!";
            }
            else
            {
                return "Vui lòng đăng nhập để thêm vào giỏ hàng!";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Bắt buộc khi sử dụng các control chạy phía server
        }
    }
}
