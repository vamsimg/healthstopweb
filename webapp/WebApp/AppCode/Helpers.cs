using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthStop.Business;
using HealthStop.Business.Framework;
using System.Reflection;

namespace HealthStop.Web.AppCode
{

     public static class Helpers
     {
          /// <summary>
          /// Gets the current Admin who is logged in.
          /// </summary>
          /// <returns></returns>
          public static Admin GetLoggedInAdmin()
          {
               if (HttpContext.Current.Session["admin_id"] == null)
               {
                    HttpContext.Current.Response.Redirect("/status.aspx?msg=notloggedin");
               }

               int admin_id = Convert.ToInt32(HttpContext.Current.Session["admin_id"]);

               Admin loggedinAdmin = Admin.GetAdmin(admin_id);

               return loggedinAdmin;
          }

          /// <summary>
          /// Gets the first permission found for an amdin. Unique constraint in DB should ensure that the first permission for an admin is the only permission.
          /// </summary>
          /// <param name="loggedInAdmin"></param>
          /// <param name="current_company"></param>
          /// <param name="roles"></param>
          /// <returns></returns>
          public static Role GetPermission(Admin loggedInAdmin, Company current_company)
          {
               EntityList<Permission> permissions = current_company.PermissionsBycompany_;

               foreach (Permission permission in permissions)
               {
                    if (permission.admin_.admin_id == loggedInAdmin.admin_id)
                    {
                         return permission.role_name;
                    }
               }

               return null;
          }


          /// <summary>
          /// Checks to see if the currently logged in Admin is an authorized admin for the company.
          /// </summary>
          /// <param name="loggedInAdmin"></param>
          /// <returns></returns>
          public static bool IsAuthorizedAdmin(Admin loggedInAdmin, Company current_company)
          {
               bool is_ok = false;
               Role admin_role = GetPermission(loggedInAdmin, current_company);

               if (admin_role != null)
               {
                    if (admin_role.role_name == "Admin" || admin_role.role_name == "Owner")
                    {
                         is_ok = true;
                    }
               }

               is_ok = (is_ok || IsSuperUser(loggedInAdmin));
               return is_ok;

          }

          /// <summary>
          /// Checks to see if the currently logged in Admin is an authorized clerk for the company.
          /// </summary>
          /// <param name="loggedInAdmin"></param>
          /// <returns></returns>
          public static bool IsAuthorizedClerk(Admin loggedInAdmin, Company current_company)
          {
               bool is_ok = false;
               Role admin_role = GetPermission(loggedInAdmin, current_company);

               if (admin_role != null)
               {
                    if (admin_role.role_name == "Clerk")
                    {
                         is_ok = true;
                    }
               }

               return is_ok;
          }


          /// <summary>
          /// Checks to see if the currently logged in Admin is an authorized Owner for the company.
          /// </summary>
          /// <param name="loggedInAdmin"></param>
          /// <param name="current_company"></param>
          /// <returns></returns>
          public static bool IsAuthorizedOwner(Admin loggedInAdmin, Company current_company)
          {
               bool is_ok = false;
               Role admin_role = GetPermission(loggedInAdmin, current_company);

               if (admin_role != null)
               {
                    if (admin_role.role_name == "Owner")
                    {
                         is_ok = true;
                    }
               }
               is_ok = (is_ok || IsSuperUser(loggedInAdmin));
               return is_ok;
          }

          /// <summary>
          ///  Checks to see if the currently logged in Admin is a SuperUser.
          /// </summary>
          /// <param name="loggedInAdmin"></param>
          /// <returns></returns>
          public static bool IsSuperUser(Admin loggedInAdmin)
          {
               if (loggedInAdmin.email == "vamsi.mg@gmail.com")
               {
                    return true;
               }
               else
               {
                    return false;
               }
          }

         

          /// <summary>
          /// Gets the company object for a currently selected company.
          /// </summary>
          /// <returns></returns>
          public static Company GetCurrentCompany()
          {

               if (HttpContext.Current.Session["company_id"] == null)
               {
                    HttpContext.Current.Response.Redirect("/manage/Companies/MyCompanies.aspx");
               }

               int company_id = Convert.ToInt32(HttpContext.Current.Session["company_id"]);

               Company current_company = Company.GetCompany(company_id);

               if (current_company == null)
               {
                    HttpContext.Current.Response.Redirect("/status.aspx?msg=companynotfound");
               }

               return current_company;
          }

          public static Company GetRequestedCompany()
          {

               if (HttpContext.Current.Request.QueryString["company_id"] == null)
               {
                    HttpContext.Current.Response.Redirect("/manage/Dashboard.aspx");
               }

               int company_id = Convert.ToInt32(HttpContext.Current.Session["company_id"]);

               Company current_company = Company.GetCompany(company_id);

               if (current_company == null)
               {
                    HttpContext.Current.Response.Redirect("/status.aspx?msg=companynotfound");
               }

               return current_company;
          }


          public static PurchaseOrder GetRequestedPurchaseOrder()
          {

               if (HttpContext.Current.Request.QueryString["purchaseorder_id"] == null)
               {
                    HttpContext.Current.Response.Redirect("/status.aspx?msg=ordernotfound");
               }

               int purchaseorder_id = Convert.ToInt32(HttpContext.Current.Request.QueryString["purchaseorder_id"]);

               var currentOrder = PurchaseOrder.GetPurchaseOrder(purchaseorder_id);

               if (currentOrder == null)
               {
                    HttpContext.Current.Response.Redirect("/status.aspx?msg=ordernotfound");
               }

               return currentOrder;
          }

          public static Invoice GetRequestedInvoice()
          {

               if (HttpContext.Current.Request.QueryString["invoice_id"] == null)
               {
                    HttpContext.Current.Response.Redirect("/status.aspx?msg=invoicenotfound");
               }

               int invoice_id = Convert.ToInt32(HttpContext.Current.Request.QueryString["invoice_id"]);

               var currentInvoice = Invoice.GetInvoice(invoice_id);

               if (currentInvoice == null)
               {
                    HttpContext.Current.Response.Redirect("/status.aspx?msg=invoicenotfound");
               }

               return currentInvoice;
          }

          //public static ReceivedGoodsOrder GetReceivedGoodsOrder()
          //{

          //     if (HttpContext.Current.Request.QueryString["receivedgoodsorder_id"] == null)
          //     {
          //          HttpContext.Current.Response.Redirect("/manage/ReceivedGoods/ReceivedGoodsHome.aspx");
          //     }

          //     int receivedgoodsorder_id = Convert.ToInt32(HttpContext.Current.Request.QueryString["receivedgoodsorder_id"]);

          //     var currentOrder = ReceivedGoodsOrder.GetReceivedGoodsOrder(receivedgoodsorder_id);

          //     if (currentOrder == null)
          //     {
          //          HttpContext.Current.Response.Redirect("/status.aspx?msg=ordernotfound");
          //     }

          //     return currentOrder;
          //}


          public static DataTable ListToDataTable<T>(List<T> list)
          {
               DataTable dt = new DataTable();

               foreach (PropertyInfo info in typeof(T).GetProperties())
               {
                    dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
               }
               foreach (T t in list)
               {
                    DataRow row = dt.NewRow();
                    foreach (PropertyInfo info in typeof(T).GetProperties())
                    {
                         row[info.Name] = info.GetValue(t, null);
                    }
                    dt.Rows.Add(row);
               }
               return dt;
          }

          public static string GenerateFiveDigitRandom()
          {
               Random r = new Random();
               int num = r.Next(0, 99999);

               string output = num.ToString().Trim();
               return output;
          }


          /// <summary>
          /// Used for encoding receipt content before sending to server. This removes http issue with esc characters.
          /// </summary>
          /// <param name="toEncode"></param>
          /// <returns></returns>
          public static string EncodeToBase64(string toEncode)
          {
               byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

               string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

               return returnValue;
          }


          public static string DecodeFromBase64(string encodedData)
          {
               byte[] encodedDataAsBytes
                   = System.Convert.FromBase64String(encodedData);
               string returnValue =
                  System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
               return returnValue;
          }

          /// <summary>
          /// This is a hack to see if a date field is null in an object from the DAL.
          /// </summary>
          /// <param name="testDate"></param>
          /// <returns></returns>
          public static bool isDateSet(DateTime testDate)
          {
               DateTime test = new DateTime(0001, 01, 01);
               return (!(testDate == test));
          }


          /// <summary>
          /// Offsets are relative to Greenwich Mean Time. Server is US Pacific
          /// </summary>
          private static int serverDatetimeOffset = -8;

          /// <summary>
          /// Stores are Australian Eastern 
          /// </summary>
          private static int storeDatetimeOffset = 10;

          public static DateTime ConvertServerDateTimetoLocal(DateTime serverDatetime)
          {
               return serverDatetime.AddHours(storeDatetimeOffset - serverDatetimeOffset);
          }

          /// <summary>
          /// Function to get byte array from a file
          /// </summary>
          /// <param name="_FileName">File name to get byte array</param>
          /// <returns>Byte Array</returns>
          public static byte[] FileToByteArray(string _FileName)
          {
               byte[] _Buffer = null;

               try
               {
                    // Open file for reading
                    System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // attach filestream to binary reader
                    System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

                    // get total byte length of the file
                    long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

                    // read entire file into buffer
                    _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                    // close file reader
                    _FileStream.Close();
                    _FileStream.Dispose();
                    _BinaryReader.Close();
               }
               catch (Exception _Exception)
               {
                    // Error
                    Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
               }

               return _Buffer;
          }


     }
}