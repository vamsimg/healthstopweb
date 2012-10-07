/****** Object:  Stored Procedure CompanyGetAll - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[CompanyGetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [CompanyGetAll]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:48:58 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

CREATE PROCEDURE [CompanyGetAll]

AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT 	[Companies].[company_id],
	[Companies].[name],
	[Companies].[brand_name],
	[Companies].[company_number],
	[Companies].[contact_name],
	[Companies].[contact_email],
	[Companies].[transactions_email],
	[Companies].[address],
	[Companies].[suburb],
	[Companies].[state],
	[Companies].[country],
	[Companies].[postcode],
	[Companies].[phone],
	[Companies].[website],
	[Companies].[api_key],
	[Companies].[notes],
	[Companies].[is_active],
	[Companies].[is_customer],
	[Companies].[is_supplier],
	[Companies].[is_manufacturer],
	[Companies].[paidto_datetime],
	[Companies].[creation_datetime],
	[Companies].[has_POSSystem] 
FROM [dbo].[Companies]

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
