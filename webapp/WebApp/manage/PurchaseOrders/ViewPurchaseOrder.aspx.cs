using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;

namespace HealthStop.Web.manage.PurchaseOrders
{
     public partial class ViewPurchaseOrder : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company homeCompany;
          private AllowedStore permission;
          private PurchaseOrder currentOrder;


          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               homeCompany = Helpers.GetCurrentCompany();
               currentOrder = Helpers.GetRequestedPurchaseOrder();
               permission = AllowedStore.GetAllowedStoreByCustomerSupplier(homeCompany.company_id, currentOrder.supplier_id);

               if (!(Helpers.IsAuthorizedAdmin(loggedInAdmin, homeCompany)))
               {
                    Response.Redirect("/status.aspx?error=notadmin");
               }
               else if (!(currentOrder.customer_id == homeCompany.company_id || currentOrder.supplier_id == homeCompany.company_id))
               {
                    Response.Redirect("/status.aspx?error=genericerror");
               }

               if (!IsPostBack)
               {
                    PopulateDetails();

                    PopulateOrderItems();

                    PopulaterInvoices();
               }
               
               if (currentOrder.is_submitted)
               {
                    StatusLabel.Text = "Submitted and waiting for fulfillment";

                    EditableOrderItemsGridView.Visible = false;
               }               
               else if (currentOrder.InvoicesBypurchaseorder_.Count > 0)
               {
                    StatusLabel.Text = "Fulfilled";
                    EditableOrderItemsGridView.Visible = false;
                    
               }
               else
               {
                    StatusLabel.Text = "Waiting to submit";
                    
                    if (currentOrder.customer_id == homeCompany.company_id)
                    {
                         SubmitButton.Visible = true;
                         FindProductPanel.Visible = true;
                    }

                    EditableOrderItemsGridView.Visible = true;
                    FrozenOrderItemsGridView.Visible = false;
                    
               }
          }

          private void PopulateDetails()
          {
               LocalCodeLabel.Text = currentOrder.local_code;
               CustomerLabel.Text = currentOrder.customerName;
               SupplierLabel.Text = currentOrder.supplierName;
               DateLabel.Text = currentOrder.creation_datetime.ToString("dd MMM yyyy");
               SubmitterLabel.Text = currentOrder.person;

               
          }

          protected void FindButton_Click(object sender, EventArgs e)
          {
               string barcode = BarcodeTextBox.Text;

               var foundProduct =  SupplierProduct.findProductByBarcode(currentOrder.supplier_id, barcode);

               if (foundProduct != null)
               {
                    DescriptionLabel.Text = foundProduct.description;
                    CostsLabel.Text = foundProduct.ShowPrices();
                    QuantityTextBox.Text = "";
                    FinalCostLabel.Text = "";
               }
               else
               {
                    DescriptionLabel.Text = "Product not found.";
                    CostsLabel.Text = "";
                    QuantityTextBox.Text = "";
                    FinalCostLabel.Text = "";
               }
          }

          protected void CalculateButton_Click(object sender, EventArgs e)
          {
               if(IsValid)
               {
                    string barcode = BarcodeTextBox.Text;
                    double quantity = Convert.ToDouble(QuantityTextBox.Text);

                    var foundProduct = SupplierProduct.findProductByBarcode(currentOrder.supplier_id, barcode);
                                

                    FinalCostLabel.Text = "$" + foundProduct.CalculateTotalCost(quantity, permission.is_member).ToString("0.00");
               }
          }

          protected void AddProductButton_Click(object sender, EventArgs e)
          {
               if (IsValid)
               {
                    string barcode = BarcodeTextBox.Text;
                    double quantity = Convert.ToDouble(QuantityTextBox.Text);

                    var foundProduct = SupplierProduct.findProductByBarcode(currentOrder.supplier_id, barcode);

                    if (foundProduct != null)
                    {
                         if (currentOrder.PurchaseOrderItemsBypurchaseorder_.Where(i => i.barcode == barcode).Count() > 0)
                         {
                              AddProductsErrorLabel.Text = "This item is already in the order. Please delete and add again.";
                         }
                         else
                         {
                              PurchaseOrderItem newOrderItem = currentOrder.CreatePurchaseOrderItem();
                              newOrderItem.barcode = foundProduct.barcode;
                              newOrderItem.cost_price = foundProduct.CalculateApplicableCost(quantity, permission.is_member);
                              newOrderItem.description = foundProduct.description;
                              newOrderItem.product_code = foundProduct.product_code;
                              newOrderItem.quantity = quantity;

                              newOrderItem.Save();
                         }
                         currentOrder.Refresh();
                         PopulateOrderItems();
                    }
                    else
                    {
                         AddProductsErrorLabel.Text = "Product not found";
                    }
               }
          }

          protected void DeleteItemImageButton_Command(object sender, CommandEventArgs e)
          {
               ImageButton ib = (ImageButton)sender;
               string productCode = ib.CommandArgument;

               try
               {
                    foreach (var item in currentOrder.PurchaseOrderItemsBypurchaseorder_.Where(i => i.product_code == productCode))
                    {
                         item.Delete();
                    }

                    currentOrder.Refresh();
                    PopulateOrderItems();
               }
               catch
               {
                    throw;
               }
          }

          private void PopulateOrderItems()
          {
               EditableOrderItemsGridView.DataSource = currentOrder.PurchaseOrderItemsBypurchaseorder_;
               EditableOrderItemsGridView.DataBind();

               FrozenOrderItemsGridView.DataSource = currentOrder.PurchaseOrderItemsBypurchaseorder_;
               FrozenOrderItemsGridView.DataBind();



               TotalLabel.Text = "$" + currentOrder.PurchaseOrderItemsBypurchaseorder_.Sum(i => i.total).ToString("#0.00");

               XMLLiteral.Text = currentOrder.createEDI();
          }

          private void PopulaterInvoices()
          {
               InvoicesGridView.DataSource = currentOrder.InvoicesBypurchaseorder_;
               InvoicesGridView.DataBind();
          }

          protected void SubmitButton_Click(object sender, EventArgs e)
          {
               if (currentOrder.PurchaseOrderItemsBypurchaseorder_.Count == 0)
               {
                    SubmitErrorLabel.Text = "No items in this order";
               }
               else
               {
                    currentOrder.is_submitted = true;
                    currentOrder.submitted_datetime = DateTime.UtcNow;
                    currentOrder.Save();

                    EmailHelper.SendXMLOrder(loggedInAdmin.full_name, homeCompany, currentOrder.supplier_, currentOrder.createEDI());

                    Response.Redirect("/manage/PurchaseOrders/CustomerPurchaseOrders.aspx");
               }
          }
     }
}