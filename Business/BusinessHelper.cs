using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace HealthStop.Business
{
     public class BusinessHelper
     {
          public static string computeSHAhash(string password, DateTime salt)
          {

               byte[] tmpSource;
               byte[] result;

               string password_salted = password + salt.ToString();

               tmpSource = ASCIIEncoding.ASCII.GetBytes(password_salted);

               SHA512 shaM = new SHA512Managed();
               result = shaM.ComputeHash(tmpSource);

               string password_hashed = ByteArrayTostring(result);

               return password_hashed;
          }

          public static string ByteArrayTostring(byte[] arrInput)
          {
               int i;
               StringBuilder sOutput = new StringBuilder(arrInput.Length);
               for (i = 0; i < arrInput.Length; i++)
               {
                    sOutput.Append(arrInput[i].ToString("X2"));
               }
               return sOutput.ToString();
          }
     }
}
