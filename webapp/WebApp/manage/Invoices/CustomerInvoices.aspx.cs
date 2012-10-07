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
     public partial class CustomerInvoices : System.Web.UI.Page
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
                    InvoicesGridView.DataSource = Invoice.GetInvoicesByCustomer(homeCompany.company_id);
                    InvoicesGridView.DataBind();
               }
          }
     }
}