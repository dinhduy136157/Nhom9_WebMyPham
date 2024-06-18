<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Website_MyPham.View.Admin.Category.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   <div class="row">
     <div class="col-md-12">
           <div class="tile">
               <h3 class="tile-title">Tạo mới loại hàng</h3>
               <div class="tile-body">
                   <div class="row element-button">
                      <%-- <div class="col-sm-2">
                           <a class="btn btn-add btn-sm" data-toggle="modal" data-target="#exampleModalCenter"><b><i
                                class="fas fa-folder-plus"></i>Tạo chức vụ mới</b></a>
                       </div>--%>
                   </div>
                   
                          <div class="form-group col-md-4">
                               <label class="control-label">Tên</label>
                               <input class="form-control" type="text" name="ten" required>
                          </div>
                       
                          <asp:Button ID="btnThem" CssClass="btn btn-save" runat="server" Text="Thêm loại hàng" OnClick="btnThem_Click" />
                         <%-- <asp:Button ID="btn btn-cancel"  runat="server" Text="Hủy bỏ" PostBackUrl="~/View/Admin/Customer/Index.aspx" />--%>
                    
               </div>
                <a class="btn btn-cancel" href="Index.aspx">Hủy bỏ</a>
           </div>
     </div>
</div>
</asp:Content>
