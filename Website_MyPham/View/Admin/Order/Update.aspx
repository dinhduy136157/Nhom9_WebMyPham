<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Website_MyPham.View.Admin.Order.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
     <h2>Sửa đơn hàng</h2>
    <table>
        <tr>
            <td><label for="txtOrderID">Mã đơn hàng</label></td>
            <td><asp:TextBox ID="txtOrderID" runat="server" Enabled="false" /></td>
        </tr>
        <tr>
            <td><label for="txtQuantity">Số lượng</label></td>
            <td><asp:TextBox ID="txtQuantity" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="txtPrice">Đơn giá</label></td>
            <td><asp:TextBox ID="txtPrice" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="ddlProductID">Mã sản phẩm</label></td>
            <td><asp:DropDownList ID="ddlProductID" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="ddlOrderID">Mã đơn hàng</label></td>
            <td><asp:DropDownList ID="ddlOrderID" runat="server" /></td>
        </tr>
        <tr>
            <td><label for="txtStatus">Trạng thái</label></td>
            <td><asp:TextBox ID="txtStatus" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSua" runat="server" Text="Sửa đơn hàng" OnClick="btnSua_Click" />
                <asp:Button ID="btnReturnDS" runat="server" Text="Trở về" PostBackUrl="~/View/Admin/Order/Index.aspx" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="msg" runat="server" Font-Italic="true" />
            </td>
        </tr>
    </table>
</asp:Content>
