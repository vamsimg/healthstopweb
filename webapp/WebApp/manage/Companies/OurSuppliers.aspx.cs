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
     public partial class OurSuppliers : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company homeCompany;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               homeCompany = Helpers.GetCurrentCompany();

               if (!IsPostBack)
               {
                    PopulateSuppliers();
               }

          }

          private void PopulateSuppliers()
          {
               OurSuppliersGridView.DataSource = AllowedStore.GetSuppliers(homeCompany.company_id);
               OurSuppliersGridView.DataBind();
          }
     }
}