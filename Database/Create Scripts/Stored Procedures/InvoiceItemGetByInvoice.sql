/****** Object:  Stored Procedure InvoiceItemGetByInvoice - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[InvoiceItemGetByInvoice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [InvoiceItemGetByInvoice]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:49:00 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

CREATE PROCEDURE [InvoiceItemGetByInvoice]
	@invoice_id int
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT 
	[InvoiceItems].[invoice_id],
	[InvoiceItems].[product_code],
	[InvoiceItems].[barcode],
	[InvoiceItems].[description],
	[InvoiceItems].[quantity],
	[InvoiceItems].[cost_price],
	[InvoiceItems].[RRP],
	[InvoiceItems].[is_GST] 
FROM 
	[dbo].[InvoiceItems] 
WHERE 
	[InvoiceItems].[invoice_id] = @invoice_id

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO