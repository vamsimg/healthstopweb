/****** Object:  Stored Procedure PermissionGetByRole - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[PermissionGetByRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [PermissionGetByRole]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:49:03 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

CREATE PROCEDURE [PermissionGetByRole]
	@role_name varchar(100)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT 
	[Permissions].[permission_id],
	[Permissions].[role_name],
	[Permissions].[admin_id],
	[Permissions].[company_id],
	[Permissions].[authoriser_id],
	[Permissions].[company_position],
	[Permissions].[creation_datetime] 
FROM 
	[dbo].[Permissions] 
WHERE 
	[Permissions].[role_name] = @role_name

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO