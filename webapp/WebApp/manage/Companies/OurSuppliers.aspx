<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="OurSuppliers.aspx.cs" Inherits="HealthStop.Web.manage.Companies.OurSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

      <h1>Our Suppliers</h1>

      <asp:GridView ID="OurSuppliersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="company_id">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
               <asp:HyperLinkField DataNavigateUrlFields="company_id" ItemStyle-CssClass="action"
						DataTextFormatString ="{0:G}"
						DataNavigateUrlFormatString="~/manage/Companies/ViewSupplier.aspx?company_id={0}"
						Text="View"/>							
			<asp:BoundField DataField="name" HeaderText="Name" />
               <asp:BoundField DataField="contact_name" HeaderText="Contact" />					
			<asp:BoundField DataField="suburb" HeaderText="Suburb" />					
               <asp:BoundField DataField="state" HeaderText="State" />                  
                <asp:BoundField DataField="localPOSSupplierCode" HeaderText="POS Code" /> 
               
		</Columns>
	</asp:GridView>	


     <h2></h2>

     <asp:GridView ID="AvailableSuppliersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="company_id">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
               <asp:HyperLinkField DataNavigateUrlFields="company_id" ItemStyle-CssClass="action"
						DataTextFormatString ="{0:G}"
						DataNavigateUrlFormatString="~/manage/Comapanies/ViewCompany.aspx?company_id={0}"
						Text="View"/>							
			<asp:BoundField DataField="name" HeaderText="Name" />
               <asp:BoundField DataField="contact_name" HeaderText="Contact" />					
			<asp:BoundField DataField="suburb" HeaderText="Suburb" />					
               <asp:BoundField DataField="state" HeaderText="State" />                  
              
               
		</Columns>
	</asp:GridView>

</asp:Content>
