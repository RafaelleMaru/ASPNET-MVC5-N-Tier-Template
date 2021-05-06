USE NTIERDB
GO

SET IDENTITY_INSERT [dbo].[Module] ON





IF NOT EXISTS(SELECT ModuleName FROM [dbo].[Module]
	WHERE [ModuleId] = 1)

BEGIN
	INSERT INTO [dbo].[Module] (
		[ModuleId], [ModuleName],[ValidPermission]
	)
	VALUES (1,'User',31)
END

GO



IF NOT EXISTS(SELECT ModuleName FROM [dbo].[Module]
	WHERE [ModuleId] = 2)

BEGIN
	INSERT INTO [dbo].[Module] (
		[ModuleId], [ModuleName],[ValidPermission]
	)
	VALUES (2,'UserType',31)
END

GO




IF NOT EXISTS(SELECT ModuleName FROM [dbo].[Module]
	WHERE [ModuleId] = 3)

BEGIN
	INSERT INTO [dbo].[Module] (
		[ModuleId], [ModuleName],[ValidPermission]
	)
	VALUES (3,'Permission',31)
END

GO


SET IDENTITY_INSERT [dbo].[Module] OFF