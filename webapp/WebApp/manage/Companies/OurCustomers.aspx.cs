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
     public partial class OurCustomers : System.Web.UI.Page
     {
          private Admin loggedInAdmin;          
          private Company homeCompany;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();          
               homeCompany = Helpers.GetCurrentCompany();

               if (!IsPostBack)
               {
                    PopulateCustomers();
               }

          }

          private void PopulateCustomers()
          {
               CustomersGridView.DataSource = AllowedStore.GetCustomers(homeCompany.company_id);
               CustomersGridView.DataBind();
          }


          protected void GiveAccessButton_Click(object sender, EventArgs e)
          {
               if (IsValid)
               {
                    Company foundCompany = Company.GetCompanyByCompanyNumber(ABNTextBox.Text.Trim());

                    if (foundCompany == null)
                    {
                         GiveAccessErrorLabel.Text = "Retailer not found. Contact help@healthstop.com.au";
                    }
                    else if (AllowedStore.GetAllowedStoreByCustomerSupplier(foundCompany.company_id, homeCompany.company_id) != null)
                    {
                         GiveAccessErrorLabel.Text = "Retailer already has access, if you wish to give Member access , delete them first from the Allowed stores list and then add them again here.";
                    }
                    else
                    {
                         AllowedStore newPermission = AllowedStore.CreateAllowedStore();

                         newPermission.customer_id = foundCompany.company_id;
                         newPermission.supplier_id = homeCompany.company_id;
                         newPermission.account_number = AccountNumberTextBox.Text.Trim();
                         newPermission.is_member = Convert.ToBoolean(MemberRadioButtonList.SelectedValue);

                         newPermission.creation_datetime = DateTime.UtcNow;
                         newPermission.authoriser_email = loggedInAdmin.email;

                         newPermission.Save();

                         GiveAccessErrorLabel.Text = "Retailer added successfully.";

                         PopulateCustomers();
                    }

               }
          }


          protected void DeletePermissionImageButton_Command(object sender, CommandEventArgs e)
          {
               ImageButton ib = (ImageButton)sender;
               int customerID = Convert.ToInt32(ib.CommandArgument);

               try
               {
                    AllowedStore permission = AllowedStore.GetAllowedStoreByCustomerSupplier(customerID, homeCompany.company_id);
                    permission.Delete();
                    homeCompany.Refresh();
                    PopulateCustomers();
               }
               catch
               {
                    throw;
               }
          }
     }
}