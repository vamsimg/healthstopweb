<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="CustomerPurchaseOrders.aspx.cs" Inherits="HealthStop.Web.manage.PurchaseOrders.CustomerPurchaseOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>Purchase Orders</h1>

     <span class="shortLeftLabel">Suppliers: </span>
          <asp:DropDownList ID="SuppliersDropDownList" runat="server" DataTextField="name" DataValueField="company_id" CssClass="textField"  />  
     
          <asp:Button ID="UpdateButton" runat="server" Text="Show" onclick="UpdateButton_Click" CssClass="textField"  />

     <div class="brclear"></div>

     <asp:Button ID="NewPurchaseOrderButton" runat="server" Text="New Purchase Order" onclick="NewPurchaseOrderButton_Click" />
     
     <div class="brclear"></div>

     <h3>New Orders</h3>

     <asp:GridView ID="NewOrdersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="purchaseorder_id">
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
               <asp:BoundField DataField="supplierName" HeaderText="Supplier" />                             

               <asp:TemplateField HeaderText="Delete"> 
				<ItemTemplate>
					<asp:ImageButton ID="DeleteOrderImageButton" AlternateText="Delete Order" runat="server"   ToolTip="Delete Order" ImageUrl="/icons/delete.png" CommandArgument='<%# Eval("purchaseorder_id") %>' CommandName='DeleteOrder' OnCommand="DeleteOrderImageButton_Command" />						
				</ItemTemplate> 
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>	                    
		</Columns>
	</asp:GridView>	

          
     <h3>Submitted Orders</h3>

     <asp:GridView ID="PendingOrdersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="purchaseorder_id">
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
               <asp:BoundField DataField="supplierName" HeaderText="Supplier" />                             
                                  
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
               <asp:BoundField DataField="supplierName" HeaderText="Supplier" />                             
		</Columns>
	</asp:GridView>	


</asp:Content>
