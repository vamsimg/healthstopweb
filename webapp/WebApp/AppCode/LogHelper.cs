using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthStop.Web.AppCode
{
     /// <summary>
     /// Summary description for ErrorHelper
     /// </summary>
     public static class LogHelper
     {
          /// Handles error by accepting the error message 
          /// Displays the page on which the error occured
          public static void WriteError(string errorMessage)
          {
               try
               {
                    string path = "/logs/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                    if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                    {
                         System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                    }
                    using (System.IO.StreamWriter w = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                    {
                         w.WriteLine("\r\nLog Entry : ");
                         w.WriteLine("{0}", DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
                         string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +
                                       ". Error Message:" + errorMessage;
                         w.WriteLine(err);
                         w.WriteLine("__________________________");
                         w.Flush();
                         w.Close();
                    }
               }
               catch (Exception ex)
               {
                    WriteError(ex.Message);
               }
          }

          public static void WriteStatus(string message)
          {
               try
               {
                    string path = "/logs/status_" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                    if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                    {
                         System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                    }
                    using (System.IO.StreamWriter w = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                    {
                         message = DateTime.Now.ToString() + " , " + message;
                         w.WriteLine(message);
                         w.Flush();
                         w.Close();
                    }
               }
               catch (Exception ex)
               {
                    WriteError(ex.Message);
               }
          }

     }
}