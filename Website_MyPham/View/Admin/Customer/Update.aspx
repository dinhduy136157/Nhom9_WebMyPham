<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Website_MyPham.View.Admin.Customer.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <h2>Sửa khách hàng</h2>
    <table>
        <tr>
            <td><label for="txtcustomer_id">Mã khách hàng</label></td>
            <td><asp:TextBox ID="txtcustomer_id" runat="server" Enabled="false" /></td>
        </tr>
        <tr>
            <td><label for="txthodem">Họ đệm</label></td>
            <td><asp:TextBox ID="txthodem" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="txttenkh">Tên</label></td>
            <td><asp:TextBox ID="txttenkh" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="txtemail">Email</label></td>
            <td><asp:TextBox ID="txtemail" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="txtmatkhau">Mật khẩu</label></td>
            <td><asp:TextBox ID="txtmatkhau" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="txtdiachi">Địa chỉ</label></td>
            <td><asp:TextBox ID="txtdiachi" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="txtsodienthoai">Số điện thoại</label></td>
            <td><asp:TextBox ID="txtsodienthoai" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSua" runat="server" Text="Sửa khách hàng" OnClick="btnSua_Click" />
                <asp:Button ID="btnReturnDS" runat="server" Text="Trở về" PostBackUrl="~/View/Admin/Customer/Index.aspx" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="msg" runat="server" Font-Italic="true" />
            </td>
        </tr>
    </table>
</asp:Content>
