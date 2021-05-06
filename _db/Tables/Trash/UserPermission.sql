USE NTIERDB
GO


IF EXISTS (select * from sysobjects
	WHERE id = object_id(N'[dbo].[UsePermissionSelectByUserTypeId]')
	AND OBJECTPROPERTY(id, N'IsProcedure') = 1)

	DROP PROCEDURE [dbo].[UsePermissionSelectByUserTypeId]
GO

CREATE PROC [dbo].[UsePermissionSelectByUserTypeId]
	@UserTypeId tinyint
AS

BEGIN
	SELECT [UserPermissionId]
      ,[UserTypeId]
      ,[ModuleId]
      ,[Add]
      ,[Edit]
      ,[View]
      ,[Delete]
      ,[ListView]
      ,[FileUpload]
      ,[FileDownload] FROM [dbo].[UserPermission]
	WHERE [UserTypeId] = @UserTypeId

END


GO


IF EXISTS(SELECT * FROM sysobjects
	WHERE id = object_id(N'[dbo].[UpdateUserPermission]')
	AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )

	DROP PROCEDURE [dbo].[UpdateUserPermission]
GO


CREATE PROC [dbo].[UpdateUserPermission]
	@UserPermissionId uniqueidentifier,
	@UserTypeId tinyint,
	@ModuleId smallint,
	@Add int,
	@Edit int,
	@View int,
	@Delete int,
	@ListView int,
	@FileUpload int,
	@FileDownload int
AS
	BEGIN
		UPDATE [dbo].[UserPermission] SET
		[UserTypeId] = @UserTypeId,
		[ModuleId] = @ModuleId,
		[Add] = @Add,
		[Edit] = @Edit,
		[View] = @View,
		[Delete] = @Delete,
		[ListView] = @ListView,
		[FileUpload] = @FileUpload,
		[FileDownload]= @FileDownload

		WHERE [UserPermissionId] = @UserPermissionId
	END

GO




IF EXISTS(SELECT * FROM sysobjects
	WHERE id = object_id(N'[dbo].[DeleteUserPermission]')
	AND OBJECTPROPERTY(id, N'IsProcedure') = 1)

	DROP PROCEDURE [dbo].[DeleteUserPermission]
GO

CREATE PROC [dbo].[DeleteUserPermission]
	@UserPermissionId uniqueidentifier
AS

	SET NOCOUNT ON

	DELETE FROM [dbo].[UserPermission]
	WHERE [UserPermissionId] = @UserPermissionId

	SET NOCOUNT OFF

GO