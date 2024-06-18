<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Employee.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="row element-button">
              <div class="col-sm-2">

                <a class="btn btn-add btn-sm" href="Add.aspx" title="Thêm"><i class="fas fa-plus"></i>
                  Tạo mới nhân viên</a>
              </div>
              <div class="col-sm-2">
                <a class="btn btn-delete btn-sm pdf-file" type="button" title="In" onclick="myFunction(this)"><i
                    class="fas fa-file-pdf"></i> Xuất PDF</a>
              </div>
            </div>
    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="employee_id" HeaderText="Mã nhân viên" />
        <asp:BoundField DataField="fullName" HeaderText="Họ tên" />
        <asp:BoundField DataField="avatar" HeaderText="Ảnh" />
        <asp:BoundField DataField="address" HeaderText="Địa chỉ" />
        <asp:BoundField DataField="birthDate" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="gender" HeaderText="Giới tính" />
        <asp:BoundField DataField="phone" HeaderText="Số điện thoại" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="password" HeaderText="Mật khẩu" />
        <%--<button class="btn btn-primary btn-sm trash" type="button" title="Xóa"
        onclick="myFunction(this)"><i class="fas fa-trash-alt"></i>
        </button>
        <button class="btn btn-primary btn-sm edit" type="button" title="Sửa" id="show-emp"
            data-toggle="modal" data-target="#ModalUP"><i class="fas fa-edit"></i>
        </button>--%>
        
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
