<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="CreateNewCompany.aspx.cs" Inherits="HealthStop.Web.admin.CreateNewCompany" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	<h2>Create a New Company</h2>
	
     <hr id="titleLine" />
	
	<br />
	
	<asp:Label ID="NameLabel" runat="server" Text="* Company Name:" CssClass="leftLabel" AssociatedControlID="NameTextBox"></asp:Label>
		<asp:TextBox ID="NameTextBox" runat="server" Columns="50" MaxLength="50" CssClass="textField"></asp:TextBox>
		<asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="* Please enter a name for your company." ControlToValidate="NameTextBox" Display="dynamic" CssClass="errorMessage" ></asp:RequiredFieldValidator>
	
	<div class="brclear"></div>   
	
     <span class="leftLabel"> * Brand Name </span>
		<asp:TextBox ID="BrandNameTextBox" runat="server" Columns="50" MaxLength="50" CssClass="textField"></asp:TextBox>
		<asp:RequiredFieldValidator ID="BrandNameRequiredFieldValidator" runat="server" ErrorMessage="* Please enter a brand name for your company." ControlToValidate="BrandNameTextBox" Display="dynamic" CssClass="errorMessage" ></asp:RequiredFieldValidator>
	
	<div class="brclear"></div>   
     	
	<span class="leftLabel">ABN</span>
		<asp:TextBox ID="ABNTextBox" runat="server" Columns="20" MaxLength="20" CssClass="textField"></asp:TextBox>
		
	<div class="brclear"></div>   
	
	<asp:Label ID="ContactNameLabel" runat="server" Text="* Contact Name:" CssClass="leftLabel" AssociatedControlID="ContactNameTextBox"></asp:Label>
		<asp:TextBox ID="ContactNameTextBox" runat="server" Columns="50" MaxLength="50" CssClass="textField"></asp:TextBox>
		<asp:RequiredFieldValidator ID="ContactNameRequiredFieldValidator" runat="server" ErrorMessage="* Please enter a contact for your company." ControlToValidate="ContactNameTextBox" Display="dynamic" CssClass="errorMessage" ></asp:RequiredFieldValidator>
	
     <div class="brclear"></div>   
     
     <asp:Label ID="ContactEmailLabel" runat="server" Text="* Contact Email:" CssClass="leftLabel" AssociatedControlID="ContactEmailTextBox"></asp:Label>
		<asp:TextBox ID="ContactEmailTextBox" runat="server" CssClass="textField" Columns="50" MaxLength="50"></asp:TextBox>
		<asp:RequiredFieldValidator ID="ContactEmailRequired" runat="server" ControlToValidate="ContactEmailTextBox" SetFocusOnError="True" ErrorMessage="*An email for the above contact is required" Display="dynamic" CssClass="errorMessage"></asp:RequiredFieldValidator>							   	
		<asp:RegularExpressionValidator ID="ContactEmailRegularExpressionValidator" runat="server" ErrorMessage="The email address is not valid."  CssClass="errorMessage"
			ControlToValidate="ContactEmailTextBox" ValidationExpression="^([a-zA-Z0-9_\-\.+]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" 
			Display="Dynamic">
		</asp:RegularExpressionValidator>
	
	<div class="brclear"></div>    

      
     <span class="leftLabel">* Transaction Email </span>
		<asp:TextBox ID="TransactionEmailTextBox" runat="server" CssClass="textField" Columns="50" MaxLength="50"></asp:TextBox>
		<asp:RequiredFieldValidator ID="TransactionEmailRequiredFieldValidator" runat="server" ControlToValidate="TransactionEmailTextBox" SetFocusOnError="True" ErrorMessage="*An email for the above contact is required" Display="dynamic" CssClass="errorMessage"></asp:RequiredFieldValidator>							   	
		<asp:RegularExpressionValidator ID="TransactionEmailRegularExpressionValidator" runat="server" ErrorMessage="The email address is not valid."  CssClass="errorMessage"
			ControlToValidate="TransactionEmailTextBox" ValidationExpression="^([a-zA-Z0-9_\-\.+]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" 
			Display="Dynamic">
		</asp:RegularExpressionValidator>
	
	<div class="brclear"></div>    
     
     <asp:Label ID="AddressLabel" runat="server" Text="* Address" CssClass="leftLabel" AssociatedControlID="AddressTextBox"></asp:Label>
		<asp:TextBox ID="AddressTextBox" runat="server" Columns="30" MaxLength="100" Rows="3" TextMode="MultiLine" CssClass="textField"></asp:TextBox>
	     <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" ControlToValidate="AddressTextBox" SetFocusOnError="True" ErrorMessage="*An mailing or physical address is required" Display="dynamic" CssClass="errorMessage"></asp:RequiredFieldValidator>							   	
		
	<div class="brclear"></div> 
			
	<asp:Label ID="SuburbLabel" runat="server" Text="* Suburb:" CssClass="leftLabel" AssociatedControlID="SuburbTextBox"></asp:Label>
		<asp:TextBox ID="SuburbTextBox" runat="server" Columns="30" MaxLength="50" CssClass="textField"></asp:TextBox>
		<asp:RequiredFieldValidator ID="SuburbRequiredFieldValidator" runat="server" ControlToValidate="SuburbTextBox" SetFocusOnError="True" ErrorMessage="*A suburb is required" Display="dynamic" CssClass="errorMessage"></asp:RequiredFieldValidator>							   	
			
	<div class="brclear"></div>   			
	
	<asp:Label ID="StateLabel" runat="server" Text="* State:" CssClass="leftLabel" AssociatedControlID="StateDropDownList"></asp:Label>
		<asp:DropDownList ID="StateDropDownList" runat="server" CssClass="textField" >
			<asp:ListItem>NSW</asp:ListItem>
			<asp:ListItem>VIC</asp:ListItem>
			<asp:ListItem>QLD</asp:ListItem>
			<asp:ListItem>SA</asp:ListItem>
			<asp:ListItem>ACT</asp:ListItem>
			<asp:ListItem>TAS</asp:ListItem>
			<asp:ListItem>WA</asp:ListItem>
			<asp:ListItem>NT</asp:ListItem>
		</asp:DropDownList>
	
	<div class="brclear"></div>   			
	
						
	<asp:Label ID="PostcodeLabel" runat="server" Text="* Postcode:" CssClass="leftLabel" AssociatedControlID="PostcodeTextBox"></asp:Label>
		<asp:TextBox ID="PostcodeTextBox" runat="server" Columns="4" MaxLength="4" CssClass="textField"></asp:TextBox>
		<asp:RegularExpressionValidator ID="PostcodeRegularExpressionValidator" runat="server" ErrorMessage="Postcode must be a number" Display="Dynamic" ValidationExpression="\d{4}" ControlToValidate="PostcodeTextBox" ValidationGroup="Details"></asp:RegularExpressionValidator>
	     <asp:RequiredFieldValidator ID="PostcodeRequiredFieldValidator" runat="server" ControlToValidate="PostcodeTextBox" SetFocusOnError="True" ErrorMessage="*A postcode is required" Display="dynamic" CssClass="errorMessage"></asp:RequiredFieldValidator>							   	
	
	<div class="brclear"></div>   			
	
	<asp:Label ID="PhoneNumberLabel" runat="server" Text="* Phone Number:" CssClass="leftLabel" AssociatedControlID="PhoneTextBox"></asp:Label>
		<asp:TextBox ID="PhoneTextBox" runat="server" Columns="15" MaxLength="15" CssClass="textField" ></asp:TextBox>
		<asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="* Please enter a phone number for the organisation." ControlToValidate="PhoneTextBox" Display="dynamic" CssClass="errorMessage" ></asp:RequiredFieldValidator>
		
	<div class="brclear"></div> 
	
	<div class="brclear"></div> 
	<br />	
	<asp:Label ID="WebsiteLabel" runat="server" Text="Company Website:" CssClass="leftLabel" AssociatedControlID="WebsiteTextBox"></asp:Label>
		<asp:TextBox ID="WebsiteTextBox" runat="server" Columns="85" MaxLength="100" CssClass="textField"></asp:TextBox>
		
	<div class="brclear"></div>  
	
     <span class="leftLabel">Company Type</span>
          <asp:RadioButtonList ID="CompanyTypeRadioButtonList" runat="server">
               <asp:ListItem Value="Retailer">Retailer</asp:ListItem>
               <asp:ListItem Value="Supplier">Supplier</asp:ListItem>
               <asp:ListItem Value="Manufacturer">Manufacturer</asp:ListItem>
          </asp:RadioButtonList>

	<asp:Button ID="CreateCompanyButton" runat="server" Text="Create Company" onclick="CreateCompanyButton_Click"/>
	
	<div class="brclear"></div> 

	<asp:Label ID="CreateCompanyErrorLabel" runat="server" Text="" CssClass="errorMessage"></asp:Label>
	



</asp:Content>

