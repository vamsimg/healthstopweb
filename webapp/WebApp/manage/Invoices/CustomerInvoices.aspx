<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="CustomerInvoices.aspx.cs" Inherits="HealthStop.Web.manage.Invoices.CustomerInvoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>Our Invoices</h1>

     <asp:GridView ID="InvoicesGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="invoice_id">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
                 <asp:HyperLinkField DataNavigateUrlFields="invoice_id" ItemStyle-CssClass="action"
				     DataTextFormatString ="{0:G}"
				     DataNavigateUrlFormatString="~/manage/Invoices/ViewInvoice.aspx?invoice_id={0}"
				     Text="View">			
                         <ItemStyle CssClass="action"></ItemStyle>
               </asp:HyperLinkField>            												
               <asp:BoundField DataField="supplierName" HeaderText="Supplier" />					
               <asp:BoundField DataField="creation_datetime" HeaderText="Date" />					
			<asp:BoundField DataField="itemCount" HeaderText="# Items" />					
               <asp:BoundField DataField="tax" HeaderText="Tax" />					         
               <asp:BoundField DataField="freight" HeaderText="Frieght" />					         
               <asp:BoundField DataField="total" HeaderText="Total" />
               <asp:BoundField DataField="is_downloaded" HeaderText="DLed?" />


		</Columns>
	</asp:GridView>   

</asp:Content>
