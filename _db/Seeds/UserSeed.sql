USE NTIERDB
GO

IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'admin')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 1, 'admin', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'admin@collabor8digital.com', 'admin', 'admin', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO

IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'admin')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 10, 'audrey', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'brenda@collabor8digital.com', 'admin', 'admin', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO



IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'drake')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 2, 'drake', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'drake@collabor8digital.com', 'Drake', 'Williams', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO


IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'aamistad')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 2, 'aamistad', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'aamistad@collabor8digital.com', 'Alicia', 'Amistad', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO




IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'nlacson')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 2, 'nlacson', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'nlacson@collabor8digital.com', 'Nikolai', 'Lacson', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO


IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'jbracken')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 2, 'jbracken', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'jbracken@collabor8digital.com', 'Josephine', 'Bracken', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO


IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'jdoe')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 2, 'jdoe', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'jdoe@collabor8digital.com', 'John', 'Doe', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO


IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'jdelacruz')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 2, 'jdelacruz', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'jdelacruz@collabor8digital.com', 'Juan', 'Dela Cruz', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO



IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'wsmith')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 2, 'wsmith', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'wsmith@collabor8digital.com', 'Will', 'Smith', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO



IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'pteodoro')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 1, 'pteodoro', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'pteodoro@collabor8digital.com', 'Patricia', 'Teodoro', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO



IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'jchan')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 3, 'jchan', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'jchan@collabor8digital.com', 'Jackie', 'Chan', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO



IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'drosenblum')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 3, 'drosenblum', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'drosenblum@collabor8digital.com', 'David', 'Rosenblum', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO




IF NOT EXISTS(SELECT UserID 
                FROM [User] 
                WHERE Username = 'bbrown')
    BEGIN

        INSERT INTO [User]
             (
            [UserID], [UserTypeID], [Username], [Password], [Salt], 
        [Email], [Firstname], [Lastname], [Middlename],
        [Active], [Created], [CreatedBy], [Updated], [UpdatedBy], [Timestamp]
            )
         VALUES
             (
            NEWID(), 3, 'bbrown', 'daa07e9e804548ece7cbfc2917078287ec75935f3056c693c07d8b2f7a7f67b3', '9522e9c5', 
        'bbrown@collabor8digital.com', 'Brenda', 'Brown', '',
         1, GetDate(), 'system', GetDate(), 'system', null
            )
    END

GO
select * from dbo.[User]