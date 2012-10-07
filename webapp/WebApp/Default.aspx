﻿<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true"   CodeBehind="Default.aspx.cs" Inherits="HealthStop.Web._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DocketPlace Marketing</title>
	<link rel="stylesheet" type="text/css" href="css/navbar.css" />
	<link rel="stylesheet" type="text/css" href="css/frontpage.css" />    
	
</head>
<body>
    <form id="form1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


	<div id="header"> 
		<a href ="/Default.aspx"><img src="/images/logo.png" alt="logo" id="logo" /></a>         
          <asp:Panel ID="NotLoggedInNavbarPanel" runat="server">
              
                <ul id="topNavBar0">
                    <li><a href="/HowItWorks.aspx">How does it work?</a></li>
				<li><a href="/Pricing.aspx">Pricing</a></li>						
				<li><a href="/Partners.aspx">Partners</a></li>
                    <li><a href="/ContactUs.aspx">Contact Us</a></li>				
				<li>	<a href="/Login.aspx">Login</a></li>
               </ul>            
          </asp:Panel>


          <asp:Panel ID="TopNavPanel" runat="server" Visible="false">               
               <ul id="topNavBar1">
                    <li><a href="/Default.aspx">Home</a></li>
                    <li><a href="/HowItWorks.aspx" >How does it work?</a></li>
                    <li><a href="/AboutUs.aspx">About Us</a></li>
                    <li><a href="/FAQ.aspx">Help and FAQ</a></li>			
                    <li><a href="/ContactUs.aspx">Contact Us</a></li>					
               </ul>             
          </asp:Panel>          
              
          <asp:Panel ID="MiddleNavPanel" runat="server" Visible="false">
               <ul id="middleNavBar1">
                    <li>
					<a href="/manage/SelectCompany.aspx">My Company</a>
					<ul>
                              <li><a href="/manage/Items/InventoryHome.aspx">Inventory</a></li>
                              <li><a href="/manage/PurchaseOrders/PurchaseOrdersHome.aspx">Purchase Orders</a></li>
                              <li><a href="/manage/ReceivedGoods/ReceivedGoodsHome.aspx">Received Goods</a></li>
						<li><a href="/manage/Stores/Stores.aspx">Stores</a></li>
						<li><a href="/manage/Admins/Admins.aspx">Admins</a></li>
						<li><a href="/manage/Companies/UpdateCompanyCompany.aspx">Details</a></li>		
					</ul>
				</li>					
                    <li>
					<a href="/manage/Account/MyAccount.aspx">My Account</a>
					<ul>
						<li><a href="/manage/Account/UpdateDetails.aspx">My Details</a></li>
						<li><a href="/manage/Account/UpdateEmail.aspx">Update Email</a></li>
						<li><a href="/manage/Account/UpdatePassword.aspx">Update Password</a></li>
						
					</ul>
				</li>                        
               </ul>                      
          </asp:Panel>

		<div class="brclear"></div>
	</div>	


	<div id="frontpageContent">
		<br />		

		<h1 style="text-align:center">HealthStop EDI</h1>

        	
	</div>
	
	
		
		
     <div id="footer">
		<ul id="navbarfooter">					
				<li><a href="/FAQ.aspx">Help and FAQS</a></li>
				<li><a href="/AboutUs.aspx">About Us</a></li>
				<li><a href="/ContactUs.aspx">Contact Us</a></li>	
				<li><a href="/Terms.aspx">Terms and Conditions</a></li>
				<li><a href="/Privacy.aspx">Privacy Policy</a></li>
			</ul>
		              
	</div>	

	</form>

	<script type="text/javascript">

	     var _gaq = _gaq || [];
	     _gaq.push(['_setAccount', 'UA-33095959-1']);
	     _gaq.push(['_trackPageview']);

	     (function () {
	          var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
	          ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
	          var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
	     })();

     </script>
		
	
</body>
</html>