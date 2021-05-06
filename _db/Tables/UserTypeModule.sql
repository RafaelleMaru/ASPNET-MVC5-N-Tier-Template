
USE [NTIERDB]
GO



IF EXISTS(SELECT * from dbo.sysobjects
			WHERE id = object_id(N'[dbo].[UserTypeModuleInsert]')
			and OBJECTPROPERTY(id, N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeModuleInsert]
GO

CREATE PROC [dbo].[UserTypeModuleInsert]
	@UserTypeId tinyint,
	@ModuleId smallint,
	@Permission bigint,
	@Created varchar(120),
	@Updated varchar(120)
AS

BEGIN
	INSERT INTO [UserTypeModule]
	(
			[UserTypeId]
           ,[ModuleId]
           ,[Permission]
           ,[Created]
           ,[CreatedBy]
           ,[Updated]
           ,[UpdatedBy]
	)
	VALUES
	(
			@UserTypeId,
			@ModuleId,
			@Permission,
			@Created,
			GETDATE(),
			@Updated,
			GETDATE()
	)
	 
	SELECT SCOPE_IDENTITY()
END

GO



IF EXISTS (SELECT * FROM dbo.sysobjects
			WHERE id = object_id(N'[dbo].[UserTypeModuleUpdate]')
			and OBJECTPROPERTY(id,N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeModuleUpdate]
GO

CREATE PROC [dbo].[UserTypeModuleUpdate]
@UserTypeModuleId int,
@UserTypeId tinyint,
@ModuleId smallint,
@Permission bigint,
@UpdatedBy varchar(120)
AS
	UPDATE [dbo].[UserTypeModule]
	SET [UserTypeId] = @UserTypeId,
		[ModuleId] = @ModuleId,
		[Permission] = @Permission,
		[Updated] = GETDATE(),
		[UpdatedBy] = @UpdatedBy
	WHERE UserTypeModuleId = @UserTypeModuleId
GO


IF EXISTS (SELECT * FROM dbo.sysobjects	
			WHERE id = object_id(N'[dbo].[UserTypeModuleDelete]')
			and OBJECTPROPERTY(id, N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeModuleDelete]
GO

CREATE PROC [dbo].[UserTypeModuleDelete]
	@UserTypeModuleId TINYINT
AS
	DELETE FROM [dbo].[UserTypeModule]
	WHERE [UserTypeModuleId] = @UserTypeModuleId
GO





IF EXISTS (SELECT * FROM dbo.sysobjects	
			WHERE id = object_id(N'[dbo].[UserTypeModuleSelectByUserTypeId]')
			and OBJECTPROPERTY(id, N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeModuleSelectByUserTypeId]
GO

CREATE PROC [dbo].[UserTypeModuleSelectByUserTypeId]
	@UserTypeId TINYINT
AS
	SELECT * FROM [dbo].[UserTypeModule]
	WHERE [UserTypeId] = @UserTypeId
GO


IF EXISTS (SELECT * FROM dbo.sysobjects	
			WHERE id = object_id(N'[dbo].[UserTypeModuleSelectByUserTypeIdAndModuleId]')
			and OBJECTPROPERTY(id, N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeModuleSelectByUserTypeIdAndModuleId]
GO

CREATE PROC [dbo].[UserTypeModuleSelectByUserTypeIdAndModuleId]
	@UserTypeId TINYINT,
	@ModuleId SMALLINT
AS
	SELECT * FROM [dbo].[UserTypeModule]
	WHERE [UserTypeId] = @UserTypeId AND [ModuleId] = @ModuleId
GO