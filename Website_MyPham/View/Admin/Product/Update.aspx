<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Website_MyPham.View.Admin.Product.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
      <h2>Sửa sản phẩm</h2>
  <table>
      <tr>
          <td><label for="txtproduct_id">Mã sản phẩm</label></td>
          <td><asp:TextBox ID="txtproduct_id" runat="server" Enabled="false" /></td>
      </tr>
      <tr>
          <td><label for="txtmavach">Mã vạch</label></td>
          <td><asp:TextBox ID="txtmavach" runat="server" /></td>
      </tr>
      <tr>
          <td><label for="txtmota">Mô tả</label></td>
          <td><asp:TextBox ID="txtmota" runat="server" /></td>
      </tr>
      <tr>
          <td><label for="txtgia">Đơn giá</label></td>
          <td><asp:TextBox ID="txtgia" runat="server" /></td>
      </tr>
      <tr>
          <td><label for="txttrangthai">Mật khẩu</label></td>
          <td><asp:TextBox ID="txttrangthai" runat="server" /></td>
      </tr>
     <tr>

    <td><label for="ddlCategory">Loại sản phẩm</label></td>
    <td>
        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="false" DataTextField="name" DataValueField="Category_catego" />
</tr>

      <tr>
          <td><label for="txtanh">Ảnh</label></td>
          <td><asp:TextBox ID="txtanh" runat="server" /></td>
      </tr>
      <tr>
          <td colspan="2">
              <asp:Button ID="btnSua" runat="server" Text="Sửa sản phẩm" OnClick="btnSua_Click" />
              <asp:Button ID="btnReturnDS" runat="server" Text="Trở về" PostBackUrl="~/View/Admin/Product/Index.aspx" />
          </td>
      </tr>
      <tr>
          <td colspan="2">
              <asp:Label ID="msg" runat="server" Font-Italic="true" />
          </td>
      </tr>
  </table>
</asp:Content>
