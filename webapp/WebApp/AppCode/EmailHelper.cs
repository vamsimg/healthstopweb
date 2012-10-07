using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;
using System.IO;
using HealthStop.Business;

namespace HealthStop.Web.AppCode
{
     public static class EmailHelper
     {
          public const string sender = "help@healthstop.com.au";
          public const string backupAddress = "backup@healthstop.com.au";

          // For testing use only
          //private const string domain = "localhost:1072";
          //


          public static void SendGenericEmail(string recipient, string subject, string body)
          {
               // create mail message object
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress(sender);		       // put the from address here
               mail.To.Add(new MailAddress(recipient));             // put to address here
               mail.Subject = subject;						  // put subject here			
               mail.Body = body;							  // put body of email here
               SmtpClient client = new SmtpClient();
               try
               {
                    client.Send(mail);
               }
               catch (Exception ex)
               {
                    throw ex;
               }
          }

          /// <summary>
          /// Sends a welcome email to a new admin added by an owner .
          /// </summary>
          /// <param name="newEmail"></param>
          /// <param name="fullName"></param>
          public static void AdminAccountCreationEmail(string newEmail, string fullName, string owner, string role, string company)
          {
               // create mail message object
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress(sender);		       // put the from address here
               mail.To.Add(new MailAddress(newEmail));             // put to address here
               mail.Subject = "Welcome to HealthStop";			  // put subject here	

               string serverPath = System.Web.HttpContext.Current.Server.MapPath("/email/");
               string body = File.ReadAllText(serverPath + "AdminAccountCreationEmail.txt");

               body = body.Replace("$full_name", fullName);
               body = body.Replace("$role", role);
               body = body.Replace("$owner", owner);
               body = body.Replace("$company", company);

               mail.Body = body;							  // put body of email here
               SmtpClient client = new SmtpClient();
               try
               {
                    client.Send(mail);
               }
               catch (Exception ex)
               {
                    throw ex;
               }
          }





          /// <summary>
          /// Sends a new password to a user.
          /// </summary>
          /// <param name="email"></param>
          /// <param name="new_password"></param>
          public static void PasswordResetEmail(string email, string new_password)
          {
               // create mail message object
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress(sender);           // put the from address here
               mail.To.Add(new MailAddress(email));             // put to address here

               mail.Subject = "Password reset from HealthStop";        // put subject here	
               string serverPath = HttpContext.Current.Server.MapPath("/email/");
               string body = File.ReadAllText(serverPath + "PasswordResetEmail.txt");

               body = body.Replace("$new_password", new_password);
               mail.Body = body;



               SmtpClient client = new SmtpClient();
               try
               {
                    client.Send(mail);
               }
               catch (Exception ex)
               {
                    throw ex;
               }

          }


          public static void StorePasswordEmail(string email, string new_password, string store_details)
          {
               // create mail message object
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress(sender);           // put the from address here
               mail.To.Add(new MailAddress(email));             // put to address here

               mail.Subject = "Store Password reset from HealthStop";        // put subject here	
               string serverPath = HttpContext.Current.Server.MapPath("/email/");
               string body = File.ReadAllText(serverPath + "StorePasswordResetEmail.txt");

               body = body.Replace("$store_details", store_details);
               body = body.Replace("$new_password", new_password);

               mail.Body = body;



               SmtpClient client = new SmtpClient();
               try
               {
                    client.Send(mail);
               }
               catch (Exception ex)
               {
                    throw ex;
               }

          }

          public static void RequestAccess(Admin requestingAdmin, Company customer ,Company supplier )
          {
               // create mail message object
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress(sender);		       // put the from address here
               mail.To.Add(new MailAddress(supplier.contact_email));             // put to address here
               mail.Subject = "New Request from a retailer in Healthstop";			  // put subject here	

               string serverPath = HttpContext.Current.Server.MapPath("/email/");
               string body = File.ReadAllText(serverPath + "RequestAccessEmail.txt");

               body = body.Replace("$fullName", requestingAdmin.full_name);
               body = body.Replace("$store", customer.name);
               body = body.Replace("$abn", customer.company_number);
               body = body.Replace("$email", customer.contact_email);
               body = body.Replace("$phone", customer.phone);


               mail.Body = body;



               SmtpClient client = new SmtpClient();
               try
               {
                    client.Send(mail);
               }
               catch (Exception ex)
               {
                    throw ex;
               }
          }

          public static void SendXMLOrder(string person, Company customer, Company supplier, string orderXML)
          {
               // create mail message object
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress(sender);		       // put the from address here
               mail.To.Add(new MailAddress(supplier.transactions_email));             // put to address here
               mail.CC.Add(new MailAddress(customer.transactions_email));
               //mail.Bcc.Add(new MailAddress(backupAddress));
               mail.Subject = "New purchase order from " + person + " at " + customer.name;			  // put subject here	

               mail.Body = orderXML;

               SmtpClient client = new SmtpClient();
               try
               {
                    client.Send(mail);
               }
               catch (Exception ex)
               {
                    throw ex;
               }
          }

          public static void SendInvoice(Invoice newInvoice)
          {
               // create mail message object
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress(sender);		       // put the from address here
               mail.To.Add(new MailAddress(newInvoice.customer_.transactions_email));             // put to address here
               //mail.Bcc.Add(new MailAddress(backupAddress));


               mail.Subject = "Invoice # " + newInvoice.invoice_id.ToString() + " available.";			  // put subject here	


               string serverPath = HttpContext.Current.Server.MapPath("/email/");
               string body = File.ReadAllText(serverPath + "InvoiceEmail.txt");

               body = body.Replace("$invoiceID", newInvoice.invoice_id.ToString());
               body = body.Replace("$supplierName", newInvoice.supplierName);
               body = body.Replace("$local_code", newInvoice.local_code);
               body = body.Replace("$purchaseorder_code", newInvoice.purchaseorder_.local_code);
               body = body.Replace("$freight", newInvoice.freight.ToString("#0.00"));
               body = body.Replace("$tax", newInvoice.tax.ToString("#0.00"));
               body = body.Replace("$total", newInvoice.total.ToString("#0.00"));

               
               string invoiceItemHeader = "Barcode\t\tGST?\tRRP\tQty\tCostEx\tDescription";
               body = body.Replace("$invoiceItemHeader", invoiceItemHeader);

               string invoiceItems = "";
               foreach (var item in newInvoice.InvoiceItemsByinvoice_)
               {
                    string gst = item.is_GST ? "GST" : "FRE";                    

                    invoiceItems += item.barcode + "\t" + gst + "\t" + item.RRP.ToString("#0.00") + "\t" + item.quantity + "\t" + item.cost_price.ToString("#0.00") + "\t" + item.description + "\r\n";
               }

               body = body.Replace("$invoiceItems", invoiceItems);

               mail.Body = body;

               SmtpClient client = new SmtpClient();
               try
               {
                    client.Send(mail);
               }
               catch (Exception ex)
               {
                    throw ex;
               }
          }
     }
}