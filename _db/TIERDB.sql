/*
	Created Date: April 6, 2018
	Created by: Rafaelle Maru Villegas
	Updated Date: May 10, 2018
*/



/* Create NTIERDB database.                                                               */
use master  

go

create database "NTIERDB"  

go

use "NTIERDB"  

go

create table "User" ( 
	"UserId" uniqueidentifier not null,
	"UserTypeId" tinyint not null,
	"Username" varchar(120) not null,
	"Password" char(128) not null,
	"Salt" char(8) not null,
	"SecurityStamp" nvarchar(max) null,
	"Email" varchar(120) not null,
	"Firstname" varchar(120) not null,
	"Lastname" varchar(120) not null,
	"Middlename" varchar(120) not null,
	"Active" bit not null,
	"Created" datetime not null,
	"CreatedBy" varchar(120) not null,
	"Updated" datetime not null,
	"UpdatedBy" varchar(120) not null,
	"Timestamp" timestamp not null)  

go

alter table "User"
	add constraint "User_PK" primary key ("UserId")   
go

/* Create new table "Module".                                                                 */
/* "Module" : Table of Module                                                                 */
/* 	"ModuleID" : ModuleID identifies Module                                                   */
/* 	"ModuleName" : ModuleName is of Module                                                    */
/* 	"ValidPermission" : ValidPermission is of Module                                          */  
create table "Module" ( 
	"ModuleId" smallint identity not null,
	"ModuleName" varchar(120) not null,
	"ValidPermission" bigint not null)  

go

alter table "Module"
	add constraint "Module_PK" primary key ("ModuleId")   


go

create table "UserType" ( 
	"UserTypeId" tinyint identity not null,
	"UserTypeName" varchar(120) not null)  

go

alter table "UserType"
	add constraint "UserType_PK" primary key ("UserTypeId")   

go

create table "UserTypeModule" ( 
	"UserTypeModuleId" int identity not null,
	"UserTypeId" tinyint not null,
	"ModuleId" smallint not null,
	"Permission" bigint not null,
	"Created" datetime not null,
	"CreatedBy" varchar(120) not null,
	"Updated" datetime not null,
	"UpdatedBy" varchar(120) not null)  

go

alter table "UserTypeModule"
	add constraint "UserTypeModule_PK" primary key ("UserTypeModuleId")   

go

-- DROP TABLE UserPermission
--create table "UserPermission"(
--	"UserPermissionId" uniqueidentifier not null,
--	"UserTypeId" tinyint not null,
--	"ModuleId" smallint not null,
--	"Add" int not null,
--	"Edit" int not null,
--	"View" int not null,
--	"Delete" int not null,
--	"ListView" int not null,
--	"FileUpload" int not null,
--	"FileDownload" int not null
--)
--go

--alter table "UserPermission"
--	add constraint "Permission_PK" primary key ("UserPermissionId")   
--go


-- AUDIT LOG TABLES
--- drop table "AuditLog"
CREATE TABLE "AuditLog" (
	"AuditLogId" bigint identity not null,
	"UserId" uniqueidentifier not null,
	"IPAddress" varchar(128) not null,
	"ObjectSourceType" tinyint not null,
	"ObjectSourceId" NVARCHAR(64) not null,
	"Action" tinyint not null,
	"Created" datetime not null,
	"CreatedBy" VARCHAR(500) not null
)
GO

alter table "AuditLog"
	add constraint "AuditLog_PK" primary key clustered ("AuditLogID")   

-- drop table AuditLogDetail
CREATE TABLE "AuditLogDetail"(
	"AuditLogDetailId" uniqueidentifier not null,
	"ColumnName" varchar(100) not null,
	"OrigianlValue" varchar(max) not null,
	"NewValue" varchar(max) not null,
	"AuditoLogId" bigint not null
)

alter table "AuditLogDetail"
	add constraint "AuditLogDetail_PK" primary key clustered ("AuditLogDetailId")   

-- END OF AUDIT LOG TABLES