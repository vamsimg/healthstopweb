/****** Object:  Stored Procedure RoleGet - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[RoleGet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [RoleGet]
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

CREATE PROCEDURE [RoleGet]
	@role_name varchar(100)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT 
	[Roles].[role_name],
	[Roles].[notes] 
FROM [dbo].[Roles] 
WHERE 
	[Roles].[role_name] = @role_name

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
