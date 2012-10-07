/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 15/07/2012 3:36:24 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will NOT be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using HealthStop.Business.Framework;

namespace HealthStop.Business
{
	/// <summary>
	/// This object represents the properties and methods of a InvoiceItem.
	/// </summary>
	public partial class InvoiceItem : EntityBase
	{
          public decimal taxAmount
          {
               get
               {
                    decimal taxRate = 0;

                    if (this.is_GST)
                    {
                         taxRate = 0.1M;
                    }

                    return subTotal * taxRate;
               }
          }

          public decimal subTotal
          {
               get
               {
                   return ((decimal)this.quantity * this.cost_price);
               }
          }
	}
}