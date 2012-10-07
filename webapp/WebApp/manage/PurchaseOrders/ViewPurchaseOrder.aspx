<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="ViewPurchaseOrder.aspx.cs" Inherits="HealthStop.Web.manage.PurchaseOrders.ViewPurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     
     <h1>View Purchase Order</h1>

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

     <span class="leftLabel">Submitter: </span>
          <asp:Label ID="SubmitterLabel" runat="server" CssClass="textField"></asp:Label>

     <div class="brclear"></div>
     


     <asp:Button ID="SubmitButton" runat="server" Text="Submit Order" onclick="SubmitButton_Click" Visible="false" />
            <asp:Label ID="SubmitErrorLabel" runat="server" CssClass="errorMessage"  EnableViewState="false"></asp:Label>
     
     
     <asp:Panel ID="FindProductPanel" runat="server" Visible="false">

          <h2>Find Product </h2>

          <span class="leftLabel">Barcode: </span>
               <asp:TextBox ID="BarcodeTextBox" runat="server" CssClass="textField"></asp:TextBox>
     
          <asp:Button ID="FindButton" runat="server" Text="Find" CssClass="textField" onclick="FindButton_Click" />
              
          <div class="brclear"></div>

          <span class="leftLabel">Description: </span>
                <asp:Label ID="DescriptionLabel" runat="server" CssClass="textField"></asp:Label>

          <div class="brclear"></div>

          <span class="leftLabel">Costs : </span>
                <asp:Label ID="CostsLabel" runat="server" CssClass="textField" ></asp:Label>

          <div class="brclear"></div>

          <span class="leftLabel">Quantity: </span>
               <asp:TextBox ID="QuantityTextBox" runat="server" CssClass="textField" ValidationGroup="Quantity"></asp:TextBox>
                    
          <asp:Button ID="CalculateButton" runat="server" Text="Calculate Cost" CssClass="textField" onclick="CalculateButton_Click" ValidationGroup="Quantity"  />
                   <asp:RangeValidator ID="QuantityRangeValidator" runat="server" ErrorMessage="Number must be greater than 0" ControlToValidate="QuantityTextBox" MaximumValue="10000" MinimumValue="0" Type="Double" ValidationGroup="Quantity" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="QuantityTextBoxRequiredFieldValidator" ControlToValidate="QuantityTextBox" runat="server" ErrorMessage="Enter a value between 0 and 10000" ValidationGroup="Quantity" Display="Dynamic"></asp:RequiredFieldValidator>

          <div class="brclear"></div>

          <span class="leftLabel">Final Costs: </span>
                <asp:Label ID="FinalCostLabel" runat="server" CssClass="textField"></asp:Label> 

          <div class="brclear"></div>

          <asp:Button ID="AddProductButton" runat="server" Text="Add to Order" CssClass="textField" onclick="AddProductButton_Click" ValidationGroup="Quantity" /> 
     
          <asp:Label ID="AddProductsErrorLabel" runat="server" CssClass="errorMessage"  EnableViewState="false"></asp:Label>
     
           <div class="brclear"></div>

     </asp:Panel>
     
     <h2>Current Order Items</h2>

     
     <span class="leftLabel">Current Order Total: </span>
          <asp:Label ID="TotalLabel" runat="server" CssClass="textField" ></asp:Label> 

     <div class="brclear"></div>

     <asp:GridView ID="EditableOrderItemsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="product_code">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
            						
			<asp:BoundField DataField="description" HeaderText="Description" />
               <asp:BoundField DataField="cost_price" HeaderText="Price" DataFormatString="{0:0.00}" />					
			<asp:BoundField DataField="quantity" HeaderText="Quantity"  />					
               <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:0.00}" />					
               
               <asp:TemplateField HeaderText="Delete"> 
				<ItemTemplate>
					<asp:ImageButton ID="DeleteItemImageButton" AlternateText="Remove Item" runat="server"   ToolTip="Remove Item" ImageUrl="/icons/delete.png" CommandArgument='<%# Eval("product_code") %>' CommandName='DeleteItem' OnCommand="DeleteItemImageButton_Command" />						
				</ItemTemplate> 
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>	     
               
		</Columns>
	</asp:GridView>   

     <asp:GridView ID="FrozenOrderItemsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="product_code">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
            						
			<asp:BoundField DataField="description" HeaderText="Description" />
               <asp:BoundField DataField="cost_price" HeaderText="Price" DataFormatString="{0:0.00}" />					
			<asp:BoundField DataField="quantity" HeaderText="Quantity" />					
               <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:0.00}" />					         
            
               
		</Columns>
	</asp:GridView>   


     <h2>Attached Invoices</h2>
     
     <asp:GridView ID="InvoicesGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="invoice_id">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
                 <asp:HyperLinkField DataNavigateUrlFields="invoice_id" ItemStyle-CssClass="action"
				     DataTextFormatString ="{0:G}"
				     DataNavigateUrlFormatString="~/manage/Invoices/ViewInvoice.aspx?invoice_id={0}"
				     Text="View">			
                         <ItemStyle CssClass="action"></ItemStyle>
               </asp:HyperLinkField>            												
               <asp:BoundField DataField="creation_datetime" HeaderText="Date" />					
			<asp:BoundField DataField="itemCount" HeaderText="# Items" />					
               <asp:BoundField DataField="tax" HeaderText="Tax" DataFormatString="{0:0.00}"/>					         
               <asp:BoundField DataField="freight" HeaderText="Frieght" DataFormatString="{0:0.00}" />					         
               <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:0.00}" />

		</Columns>
	</asp:GridView>   

     <h3>EDI</h3>

     <asp:Literal ID="XMLLiteral" runat="server" Mode="Encode"></asp:Literal>

</asp:Content>
