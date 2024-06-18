<%--<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Website_MyPham.View.Admin.Category.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    Sua loai hang
    
    <p>
        <label>Ma loai</label>
        <asp:TextBox ID="txtcategory_id" runat="server" Enabled="false" />
        
    </p>

    <p>
        <label>Ten loai</label>
        <asp:TextBox ID="txtname" runat="server"/>
    </p>
    <p>

    </p>

    <p>
        <asp:Button ID="btnSua" runat="server" Text="Sua loai hang" OnClick="btnSua_Click" />
        <asp:Button ID="btnReturnDS" runat="server" Text="Return" PostBackUrl="~/Index.aspx" />

    </p>


    <p>
        <asp:Label ID="msg" runat="server" Font-Italic="true" />
    </p>
</asp:Content>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Website_MyPham.View.Admin.Category.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    Sửa loại hàng
    
    <p>
        <label>Mã loại</label>
        <asp:TextBox ID="txtcategory_id" runat="server" Enabled="false" />
        
    </p>

    <p>
        <label>Tên loại</label>
        <asp:TextBox ID="txtname" runat="server"/>
    </p>
    <p>

    </p>
  <%--<p>
        <label>ma san pham</label>
        <asp:dropdownlist id="ddlproduct_id" runat="server" font-size="3" />
    </p>--%>

    <p>
        <asp:Button ID="btnSua" runat="server" Text="Sửa loại hàng" OnClick="btnSua_Click" />
        <asp:Button ID="btnReturnDS" runat="server" Text="Trở về" PostBackUrl="~/View/Admin/Category/Index.aspx" />

    </p>


    <p>
        <asp:Label ID="msg" runat="server" Font-Italic="true" />
    </p>
</asp:Content>
