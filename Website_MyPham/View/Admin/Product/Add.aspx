<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Website_MyPham.View.Admin.Product.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

        <div class="row">
     <div class="col-md-12">
           <div class="tile">
               <h3 class="tile-title">Tạo mới sản phẩm</h3>
               <div class="tile-body">
                   <div class="row element-button">
                      <%-- <div class="col-sm-2">
                           <a class="btn btn-add btn-sm" data-toggle="modal" data-target="#exampleModalCenter"><b><i
                                class="fas fa-folder-plus"></i>Tạo chức vụ mới</b></a>
                       </div>--%>
                   </div>
                    
                          <div class="form-group col-md-4">
                               <label class="control-label">Mã vạch</label>
                               <input class="form-control" type="text" name="maVach" required>
                          </div>
                         <div class="form-group col-md-4">
                              <label class="control-label">Mô tả</label>
                             <input class="form-control" type="text" name="moTa" required>
                         </div>
                         <div class="form-group col-md-4">
                              <label class="control-label">Đơn giá</label>
                             <input class="form-control" type="text" name="donGia" required>
                         </div>
                          <div class="form-group col-md-4">
                                <label class="control-label">Trạng thái</label>
                                <input class="form-control" type="text" name="trangThai" required>
                          </div>
                         <div class="form-group col-md-4">
                             <label class="control-label">Mã loại</label>
                             <input class="form-control" type="text" name="maLoai" required>
                         </div>
                         <div class="form-group col-md-4">
                              <label class="control-label">Ảnh</label>
                              <input class="form-control" type="file" name="anh" accept="image/*" required>
                             <div class="col-md-4">
                                <img id="imagePreview" src="#" alt="Ảnh xem trước" style="max-width: 100%; max-height: 200px;">
                            </div>
                         </div>
                          <asp:Button ID="btnThem" CssClass="btn btn-save" runat="server" Text="Thêm sản phẩm" OnClick="btnThem_Click" />
                         <%-- <asp:Button ID="btn btn-cancel"  runat="server" Text="Hủy bỏ" PostBackUrl="~/View/Admin/Customer/Index.aspx" />--%>
                  
               </div>
                <a class="btn btn-cancel" href="Index.aspx">Hủy bỏ</a>
           </div>
     </div>
</div>
<script>
    function previewImage(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function(e) {
                var preview = document.getElementById('imagePreview');
                preview.src = e.target.result;
            };
            reader.readAsDataURL(input.files[0]);
        }
    }
</script>
</asp:Content>
