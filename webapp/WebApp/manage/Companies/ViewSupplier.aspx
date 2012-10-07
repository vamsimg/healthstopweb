<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="ViewSupplier.aspx.cs" Inherits="HealthStop.Web.manage.Companies.ViewSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>View Supplier</h1>

      <h1><asp:Literal ID="CompanyNameLiteral" runat="server"></asp:Literal></h1>     

     <asp:Label ID="AccessAvailableLabel" runat="server" Text="You have access to this supplier's product lise and ordering system."></asp:Label>
     
     <asp:Panel ID="SupplierPanel" runat="server" Visible="false" Enabled="false">

          <h3>Request access to this Supplier's Product List</h3>

          <asp:Button ID="RequestAccessButton" runat="server" Text="Request Access" onclick="RequestAccessButton_Click" />            
               
           <asp:Label ID="RequestAccessErrorLabel" runat="server" Text="" EnableViewState="false"></asp:Label>
    

     </asp:Panel>

	<div id="detatilsPanel" style="float:left;">

		<asp:Label ID="NameLabel" runat="server" Text=" Company Name:" CssClass="leftLabel" ></asp:Label>
			<asp:Label ID="NameFieldLabel" runat="server" CssClass="textField"></asp:Label>
			
		<div class="brclear"></div>   
				
		<span class="leftLabel">Company Number(ABN): </span>
			<asp:Label ID="ABNFieldLabel" runat="server" CssClass="textField"></asp:Label>		

		<div class="brclear"></div>   
		
		<asp:Label ID="ContactNameLabel" runat="server" Text=" Contact Name:" CssClass="leftLabel"></asp:Label>
			<asp:Label ID="ContactNameFieldLabel" runat="server" CssClass="textField"></asp:Label>
		<div class="brclear"></div>   
	     
		<asp:Label ID="ContactEmailLabel" runat="server" Text=" Email:" CssClass="leftLabel"></asp:Label>
			<asp:Label ID="ContactEmailFieldLabel" runat="server" CssClass="textField"></asp:Label>
		
		<div class="brclear"></div>    
	     
		<asp:Label ID="AddressLabel" runat="server" Text=" Address" CssClass="leftLabel"></asp:Label>
			<asp:Label ID="AddressFieldLabel" runat="server" CssClass="textField"></asp:Label>	
		<div class="brclear"></div> 
				
		<asp:Label ID="SuburbLabel" runat="server" Text=" Suburb:" CssClass="leftLabel"></asp:Label>
			<asp:Label ID="SuburbFieldLabel" runat="server" CssClass="textField"></asp:Label>	
		<div class="brclear"></div>   			
		
		<asp:Label ID="StateLabel" runat="server" Text=" State:" CssClass="leftLabel"></asp:Label>
			<asp:Label ID="StateFieldLabel" runat="server" CssClass="textField"></asp:Label>
		<div class="brclear"></div>   			
		
							
		<asp:Label ID="PostcodeLabel" runat="server" Text=" Postcode:" CssClass="leftLabel"></asp:Label>
			<asp:Label ID="PostcodeFieldLabel" runat="server" CssClass="textField"></asp:Label>
		<div class="brclear"></div>   			
		
		<asp:Label ID="PhoneNumberLabel" runat="server" Text=" Phone Number:" CssClass="leftLabel"></asp:Label>
			<asp:Label ID="PhoneFieldLabel" runat="server" CssClass="textField"></asp:Label>
		<div class="brclear"></div> 
	
	     <div class="brclear"></div> 
		<br />	
		<asp:Label ID="WebsiteLabel" runat="server" Text="Company Website:" CssClass="leftLabel" ></asp:Label>
			<asp:Label ID="WebsiteFieldLabel" runat="server" CssClass="textField"></asp:Label>

		<div class="brclear"></div> 

	</div>





</asp:Content>
