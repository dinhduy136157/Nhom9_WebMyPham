<%@ Page Title="" Language="C#" MasterPageFile="~/View/User/AnotherLayout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.User.FindProduct.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="main">
    <!--Product Category -->
    <div class="main__tabnine">
        <div class="grid wide">
            <!-- Tab items -->
            <div class="tabs">
                <div class="tab-item active">
                    Bán Chạy
                </div>
                <div class="tab-item">
                    Giá tốt
                </div>
                <div class="tab-item">
                    Mới Nhập
                </div>
                <div class="line"></div>
            </div>
            <div style="margin-bottom: 20px" class="main__sort">
                <h3 class="sort__title">
                    Hiển thị kết quả theo
                </h3>
                <asp:DropDownList ID="sortSelect" runat="server" CssClass="sort__select" onchange="redirectToPage(this)">
                    <asp:ListItem Text="Mặc định" Value="1" />
                    <asp:ListItem Text="Giá dưới 500.000đ" Value="2" />
                    <asp:ListItem Text="Giá trên 500.000đ" Value="3" />
                </asp:DropDownList>

            </div>
            <!--------------------------------------LIST SẢN PHẨM CẦN FILL ------------------------------------>
            <div class="product-list">
                <asp:Repeater ID="ProductRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col l-2 m-4 s-6 product-item">
                            <div class="product">
                                <div class="product__avt" style='<%# Eval("image", "background-image: url(../assets/img/product/{0}") %>'></div>
                                <div class="product__info">
                                    <h3 class="product__name"><%# Eval("SKU") %></h3>
                                    <div class="product__price">
                                        <div class="price__old">
                                            300.000 đ
                                        </div>
                                        <div class="price__new"><%# Eval("price")%> <span class="price__unit">đ</span></div>
                                    </div>
                                    <div class="product__sale">
                                        <span class="product__sale-percent">24%</span>
                                        <span class="product__sale-text">Giảm</span>
                                    </div>
                                </div>
                                <a href='<%# Eval("product_id", "../Product/Index.aspx?ProductID={0}") %>' class="viewDetail">Xem chi tiết</a>
                                <a href='<%# Eval("product_id", "../Product/Index.aspx?ProductID={0}") %>' class="addToCart">Thêm vào giỏ</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
function redirectToPage(dropDownList) {
    var selectedValue = dropDownList.value;
    var url = ""; // Đặt URL của trang bạn muốn chuyển hướng đến dựa trên giá trị đã chọn
    switch (selectedValue) {
        case "2":
            url = "../HienThiTheoGia/Index.aspx?gia=less500";
            break;
        case "3":
            url = "../HienThiTheoGia/Index.aspx?gia=more500";
            break;
        default:
            url = "Default.aspx";
            break;
    }
    window.location.href = url; // Chuyển hướng đến trang mới
}
</script>
</asp:Content>
