using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;
using HealthStop.Business.Framework;

namespace HealthStop.Web.manage.PurchaseOrders
{
     public partial class CustomerPurchaseOrders : System.Web.UI.Page
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
               else if (!homeCompany.is_customer)
               {
                    Response.Redirect("/status.aspx?error=notcustomer");
               }


               if (!IsPostBack)
               {
                    SuppliersDropDownList.DataSource = AllowedStore.GetSuppliers(homeCompany.company_id);
                    SuppliersDropDownList.DataBind();

                  
               }
               

          
          }

          private void PopulateOrderLists()
          {
               

               int supplierID = Convert.ToInt32(SuppliersDropDownList.SelectedValue);
               EntityList<PurchaseOrder> orders = PurchaseOrder.GetPurchaseOrdersByCustomerAndSupplier(homeCompany.company_id, supplierID);

               NewOrdersGridView.DataSource = orders.Where(p => p.is_submitted == false);
               NewOrdersGridView.DataBind();

               PendingOrdersGridView.DataSource = orders.Where(p => p.is_submitted == true && p.InvoicesBypurchaseorder_.Count == 0);
               PendingOrdersGridView.DataBind();

               FulfilledOrderGridView.DataSource = orders.Where(p => p.InvoicesBypurchaseorder_.Count > 0);
               FulfilledOrderGridView.DataBind();
          }

          protected void NewPurchaseOrderButton_Click(object sender, EventArgs e)
          {
               PurchaseOrder newOrder = PurchaseOrder.CreatePurchaseOrder();

               newOrder.customer_id = homeCompany.company_id;
               newOrder.supplier_id = Convert.ToInt32(SuppliersDropDownList.SelectedValue);

               newOrder.person = loggedInAdmin.full_name;
              
               newOrder.is_submitted = false;

               newOrder.creation_datetime = DateTime.UtcNow;

               newOrder.Save();

               newOrder.Refresh();

               Response.Redirect("/manage/PurchaseOrders/ViewPurchaseOrder.aspx?purchaseorder_id=" + newOrder.purchaseorder_id.ToString());
          }
          
          protected void DeleteOrderImageButton_Command(object sender, CommandEventArgs e)
          {
               ImageButton ib = (ImageButton)sender;
               int purchaseOrderId = Convert.ToInt32(ib.CommandArgument);

               try
               {
                    PurchaseOrder foundOrder = PurchaseOrder.GetPurchaseOrder(purchaseOrderId);
                    foundOrder.PurchaseOrderItemsBypurchaseorder_.DeleteAll();
                    foundOrder.Delete();

                    PopulateOrderLists();

               }
               catch
               {
                    throw;
               }
          }

          protected void UpdateButton_Click(object sender, EventArgs e)
          {
               PopulateOrderLists();
          }         
     }
}