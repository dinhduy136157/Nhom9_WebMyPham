<%@ Page Title="" Language="C#" MasterPageFile="~/View/User/AnotherLayout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.User.Pay.Index" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../assets/css/pay.css">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="main">
        <div class="grid wide">
            <div class="row">
                <div class="col l-7 m-12 s-12">
                    <div class="pay-information">
                        <div class="pay__heading">Thông tin thanh toán</div>
                        <div class="form-group">
                            <label for="account" class="form-label">Họ Tên *</label>
                            <input runat="server" id="customer_name" name="account" type="text" class="form-control">
                        </div>
                        <div class="form-group">
                            <label for="account" class="form-label">Địa chỉ *</label>
                            <input runat="server" id="customer_address" name="account" type="text" class="form-control">
                            <span class="form-message"></span>
                        </div>
                        <div class="form-group">
                            <label for="account" class="form-label">Số điện thoại *</label>
                            <input runat="server" id="customer_phone" name="account" type="text" class="form-control">
                            <span class="form-message"></span>
                        </div>
                        <div class="form-group">
                            <label for="account" class="form-label">Đơn vị vận chuyển: </label>
                            <input runat="server" id="shipment" name="account" value="Giao hàng nhanh" type="text" class="form-control">
                        </div>
                    </div>
                </div>
                <div class="col l-5 m-12 s-12">
                    <div class="pay-order">
                        <div class="pay__heading">Đơn hàng của bạn</div>
                        <asp:Repeater ID="ProductRepeater" runat="server">
                            <ItemTemplate>
                                <div class="pay-info">
                                    <div class="main__pay-text">
                                        <%# Eval("Product.SKU") %>
                                    </div>
                                    <div class="main__pay-amount">
                                        <%# Eval("quantity") %>
                                    </div>
                                    <div class="main__pay-price">
                                        <%# Eval("totalPrice") %>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="pay-info">
                            <div class="main__pay-text special">
                                Giao hàng
                            </div>
                            <div class="main__pay-text">
                                Giao hàng miễn phí
                            </div>
                        </div>
                        <div class="pay-info">
                            <div class="main__pay-text special">
                                Tổng thành tiền</div>
                            <div runat="server" id="tongTien1" class="main__pay-price">
                            </div>
                        </div>
                        <div class="btn btn--default" id="btnDatHang">Đặt hàng</div>
                    </div>

                </div>
            </div>
        </div>
    </div>
<script>
    document.getElementById("btnDatHang").addEventListener("click", function () {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "Index.aspx/AddOrderItemWeb", true);
        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xhr.onload = function () {
            if (xhr.status === 200) {
                try {
                    var response = JSON.parse(xhr.responseText);
                    if (response.success) {
                        // Xử lý khi đặt hàng thành công
                        window.location.href = '../../Index'; // Chuyển hướng đến trang kế tiếp sau khi đặt hàng thành công
                    } else {
                        // Xử lý khi đặt hàng thất bại
                        alert('Đặt hàng thành công');
                    }
                } catch (e) {
                    alert('Đã xảy ra lỗi khi phân tích phản hồi từ server: ' + e.message);
                }
            } else {
                // Xử lý lỗi khi kết nối server
                alert('Đã xảy ra lỗi khi kết nối đến server.');
            }
        };
        xhr.onerror = function () {
            // Xử lý khi gặp lỗi không mong muốn
            alert('Đã xảy ra lỗi không mong muốn.');
        };
        xhr.send();
    });
</script>

</asp:Content>

