using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Web.AppCode;
using HealthStop.Business;
using HealthStop.Business.Framework;

namespace HealthStop.Web.manage.PurchaseOrders
{
     public partial class SupplierPurchaseOrders : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company homeCompany;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               homeCompany = Helpers.GetCurrentCompany();

               if (!(Helpers.IsAuthorizedAdmin(loggedInAdmin, homeCompany)))
               {
                    Response.Redirect("/status.aspx?error=notadmin");
               }
               else if (!homeCompany.is_supplier)
               {
                    Response.Redirect("/status.aspx?error=notcustomer");
               }


               if (!IsPostBack)
               {
                    CustomersDropDownList.DataSource = AllowedStore.GetCustomers(homeCompany.company_id);
                    CustomersDropDownList.DataBind();                  
               }


          }

          private void PopulateOrderLists()
          {
               int customerID = Convert.ToInt32(CustomersDropDownList.SelectedValue);
               EntityList<PurchaseOrder> orders = PurchaseOrder.GetPurchaseOrdersByCustomerAndSupplier(customerID,homeCompany.company_id);

               PendingOrdersGridView.DataSource = orders.Where(p => p.is_submitted == true && p.InvoicesBypurchaseorder_.Count == 0);
               PendingOrdersGridView.DataBind();

               FulfilledOrderGridView.DataSource = orders.Where(p => p.InvoicesBypurchaseorder_.Count > 0);
               FulfilledOrderGridView.DataBind();
          }

          protected void UpdateButton_Click(object sender, EventArgs e)
          {
               PopulateOrderLists();
          }

          protected void CreateInvoiceImageButton_Command(object sender, CommandEventArgs e)
          {
               ImageButton ib = (ImageButton)sender;
               int purchaseOrderId = Convert.ToInt32(ib.CommandArgument);

               try
               {

                    PurchaseOrder foundOrder = PurchaseOrder.GetPurchaseOrder(purchaseOrderId);
                    AllowedStore permission = AllowedStore.GetAllowedStoreByCustomerSupplier(foundOrder.customer_id, homeCompany.company_id);
                    
                    Invoice newInvoice = foundOrder.CreateInvoice();

                    newInvoice.customer_id = foundOrder.customer_id;
                    newInvoice.supplier_id = foundOrder.supplier_id;
                    newInvoice.freight = 10;
                    newInvoice.total = 0;
                    newInvoice.creation_datetime = DateTime.UtcNow;

                    newInvoice.Save();

                    newInvoice.Refresh();

                    foreach(var item in foundOrder.PurchaseOrderItemsBypurchaseorder_)
                    {
                         string barcode = item.barcode;
                         double quantity = item.quantity;

                         var foundProduct = SupplierProduct.findProductByBarcode(homeCompany.company_id, barcode);

                         if (foundProduct != null)
                         {    
                              InvoiceItem newItem = newInvoice.CreateInvoiceItem();
                              newItem.barcode = foundProduct.barcode;
                              newItem.cost_price = foundProduct.CalculateApplicableCost(quantity, permission.is_member);
                              newItem.description = foundProduct.description;
                              newItem.product_code = foundProduct.product_code;
                              newItem.quantity = quantity;
                              newItem.is_GST = foundProduct.is_GST;
                              newItem.RRP = foundProduct.RRP;
                              newItem.Save();                              
                         }
                    }

                    newInvoice.total = newInvoice.InvoiceItemsByinvoice_.Sum(i => i.subTotal) + newInvoice.freight;
                    newInvoice.tax = newInvoice.InvoiceItemsByinvoice_.Sum(i => i.taxAmount);

                    if (!newInvoice.customer_.has_POSSystem)
                    {
                         newInvoice.is_downloaded = true;
                         newInvoice.downloaded_datetime = newInvoice.creation_datetime;
                    }
                    else
                    {
                         newInvoice.is_downloaded = false;
                    }

                    newInvoice.Save();                    
                    newInvoice.Refresh();

                    EmailHelper.SendInvoice(newInvoice);


                    PopulateOrderLists();
               }
               catch
               {
                    throw;
               }
          }
     }
}