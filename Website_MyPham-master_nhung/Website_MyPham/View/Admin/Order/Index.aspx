<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Order.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="order_item_id" HeaderText="Mã đơn hàng" />
            <asp:BoundField DataField="Customer.first_name" HeaderText="Họ đệm" />
            <asp:BoundField DataField="Customer.last_name" HeaderText="Tên" />
            <asp:BoundField DataField="Customer.phone_number" HeaderText="Số điện thoại" />
            <asp:BoundField DataField="Product.SKU" HeaderText="Tên sản phẩm" />
            <asp:BoundField DataField="quantity" HeaderText="Số lượng" />

            <asp:BoundField DataField="Orders.total_price" HeaderText="Tổng tiền" />
            <asp:BoundField DataField="status" HeaderText="Trạng thái" />
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
