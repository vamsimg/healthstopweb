/****** Object:  Stored Procedure InvoiceItemDelete - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[InvoiceItemDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [InvoiceItemDelete]
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

CREATE PROCEDURE [InvoiceItemDelete]
	@invoice_id int,
	@product_code varchar(100)
AS

DELETE FROM [dbo].[InvoiceItems]
WHERE 
	[InvoiceItems].[invoice_id] = @invoice_id
	AND [InvoiceItems].[product_code] = @product_code

GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
