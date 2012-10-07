/****** Object:  Stored Procedure PurchaseOrderGetByCompany - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[PurchaseOrderGetByCompany]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [PurchaseOrderGetByCompany]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:49:05 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

CREATE PROCEDURE [PurchaseOrderGetByCompany]
	@supplier_id int
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT 
	[PurchaseOrders].[purchaseorder_id],
	[PurchaseOrders].[customer_id],
	[PurchaseOrders].[supplier_id],
	[PurchaseOrders].[person],
	[PurchaseOrders].[creation_datetime],
	[PurchaseOrders].[local_code],
	[PurchaseOrders].[is_submitted],
	[PurchaseOrders].[submitted_datetime],
	[PurchaseOrders].[due_datetime] 
FROM 
	[dbo].[PurchaseOrders] 
WHERE 
	[PurchaseOrders].[supplier_id] = @supplier_id

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO