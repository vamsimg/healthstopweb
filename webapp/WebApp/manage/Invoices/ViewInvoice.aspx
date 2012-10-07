<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="ViewInvoice.aspx.cs" Inherits="HealthStop.Web.manage.Invoices.ViewInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>View Invoice</h1>
     
     <span class="leftLabel">Original PO: </span>
          <asp:HyperLink ID="POHyperLink" runat="server" CssClass="textField">View</asp:HyperLink>
     <div class="brclear"></div> 

     <span class="leftLabel">Status: </span>     
          <asp:Label ID="StatusLabel" runat="server" CssClass="textField" />

     <div class="brclear"></div> 
     
     <span class="leftLabel">Local Code/ID: </span>
          <asp:Label ID="LocalCodeLabel" runat="server" Text="" CssClass="textField"></asp:Label>
     
     <div class="brclear"></div>   
     
     <span class="leftLabel">Customer</span>
          <asp:Label ID="CustomerLabel" runat="server" Text="" CssClass="textField"></asp:Label>


     <div class="brclear"></div>        

     <span class="leftLabel">Supplier</span>
          <asp:Label ID="SupplierLabel" runat="server" Text="" CssClass="textField"></asp:Label>

     <div class="brclear"></div>
     
     <span class="leftLabel">Date: </span>
          <asp:Label ID="DateLabel" runat="server" CssClass="textField"></asp:Label>

      <div class="brclear"></div>        

     <span class="leftLabel">Freight</span>
          <asp:Label ID="FrieghtLabel" runat="server" Text="" CssClass="textField"></asp:Label>

      <div class="brclear"></div>        

     <span class="leftLabel">Tax</span>
          <asp:Label ID="TaxLabel" runat="server" Text="" CssClass="textField"></asp:Label>

      <div class="brclear"></div>        

     <span class="leftLabel">Total</span>
          <asp:Label ID="TotalLabel" runat="server" Text="" CssClass="textField"></asp:Label>


     <div class="brclear"></div>

     <asp:GridView ID="InvoiceItemsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="product_code">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			            						
               <asp:BoundField DataField="product_code" HeaderText="Product Code" />
               <asp:BoundField DataField="barcode" HeaderText="Barcode" />
			<asp:BoundField DataField="description" HeaderText="Description" />
               <asp:BoundField DataField="cost_price" HeaderText="Price" DataFormatString="{0:0.00}" />					
			<asp:BoundField DataField="quantity" HeaderText="Quantity" />					
               <asp:BoundField DataField="RRP" HeaderText="RRP" DataFormatString="{0:0.00}" />					
			<asp:BoundField DataField="is_GST" HeaderText="GST ?"  />					                                  
		</Columns>
	</asp:GridView>   


</asp:Content>
