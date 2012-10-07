/****** Object:  Stored Procedure PurchaseOrderUpdate - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[PurchaseOrderUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [PurchaseOrderUpdate]
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

CREATE PROCEDURE [PurchaseOrderUpdate]
	@purchaseorder_id int,
	@customer_id int,
	@supplier_id int,
	@person varchar(100),
	@creation_datetime datetime,
	@local_code varchar(100),
	@is_submitted bit,
	@submitted_datetime datetime,
	@due_datetime datetime
AS

DECLARE @table TABLE(
	[purchaseorder_id] int,
	[customer_id] int,
	[supplier_id] int,
	[person] varchar(100),
	[creation_datetime] datetime,
	[local_code] varchar(100),
	[is_submitted] bit,
	[submitted_datetime] datetime,
	[due_datetime] datetime
);

UPDATE [dbo].[PurchaseOrders] SET 
	[PurchaseOrders].[customer_id] = @customer_id,
	[PurchaseOrders].[supplier_id] = @supplier_id,
	[PurchaseOrders].[person] = @person,
	[PurchaseOrders].[creation_datetime] = @creation_datetime,
	[PurchaseOrders].[local_code] = @local_code,
	[PurchaseOrders].[is_submitted] = @is_submitted,
	[PurchaseOrders].[submitted_datetime] = @submitted_datetime,
	[PurchaseOrders].[due_datetime] = @due_datetime 
output 
	INSERTED.[purchaseorder_id],
	INSERTED.[customer_id],
	INSERTED.[supplier_id],
	INSERTED.[person],
	INSERTED.[creation_datetime],
	INSERTED.[local_code],
	INSERTED.[is_submitted],
	INSERTED.[submitted_datetime],
	INSERTED.[due_datetime]
into @table
WHERE 
	[PurchaseOrders].[purchaseorder_id] = @purchaseorder_id

SELECT 
	[purchaseorder_id],
	[customer_id],
	[supplier_id],
	[person],
	[creation_datetime],
	[local_code],
	[is_submitted],
	[submitted_datetime],
	[due_datetime] 
FROM @table;


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


