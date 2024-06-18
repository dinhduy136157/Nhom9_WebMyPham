<%@ Page Title="" Language="C#" MasterPageFile="~/View/User/AnotherLayout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.User.Product.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="main">
        <div class="grid wide">
            <div class="productInfo">
                <div class="row">
                    <div class="col l-5 m-12 s-12">
                        <div>
                            <a href="#" class="product">
                                <div id="productImage" class="product__avt" runat="server" style="background-size: cover; background-position: center;">
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col l-7 m-12s s-12 pl">
                        <h3 id="productName" class="productInfo__name" runat="server"></h3>
                        <div class="productInfo__price">
                            <span id="productPrice" class="priceInfo__unit" runat="server">đ</span>
                        </div>
                        <div id="productDescription" class="productInfo__description" runat="server"></div>
                        <div class="productInfo__addToCart">
                            <div class="buttons_added">
                                <input class="minus is-form" type="button" value="-" onclick="minusProduct()">
                                <input aria-label="quantity" class="input-qty" id="productQuantity" max="10" min="1" name="" type="number" value="1">
                                <input class="plus is-form" type="button" value="+" onclick="plusProduct()">
                            </div>
                            <button class=" btn btn--default orange" type="button" id="btnAddToCart" onclick="addToCart()">Thêm vào giỏ</button>
                        </div>
                        <div class="productIndfo__policy ">
                            <div class="policy bg-1 ">
                                <img src="../assets/img/policy/policy1.png " class="productIndfo__policy-img "></img>
                                <div class="productIndfo__policy-info ">
                                    <h3 class="productIndfo__policy-title ">Giao hàng miễn phí</h3>
                                    <p class="productIndfo__policy-description ">Cho đơn hàng từ 300K</p>
                                </div>
                            </div>
                            <div class="policy bg-2 ">
                                <img src="../assets/img/policy/policy2.png " class="productIndfo__policy-img "></img>
                                <div class="productIndfo__policy-info ">
                                    <h3 class="productIndfo__policy-title ">Giao hàng miễn phí</h3>
                                    <p class="productIndfo__policy-description ">Cho đơn hàng từ 300K</p>
                                </div>
                            </div>
                            <div class="policy bg-1 ">
                                <img src="../assets/img/policy/policy3.png " class="productIndfo__policy-img "></img>
                                <div class="productIndfo__policy-info ">
                                    <h3 class="productIndfo__policy-title ">Giao hàng miễn phí</h3>
                                    <p class="productIndfo__policy-description ">Cho đơn hàng từ 300K</p>
                                </div>
                            </div>
                            <div class="policy bg-2 ">
                                <img src="../assets/img/policy/policy4.png " class="productIndfo__policy-img "></img>
                                <div class="productIndfo__policy-info ">
                                    <h3 class="productIndfo__policy-title ">Giao hàng miễn phí</h3>
                                    <p class="productIndfo__policy-description ">Cho đơn hàng từ 300K</p>
                                </div>
                            </div>
                        </div>
                        <div class="productIndfo__category">
                            <p class="productIndfo__category-text">Danh mục: <a href="#" class="productIndfo__category-link">Nail</a></p>
                            <p class="productIndfo__category-text">Hãng: <a href="#" class="productIndfo__category-link">The Face Shop</a></p>
                            <p class="productIndfo__category-text">Số lượng đã bán: 322</p>
                            <p class="productIndfo__category-text">Số lượng trong kho: 322</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="productDetail">
                <div class="main__tabnine">
                    <div class="grid wide">
                        <!-- Tab items -->
                        <div class="tabs">
                            <div class="tab-item active">Mô tả</div>
                            <div class="line"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function minusProduct() {
            var quantityInput = document.querySelector('.input-qty');
            var currentQuantity = parseInt(quantityInput.value);
            if (currentQuantity > 1) {
                quantityInput.value = currentQuantity - 1;
            }
        }

        function plusProduct() {
            var quantityInput = document.querySelector('.input-qty');
            var currentQuantity = parseInt(quantityInput.value);
            var maxQuantity = parseInt(quantityInput.getAttribute('max'));
            if (currentQuantity < maxQuantity) {
                quantityInput.value = currentQuantity + 1;
            }
        }

        function addToCart() {
            var urlParams = new URLSearchParams(window.location.search);
            var productID = urlParams.get('ProductID');
            var quantity = document.querySelector('.input-qty').value;

            if (productID && quantity) {
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        alert(this.responseText);
                    }
                };
                xhttp.open("POST", "Index.aspx/AddToCart", true);
                xhttp.setRequestHeader("Content-type", "application/json");
                xhttp.send(JSON.stringify({ productID: productID, quantity: quantity }));
            } else {
                alert("Không tìm thấy ProductID hoặc số lượng không hợp lệ");
            }
        }
    </script>
</asp:Content>
