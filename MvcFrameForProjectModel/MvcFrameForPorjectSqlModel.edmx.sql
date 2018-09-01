
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2018 16:41:45
-- Generated from EDMX file: C:\刘宏宇的文件\框架测试\MvcFrameForProject\MvcFrameForProject\MvcFrameForProject\MvcFrameForProjectModel\MvcFrameForPorjectSqlModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MvcFrameForProjectDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UsersDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersDbSet];
GO
IF OBJECT_ID(N'[dbo].[UserClassDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserClassDbSet];
GO
IF OBJECT_ID(N'[dbo].[ResourceDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResourceDbSet];
GO
IF OBJECT_ID(N'[dbo].[InformationDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InformationDbSet];
GO
IF OBJECT_ID(N'[dbo].[CommentDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentDbSet];
GO
IF OBJECT_ID(N'[dbo].[InformationTypeDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InformationTypeDbSet];
GO
IF OBJECT_ID(N'[dbo].[ResourceTypeDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResourceTypeDbSet];
GO
IF OBJECT_ID(N'[dbo].[ConfigDbSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConfigDbSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsersDbSet'
CREATE TABLE [dbo].[UsersDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Passwd] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [ClassId] int  NOT NULL,
    [UserPower] int  NOT NULL
);
GO

-- Creating table 'UserClassDbSet'
CREATE TABLE [dbo].[UserClassDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassName] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'ResourceDbSet'
CREATE TABLE [dbo].[ResourceDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InformationId] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [ResourceName] nvarchar(max)  NOT NULL,
    [ResourcePath] nvarchar(max)  NOT NULL,
    [TypeId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InformationDbSet'
CREATE TABLE [dbo].[InformationDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Details] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [TypeId] int  NOT NULL
);
GO

-- Creating table 'CommentDbSet'
CREATE TABLE [dbo].[CommentDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InformationId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Grade] int  NOT NULL,
    [Details] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'InformationTypeDbSet'
CREATE TABLE [dbo].[InformationTypeDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Status] int  NOT NULL,
    [TypePower] int  NOT NULL
);
GO

-- Creating table 'ResourceTypeDbSet'
CREATE TABLE [dbo].[ResourceTypeDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ConfigDbSet'
CREATE TABLE [dbo].[ConfigDbSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Values] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ModifyTime] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsersDbSet'
ALTER TABLE [dbo].[UsersDbSet]
ADD CONSTRAINT [PK_UsersDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserClassDbSet'
ALTER TABLE [dbo].[UserClassDbSet]
ADD CONSTRAINT [PK_UserClassDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResourceDbSet'
ALTER TABLE [dbo].[ResourceDbSet]
ADD CONSTRAINT [PK_ResourceDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InformationDbSet'
ALTER TABLE [dbo].[InformationDbSet]
ADD CONSTRAINT [PK_InformationDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentDbSet'
ALTER TABLE [dbo].[CommentDbSet]
ADD CONSTRAINT [PK_CommentDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InformationTypeDbSet'
ALTER TABLE [dbo].[InformationTypeDbSet]
ADD CONSTRAINT [PK_InformationTypeDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResourceTypeDbSet'
ALTER TABLE [dbo].[ResourceTypeDbSet]
ADD CONSTRAINT [PK_ResourceTypeDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConfigDbSet'
ALTER TABLE [dbo].[ConfigDbSet]
ADD CONSTRAINT [PK_ConfigDbSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------