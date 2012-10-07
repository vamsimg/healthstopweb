using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;

namespace HealthStop.Web.admin
{
     public partial class CreateNewCompany : System.Web.UI.Page
     {
          private Admin loggedInAdmin;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();

               if (!Helpers.IsSuperUser(loggedInAdmin))
               {
                    Response.Redirect("/status/errormessage.aspx?error=" + ErrorHelper.notsuperuser);
               }
          }

          protected void CreateCompanyButton_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{    
				Admin loggedInAdmin = Helpers.GetLoggedInAdmin();   

				
					try
					{
                     
						Company new_company = Company.CreateCompany();

                              new_company.name = NameTextBox.Text;
                              new_company.brand_name = BrandNameTextBox.Text;

						new_company.company_number = ABNTextBox.Text.Trim();
						new_company.contact_name = ContactNameTextBox.Text;

						new_company.contact_email = ContactEmailTextBox.Text.Trim();
                              new_company.transactions_email = TransactionEmailTextBox.Text.Trim();

						new_company.address = AddressTextBox.Text;
						new_company.suburb = SuburbTextBox.Text;
						new_company.state = StateDropDownList.SelectedValue;

						new_company.postcode = PostcodeTextBox.Text;
                              new_company.country = "Australia";

						new_company.phone = PhoneTextBox.Text;
												
						new_company.website = WebsiteTextBox.Text;
                              new_company.api_key = Guid.NewGuid().ToString();

                              new_company.is_active = true;

                              new_company.is_customer = false;
                              new_company.is_supplier = false;
                              new_company.is_manufacturer = false;

                              switch (CompanyTypeRadioButtonList.SelectedValue)
                              {
                                   case "Retailer":
                                        new_company.is_customer = true;
                                        break;
                                   case "Supplier":
                                        new_company.is_supplier = true;
                                        break;
                                   case "Manufacturer":
                                        new_company.is_manufacturer = true;
                                        break;
                              }
                                                  
						new_company.creation_datetime = DateTime.Now;
                              new_company.has_POSSystem = true;
						new_company.Save();
						new_company.Refresh();
					                         
						Session["company_id"] = new_company.company_id;
						Response.Redirect("/manage/Companies/ViewCompany.aspx",false);
					}                   
					catch(Exception ex)
					{
						LogHelper.WriteError(ex.ToString());
						CreateCompanyErrorLabel.Text = ex.ToString();
					}
				}  
			}		     

     }
}