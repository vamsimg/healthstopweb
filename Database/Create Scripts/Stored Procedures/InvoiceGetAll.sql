/****** Object:  Stored Procedure InvoiceGetAll - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[InvoiceGetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [InvoiceGetAll]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:49:01 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

CREATE PROCEDURE [InvoiceGetAll]

AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT 	[Invoices].[invoice_id],
	[Invoices].[customer_id],
	[Invoices].[supplier_id],
	[Invoices].[purchaseorder_id],
	[Invoices].[freight],
	[Invoices].[total],
	[Invoices].[tax],
	[Invoices].[is_downloaded],
	[Invoices].[creation_datetime],
	[Invoices].[local_code],
	[Invoices].[downloaded_datetime] 
FROM [dbo].[Invoices]

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
