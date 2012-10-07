using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;

namespace HealthStop.Web.manage.Companies
{
     public partial class ViewCompany : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company requestedCompany;
          private Company homeCompany;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               requestedCompany = Helpers.GetRequestedCompany();
               homeCompany = Helpers.GetCurrentCompany();

               if (homeCompany.is_customer && requestedCompany.is_customer)
               {
                    Response.Redirect("/status.aspx?errormessage=notallowed");
               }

               if (homeCompany.AllowedStoresBysupplier_.Where(p => p.supplier_id == requestedCompany.company_id).Count() == 0)
               {
                    SupplierPanel.Visible = true;
                    SupplierPanel.Enabled = true;
                    AccessAvailableLabel.Visible = false;
               }

          }

          protected void RequestAccessButton_Click(object sender, EventArgs e)
          {
               try
               {
                    EmailHelper.RequestAccess(loggedInAdmin, homeCompany, requestedCompany);
                    RequestAccessErrorLabel.Text = "An email has been sent to the supplier. They will in contact shortly.";

                    //LogChange(current_admin);
               }
               catch (Exception ex)
               {
                    RequestAccessErrorLabel.Text = "An error has occurred. Please contact help@healthstop.com.au";
                    throw ex;
               }
          }
     }
}