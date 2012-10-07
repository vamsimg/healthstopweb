<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="SupplierProducts.aspx.cs" Inherits="HealthStop.Web.manage.Products.SupplierProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>Supplier Product List</h1>

     <span class="shortLeftLabel">Supplier: </span>
          <asp:DropDownList ID="SupplierDropDownList" runat="server" CssClass="textField" DataTextField="name" DataValueField="company_id"></asp:DropDownList>

      

     <asp:Button ID="UpdateButton" runat="server" Text="Show" onclick="UpdateButton_Click" CssClass="textField"  />


     <div class="brclear"></div>          

      <asp:GridView ID="SupplierProductsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="product_code">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			               				
               <asp:BoundField DataField="product_code" HeaderText="Supplier Code" />
			<asp:BoundField DataField="barcode" HeaderText="Barcode" />
               <asp:BoundField DataField="department" HeaderText="Department" />
               <asp:BoundField DataField="brand" HeaderText="Brand" />
               <asp:BoundField DataField="description" HeaderText="Descr" />
               <asp:BoundField DataField="RRP" HeaderText="RRP" DataFormatString="{0:0.00}" />               
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
