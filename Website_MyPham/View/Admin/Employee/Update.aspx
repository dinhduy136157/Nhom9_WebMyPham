<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Website_MyPham.View.Admin.Employee.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
     <h2>Sửa nhân viên</h2>
 <table>
     <tr>
         <td><label for="txtemployee_id">Mã nhân viên</label></td>
         <td><asp:TextBox ID="txtemployee_id" runat="server" Enabled="false" /></td>
     </tr>
     <tr>
         <td><label for="txthoten">Họ tên</label></td>
         <td><asp:TextBox ID="txthoten" runat="server" /></td>
     </tr>
     <tr>
         <td><label for="txtmotaanh">Mô tả ảnh</label></td>
         <td><asp:TextBox ID="txtmotaanh" runat="server" /></td>
     </tr>
     <tr>
         <td><label for="txtdiachi">Địa chỉ</label></td>
         <td><asp:TextBox ID="txtdiachi" runat="server" /></td>
     </tr>
     <tr>
         <td><label for="txtngaysinh">Ngày sinh</label></td>
         <td><asp:TextBox ID="txtngaysinh" runat="server" /></td>
     </tr>
     <tr>
       <td><label for="ddlGioiTinh">Giới tính</label></td>
        <td>
             <asp:DropDownList ID="ddlGioiTinh" runat="server">
              <asp:ListItem Text="Nam" Value="Nam" />
              <asp:ListItem Text="Nữ" Value="Nữ" />            
            </asp:DropDownList>
</td>

     </tr>
     <tr>
         <td><label for="txtsodienthoai">Số điện thoại</label></td>
         <td><asp:TextBox ID="txtsodienthoai" runat="server" /></td>
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
         <td colspan="2">
             <asp:Button ID="btnSua" runat="server" Text="Sửa nhân viên" OnClick="btnSua_Click" />
             <asp:Button ID="btnReturnDS" runat="server" Text="Trở về" PostBackUrl="~/View/Admin/Employee/Index.aspx" />
         </td>
     </tr>
     <tr>
         <td colspan="2">
             <asp:Label ID="msg" runat="server" Font-Italic="true" />
         </td>
     </tr>
 </table>
</asp:Content>
