using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Web.AppCode;
using HealthStop.Business;

namespace HealthStop.Web.manage.Products
{
     public partial class MyProductList : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company homeCompany;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               homeCompany = Helpers.GetCurrentCompany();

               if (homeCompany.is_supplier)
               {
                    SupplierProductsGridView.DataSource = homeCompany.SupplierProductsBycompany_;
                    SupplierProductsGridView.DataBind();               
               }              
               else
               {
                    Response.Redirect("/status.aspx?errormessage=notallowed");
               }
          }            
     }
}