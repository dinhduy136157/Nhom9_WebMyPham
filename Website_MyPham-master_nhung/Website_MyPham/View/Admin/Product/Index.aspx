<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Product.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
        <asp:BoundField DataField="SKU" HeaderText="Tên sản phẩm" />
        <asp:BoundField DataField="description" HeaderText="Mô tả" />
        <asp:BoundField DataField="price" HeaderText="Giá" />
        <asp:BoundField DataField="stock" HeaderText="Stock" />
       <%-- <asp:BoundField DataField="Category_catego" HeaderText="Thể loại" />--%>
        <asp:BoundField DataField="CategoryId" HeaderText="Thể loại" />
        <%--<asp:TemplateField HeaderText="Xoá">
        <ItemTemplate>
            <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("id") %>'
                Text="Xoá" runat="server" OnCommand="Xoa_Click"
                OnClientClick="return confirm('Bạn có chắc xoá không ?')" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sửa">
            <ItemTemplate>
                <asp:Button ID="capnhat" CommandName="capnhat" CommandArgument='<%# Bind("id") %>'
                    Text="Cập nhật" runat="server" OnCommand="Sua_Click" />
            </ItemTemplate>
        </asp:TemplateField>--%>
    </Columns>
</asp:GridView>
</asp:Content>
