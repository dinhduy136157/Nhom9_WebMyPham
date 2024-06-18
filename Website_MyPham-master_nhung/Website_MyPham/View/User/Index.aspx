<%@ Page Title="" Language="C#" MasterPageFile="~/View/User/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.User.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <style>
        .product-list {
            display: flex;
            flex-wrap: wrap;
            gap: 16px; /* khoảng cách giữa các sản phẩm */
        }

        .product-item {
            flex: 1 1 calc(20% - 16px); /* điều chỉnh kích thước sản phẩm, ví dụ 20% cho 5 sản phẩm mỗi hàng */
            box-sizing: border-box; /* để padding và border không ảnh hưởng tới kích thước */
        }

        /* Đảm bảo các sản phẩm chiếm toàn bộ không gian container */
        .product {
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            height: 100%;
        }
    </style>
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

                <!--------------------------------------LIST SẢN PHẨM CẦN FILL ------------------------------------>
                <div class="product-list">
                    <asp:Repeater ID="ProductRepeater" runat="server">
                        <ItemTemplate>
                            <div class="product-item">
                                <div class="product">
                                    <div class="product__avt" style='<%# Eval("image", "background-image: url(./assets/img/product/{0}") %>'></div>
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
                                    <a href='<%# Eval("product_id", "Product/Index.aspx?ProductID={0}") %>' class="viewDetail">Xem chi tiết</a>
                                    <a href='<%# Eval("product_id", "Product/Index.aspx?ProductID={0}") %>' class="addToCart">Thêm vào giỏ</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
