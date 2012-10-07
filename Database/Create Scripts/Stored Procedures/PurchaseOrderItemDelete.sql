/****** Object:  Stored Procedure PurchaseOrderItemDelete - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[PurchaseOrderItemDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [PurchaseOrderItemDelete]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:49:04 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

CREATE PROCEDURE [PurchaseOrderItemDelete]
	@purchaseorder_id int,
	@product_code varchar(100)
AS

DELETE FROM [dbo].[PurchaseOrderItems]
WHERE 
	[PurchaseOrderItems].[purchaseorder_id] = @purchaseorder_id
	AND [PurchaseOrderItems].[product_code] = @product_code

GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
