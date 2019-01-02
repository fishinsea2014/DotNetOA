
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/02/2019 18:38:30
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
IF OBJECT_ID(N'[dbo].[FK_UserInfoR_User_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_ActionInfo] DROP CONSTRAINT [FK_UserInfoR_User_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoDepartment_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoDepartment] DROP CONSTRAINT [FK_UserInfoDepartment_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoDepartment_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoDepartment] DROP CONSTRAINT [FK_UserInfoDepartment_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoR_User_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_ActionInfo] DROP CONSTRAINT [FK_ActionInfoR_User_ActionInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[R_User_ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_User_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfoMeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoMeta];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRole];
GO
IF OBJECT_ID(N'[dbo].[UserInfoDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoDepartment];
GO
IF OBJECT_ID(N'[dbo].[ActionInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfoRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(32)  NOT NULL,
    [Pwd] nvarchar(32)  NOT NULL,
    [Mail] nvarchar(256)  NULL,
    [Phone] nvarchar(32)  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(256)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(32)  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [ParentId] int  NOT NULL,
    [DepName] nvarchar(32)  NOT NULL,
    [DepMasterId] int  NOT NULL,
    [DepNo] nvarchar(32)  NOT NULL,
    [IsLeaf] bit  NOT NULL,
    [Level] int  NOT NULL,
    [TreePath] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Url] nvarchar(512)  NULL,
    [HttpMethod] varchar(32)  NULL,
    [ActionName] nvarchar(32)  NOT NULL,
    [Remark] nvarchar(128)  NULL,
    [Controoller] nvarchar(128)  NOT NULL,
    [ActionMethod] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'R_User_ActionInfo'
CREATE TABLE [dbo].[R_User_ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsPass] bit  NOT NULL,
    [UserInfoID] int  NOT NULL,
    [ActionInfoID] int  NOT NULL,
    [DelFlag] smallint  NOT NULL
);
GO

-- Creating table 'UserInfoMeta'
CREATE TABLE [dbo].[UserInfoMeta] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [QQ] nvarchar(32)  NOT NULL,
    [Msn] nvarchar(32)  NOT NULL,
    [UserInfoId] int  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'UserInfoRole'
CREATE TABLE [dbo].[UserInfoRole] (
    [UserInfo_ID] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- Creating table 'UserInfoDepartment'
CREATE TABLE [dbo].[UserInfoDepartment] (
    [UserInfo_ID] int  NOT NULL,
    [Department_ID] int  NOT NULL
);
GO

-- Creating table 'ActionInfoRole'
CREATE TABLE [dbo].[ActionInfoRole] (
    [ActionInfo_ID] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_User_ActionInfo'
ALTER TABLE [dbo].[R_User_ActionInfo]
ADD CONSTRAINT [PK_R_User_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfoMeta'
ALTER TABLE [dbo].[UserInfoMeta]
ADD CONSTRAINT [PK_UserInfoMeta]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserInfo_ID], [Role_ID] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [PK_UserInfoRole]
    PRIMARY KEY CLUSTERED ([UserInfo_ID], [Role_ID] ASC);
GO

-- Creating primary key on [UserInfo_ID], [Department_ID] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [PK_UserInfoDepartment]
    PRIMARY KEY CLUSTERED ([UserInfo_ID], [Department_ID] ASC);
GO

-- Creating primary key on [ActionInfo_ID], [Role_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [PK_ActionInfoRole]
    PRIMARY KEY CLUSTERED ([ActionInfo_ID], [Role_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_ID] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_ID] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRole_Role'
CREATE INDEX [IX_FK_UserInfoRole_Role]
ON [dbo].[UserInfoRole]
    ([Role_ID]);
GO

-- Creating foreign key on [UserInfoID] in table 'R_User_ActionInfo'
ALTER TABLE [dbo].[R_User_ActionInfo]
ADD CONSTRAINT [FK_UserInfoR_User_ActionInfo]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_User_ActionInfo'
CREATE INDEX [IX_FK_UserInfoR_User_ActionInfo]
ON [dbo].[R_User_ActionInfo]
    ([UserInfoID]);
GO

-- Creating foreign key on [UserInfo_ID] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [FK_UserInfoDepartment_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Department_ID] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [FK_UserInfoDepartment_Department]
    FOREIGN KEY ([Department_ID])
    REFERENCES [dbo].[Department]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoDepartment_Department'
CREATE INDEX [IX_FK_UserInfoDepartment_Department]
ON [dbo].[UserInfoDepartment]
    ([Department_ID]);
GO

-- Creating foreign key on [ActionInfo_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoRole_Role'
CREATE INDEX [IX_FK_ActionInfoRole_Role]
ON [dbo].[ActionInfoRole]
    ([Role_ID]);
GO

-- Creating foreign key on [ActionInfoID] in table 'R_User_ActionInfo'
ALTER TABLE [dbo].[R_User_ActionInfo]
ADD CONSTRAINT [FK_ActionInfoR_User_ActionInfo]
    FOREIGN KEY ([ActionInfoID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoR_User_ActionInfo'
CREATE INDEX [IX_FK_ActionInfoR_User_ActionInfo]
ON [dbo].[R_User_ActionInfo]
    ([ActionInfoID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------