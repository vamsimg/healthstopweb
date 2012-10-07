using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;

namespace HealthStop.Web.manage.Invoices
{
     public partial class ViewInvoice : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company homeCompany;
          private AllowedStore permission;
          private Invoice currentInvoice;


          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               homeCompany = Helpers.GetCurrentCompany();
               currentInvoice = Helpers.GetRequestedInvoice();
               permission = AllowedStore.GetAllowedStoreByCustomerSupplier(homeCompany.company_id, currentInvoice.supplier_id);

               if (!(Helpers.IsAuthorizedAdmin(loggedInAdmin, homeCompany)))
               {
                    Response.Redirect("/status.aspx?error=notadmin");
               }
               else if (!(currentInvoice.customer_id == homeCompany.company_id || currentInvoice.supplier_id == homeCompany.company_id))
               {
                    Response.Redirect("/status.aspx?error=genericerror");
               }

               if (!IsPostBack)
               {
                    PopulateDetails();
                    PopulateInvoiceItems();
               }

                            
          }

          private void PopulateDetails()
          {
               LocalCodeLabel.Text = currentInvoice.local_code;
               CustomerLabel.Text = currentInvoice.customerName;
               SupplierLabel.Text = currentInvoice.supplierName;
               DateLabel.Text = currentInvoice.creation_datetime.ToString("dd MMM yyyy");

               FrieghtLabel.Text = "$" + currentInvoice.freight.ToString("#0.00");
               TaxLabel.Text = "$" + currentInvoice.tax.ToString("#0.00");
               TotalLabel.Text = "$" + currentInvoice.total.ToString("#0.00");

               POHyperLink.NavigateUrl = "/manage/PurchaseOrders/ViewPurchaseOrder.aspx?purchaseorder_id=" + currentInvoice.purchaseorder_id.ToString();

               if (currentInvoice.is_downloaded)
               {
                    StatusLabel.Text = "Invoice downloaded into POS system";
               }
               else
               {
                    StatusLabel.Text = "Waiting to be downloaded to POS";
               }
          }

          private void PopulateInvoiceItems()
          {
               InvoiceItemsGridView.DataSource = currentInvoice.InvoiceItemsByinvoice_;
               InvoiceItemsGridView.DataBind();
          }
     }
}