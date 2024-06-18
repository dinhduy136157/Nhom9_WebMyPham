<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="FindProduct.aspx.cs" Inherits="Website_MyPham.View.Admin.Product.FindProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
      <h2>Tìm kiếm sản phẩm</h2>
  <asp:TextBox ID="txtKeyword" runat="server" placeholder="Nhập từ khóa tìm kiếm"></asp:TextBox>
  <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
  <hr />
  <asp:ListView ID="lvProducts" runat="server">
      <ItemTemplate>
          <div>
              <h3><%# Eval("SKU") %></h3>
              <p><%# Eval("description") %></p>
              <p>Giá: <%# Eval("price", "{0:C}") %></p>
              <p>Số lượng trong kho: <%# Eval("stock") %></p>
              <hr />
          </div>
      </ItemTemplate>
  </asp:ListView>
</asp:Content>
