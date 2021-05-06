USE NTIERDB
DECLARE @ModuleID INT 
DECLARE @Permission BIGINT
DECLARE @userTypeID TINYINT

SELECT @userTypeID = UserTypeID FROM [UserType] 
	WHERE [UserTypeName] = 'System Administrator'

SET @ModuleID = 1
SET @Permission = 0

SELECT @ModuleID = ModuleID FROM Module
		WHERE ModuleName = 'User'


IF(NOT EXISTS(SELECT * FROM UserTypeModule WHERE 
	UserTypeID = @userTypeID AND ModuleID = @ModuleID)) 
BEGIN	

	-- insert in all other users
	INSERT INTO UserTypeModule
		(UserTypeID, ModuleID, Permission,[Created]
				,[CreatedBy],[Updated],[UpdatedBy])
		SELECT UserTypeID, @ModuleID, 31,GetDate()
				   ,'system',GetDate() ,'system'
			FROM [UserType]
			WHERE UserTypeID = @UserTypeID				
	
		
END

GO




DECLARE @ModuleID INT 
DECLARE @Permission BIGINT
DECLARE @userTypeID TINYINT

SELECT @userTypeID = UserTypeID FROM [UserType] 
	WHERE [UserTypeName] = 'System Administrator'

SET @ModuleID = 1
SET @Permission = 0

SELECT @ModuleID = ModuleID FROM Module
		WHERE ModuleName = 'UserType'


IF(NOT EXISTS(SELECT * FROM UserTypeModule WHERE 
	UserTypeID = @userTypeID AND ModuleID = @ModuleID)) 
BEGIN	

	-- insert in all other users
	INSERT INTO UserTypeModule
		(UserTypeID, ModuleID, Permission,[Created]
				,[CreatedBy],[Updated],[UpdatedBy])
		SELECT UserTypeID, @ModuleID, 31,GetDate()
				   ,'system',GetDate() ,'system'
			FROM [UserType]
			WHERE UserTypeID = @UserTypeID				
	
		
END

GO