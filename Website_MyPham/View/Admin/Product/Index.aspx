<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Product.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="row element-button">
        <div class="col-sm-3">
            <a class="btn btn-add btn-sm" href="Add.aspx" title="Thêm"><i class="fas fa-plus"></i>Tạo mới sản phẩm</a>
        </div>
        <div class="col-sm-3">
            <a class="btn btn-delete btn-sm pdf-file" type="button" title="In" onclick="myFunction(this)"><i class="fas fa-file-pdf"></i>Xuất PDF</a>
        </div>
        <div class="col-sm-4">
            <div class="input-group">
                <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control" placeholder="Nhập từ khóa tìm kiếm"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-search btn-sm" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowDeleting="grdDs_RowDeleting" DataKeyNames="product_id" OnRowEditing="grdDs_RowEditing">
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
            <asp:BoundField DataField="SKU" HeaderText="Tên sản phẩm" />
            <asp:TemplateField HeaderText="Ảnh">
                <ItemTemplate>
                    <img style="height: 120px" src="../../../images/<%# Eval("image") %>" alt="Alternate Text" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="description" HeaderText="Mô tả" />
            <asp:BoundField DataField="price" HeaderText="Giá" DataFormatString="{0:N2} VNĐ" />
            <asp:BoundField DataField="stock" HeaderText="Trạng thái" />
            <asp:BoundField DataField="Category_catego" HeaderText="Thể loại" />
            <asp:TemplateField HeaderText="Xoá">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("product_id") %>' Text="Xoá" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Bạn có chắc chắn muốn xoá không?')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sửa">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("product_id") %>' Text="Sửa" CssClass="btn btn-primary btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlNoResults" runat="server" CssClass="alert alert-warning mt-3" Visible="false">
        Không tìm thấy sản phẩm phù hợp.
    </asp:Panel>

    <div style="margin-top: 150px" class="row">
        <div class="col-sm-6">
            <h3>Danh sách 3 sản phẩm bán chạy nhất</h3>
            <asp:GridView ID="grdTopSellingProducts" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
                    <asp:BoundField DataField="SKU" HeaderText="Tên sản phẩm" />
                    <asp:TemplateField HeaderText="Ảnh">
                        <ItemTemplate>
                            <img style="height: 120px" src="../../../images/<%# Eval("image") %>" alt="Alternate Text" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="description" HeaderText="Mô tả" />
                    <asp:BoundField DataField="price" HeaderText="Giá" DataFormatString="{0:N2} VNĐ" />
                    <asp:BoundField DataField="stock" HeaderText="Trạng thái" />
                    <asp:BoundField DataField="Category_catego" HeaderText="Thể loại" />

                </Columns>
            </asp:GridView>
        </div>
        <div class="col-sm-6">
            <h3>Danh sách sản phẩm không bán được</h3>
            <asp:GridView ID="grdLowSellingProducts" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
                    <asp:BoundField DataField="SKU" HeaderText="Tên sản phẩm" />
                    <asp:TemplateField HeaderText="Ảnh">
                        <ItemTemplate>
                            <img style="height: 120px" src="../../../images/<%# Eval("image") %>" alt="Alternate Text" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="description" HeaderText="Mô tả" />
                    <asp:BoundField DataField="price" HeaderText="Giá" DataFormatString="{0:N2} VNĐ" />
                    <asp:BoundField DataField="stock" HeaderText="Số lượng" />
                    <asp:BoundField DataField="Category_catego" HeaderText="Thể loại" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
