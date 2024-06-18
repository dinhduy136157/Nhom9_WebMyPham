<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Website_MyPham.View.Admin.Employee.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="tile">
                <h3 class="tile-title">Tạo mới nhân viên</h3>
                <div class="tile-body">
                    <div class="row element-button">
                        <div class="col-sm-2">
                            <a class="btn btn-add btn-sm" data-toggle="modal" data-target="#exampleModalCenter"><b><i
                                class="fas fa-folder-plus"></i>Tạo chức vụ mới</b></a>
                        </div>
                    </div>
                    <form id="add" runat="server" class="row">
                        <div class="form-group col-md-4">
                            <label class="control-label">Họ và tên</label>
                            <input class="form-control" type="text" name="hoTen" required>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="control-label">Giới tính</label>
                            <select class="form-control" id="exampleSelect2" name="gioiTinh" required>
                                <option value="">-- Chọn giới tính --</option>
                                <option value="Nam">Nam</option>
                                <option value="Nữ">Nữ</option>
                            </select>
                        </div>
                        <div class="form-group col-md-4">
                            <label class="control-label">Địa chỉ email</label>
                            <input class="form-control" type="text" name="email" required>
                        </div>
                        <div class="form-group col-md-4">
                            <label class="control-label">Địa chỉ thường trú</label>
                            <input class="form-control" type="text" name="diaChi" required>
                        </div>
                        <div class="form-group  col-md-4">
                            <label class="control-label">Số điện thoại</label>
                            <input class="form-control" type="number" name="soDienThoai" required>
                        </div>
                        <div class="form-group col-md-4">
                            <label class="control-label">Ngày sinh</label>
                            <input class="form-control" type="date" name="ngaySinh">
                        </div>
                        <div class="form-group col-md-4">
                            <label class="control-label">PassWord</label>
                            <input class="form-control" type="text" name="password">
                        </div>
                        <asp:Button ID="btnThem" CssClass="btn btn-save" runat="server" Text="Thêm nhân viên" OnClick="btnThem_Click" />
                    </form>
                </div>
<%--            <button class="btn btn-save" type="submit" OnServerClick="btnThem_Click">Lưu lại</button>--%>
                <a class="btn btn-cancel" href="List.aspx">Hủy bỏ</a>
            </div>
        </div>
    </div>
</asp:Content>
