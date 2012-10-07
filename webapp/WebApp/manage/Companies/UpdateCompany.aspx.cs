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
     public partial class UpdateCompany : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company current_company;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               current_company = Helpers.GetCurrentCompany();

               if (!Helpers.IsAuthorizedAdmin(loggedInAdmin, current_company))
               {
                    Response.Redirect("/status.aspx?error=notowner");
               }

               if (!IsPostBack)
               {
                    PopulateDetails();
               }
          }

          private void PopulateDetails()
          {
               APIKeyFieldLabel.Text = current_company.api_key;
               NameTextBox.Text = current_company.name;
               BrandNameTextBox.Text = current_company.brand_name;
               ABNTextBox.Text = current_company.company_number;
               ContactNameTextBox.Text = current_company.contact_name;
               ContactEmailTextBox.Text = current_company.contact_email;
               TransactionEmailTextBox.Text = current_company.transactions_email;
               AddressTextBox.Text = current_company.address;
               SuburbTextBox.Text = current_company.suburb;
               PostcodeTextBox.Text = current_company.postcode;
               PhoneTextBox.Text = current_company.phone;
               WebsiteTextBox.Text = current_company.website;
               HasPOSCheckBox.Checked = current_company.has_POSSystem;
          }

          protected void UpdateCompanyButton_Click(object sender, EventArgs e)
          {
               if (!Helpers.IsAuthorizedOwner(loggedInAdmin, current_company))
               {
                    Response.Redirect("/status.aspx?error=notowner");
               }
               else
               {
                    if (IsValid)
                    {
                         try
                         {
                              current_company.name = NameTextBox.Text;
                              current_company.brand_name = BrandNameTextBox.Text;

                              current_company.company_number = ABNTextBox.Text.Trim();
                              current_company.contact_name = ContactNameTextBox.Text;

                              current_company.contact_email = ContactEmailTextBox.Text.Trim();
                              current_company.transactions_email = TransactionEmailTextBox.Text.Trim();

                              current_company.address = AddressTextBox.Text;
                              current_company.suburb = SuburbTextBox.Text;
                              current_company.state = StateDropDownList.SelectedValue;

                              current_company.postcode = PostcodeTextBox.Text;
                              current_company.phone = PhoneTextBox.Text;
                              current_company.website = WebsiteTextBox.Text;
                              current_company.has_POSSystem = HasPOSCheckBox.Checked;
                              current_company.Save();
                              current_company.Refresh();
                              UpdateCompanyErrorLabel.Text = "Company updated successfully";
                         }
                         catch
                         {
                              UpdateCompanyErrorLabel.Text = "Company not updated successfully";
                              throw;
                         }
                    }
               }

          }
     }
}