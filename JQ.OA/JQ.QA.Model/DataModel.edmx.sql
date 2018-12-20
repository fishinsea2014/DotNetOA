
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/21/2018 00:52:29
-- Generated from EDMX file: D:\my_projects\DotNet_OA_V2\JQ.OA\JQ.QA.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OAData];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoRole_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRole] DROP CONSTRAINT [FK_UserInfoRole_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRole] DROP CONSTRAINT [FK_UserInfoRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoR_User_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_Action] DROP CONSTRAINT [FK_UserInfoR_User_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoR_User_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_Action] DROP CONSTRAINT [FK_ActionInfoR_User_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoDepartment_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoDepartment] DROP CONSTRAINT [FK_UserInfoDepartment_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoDepartment_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoDepartment] DROP CONSTRAINT [FK_UserInfoDepartment_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentRole_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartmentRole] DROP CONSTRAINT [FK_DepartmentRole_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartmentRole] DROP CONSTRAINT [FK_DepartmentRole_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoes];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[ActionInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfoes];
GO
IF OBJECT_ID(N'[dbo].[R_User_Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_User_Action];
GO
IF OBJECT_ID(N'[dbo].[UserInfoMetas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoMetas];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRole];
GO
IF OBJECT_ID(N'[dbo].[ActionInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfoRole];
GO
IF OBJECT_ID(N'[dbo].[UserInfoDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoDepartment];
GO
IF OBJECT_ID(N'[dbo].[DepartmentRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfoes'
CREATE TABLE [dbo].[UserInfoes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Pwd] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [DelFlag] smallint  NULL,
    [SubBy] int  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DepName] nvarchar(max)  NOT NULL,
    [ParentId] smallint  NULL,
    [DepMasterId] nvarchar(max)  NULL,
    [DepNo] nvarchar(max)  NULL,
    [IsLeaf] nvarchar(max)  NULL,
    [Level] int  NULL,
    [TreePath] nvarchar(128)  NULL,
    [DelFlag] smallint  NULL,
    [SubBy] int  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [DelFlag] smallint  NULL,
    [SubBy] int  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'ActionInfoes'
CREATE TABLE [dbo].[ActionInfoes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(512)  NOT NULL,
    [HttpMethod] nvarchar(32)  NULL,
    [Controller] nvarchar(64)  NULL,
    [ActionMethod] nvarchar(128)  NULL,
    [DelFlag] smallint  NULL,
    [SubBy] int  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'R_User_Action'
CREATE TABLE [dbo].[R_User_Action] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsPass] nvarchar(max)  NULL,
    [UserInfoID] int  NOT NULL,
    [ActionInfoId] int  NOT NULL
);
GO

-- Creating table 'UserInfoMetas'
CREATE TABLE [dbo].[UserInfoMetas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Mobile] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [UserInfoId] nvarchar(max)  NULL,
    [DelFlag] smallint  NULL,
    [SubBy] int  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'UserInfoRole'
CREATE TABLE [dbo].[UserInfoRole] (
    [UserInfoes_ID] int  NOT NULL,
    [Roles_ID] int  NOT NULL
);
GO

-- Creating table 'ActionInfoRole'
CREATE TABLE [dbo].[ActionInfoRole] (
    [ActionInfoes_ID] int  NOT NULL,
    [Roles_ID] int  NOT NULL
);
GO

-- Creating table 'UserInfoDepartment'
CREATE TABLE [dbo].[UserInfoDepartment] (
    [UserInfoes_ID] int  NOT NULL,
    [Departments_ID] int  NOT NULL
);
GO

-- Creating table 'DepartmentRole'
CREATE TABLE [dbo].[DepartmentRole] (
    [Departments_ID] int  NOT NULL,
    [Roles_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'UserInfoes'
ALTER TABLE [dbo].[UserInfoes]
ADD CONSTRAINT [PK_UserInfoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionInfoes'
ALTER TABLE [dbo].[ActionInfoes]
ADD CONSTRAINT [PK_ActionInfoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_User_Action'
ALTER TABLE [dbo].[R_User_Action]
ADD CONSTRAINT [PK_R_User_Action]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfoMetas'
ALTER TABLE [dbo].[UserInfoMetas]
ADD CONSTRAINT [PK_UserInfoMetas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserInfoes_ID], [Roles_ID] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [PK_UserInfoRole]
    PRIMARY KEY CLUSTERED ([UserInfoes_ID], [Roles_ID] ASC);
GO

-- Creating primary key on [ActionInfoes_ID], [Roles_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [PK_ActionInfoRole]
    PRIMARY KEY CLUSTERED ([ActionInfoes_ID], [Roles_ID] ASC);
GO

-- Creating primary key on [UserInfoes_ID], [Departments_ID] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [PK_UserInfoDepartment]
    PRIMARY KEY CLUSTERED ([UserInfoes_ID], [Departments_ID] ASC);
GO

-- Creating primary key on [Departments_ID], [Roles_ID] in table 'DepartmentRole'
ALTER TABLE [dbo].[DepartmentRole]
ADD CONSTRAINT [PK_DepartmentRole]
    PRIMARY KEY CLUSTERED ([Departments_ID], [Roles_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfoes_ID] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_UserInfo]
    FOREIGN KEY ([UserInfoes_ID])
    REFERENCES [dbo].[UserInfoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_ID] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_Role]
    FOREIGN KEY ([Roles_ID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRole_Role'
CREATE INDEX [IX_FK_UserInfoRole_Role]
ON [dbo].[UserInfoRole]
    ([Roles_ID]);
GO

-- Creating foreign key on [ActionInfoes_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_ActionInfo]
    FOREIGN KEY ([ActionInfoes_ID])
    REFERENCES [dbo].[ActionInfoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_Role]
    FOREIGN KEY ([Roles_ID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoRole_Role'
CREATE INDEX [IX_FK_ActionInfoRole_Role]
ON [dbo].[ActionInfoRole]
    ([Roles_ID]);
GO

-- Creating foreign key on [UserInfoID] in table 'R_User_Action'
ALTER TABLE [dbo].[R_User_Action]
ADD CONSTRAINT [FK_UserInfoR_User_Action]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_User_Action'
CREATE INDEX [IX_FK_UserInfoR_User_Action]
ON [dbo].[R_User_Action]
    ([UserInfoID]);
GO

-- Creating foreign key on [ActionInfoId] in table 'R_User_Action'
ALTER TABLE [dbo].[R_User_Action]
ADD CONSTRAINT [FK_ActionInfoR_User_Action]
    FOREIGN KEY ([ActionInfoId])
    REFERENCES [dbo].[ActionInfoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoR_User_Action'
CREATE INDEX [IX_FK_ActionInfoR_User_Action]
ON [dbo].[R_User_Action]
    ([ActionInfoId]);
GO

-- Creating foreign key on [UserInfoes_ID] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [FK_UserInfoDepartment_UserInfo]
    FOREIGN KEY ([UserInfoes_ID])
    REFERENCES [dbo].[UserInfoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Departments_ID] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [FK_UserInfoDepartment_Department]
    FOREIGN KEY ([Departments_ID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoDepartment_Department'
CREATE INDEX [IX_FK_UserInfoDepartment_Department]
ON [dbo].[UserInfoDepartment]
    ([Departments_ID]);
GO

-- Creating foreign key on [Departments_ID] in table 'DepartmentRole'
ALTER TABLE [dbo].[DepartmentRole]
ADD CONSTRAINT [FK_DepartmentRole_Department]
    FOREIGN KEY ([Departments_ID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_ID] in table 'DepartmentRole'
ALTER TABLE [dbo].[DepartmentRole]
ADD CONSTRAINT [FK_DepartmentRole_Role]
    FOREIGN KEY ([Roles_ID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentRole_Role'
CREATE INDEX [IX_FK_DepartmentRole_Role]
ON [dbo].[DepartmentRole]
    ([Roles_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------