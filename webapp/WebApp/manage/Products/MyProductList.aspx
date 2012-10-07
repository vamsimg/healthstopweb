<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="MyProductList.aspx.cs" Inherits="HealthStop.Web.manage.Products.MyProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>My Product List</h1>

     <a href="/manage/Products/UpdateSupplierProductList.aspx">Upload Latest List</a>

     <br />
     <br />

     <i>All prices are GST exclusive</i>

     <asp:GridView ID="SupplierProductsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="product_code">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			               				
			  <asp:BoundField DataField="product_code" HeaderText="Supplier Code" />
			<asp:BoundField DataField="barcode" HeaderText="Barcode" />
               <asp:BoundField DataField="department" HeaderText="Department" />
               <asp:BoundField DataField="brand" HeaderText="Brand" />
               <asp:BoundField DataField="description" HeaderText="Descr" />
               <asp:BoundField DataField="RRP" HeaderText="RRP" DataFormatString="{0:0.00}" />    
               <asp:BoundField DataField="is_GST" HeaderText="GST ?" DataFormatString="{0:0.00}" />    
			<asp:BoundField DataField="wholesale_price" HeaderText="Wholesale" DataFormatString="{0:0.00}" />					
               <asp:BoundField DataField="member_price" HeaderText="Member Price" DataFormatString="{0:0.00}" />					
               <asp:BoundField DataField="range1_min_quantity" HeaderText="R1 Min Q" />					
               <asp:BoundField DataField="range1_price" HeaderText="R1 Price" DataFormatString="{0:0.00}" />					
               <asp:BoundField DataField="range2_min_quantity" HeaderText="R2 Min Q" />					
               <asp:BoundField DataField="range2_price" HeaderText="R2 Price" DataFormatString="{0:0.00}" />					
               <asp:BoundField DataField="range3_min_quantity" HeaderText="R3 Min Q" />					
               <asp:BoundField DataField="range3_price" HeaderText="R3 Price" DataFormatString="{0:0.00}" />	
                 
		</Columns>
	</asp:GridView>	
</asp:Content>
