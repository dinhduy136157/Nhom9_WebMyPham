﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Login.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập quản trị | Website quản trị v2.0</title>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css"/>
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css"/>
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/util.css"/>
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@latest/css/boxicons.min.css"/>
    <link rel="stylesheet" href="https://unpkg.com/boxicons@latest/css/boxicons.min.css"/>
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt">
                    <img src="../../../images/team.jpg" alt="IMG">
                </div>
                <!--=====TIÊU ĐỀ======-->
                <form class="login100-form validate-form">
                    <span class="login100-form-title">
                        <b>ĐĂNG NHẬP HỆ THỐNG POS</b>
                    </span>
                    <!--=====FORM INPUT TÀI KHOẢN VÀ PASSWORD======-->
                    <form id="add" runat="server">
                        <div class="wrap-input100 validate-input">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="input100" placeholder="Tài khoản quản trị"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class='bx bx-user'></i>
                            </span>
                        </div>
                        <div class="wrap-input100 validate-input">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="input100" TextMode="Password" placeholder="Mật khẩu"></asp:TextBox>
                            <span toggle="#password-field" class="bx fa-fw bx-hide field-icon click-eye"></span>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class='bx bx-key'></i>
                            </span>
                        </div>

                        <!--=====ĐĂNG NHẬP======-->
                        <%--<div class="container-login100-form-btn">
                            <input type="button" value="Đăng nhập" id="submit" onclick="validate()" />
                        </div>--%>
                        <asp:Button ID="btnDangNhap" runat="server" CssClass="login100-form-btn" Text="Đăng nhập" OnClick="btnDangNhap_Click" />
                        <!--=====LINK TÌM MẬT KHẨU======-->
                        <div class="text-right p-t-12">
                            <a class="txt2" href="/forgot.html">Bạn quên mật khẩu?
                            </a>
                        </div>
                    </form>
                    <div>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <!--=====FOOTER======-->
                    <div class="text-center p-t-70 txt2">
                        Phần mềm quản lý bán hàng <i class="far fa-copyright" aria-hidden="true"></i>
                        <script type="text/javascript">document.write(new Date().getFullYear());</script> <a
                            class="txt2" href="https://www.facebook.com/dinhduyy/"> Code bởi Duy </a>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!--Javascript-->
    <script src="/js/main.js"></script>
    <script src="https://unpkg.com/boxicons@latest/dist/boxicons.js"></script>
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/select2/select2.min.js"></script>
    <script type="text/javascript">
        //show - hide mật khẩu
        function myFunction() {
            var x = document.getElementById("myInput");
            if (x.type === "password") {
                x.type = "text"
            } else {
                x.type = "password";
            }
        }
        $(".click-eye").click(function () {
            $(this).toggleClass("bx-show bx-hide");
            var input = $($(this).attr("toggle"));
            if (input.attr("type") == "password") {
                input.attr("type", "text");
            } else {
                input.attr("type", "password");
            }
        });
    </script>
</body>
</html>
