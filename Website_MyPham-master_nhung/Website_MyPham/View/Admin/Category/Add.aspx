<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Website_MyPham.View.Admin.Category.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <h2>Them loai hang</h2>
    <p>
             <label>Ma loai</label>
             <asp:TextBox ID="txtcategory_id" runat="server" Enabled="false" />
    
     </p>

     <p>
              <label>Ten loai</label>
              <asp:TextBox ID="txtname" runat="server"/>
    </p>


    <p>
              <asp:Button ID="btnThem" runat="server" Text="Them loai hang" OnClick="btnThem_Click" />
              <asp:Button ID="btnReturnDS" runat="server" Text="Return" PostBackUrl="~/Index.aspx" />

    </p>


    <p>
             <asp:Label ID="msg" runat="server" Font-Italic="true" />
    </p>

</asp:Content>
