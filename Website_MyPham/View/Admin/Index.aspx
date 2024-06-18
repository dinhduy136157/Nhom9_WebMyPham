<%--<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <h2>Đây là site thống kê</h2>
</asp:Content>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website_MyPham.View.Admin.Index" ResponseEncoding="utf-8"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
      <div class="col-sm-2">
    <asp:Button ID="btnExportPdf" runat="server" Text="Xuất PDF" CssClass="btn btn-delete btn-sm pdf-file" OnClick="ExportToPdf_Click"/>
    </div>
    <div style="margin-bottom: 20px;">
        <h3 style="color: #337ab7;">Thống kê theo ngày</h3>
        <asp:GridView ID="grdDailyStatistics" runat="server" AutoGenerateColumns="false" 
            CssClass="table table-bordered table-striped">
            <HeaderStyle BackColor="#5cb85c" ForeColor="white" />
            <RowStyle BackColor="#f9f9f9" />
            <AlternatingRowStyle BackColor="#e9ecef" />
            <Columns>
                <asp:BoundField DataField="OrderDate" HeaderText="Ngày đặt hàng" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="OrderCount" HeaderText="Số lượng đơn hàng" />
                <asp:BoundField DataField="TotalRevenue" HeaderText="Tổng doanh thu" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin-bottom: 20px;">
        <h3 style="color: #337ab7;">Thống kê theo tháng</h3>
        <asp:GridView ID="grdMonthlyStatistics" runat="server" AutoGenerateColumns="false" 
            CssClass="table table-bordered table-striped">
            <HeaderStyle BackColor="#5bc0de" ForeColor="white" />
            <RowStyle BackColor="#f9f9f9" />
            <AlternatingRowStyle BackColor="#e9ecef" />
            <Columns>
                <asp:BoundField DataField="OrderYear" HeaderText="Năm" />
                <asp:BoundField DataField="OrderMonth" HeaderText="Tháng" />
                <asp:BoundField DataField="OrderCount" HeaderText="Số lượng đơn hàng" />
                <asp:BoundField DataField="TotalRevenue" HeaderText="Tổng doanh thu" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin-bottom: 20px;">
        <h3 style="color: #337ab7;">Thống kê theo năm</h3>
        <asp:GridView ID="grdYearlyStatistics" runat="server" AutoGenerateColumns="false" 
            CssClass="table table-bordered table-striped">
            <HeaderStyle BackColor="#f0ad4e" ForeColor="white" />
            <RowStyle BackColor="#f9f9f9" />
            <AlternatingRowStyle BackColor="#e9ecef" />
            <Columns>
                <asp:BoundField DataField="OrderYear" HeaderText="Năm" />
                <asp:BoundField DataField="OrderCount" HeaderText="Số lượng đơn hàng" />
                <asp:BoundField DataField="TotalRevenue" HeaderText="Tổng doanh thu" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


