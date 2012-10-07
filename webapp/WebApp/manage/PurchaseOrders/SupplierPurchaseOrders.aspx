<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="SupplierPurchaseOrders.aspx.cs" Inherits="HealthStop.Web.manage.PurchaseOrders.SupplierPurchaseOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>Purchase Orders</h1>

     <span class="shortLeftLabel">Customers: </span><asp:DropDownList ID="CustomersDropDownList" runat="server" DataTextField="name" DataValueField="company_id"  CssClass="textField" />
          <asp:Button ID="UpdateButton" runat="server" Text="Show" onclick="UpdateButton_Click" CssClass="textField"  />

     <div class="brclear"></div>


    
     <h3>Submitted Orders</h3>

     <asp:GridView ID="PendingOrdersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="purchaseorder_id">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
               <asp:HyperLinkField DataNavigateUrlFields="purchaseorder_id" ItemStyle-CssClass="action"
						DataTextFormatString ="{0:G}"
						DataNavigateUrlFormatString="~/manage/PurchaseOrders/ViewPurchaseOrder.aspx?purchaseorder_id={0}"
						Text="View">			
                              <ItemStyle CssClass="action"></ItemStyle>
               </asp:HyperLinkField>
			<asp:BoundField DataField="purchaseorder_id" HeaderText="ID"/>			
               <asp:BoundField DataField="local_code" HeaderText="POS Code"/>	
			<asp:BoundField DataField="person" HeaderText="Person" />
               <asp:BoundField DataField="itemCount" HeaderText="Total Items" />					
			<asp:BoundField DataField="creation_datetime" HeaderText="Date" />					
                <asp:TemplateField HeaderText="Invoice"> 
				<ItemTemplate>
					<asp:ImageButton ID="CreateInvoiceImageButton" AlternateText="Create Invoice" runat="server"   ToolTip="Create Invoice" ImageUrl="/icons/add.png" CommandArgument='<%# Eval("purchaseorder_id") %>' CommandName='CreateInvoice' OnCommand="CreateInvoiceImageButton_Command" />						
				</ItemTemplate> 
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>	                    
                                  
		</Columns>
	</asp:GridView>	


     <h3>Fulfilled Orders</h3>

     <asp:GridView ID="FulfilledOrderGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="purchaseorder_id">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
               <asp:HyperLinkField DataNavigateUrlFields="purchaseorder_id" ItemStyle-CssClass="action"
						DataTextFormatString ="{0:G}"
						DataNavigateUrlFormatString="~/manage/PurchaseOrders/ViewPurchaseOrder.aspx?purchaseorder_id={0}"
						Text="View"/>			
			<asp:BoundField DataField="purchaseorder_id" HeaderText="ID"/>	
               <asp:BoundField DataField="local_code" HeaderText="POS Code"/>		
			<asp:BoundField DataField="person" HeaderText="Person" />
               <asp:BoundField DataField="itemCount" HeaderText="Total Items" />					
			<asp:BoundField DataField="creation_datetime" HeaderText="Date" />					
               
		</Columns>
	</asp:GridView>	

</asp:Content>
