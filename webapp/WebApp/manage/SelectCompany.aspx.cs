using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;
using HealthStop.Business.Framework;

namespace HealthStop.Web.manage
{
     public partial class SelectCompany : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
		{
			Admin loggedInAdmin = Helpers.GetLoggedInAdmin();

			if (!IsPostBack)
			{
				EntityList<Company> companies = new EntityList<Company>();
				if (!Helpers.IsSuperUser(loggedInAdmin))
				{
					IEnumerable<Permission> permissions = Permission.GetPermissions().Where(p => p.admin_id == loggedInAdmin.admin_id);
					foreach (Permission item in permissions)
					{
						companies.Add(item.company_);
					}
				}
				else
				{
					companies = Company.GetCompanies();
				}


				CompaniesGridView.DataSource = companies;
				CompaniesGridView.DataBind();
				if (companies.Count == 1)
				{
					Session["company_id"] = companies[0].company_id;
					Session["company_name"] = companies[0].name;
                         
                         if(companies[0].is_customer)
                         {
                              Session["is_customer"] = true;
                         }
                         else if (companies[0].is_supplier)
                         {
                              Session["is_supplier"] = true;
                         }
                         else
                         {
                              Session["is_manufacturer"] = true;
                         }
                         
                         

					Response.Redirect("/manage/Dashboard.aspx");
				}
				PopuplateBreadcrumbs();
			}
		}

		private void PopuplateBreadcrumbs()
		{
			Panel breadCrumbPanel = (Panel)this.Master.FindControl("BreadCrumbPanel");

			HyperLink Level1 = new HyperLink();
			Level1.Text = "Select Company";

			Literal arrows1 = new Literal();
			arrows1.Text = " >> ";

			breadCrumbPanel.Controls.Add(arrows1);
			breadCrumbPanel.Controls.Add(Level1);
		}


		protected void SelectCompanyLinkButton_Command(object sender, CommandEventArgs e)
		{
			LinkButton lb = (LinkButton)sender;
			int company_id = Convert.ToInt32(lb.CommandArgument);

			Session["company_id"] = company_id;

               var foundCompany  = Company.GetCompany(company_id);

               Session["company_name"] = foundCompany.name;


               if (foundCompany.is_customer)
               {
                    Session["company_type"] = "customer";
               }
               else if (foundCompany.is_supplier)
               {
                    Session["company_type"] = "supplier";
               }
               else
               {
                    Session["company_type"] = "manufacturer";
               }

			Response.Redirect("/manage/Dashboard.aspx");
		}          
     }
}