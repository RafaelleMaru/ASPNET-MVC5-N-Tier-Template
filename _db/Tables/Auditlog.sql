/*
Collabor8 Digital Media Inc., 2018
Rafaelle Maru Villegas
Created: May 9, 2018 4:56 PM
Updated: 
*/


USE [NTIERDB]
GO


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[AuditlogInsert]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[AuditlogInsert]

GO

CREATE PROC [dbo].[AuditlogInsert]
	@UserId uniqueidentifier,
	@IPAddress varchar(128),
	@ObjectSourceType tinyint,
	@ObjectSourceID NVARCHAR(64),
	@Action tinyint ,
	@CreatedBy VARCHAR(120)
AS

    INSERT INTO [AuditLog]
         (
			[UserId]
           ,[IPAddress]
           ,[ObjectSourceType]
           ,[ObjectSourceID]
           ,[Action]
           ,[Created]
           ,[CreatedBy]
        )
     VALUES
         (
        @UserId, @IPAddress, @ObjectSourceType, @ObjectSourceID,
        @Action, GetDate(), @CreatedBy
        )

		SELECT IDENT_CURRENT('AuditLog')
GO
