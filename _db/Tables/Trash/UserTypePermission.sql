USE NTIERDB
GO

IF(EXISTS(select * from sysobjects
	WHERE id = object_id(N'[dbo].[UserTypePermission]')
	AND OBJECTPROPERTY(id, N'[dbo].[IsProcedure]') = 1))

	DROP PROCEDURE [dbo].[UserTypePermission]

GO


CREATE PROC [dbo].[UserTypePermission]
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
        [UserTypePermissionId] TINYINT
    )

	SET ROWCOUNT @LastRec;


	INSERT @TempTable
        (
            [UserTypePermissionId]
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

	
		
