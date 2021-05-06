USE NTIERDB
GO

IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[ModuleSelectAll]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[ModuleSelectAll]

GO

CREATE PROC [dbo].[ModuleSelectAll]
    
AS

    SET NOCOUNT ON

    SELECT [ModuleId]
      ,[ModuleName]
      ,[ValidPermission]
    FROM [Module]
        

    SET NOCOUNT OFF

GO