USE NTIERDB
GO

SET IDENTITY_INSERT [dbo].[UserType] ON

IF NOT EXISTS(select * from UserType
	WHERE UserTypeId = 1)

	BEGIN
		INSERT INTO [dbo].[UserType](
			[UserTypeId],
			[UserTypeName]
		)
		VALUES (
			1,
			'System Administrator'
		)



	END

GO


IF NOT EXISTS(select * from UserType
	WHERE UserTypeId = 2)

	BEGIN
		INSERT INTO [dbo].[UserType](
			[UserTypeId],
			[UserTypeName]
		)
		VALUES (
			2,
			'Staff'
		)



	END

GO

	

SET IDENTITY_INSERT [dbo].[UserType] OFF