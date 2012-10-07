using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using HealthStop.Business;
using HealthStop.Web.AppCode;

namespace HealthStop.Web.services
{
     /// <summary>
     /// Summary description for POSWebService
     /// </summary>
     [WebService(Namespace = "http://healthstop.com.au/")]
     [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
     [System.ComponentModel.ToolboxItem(false)]
     // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     // [System.Web.Script.Services.ScriptService]
     public class POSWebService : System.Web.Services.WebService
     {
          public class LocalPurchaseOrder
          {
               public string local_code;
               public int supplier_id;
               public DateTime order_datetime;
               public DateTime due_datetime;
               public List<LocalPurchaseOrderItem> itemList;
          }

          public class LocalPurchaseOrderItem
          {               
               public string barcode;
               public string description;
               public double quantity;            
          }



          public class LocalInvoice
          {
               public int invoice_id;
               //Invoice number from supplier
               public string supplier_code;
               public int supplierID;
               public string supplierName;
               public string purchaseorder_code;
               public decimal freight_inc;
               public decimal tax;               
               public decimal total_inc;
               public DateTime creation_datetime;
               public List<LocalInvoiceItem> itemList;
          }

          public class LocalInvoiceItem
          {
               public string barcode;                              
               public double quantity;
               public decimal cost_ex;
               public decimal RRP;
               public bool isGST;
               public string description;
          }

          public class OrderResponse
          {
               public bool is_error;
               public string errorMessage;
               public string statusMessage;
               //local items Not used in methods but needed for the client to create the local item class.
              
               public List<LocalPurchaseOrder> localPurchaseOrders;
               public List<LocalInvoice> localInvoices;
          }


          [WebMethod]
          public string HelloWorld()
          {
               return "Hello World";
          }

          [WebMethod]
          public OrderResponse TestConnection(int companyID, string password)
          {
               var newResponse = new OrderResponse();
               newResponse.is_error = false;
               try
               {
                    Company currentCompany = Company.GetCompany(companyID);

                    if (currentCompany == null)
                    {
                         newResponse.is_error = true;
                         newResponse.errorMessage = "NoCompany";
                    }
                    else
                    {
                         if (password != currentCompany.api_key)
                         {
                              newResponse.is_error = true;
                              newResponse.errorMessage = "IncorrectPassword";
                         }
                    }
               }
               catch (Exception ex)
               {
                    newResponse.is_error = true;
                    newResponse.errorMessage = "GenericError";
                    //LogHelper.WriteError(ex.ToString());
               }
               return newResponse;
          }

          [WebMethod]
          public OrderResponse UploadPurchaseOrders(int companyID, string password, List<LocalPurchaseOrder> orders)
          {
               var newResponse = new OrderResponse();
               newResponse.is_error = false;
               newResponse.errorMessage = "";
               newResponse.statusMessage = "";
               try
               {
                    Company currentCompany = Company.GetCompany(companyID);

                    if (currentCompany == null)
                    {
                         newResponse.is_error = true;
                         newResponse.errorMessage = "NoCompany";
                    }
                    else
                    {
                         if (password != currentCompany.api_key)
                         {
                              newResponse.is_error = true;
                              newResponse.errorMessage = "IncorrectPassword";
                         }
                         else
                         {
                              foreach (var order in orders)
                              {
                                   //Check for duplicate barcodes.
                                   List<string> duplicateBarcodes = order.itemList.GroupBy(i => i.barcode)
                                                                                              .Where(g => g.Count() > 1)
                                                                                              .Select(g => g.Key)
                                                                                              .ToList();
                                   if (duplicateBarcodes.Count > 0)
                                   {
                                        string barcodes = String.Join("\r\n", duplicateBarcodes.ToArray());
                                        newResponse.is_error = true;
                                        newResponse.errorMessage += "Error with Purchase Order: " + order.local_code + ". Duplicate barcodes: \r\n " + barcodes;
                                   }
                                   else
                                   {
                                        var supplier = Company.GetCompany(order.supplier_id);
                                        if (supplier == null)
                                        {
                                             newResponse.is_error = true;
                                             newResponse.errorMessage += "Error with Purchase Order: " + order.local_code + ". Supplier not found\r\n";
                                        }
                                        else
                                        {
                                             var permission = AllowedStore.GetAllowedStoreByCustomerSupplier(currentCompany.company_id, supplier.company_id);
                                             if (permission == null)
                                             {
                                                  newResponse.is_error = true;
                                                  newResponse.errorMessage += "Error with Purchase Order: " + order.local_code + ". You don't have an account with this supplier.\r\n";
                                             }
                                             else
                                             {
                                                  if (PurchaseOrder.GetPurchaseOrdersByCustomerLocalCode(companyID, order.local_code).Count > 0)
                                                  {
                                                       newResponse.is_error = true;
                                                       newResponse.errorMessage += "Purchase order: " + order.local_code + " to " + supplier.name + " already submitted.\r\n";
                                                  }
                                                  else
                                                  {


                                                       PurchaseOrder newOrder = PurchaseOrder.CreatePurchaseOrder();
                                                       newOrder.local_code = order.local_code;
                                                       newOrder.customer_id = currentCompany.company_id;
                                                       newOrder.supplier_id = supplier.company_id;
                                                       newOrder.person = "HealthStop POS Client";
                                                       newOrder.creation_datetime = order.order_datetime;


                                                       newOrder.Save();
                                                       newOrder.Refresh();

                                                       foreach (var item in order.itemList)
                                                       {
                                                            var foundSupplierProduct = SupplierProduct.findProductByBarcode(supplier.company_id, item.barcode);

                                                            if (foundSupplierProduct == null)
                                                            {
                                                                 newResponse.is_error = true;
                                                                 newResponse.errorMessage += "Error with Purchase Order: " + order.local_code + "\r\nProduct not found in supplier list : " + item.barcode + "\r\nOrder submitted without this product." + "\r\n";
                                                            }
                                                            else
                                                            {
                                                                 var newItem = PurchaseOrderItem.CreatePurchaseOrderItem();
                                                                 newItem.purchaseorder_id = newOrder.purchaseorder_id;
                                                                 newItem.product_code = foundSupplierProduct.product_code;
                                                                 newItem.barcode = foundSupplierProduct.barcode;
                                                                 newItem.description = foundSupplierProduct.description;
                                                                 newItem.cost_price = foundSupplierProduct.CalculateApplicableCost(item.quantity, permission.is_member);
                                                                 newItem.quantity = item.quantity;

                                                                 newItem.Save();
                                                            }
                                                       }

                                                       newOrder.Refresh();
                                                       if (newOrder.PurchaseOrderItemsBypurchaseorder_.Count == 0)
                                                       {
                                                            newResponse.is_error = true;
                                                            newResponse.errorMessage += "Error with Purchase Order: " + order.local_code + " No items to order" + "\r\n";
                                                            newOrder.Delete();
                                                       }
                                                       else
                                                       {
                                                            EmailHelper.SendXMLOrder("HealthStop Auto", currentCompany, supplier, newOrder.createEDI());
                                                            newOrder.submitted_datetime = DateTime.UtcNow;
                                                            newOrder.is_submitted = true;
                                                            newOrder.Save();

                                                            newResponse.statusMessage += "Purchase Order: " + order.local_code + ". sent successfully to " + supplier.name + "\r\n";
                                                       }
                                                  }
                                             }
                                        }
                                   }
                              }
                         }
                    }                    
               }
               catch (Exception ex)
               {
                    newResponse.is_error = true;
                    newResponse.errorMessage = "GenericError";
                    LogHelper.WriteError(ex.ToString());
               }
               return newResponse;
          }

          [WebMethod]
          public OrderResponse DownloadInvoices(int companyID, string password)
          {
               var newResponse = new OrderResponse();
               newResponse.is_error = false;
               try
               {
                    Company currentCompany = Company.GetCompany(companyID);

                    if (currentCompany == null)
                    {
                         newResponse.is_error = true;
                         newResponse.errorMessage = "NoCompany";
                    }
                    else
                    {
                         if (password != currentCompany.api_key)
                         {
                              newResponse.is_error = true;
                              newResponse.errorMessage = "IncorrectPassword";
                         }
                         else
                         {
                              var invoices = Invoice.GetInvoicesForDownloadByCustomer(currentCompany.company_id);

                              if (invoices.Count == 0)
                              {
                                   newResponse.statusMessage = "No invoices to download";
                              }

                              else
                              {
                                   newResponse.localInvoices = new List<LocalInvoice>();
                                   foreach (var invoice in invoices)
                                   {
                                        var newInvoice = new LocalInvoice();
                                        newInvoice.invoice_id = invoice.invoice_id;
                                        newInvoice.supplierID = invoice.supplier_id;
                                        newInvoice.supplierName = invoice.supplierName;
                                        if (String.IsNullOrEmpty(invoice.local_code))
                                        {
                                             newInvoice.supplier_code = invoice.invoice_id.ToString();
                                        }
                                        else
                                        {
                                             newInvoice.supplier_code = invoice.local_code;
                                        }

                                        if (invoice.purchaseorder_ != null)
                                        {
                                             newInvoice.purchaseorder_code = invoice.purchaseorder_.local_code;
                                        }

                                        newInvoice.freight_inc = invoice.freight;
                                        newInvoice.tax = invoice.tax;
                                        newInvoice.total_inc = invoice.total;
                                        newInvoice.creation_datetime = invoice.creation_datetime;

                                        var newItemList = new List<LocalInvoiceItem>();

                                        foreach (var item in invoice.InvoiceItemsByinvoice_)
                                        {
                                             var newItem = new LocalInvoiceItem();

                                             newItem.barcode = item.barcode;
                                             newItem.quantity = item.quantity;
                                             newItem.cost_ex = item.cost_price;
                                             newItem.RRP = item.RRP;
                                             newItem.isGST = item.is_GST;
                                             newItem.description = item.description;

                                             newItemList.Add(newItem);
                                        }

                                        newInvoice.itemList = newItemList;

                                        newResponse.localInvoices.Add(newInvoice);                                                                                                             
                                   }
                                   newResponse.statusMessage = newResponse.localInvoices.Count + " Invoices available";
                              }
                         }
                    }
               }
               catch (Exception ex)
               {
                    newResponse.is_error = true;
                    newResponse.errorMessage = "GenericError";
                    LogHelper.WriteError(ex.ToString());
               }
               return newResponse;
          }

          [WebMethod]
          public OrderResponse MarkInvoiceAsDownloaded(int companyID, string password, int invoiceID)
          {
               var newResponse = new OrderResponse();
               newResponse.is_error = false;
               try
               {
                    Company currentCompany = Company.GetCompany(companyID);

                    if (currentCompany == null)
                    {
                         newResponse.is_error = true;
                         newResponse.errorMessage = "NoCompany";
                    }
                    else
                    {
                         if (password != currentCompany.api_key)
                         {
                              newResponse.is_error = true;
                              newResponse.errorMessage = "IncorrectPassword";
                         }
                         else
                         {         
                              var foundInvoice = Invoice.GetInvoice(invoiceID);
                              if (foundInvoice == null)
                              {
                                   newResponse.is_error = true;
                                   newResponse.errorMessage += "Error with Invoice: " + invoiceID.ToString() + " Invoice not found\r\n";
                              }
                              else
                              {
                                   foundInvoice.is_downloaded = true;
                                   foundInvoice.downloaded_datetime = DateTime.UtcNow;
                                   foundInvoice.Save();
                                   newResponse.statusMessage = "Invoice # " + invoiceID.ToString() + " updated successfully";
                              }
                         }
                    }
               }
               catch (Exception ex)
               {
                    newResponse.is_error = true;
                    newResponse.errorMessage = "GenericError";
                    LogHelper.WriteError(ex.ToString());
               }
               return newResponse;
          }
     }
}
