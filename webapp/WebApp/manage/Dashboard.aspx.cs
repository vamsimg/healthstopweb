using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthStop.Business;
using HealthStop.Web.AppCode;

namespace HealthStop.Web.manage
{
     public partial class Dashboard : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company currentCompany;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               currentCompany = Helpers.GetCurrentCompany();
               CheckPermission();

               PopuplateBreadcrumbs();
          }

          private void CheckPermission()
          {
               if (!(Helpers.IsAuthorizedAdmin(loggedInAdmin, currentCompany)))
               {
                    Response.Redirect("/status.aspx?error=notadmin");
               }
          }

          private void PopuplateBreadcrumbs()
          {
               Panel breadCrumbPanel = (Panel)this.Master.FindControl("BreadCrumbPanel");

               HyperLink Level1 = new HyperLink();
               Level1.Text = "Dashboard";

               Literal arrows1 = new Literal();
               arrows1.Text = " >> ";

               breadCrumbPanel.Controls.Add(arrows1);
               breadCrumbPanel.Controls.Add(Level1);
          }
     }
}