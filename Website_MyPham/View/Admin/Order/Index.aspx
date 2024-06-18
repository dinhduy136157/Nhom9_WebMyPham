<%--<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Order.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
         <div class="row element-button">
      <div class="col-sm-2">
            <a class="btn btn-add btn-sm" href="Add.aspx" title="Thêm"><i class="fas fa-plus"></i>
Tạo mới đơn hàng</a>
      </div>
      <div class="col-sm-2">
           <a class="btn btn-delete btn-sm pdf-file" type="button" title="In" onclick="myFunction(this)"><i
 class="fas fa-file-pdf"></i> Xuất PDF</a>
      </div>
 </div>
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
            
           <asp:TemplateField HeaderText="Xoá">
       <ItemTemplate>
           <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("order_item_id") %>'
               Text="Xoá" runat="server" OnCommand="Xoa_Click"
               OnClientClick="return confirm('Bạn có chắc xoá không ?')" />
       </ItemTemplate>
               </asp:TemplateField>
                <asp:TemplateField HeaderText="Sửa">
<ItemTemplate>
    <asp:Button ID="capnhat" CommandName="sua" CommandArgument='<%# Bind("order_item_id") %>'
        Text="Cập nhật" runat="server" OnCommand="Sua_Click" />
</ItemTemplate>
                    </asp:TemplateField>          
        </Columns>
    </asp:GridView>
</asp:Content>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Order.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="row element-button">
        <div class="col-sm-2">
            <a class="btn btn-add btn-sm" href="Add.aspx" title="Thêm"><i class="fas fa-plus"></i> Tạo mới đơn hàng</a>
        </div>
        <div class="col-sm-2">
            <a class="btn btn-delete btn-sm pdf-file" type="button" title="In" onclick="myFunction(this)"><i class="fas fa-file-pdf"></i> Xuất PDF</a>
        </div>
    </div>
    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false" DataKeyNames="order_item_id" OnRowDataBound="grdDs_RowDataBound">
        <Columns>
            <asp:BoundField DataField="order_item_id" HeaderText="Mã đơn hàng" />
            <asp:TemplateField HeaderText="Họ Tên">
                <ItemTemplate>
                    <%# Eval("Customer.first_name") + " " + Eval("Customer.last_name") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ảnh">
                <ItemTemplate>
                    <img style="height: 120px" src="../../../images/<%# Eval("Product.image") %>" alt="Alternate Text" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Customer.phone_number" HeaderText="Số điện thoại" />
            <asp:BoundField DataField="Product.SKU" HeaderText="Tên sản phẩm" />
            <asp:BoundField DataField="quantity" HeaderText="Số lượng" />
            <asp:BoundField DataField="Orders.total_price" HeaderText="Tổng tiền" />
            <asp:TemplateField HeaderText="Trạng thái">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        <asp:ListItem Text="Đang xử lý" Attributes-CssStyle="color: orange;" Value="Đang Xử Lý"></asp:ListItem>
                        <asp:ListItem Text="Đã giao" Attributes-CssStyle="color: green;" Value="Đã giao"></asp:ListItem>
                        <asp:ListItem Text="Đã hủy" Attributes-CssStyle="color: red;" Value="Đã hủy"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Xoá">
                <ItemTemplate>
                    <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("order_item_id") %>' Text="Xoá" runat="server" OnCommand="Xoa_Click" OnClientClick="return confirm('Bạn có chắc xoá không ?')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sửa">
                <ItemTemplate>
                    <asp:Button ID="capnhat" CommandName="sua" CommandArgument='<%# Bind("order_item_id") %>' Text="Cập nhật" runat="server" OnCommand="Sua_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>


