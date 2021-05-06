USE NTIERDB
GO

IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserTypeModuleList]')
    and OBJECTPROPERTY(id, N'IsView') = 1)
    DROP VIEW [dbo].[UserTypeModuleList]
GO

CREATE VIEW [dbo].[UserTypeModuleList]  
AS

	SELECT DISTINCT
	  T1.[UserTypeModuleID],  
	  T1.[ModuleID],
	  T1.[UserTypeID], 
	  T2.[ModuleName],
	  T1.[Permission],
	  T2.[ValidPermission]
  FROM [UserTypeModule] AS T1
	INNER JOIN [Module] T2 ON T1.[ModuleID] = T2.[ModuleID]
  WHERE (T2.ModuleID > 0)

GO
