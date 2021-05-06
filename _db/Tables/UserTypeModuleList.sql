USE [NTIERDB]
GO


IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserTypeModuleListSelectByUserTypeId]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserTypeModuleListSelectByUserTypeId]

GO



IF EXISTS (SELECT * FROM dbo.sysobjects
    WHERE id = object_id(N'[dbo].[UserTypeModuleListSelectByUserTypeId]')
    and OBJECTPROPERTY(id, N'IsProcedure') = 1)

    DROP PROCEDURE [dbo].[UserTypeModuleListSelectByUserTypeId]

GO

CREATE PROC [dbo].[UserTypeModuleListSelectByUserTypeId]
    @UserTypeID TINYINT
AS

    SET NOCOUNT ON

    SELECT *
    FROM [UserTypeModuleList]
        WHERE [UserTypeId] = @UserTypeId

    SET NOCOUNT OFF

GO