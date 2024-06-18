<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Customer.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
      <div class="row element-button">
       <div class="col-sm-2">
             <a class="btn btn-add btn-sm" href="Add.aspx" title="Thêm"><i class="fas fa-plus"></i>
 Tạo mới khách hàng</a>
       </div>
       <div class="col-sm-2">
            <a class="btn btn-delete btn-sm pdf-file" type="button" title="In" onclick="myFunction(this)"><i
  class="fas fa-file-pdf"></i> Xuất PDF</a>
       </div>
  </div>
    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="customer_id" HeaderText="Mã khách hàng" />
        <asp:BoundField DataField="first_name" HeaderText="Họ đệm" />
        <asp:BoundField DataField="last_name" HeaderText="Tên" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="password" HeaderText="Mật khẩu" />
        <asp:BoundField DataField="address" HeaderText="Địa chỉ" />
        <asp:BoundField DataField="phone_number" HeaderText="Số điện thoại" />

           <asp:TemplateField HeaderText="Xoá">
       <ItemTemplate>
           <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("customer_id") %>'
               Text="Xoá" runat="server" OnCommand="Xoa_Click"
               OnClientClick="return confirm('Bạn có chắc xoá không ?')" />
       </ItemTemplate>
               </asp:TemplateField>
          <asp:TemplateField HeaderText="Sửa">
      <ItemTemplate>
          <asp:Button ID="capnhat" CommandName="sua" CommandArgument='<%# Bind("customer_id") %>'
              Text="Cập nhật" runat="server" OnCommand="Sua_Click" />
      </ItemTemplate>
  </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
