using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using HealthStop.Business;
using HealthStop.Web.AppCode;
using System.IO;

namespace HealthStop.Web.manage.Products
{
     public partial class UpdateSupplierProductList : System.Web.UI.Page
     {
          private Admin loggedInAdmin;
          private Company current_company;

          protected void Page_Load(object sender, EventArgs e)
          {
               loggedInAdmin = Helpers.GetLoggedInAdmin();
               current_company = Helpers.GetCurrentCompany();

               if (!(Helpers.IsAuthorizedAdmin(loggedInAdmin, current_company)))
               {
                    Response.Redirect("/status.aspx?error=notadmin");
               }
               else if (!current_company.is_supplier)
               {
                    Response.Redirect("/status.aspx?error=notsupplier");
               }
          }

          protected void UploadListButton_Click(object sender, EventArgs e)
          {
               if (IsValid & CSVFileUpload.HasFile)
               {
                    var products = new List<SupplierProduct>();
                    DateTime lastupdated = DateTime.UtcNow;

                    String badProducts = "";

                    using (Stream fileStream = CSVFileUpload.PostedFile.InputStream)
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                         string row = null;
                         while (!String.IsNullOrEmpty((row = sr.ReadLine())))
                         {                              
                              try
                              {
                                   String[] elements = row.Split(',');
                                   var newProduct = current_company.CreateSupplierProduct();

                                   newProduct.product_code = elements[0];
                                   newProduct.barcode = elements[1];
                                   newProduct.department = elements[2];
                                   newProduct.brand = elements[3];
                                   newProduct.description = elements[4];
                                   newProduct.RRP = Convert.ToDecimal(elements[5]);
                                   newProduct.wholesale_price = Convert.ToDecimal(elements[6]);
                                   
                                   if(!String.IsNullOrEmpty(elements[7]))
                                   {
                                        newProduct.member_price = Convert.ToDecimal(elements[7]);
                                   }
                                   
                                   newProduct.is_GST = Convert.ToBoolean(elements[8]);

                                   if (!String.IsNullOrEmpty(elements[9]))
                                   {
                                        newProduct.range1_min_quantity = Convert.ToDouble(elements[9]);
                                        newProduct.range1_price = Convert.ToDecimal(elements[10]);
                                   }
                                   else
                                   {
                                        newProduct.range1_min_quantity = 0;
                                        newProduct.range1_price = 0;
                                   }

                                   if(!String.IsNullOrEmpty(elements[11]))
                                   {
                                        newProduct.range2_min_quantity = Convert.ToDouble(elements[11]);
                                        newProduct.range2_price = Convert.ToDecimal(elements[12]);
                                   }
                                   else
                                   {
                                        newProduct.range2_min_quantity = 0;
                                        newProduct.range2_price = 0;
                                   }
                                   
                                   if(!String.IsNullOrEmpty(elements[13]))
                                   {                                   
                                        newProduct.range3_min_quantity = Convert.ToDouble(elements[13]);                                   
                                        newProduct.range3_price = Convert.ToDecimal(elements[14]);
                                   }
                                   else
                                   {
                                        newProduct.range3_min_quantity = 0;
                                        newProduct.range3_price = 0;
                                   }
                                   
                                   newProduct.is_available = true;

                                   newProduct.lastupdated_datetime = lastupdated;
                                   products.Add(newProduct);
                              }
                              catch
                              {
                                   badProducts += row + "<br />";
                              }
                         }

                         if (badProducts != "")
                         {
                              UploadErrorLabel.Text = "Error with following items <br /><br />" + badProducts;
                         }
                         else
                         {
                              //Switch the company off so no conflicts with new invoices.
                              current_company.is_active = false;
                              current_company.Save();                              

                              current_company.SupplierProductsBycompany_.DeleteAll();

                              string errors = "";

                              foreach (var product in products)
                              {
                                   try
                                   {

                                        product.Save();
                                   }
                                   catch
                                   {
                                        errors += product.product_code + ",";
                                   }
                              }

                              current_company.is_active = true;
                              current_company.Save();

                              UploadErrorLabel.Text = products.Count.ToString() + " products uploaded";

                              if (!String.IsNullOrEmpty(errors))
                              {
                                   UploadErrorLabel.Text +=  " Error with product codes: " + errors;
                              }
                         }
                    }
               }
          }
     }
}