<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="Website_MyPham.View.User.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Font roboto -->
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto+Slab:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet" />
    <!-- Icon fontanwesome -->
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <!-- Reset css & grid sytem -->
    <link rel="stylesheet" href="./assets/css/library.css" />
    <link href="./assets/owlCarousel/assets/owl.carousel.min.css" rel="stylesheet" />
    <!-- Layout -->
    <link rel="stylesheet" href="./assets/css/common.css" />
    <!-- index -->
    <link href="./assets/css/home.css" rel="stylesheet" />
    <!-- Owl caroucel Js-->
    <script src="./assets/owlCarousel/owl.carousel.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="add" runat="server">
        <a href="#" class="overlay-close"></a>
        <div class="authen-modal register">
            <h3 class="authen-modal__title">Đăng Kí</h3>
            <div class="form-group">
                <label for="first_name" class="form-label">Họ đệm</label>
                <input name="first_name" type="text" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="last_name" class="form-label">Tên</label>
                <input name="last_name" type="text" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="email" class="form-label">Email</label>
                <input name="email" type="text" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="phone_number" class="form-label">Số điện thoại</label>
                <input name="phone_number" type="text" class="form-control"/>
                <span class="form-message"></span>
            </div>
            <div class="form-group">
                <label for="password" class="form-label">Mật khẩu *</label>
                <input name="password" type="password" class="form-control"/>
                <span class="form-message"></span>
            </div>
            <div class="form-group">
                <label for="address" class="form-label">Địa chỉ</label>
                <input name="address" type="text" class="form-control"/>
                <span class="form-message"></span>
            </div>
        
            <asp:Button ID="btnThem" CssClass="btn btn-save" runat="server" Text="Thêm nhân viên" OnClick="RegisterUser" />

        </div>
    </form>
</body>
</html>
