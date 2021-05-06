/*
Collabor8 Digital Media Inc., 2018
Rafaelle Maru Villegas
Created: April 6, 2018 4:20 PM
Updated: April 20, 2018 5:54 PM
*/


USE [NTIERDB]
GO


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserInsert]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserInsert]

GO

CREATE PROC [dbo].[UserInsert]
    @UserId UNIQUEIDENTIFIER,
    @UserTypeID TINYINT,
    @Username varchar(120),
    @Password CHAR(128),
    @Salt CHAR(8),
	@SecurityStamp nvarchar(max),
    @Email varchar(120),
    @Firstname varchar(120),
    @Lastname varchar(120),
    @Middlename varchar(120),
    @Active BIT,
    @CreatedBy varchar(120),
    @UpdatedBy varchar(120)
AS

    INSERT INTO [User]
         (
        [UserId], [UserTypeID], [Username], [Password], [Salt], [SecurityStamp], 
        [Email], [Firstname], [Lastname], [Middlename], [Active], 
        [Created], [CreatedBy], [Updated], [UpdatedBy]
        )
     VALUES
         (
        @UserId, @UserTypeID, @Username, @Password, @Salt, @SecurityStamp,
        @Email, @Firstname, @Lastname, @Middlename, @Active, 
        GetDate(), @CreatedBy, GetDate(), @UpdatedBy
        )

         SELECT @UserId


GO




IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserUpdate]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserUpdate]

GO

CREATE PROC [dbo].[UserUpdate]
    @UserId UNIQUEIDENTIFIER,
    @UserTypeID TINYINT,
    @Username varchar(120),
    @Password CHAR(128),
    @Salt CHAR(8),
	@SecurityStamp varchar(MAX),
    @Email varchar(120),
    @Firstname varchar(120),
    @Lastname varchar(120),
    @Middlename varchar(120),
    @Active BIT,
    @UpdatedBy varchar(120),
    @Timestamp TIMESTAMP
AS

    DECLARE @TimeStampLocal AS TIMESTAMP

    SELECT @TimeStampLocal = [TimeStamp] 
        FROM [User]
        WHERE [UserId] = @UserId

    IF @TimeStamp <> @TimeStampLocal
    BEGIN
        RAISERROR ('Record are not in the same version since you last access it.', 16, 1)
        RETURN
    END

    UPDATE [User] SET
        [UserTypeID] = @UserTypeID,
        [Username] = @Username,
        [Password] = @Password,
        [Salt] = @Salt,
		[SecurityStamp] = @SecurityStamp,
        [Email] = @Email,
        [Firstname] = @Firstname,
        [Lastname] = @Lastname,
        [Middlename] = @Middlename,
        [Active] = @Active,
        [Updated] = GetDate(),
        [UpdatedBy] = @UpdatedBy
     WHERE [UserId] = @UserId

GO


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserDeleteByUserTypeID]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserDeleteByUserTypeID]

GO

CREATE PROC [dbo].[UserDeleteByUserTypeID]
    @UserTypeID TINYINT
AS

    SET NOCOUNT ON

    DELETE FROM [User]
        WHERE [UserTypeID] = @UserTypeID

    SET NOCOUNT OFF


GO



IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserDelete]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserDelete]

GO

CREATE PROC [dbo].[UserDelete]
    @UserId UNIQUEIDENTIFIER
AS

    SET NOCOUNT ON

    DELETE FROM [User]
        WHERE [UserId] = @UserId

    SET NOCOUNT OFF


GO

IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserDeleteByUserTypeID]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserDeleteByUserTypeID]

GO

CREATE PROC [dbo].[UserDeleteByUserTypeID]
    @UserTypeID TINYINT
AS

    SET NOCOUNT ON

    DELETE FROM [User]
        WHERE [UserTypeID] = @UserTypeID

    SET NOCOUNT OFF


GO

IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserSelectByUserId]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserSelectByUserId]

GO

CREATE PROC [dbo].[UserSelectByUserId]
    @UserId UNIQUEIDENTIFIER
AS

    SET NOCOUNT ON

    SELECT [UserId],[UserTypeId], [Username], [Password], [Salt], [SecurityStamp],
	[Email], [Firstname], [Lastname], [Middlename], [Active], [Created], [CreatedBy], 
	[Updated], [UpdatedBy], [TimeStamp] FROM [User]
        WHERE [UserId] = @UserId

    SET NOCOUNT OFF


GO


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserSelectByUsername]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserSelectByUsername]

GO

CREATE PROC [dbo].[UserSelectByUsername]
    @Username varchar(120)
AS

    SET NOCOUNT ON

    SELECT [UserId],[UserTypeId], [Username], [Password], [Salt], [SecurityStamp],
	[Email], [Firstname], [Lastname], [Middlename], [Active], [Created], [CreatedBy], 
	[Updated], [UpdatedBy], [TimeStamp] FROM [User]
        WHERE [Username] = @Username

    SET NOCOUNT OFF


GO


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserSelectByEmail]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserSelectByEmail]

GO

CREATE PROC [dbo].[UserSelectByEmail]
    @Email varchar(120)
AS

    SET NOCOUNT ON

    SELECT [UserId],[UserTypeId], [Username], [Password], [Salt], [SecurityStamp],
	[Email], [Firstname], [Lastname], [Middlename], [Active], [Created], [CreatedBy], 
	[Updated], [UpdatedBy], [TimeStamp] FROM [User]
        WHERE [Email] = @Email

    SET NOCOUNT OFF


GO


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserSelectAll]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserSelectAll]

GO

CREATE PROC [dbo].[UserSelectAll]
    
AS

    SET NOCOUNT ON

    SELECT [User].[UserId], [UserTypeId], [Username], [Password], [Salt], [SecurityStamp],
        [Email], [Firstname], [Lastname], [Middlename], [Active], 
        [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
    FROM [User]
        

    SET NOCOUNT OFF

GO


/* UserSearchPagedOrderBy integrated with DataTable Plugin
** This query returns Search, Sorting, Page Lenght and Pagination
** 
*/ 

IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserSearchPagedOrderBy]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserSearchPagedOrderBy]

GO

CREATE PROC  [dbo].[UserSearchPagedOrderBy]
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
        [UserId] UNIQUEIDENTIFIER
    )

	SET ROWCOUNT @LastRec;


	INSERT @TempTable
        (
            [UserId]
        )
        SELECT [UserId]
            FROM [User]
            WHERE (([Username] LIKE '%' + @Search + '%'
             OR [Password] LIKE '%' + @Search + '%'
             OR [Salt] LIKE '%' + @Search + '%'
             OR [Email] LIKE '%' + @Search + '%'
             OR [Firstname] LIKE '%' + @Search + '%'
             OR [Lastname] LIKE '%' + @Search + '%'
             OR [Middlename] LIKE '%' + @Search + '%'))
            ORDER BY
                CASE @SortCol
                    WHEN 0 THEN
					CONVERT(VARCHAR(36), [UserId])
				WHEN 1 THEN
					RIGHT(REPLICATE('0', 24) + CONVERT(VARCHAR(32), [UserTypeId]), 24)
				WHEN 2 THEN
					[Username]
				WHEN 3 THEN
					[Password]
				WHEN 4 THEN
					[Salt]
				WHEN 5 THEN
					[Email]
				WHEN 6 THEN
					[Firstname]
				WHEN 7 THEN
					[Lastname]
				WHEN 8 THEN
					[Middlename]
				WHEN 9 THEN
					CONVERT(VARCHAR(4), [Active])
				WHEN 10 THEN
					CONVERT(VARCHAR(24), [Created], 120)
				WHEN 11 THEN
					[CreatedBy]
				WHEN 12 THEN
					CONVERT(VARCHAR(24), [Updated], 120)
				WHEN 13 THEN
					[UpdatedBy]
                END ASC,
                CASE @SortCol
                    WHEN 1000 THEN
					CONVERT(VARCHAR(36), [UserId])
				WHEN 1001 THEN
					RIGHT(REPLICATE('0', 24) + CONVERT(VARCHAR(32), [UserTypeId]), 24)
				WHEN 1002 THEN
					[Username]
				WHEN 1003 THEN
					[Password]
				WHEN 1004 THEN
					[Salt]
				WHEN 1005 THEN
					[Email]
				WHEN 1006 THEN
					[Firstname]
				WHEN 1007 THEN
					[Lastname]
				WHEN 1008 THEN
					[Middlename]
				WHEN 1009 THEN
					CONVERT(VARCHAR(4), [Active])
				WHEN 1010 THEN
					CONVERT(VARCHAR(24), [Created], 120)
				WHEN 1011 THEN
					[CreatedBy]
				WHEN 1012 THEN
					CONVERT(VARCHAR(24), [Updated], 120)
				WHEN 1013 THEN
					[UpdatedBy]
                END DESC

    SELECT [User].[UserId], [UserTypeId], [Username], [Password], [Salt], [SecurityStamp],
        [Email], [Firstname], [Lastname], [Middlename], [Active], 
        [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
        FROM @TempTable TEMPTBL
            INNER JOIN [User] ON [User].[UserId] = TEMPTBL.[UserId]
        WHERE (@DisplayStart <= ROWNUM)
            AND ([Username] LIKE '%' + @Search + '%'
             OR [Password] LIKE '%' + @Search + '%'
             OR [Salt] LIKE '%' + @Search + '%'
             OR [Email] LIKE '%' + @Search + '%'
             OR [Firstname] LIKE '%' + @Search + '%'
             OR [Lastname] LIKE '%' + @Search + '%'
             OR [Middlename] LIKE '%' + @Search + '%')
		

		SELECT @CountSelected = COUNT([User].[UserId])
        FROM @TempTable TEMPTBL
            INNER JOIN [User] ON [User].[UserId] = TEMPTBL.[UserId]
        WHERE (@DisplayStart <= ROWNUM)
            AND ([Username] LIKE '%' + @Search + '%'
             OR [Password] LIKE '%' + @Search + '%'
             OR [Salt] LIKE '%' + @Search + '%'
             OR [Email] LIKE '%' + @Search + '%'
             OR [Firstname] LIKE '%' + @Search + '%'
             OR [Lastname] LIKE '%' + @Search + '%'
             OR [Middlename] LIKE '%' + @Search + '%')


		SELECT @Count = COUNT(UserId) 
        FROM [User]
		WHERE (([Username] LIKE '%' + @Search + '%'
             OR [Password] LIKE '%' + @Search + '%'
             OR [Salt] LIKE '%' + @Search + '%'
             OR [Email] LIKE '%' + @Search + '%'
             OR [Firstname] LIKE '%' + @Search + '%'
             OR [Lastname] LIKE '%' + @Search + '%'
             OR [Middlename] LIKE '%' + @Search + '%'))




    SET ROWCOUNT 0

END

GO




/* SelectAll integrated with DataTable Plugin
** This query returns Page with Paged Order By
** 
*/ 

IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserSelectAllPagedOrderBy]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserSelectAllPagedOrderBy]

GO

--DROP PROCEDURE [dbo].[UserSelectAllPagedOrderBy]
CREATE PROC  [dbo].[UserSelectAllPagedOrderBy]
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
        [UserId] UNIQUEIDENTIFIER
    )

	SET ROWCOUNT @LastRec;


	INSERT @TempTable
        (
            [UserId]
        )
        SELECT [UserId]
            FROM [User]
            
            ORDER BY
                CASE @SortCol
                    WHEN 0 THEN
					CONVERT(VARCHAR(36), [UserId])
				WHEN 1 THEN
					RIGHT(REPLICATE('0', 24) + CONVERT(VARCHAR(32), [UserTypeId]), 24)
				WHEN 2 THEN
					[Username]
				WHEN 3 THEN
					[Password]
				WHEN 4 THEN
					[Salt]
				WHEN 5 THEN
					[Email]
				WHEN 6 THEN
					[Firstname]
				WHEN 7 THEN
					[Lastname]
				WHEN 8 THEN
					[Middlename]
				WHEN 9 THEN
					CONVERT(VARCHAR(4), [Active])
				WHEN 10 THEN
					CONVERT(VARCHAR(24), [Created], 120)
				WHEN 11 THEN
					[CreatedBy]
				WHEN 12 THEN
					CONVERT(VARCHAR(24), [Updated], 120)
				WHEN 13 THEN
					[UpdatedBy]
                END ASC,
                CASE @SortCol
                    WHEN 1000 THEN
					CONVERT(VARCHAR(36), [UserId])
				WHEN 1001 THEN
					RIGHT(REPLICATE('0', 24) + CONVERT(VARCHAR(32), [UserTypeId]), 24)
				WHEN 1002 THEN
					[Username]
				WHEN 1003 THEN
					[Password]
				WHEN 1004 THEN
					[Salt]
				WHEN 1005 THEN
					[Email]
				WHEN 1006 THEN
					[Firstname]
				WHEN 1007 THEN
					[Lastname]
				WHEN 1008 THEN
					[Middlename]
				WHEN 1009 THEN
					CONVERT(VARCHAR(4), [Active])
				WHEN 1010 THEN
					CONVERT(VARCHAR(24), [Created], 120)
				WHEN 1011 THEN
					[CreatedBy]
				WHEN 1012 THEN
					CONVERT(VARCHAR(24), [Updated], 120)
				WHEN 1013 THEN
					[UpdatedBy]
                END DESC

    SELECT [User].[UserId], [UserTypeId], [Username], [Password], [Salt],[SecurityStamp], 
        [Email], [Firstname], [Lastname], [Middlename], [Active], 
        [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
        FROM @TempTable TEMPTBL
            INNER JOIN [User] ON [User].[UserId] = TEMPTBL.[UserId]
        WHERE (@DisplayStart <= ROWNUM)
           
		

		SELECT @CountSelected = COUNT([User].[UserId])
        FROM @TempTable TEMPTBL
            INNER JOIN [User] ON [User].[UserId] = TEMPTBL.[UserId]
        WHERE (@DisplayStart <= ROWNUM)
            


		SELECT @Count = COUNT(UserId) 
        FROM [User]

    SET ROWCOUNT 0

END

GO


-- select top 10 * from dbo.[User] order by UserId desc


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserSelectByUserTypeId]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserSelectByUserTypeId]

GO

CREATE PROC [dbo].[UserSelectByUserTypeId]
    @UserTypeId tinyint
AS

    SET NOCOUNT ON

    SELECT [UserId],[UserTypeId], [Username], [Password], [Salt], [SecurityStamp],
	[Email], [Firstname], [Lastname], [Middlename], [Active], [Created], [CreatedBy], 
	[Updated], [UpdatedBy], [TimeStamp] FROM [User]
        WHERE [UserTypeId] = @UserTypeId

    SET NOCOUNT OFF


GO