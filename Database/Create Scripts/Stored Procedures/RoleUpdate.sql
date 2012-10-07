/****** Object:  Stored Procedure RoleUpdate - Script Date: Friday, 10 August 2012 ******/
if exists (select * from sysobjects where id = object_id(N'[RoleUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [RoleUpdate]
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

CREATE PROCEDURE [RoleUpdate]
	@role_name varchar(100),
	@notes varchar(100)
AS

DECLARE @table TABLE(
	[role_name] varchar(100),
	[notes] varchar(100)
);

UPDATE [dbo].[Roles] SET 
	[Roles].[notes] = @notes 
output 
	INSERTED.[role_name],
	INSERTED.[notes]
into @table
WHERE 
	[Roles].[role_name] = @role_name

SELECT 
	[role_name],
	[notes] 
FROM @table;


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

