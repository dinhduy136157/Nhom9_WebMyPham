<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Category.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false" >
    <Columns>
        <asp:BoundField DataField="category_id" HeaderText="Mã loại" />
        <asp:BoundField DataField="name" HeaderText="Tên loại" />
        <asp:TemplateField HeaderText="Xoá">
            <ItemTemplate>
                <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("category_id") %>'
                    Text="Xoá" runat="server" OnCommand="Xoa_Click"
                    OnClientClick="return confirm('Bạn có chắc xoá không ?')" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sửa">
            <ItemTemplate>
                <asp:Button ID="capnhat" CommandName="capnhat" CommandArgument='<%# Bind("category_id") %>'
                    Text="Cập nhật" runat="server" OnCommand="Sua_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
         </form>
</asp:Content>
   
