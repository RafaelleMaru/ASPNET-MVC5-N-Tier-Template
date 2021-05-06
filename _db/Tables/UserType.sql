/*
Collabor8digital Media Inc., 2018
Rafaelle Maru Villegas
Created: April 24, 2018 10:40 PM
Updated: April 24, 2018 5:54 PM
*/

USE [NTIERDB]
GO



IF EXISTS(SELECT * from dbo.sysobjects
			WHERE id = object_id(N'[dbo].[UserTypeInsert]')
			and OBJECTPROPERTY(id, N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeInsert]
GO

CREATE PROC [dbo].[UserTypeInsert]
	@UserTypeName varchar(120)
AS

BEGIN
	INSERT INTO [UserType]
	(
		[UserTypeName]
	)
	VALUES
	(
		@UserTypeName
	)
	 
	SELECT SCOPE_IDENTITY()
END

GO

IF EXISTS (SELECT * FROM dbo.sysobjects
			WHERE id = object_id(N'[dbo].[UserTypeUpdate]')
			and OBJECTPROPERTY(id,N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeUpdate]
GO

CREATE PROC [dbo].[UserTypeUpdate]
@UserTypeId TINYINT,
@UserTypeName varchar(120)
AS
	UPDATE [dbo].[UserType]
	SET UserTypeName = @UserTypeName
	WHERE UserTypeId = @UserTypeId
GO


IF EXISTS (SELECT * FROM dbo.sysobjects	
			WHERE id = object_id(N'[dbo].[UserTypeDelete]')
			and OBJECTPROPERTY(id, N'IsProcedure') = 1)

			DROP PROCEDURE [dbo].[UserTypeDelete]
GO

CREATE PROC [dbo].[UserTypeDelete]
	@UserTypeId TINYINT
AS
	DELETE FROM [dbo].[UserType]
	WHERE [UserTypeId] = @UserTypeId
GO

IF EXISTS(SELECT * FROM dbo.sysobjects
		WHERE id = object_id(N'[dbo].[UserTypeSelectAll]')
		and OBJECTPROPERTY(id, N'IsProcedure') = 1)

		DROP PROCEDURE [dbo].[UserTypeSelectAll]

GO

CREATE PROC [dbo].[UserTypeSelectAll]

AS
	SET NOCOUNT ON

	SELECT [UserType].[UserTypeId], [UserType].[UserTypeName] FROM [dbo].[UserType]

	SET NOCOUNT OFF
GO





/* UserSearchPagedOrderBy integrated with DataTable Plugin
** This query returns Search, Sorting, Page Lenght and Pagination
** 
*/ 

IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserTypeSearchPagedOrderBy]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserTypeSearchPagedOrderBy]

GO

CREATE PROC  [dbo].[UserTypeSearchPagedOrderBy]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir BIT,
@Search nvarchar(255),
@CountSelected INT OUTPUT,
@Count INT OUTPUT
AS

BEGIN
	Declare @FirstRec int, @LastRec int
	SET @FirstRec = @DisplayStart;
	SET @LastRec = @DisplayStart + @DisplayLength;
	
	IF @SortDir = 0
        SET @SortCol = @SortCol + 1000;
	

	DECLARE @TempTable TABLE
    (
        [ROWNUM] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
        [UserTypeId] TINYINT
    )

	SET ROWCOUNT @LastRec;


	INSERT @TempTable
        (
            [UserTypeId]
        )
        SELECT [UserTypeId]
            FROM [UserType]
            WHERE ([UserTypeName] LIKE '%' + @Search + '%')
            ORDER BY
                CASE @SortCol
                    WHEN 0 THEN
					CONVERT(VARCHAR(36), [UserTypeId])
                END DESC

    SELECT [UserType].[UserTypeId], [UserTypeName]
        FROM @TempTable TEMPTBL
            INNER JOIN [UserType] ON [UserType].[UserTypeId] = TEMPTBL.[UserTypeId]
        WHERE (@DisplayStart <= ROWNUM)
            AND ([UserTypeName] LIKE '%' + @Search + '%')
             

		SELECT @CountSelected = COUNT([UserType].[UserTypeId])
        FROM @TempTable TEMPTBL
            INNER JOIN [UserType] ON [UserType].[UserTypeId] = TEMPTBL.[UserTypeId]
        WHERE (@DisplayStart <= ROWNUM)
            AND ([UserTypeName] LIKE '%' + @Search + '%')


		SELECT @Count = COUNT(UserTypeId) 
        FROM [UserType]
		WHERE ([UserTypeName] LIKE '%' + @Search + '%')

    SET ROWCOUNT 0

END

GO


IF EXISTS(select * from dbo.sysobjects
		WHERE id = Object_id(N'[dbo].[UserTypeSelectById]')
		and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
		
		DROP PROCEDURE [dbo].[UserTypeSelectById]
GO 


CREATE PROC [dbo].[UserTypeSelectById]
@UserTypeId tinyint
AS

BEGIN
	SELECT * FROM [dbo].[UserType]
	WHERE [UserTypeId] = @UserTypeId
END

GO
	


	/* SelectAll integrated with DataTable Plugin
** This query returns Page with Paged Order By
** 
*/ 
IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserTypeSelectAllPagedOrderBy]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserTypeSelectAllPagedOrderBy]

GO

--DROP PROCEDURE [dbo].[UserTypeSelectAllPagedOrderBy]
CREATE PROC  [dbo].[UserTypeSelectAllPagedOrderBy]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir BIT,
@CountSelected INT OUTPUT,
@Count INT OUTPUT
AS

BEGIN
	Declare @FirstRec int, @LastRec int
	SET @FirstRec = @DisplayStart;
	SET @LastRec = @DisplayStart + @DisplayLength;
	
	IF @SortDir = 0
        SET @SortCol = @SortCol + 1000;
	

	DECLARE @TempTable TABLE
    (
        [ROWNUM] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
        [UserTypeId] tinyint
    )

	SET ROWCOUNT @LastRec;


	INSERT @TempTable
        (
            [UserTypeId]
        )
        SELECT [UserTypeId]
            FROM [UserType]
            
            ORDER BY
                CASE @SortCol
                    WHEN 0 THEN
					RIGHT(REPLICATE('0', 24) + CONVERT(VARCHAR(32), [UserTypeId]), 24)
                END ASC,
                CASE @SortCol
                    WHEN 1000 THEN
					RIGHT(REPLICATE('0', 24) + CONVERT(VARCHAR(32), [UserTypeId]), 24)
                END DESC

    SELECT [UserType].[UserTypeId], [UserTypeName]
        FROM @TempTable TEMPTBL
            INNER JOIN [UserType] ON [UserType].[UserTypeId] = TEMPTBL.[UserTypeId]
        WHERE (@DisplayStart <= ROWNUM)
           
		

		SELECT @CountSelected = COUNT([UserType].[UserTypeId])
        FROM @TempTable TEMPTBL
            INNER JOIN [UserType] ON [UserType].[UserTypeId] = TEMPTBL.[UserTypeId]
        WHERE (@DisplayStart <= ROWNUM)
            


		SELECT @Count = COUNT(UserTypeId) 
        FROM [UserType]

    SET ROWCOUNT 0

END

GO



IF EXISTS(select * from dbo.sysobjects
		WHERE id = Object_id(N'[dbo].[UserTypeSelectByUserTypeName]')
		and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
		
		DROP PROCEDURE [dbo].[UserTypeSelectByUserTypeName]
GO 


CREATE PROC [dbo].[UserTypeSelectByUserTypeName]
@UserTypeName varchar(120)
AS

BEGIN
	SELECT * FROM [dbo].[UserType]
	WHERE [UserTypeName] = @UserTypeName
END

GO
	