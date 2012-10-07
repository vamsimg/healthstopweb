<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="UpdateSupplierProductList.aspx.cs" Inherits="HealthStop.Web.manage.Products.UpdateSupplierProductList" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <h1>Upload your Product List</h1>

     <p>Upload csv file with the following columns.</p>


     <ol>
          <li>Product Code, Item ID or Part Number</li>    
          <li>Product Barcode</li>   
          <li>Department</li> 
          <li>Brand</li>
          <li>Description</li>  
          <li>RRP (Numbers only, no $ dollar signs)</li>  
          <li>Wholesale Price(Numbers only, no $ dollar signs) </li>    
          <li>Member Price (Numbers only, no $ dollar signs, leave empty if same as Wholesale price)  </li>    
          <li>GST(True or False)</li>                       
          <li>Range 1 Minimum Quantity</li>    
          <li>Range 1 Price </li>    
          <li>Range 2 Minimum Quantity</li>    
          <li>Range 2 Price </li>    
          <li>Range 3 Minimum Quantity</li>    
          <li>Range 3 Price </li>    
     </ol>
          
     A sample spreadsheet is available here with all columns already set: <a href="sample.xlsx">sample.xslsx</a> You simply need to paste your data into that and then Save As .csv

     <br />
     <br />

     <span class="shortLeftLabel">Select file: </span>
		<asp:FileUpload ID="CSVFileUpload" runat="server" CssClass="textField" Width="30em" /> 
		     <asp:RegularExpressionValidator ID="ExtensionRegularExpressionValidator" runat="server" ErrorMessage="File must end in .csv " ControlToValidate="CSVFileUpload" ValidationExpression="..+(\.csv)$" Display="Dynamic"></asp:RegularExpressionValidator>
			<asp:RequiredFieldValidator ID="FileUploadRequiredFieldValidator" runat="server" ErrorMessage="Please select a CSV file to upload" ControlToValidate="CSVFileUpload"  Display="Dynamic"></asp:RequiredFieldValidator>
	<div class="brclear"></div>

	<asp:Button ID="UploadListButton" runat="server" Text="Upload Item List" onclick="UploadListButton_Click" OnClientClick="loadImg()"/>

     
     <div class="brclear"></div>

     <asp:Label ID="UploadErrorLabel" runat="server" Text="" CssClass="errorMessage" EnableViewState="false"></asp:Label>

     <br />
     <br />

     <img id="loading" src="/images/loading.gif" alt="" style="display:none;"/>

     <script type="text/javascript">
          function loadImg() {
               document.getElementById('loading').style.display = "";
               setTimeout('document.images["loading"].src="/images/loading.gif"', 200);
          } 
     </script>

</asp:Content>