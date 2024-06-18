<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Website_MyPham.View.Admin.Order.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   <div class="row">
        <div class="col-md-12">
            <div class="tile">
                <h3 class="tile-title">Thêm Đơn Hàng Mới</h3>
                <div class="tile-body">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    <div class="form-group">
                        <label class="control-label">Số lượng:</label>
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Giá:</label>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Mã sản phẩm:</label>
                        <asp:DropDownList ID="ddlProductID" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                  <%--  <div class="form-group">
                        <label class="control-label">Mã đơn hàng:</label>
                        <asp:TextBox ID="txtOrderID" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>--%>
                    <div class="form-group">
    <label class="control-label">Mã đơn hàng:</label>
    <asp:DropDownList ID="ddlOrderID" runat="server" CssClass="form-control"></asp:DropDownList>
</div>

                    <div class="form-group">
                        <label class="control-label">Trạng thái:</label>
                        <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnThem" runat="server" Text="Thêm Đơn Hàng" CssClass="btn btn-primary" OnClick="btnThem_Click" />
                    <a class="btn btn-secondary" href="Index.aspx">Hủy bỏ</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
