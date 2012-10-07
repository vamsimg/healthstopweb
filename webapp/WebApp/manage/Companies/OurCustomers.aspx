<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="OurCustomers.aspx.cs" Inherits="HealthStop.Web.manage.Companies.OurCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <h1>Our Customers</h1>

    
     <h2>Give Access to Customer</h2>

     <i>This will give access to the retailer to place orders and view your product list.</i>


     <span class="shortLeftLabel">ABN: </span>
          <asp:TextBox ID="ABNTextBox" runat="server" Columns="20" MaxLength="20" CssClass="textField"></asp:TextBox>
          <asp:RequiredFieldValidator ID="ABNTextboxRequiredFieldValidator" runat="server" ErrorMessage="ABN Required" CssClass="errorMessage" ControlToValidate="ABNTextBox" Display="Dynamic" ValidationGroup ="GiveAccess" ></asp:RequiredFieldValidator>

     <div class="brclear"></div>

     <span class="shortLeftLabel">Account Number: </span>
          <asp:TextBox ID="AccountNumberTextBox" runat="server" Columns="20" MaxLength="20" CssClass="textField" ></asp:TextBox>
          <asp:RequiredFieldValidator ID="AccountNumberRequiredFieldValidator" runat="server" ErrorMessage="Account Number Required" CssClass="errorMessage" ControlToValidate="AccountNumberTextBox" Display="Dynamic" ValidationGroup ="GiveAccess" ></asp:RequiredFieldValidator>

     <div class="brclear"></div>

     <span class="shortLeftLabel">Is Member ?</span>
          <asp:RadioButtonList ID="MemberRadioButtonList" runat="server">
               <asp:ListItem Value="True">True</asp:ListItem>
               <asp:ListItem Value="False">False</asp:ListItem>
          </asp:RadioButtonList>

     <div class="brclear"></div>

     <asp:Button ID="GiveAccessButton" runat="server" Text="Give Access" onclick="GiveAccessButton_Click" ValidationGroup ="GiveAccess" />
          <asp:Label ID="GiveAccessErrorLabel" runat="server" Text="" CssClass="errorMessage" EnableViewState="false"></asp:Label>

     <div class="brclear"></div>

     <br />
     <br />


      <asp:GridView ID="CustomersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="company_id">
          <EmptyDataTemplate>None</EmptyDataTemplate>
		<Columns>			
               <asp:HyperLinkField DataNavigateUrlFields="company_id" ItemStyle-CssClass="action"
						DataTextFormatString ="{0:G}"
						DataNavigateUrlFormatString="~/manage/Companies/ViewCompany.aspx?company_id={0}"
						Text="View"/>		
                              					
               <asp:BoundField DataField="company_number" HeaderText="ABN" />               
			<asp:BoundField DataField="name" HeaderText="Name" />
               <asp:BoundField DataField="contact_name" HeaderText="Contact" />					
			<asp:BoundField DataField="suburb" HeaderText="Suburb" />					
               <asp:BoundField DataField="state" HeaderText="State" />     
               
               <asp:TemplateField HeaderText="Delete"> 
				<ItemTemplate>
					<asp:ImageButton ID="DeletePermissionImageButton" AlternateText="Remove Access" runat="server"   ToolTip="Remove Access" ImageUrl="/icons/delete.png" CommandArgument='<%# Eval("company_id") %>' CommandName='DeletePermission' OnCommand="DeletePermissionImageButton_Command" />						
				</ItemTemplate> 
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>	     
               
		</Columns>
	</asp:GridView>	

</asp:Content>
