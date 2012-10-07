/****** Object:  Stored Procedure PurchaseOrderItemUpdate - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[PurchaseOrderItemUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [PurchaseOrderItemUpdate]
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

CREATE PROCEDURE [PurchaseOrderItemUpdate]
	@purchaseorder_id int,
	@product_code varchar(100),
	@barcode varchar(100),
	@description varchar(100),
	@quantity float,
	@cost_price money
AS

DECLARE @table TABLE(
	[purchaseorder_id] int,
	[product_code] varchar(100),
	[barcode] varchar(100),
	[description] varchar(100),
	[quantity] float,
	[cost_price] money
);

UPDATE [dbo].[PurchaseOrderItems] SET 
	[PurchaseOrderItems].[barcode] = @barcode,
	[PurchaseOrderItems].[description] = @description,
	[PurchaseOrderItems].[quantity] = @quantity,
	[PurchaseOrderItems].[cost_price] = @cost_price 
output 
	INSERTED.[purchaseorder_id],
	INSERTED.[product_code],
	INSERTED.[barcode],
	INSERTED.[description],
	INSERTED.[quantity],
	INSERTED.[cost_price]
into @table
WHERE 
	[PurchaseOrderItems].[purchaseorder_id] = @purchaseorder_id
	AND [PurchaseOrderItems].[product_code] = @product_code

SELECT 
	[purchaseorder_id],
	[product_code],
	[barcode],
	[description],
	[quantity],
	[cost_price] 
FROM @table;


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


