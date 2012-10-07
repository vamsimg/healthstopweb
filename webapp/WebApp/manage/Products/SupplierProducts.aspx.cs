using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;

namespace HealthStop.Web.manage.Products
{
     public partial class SupplierProducts : System.Web.UI.Page
     {
          private Admin loggedInAdmin;          
          private Company homeCompany;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               homeCompany = Helpers.GetCurrentCompany();

               if (!IsPostBack)
               {
                    SupplierDropDownList.DataSource = AllowedStore.GetSuppliers(homeCompany.company_id);
                    SupplierDropDownList.DataBind();
               }
          }            

          protected void UpdateButton_Click(object sender, EventArgs e)
          {
               int companyID = Convert.ToInt32(SupplierDropDownList.SelectedValue);

               Company selectedCompany = Company.GetCompany(companyID);
               SupplierProductsGridView.DataSource = selectedCompany.SupplierProductsBycompany_;
               SupplierProductsGridView.DataBind();
          }
     }
}