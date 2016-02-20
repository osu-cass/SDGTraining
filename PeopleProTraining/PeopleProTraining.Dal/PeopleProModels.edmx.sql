
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/19/2016 15:05:16
-- Generated from EDMX file: C:\Users\mistkawg\Source\Repos\SDGTraining\PeopleProTraining\PeopleProTraining.Dal\PeopleProModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PeopleProTraining];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_EmployeeDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingDepartment_Building]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuildingDepartment] DROP CONSTRAINT [FK_BuildingDepartment_Building];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingDepartment_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuildingDepartment] DROP CONSTRAINT [FK_BuildingDepartment_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_BuildingEmployee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Buildings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buildings];
GO
IF OBJECT_ID(N'[dbo].[BuildingDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuildingDepartment];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [DepartmentDepartmentId] int  NOT NULL,
    [BuildingBuildingId] int  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DepartmentCode] nvarchar(max)  NOT NULL,
    [StaffCount] nvarchar(max)  NOT NULL,
    [DepartmentName] nvarchar(max)  NOT NULL,
    [DepartmentId] int  NOT NULL
);
GO

-- Creating table 'Buildings'
CREATE TABLE [dbo].[Buildings] (
    [BuildingId] int IDENTITY(1,1) NOT NULL,
    [BuildingName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BuildingDepartment'
CREATE TABLE [dbo].[BuildingDepartment] (
    [Buildings_BuildingId] int  NOT NULL,
    [Departments_DepartmentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [DepartmentId] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DepartmentId] ASC);
GO

-- Creating primary key on [BuildingId] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [PK_Buildings]
    PRIMARY KEY CLUSTERED ([BuildingId] ASC);
GO

-- Creating primary key on [Buildings_BuildingId], [Departments_DepartmentId] in table 'BuildingDepartment'
ALTER TABLE [dbo].[BuildingDepartment]
ADD CONSTRAINT [PK_BuildingDepartment]
    PRIMARY KEY CLUSTERED ([Buildings_BuildingId], [Departments_DepartmentId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmentDepartmentId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeDepartment]
    FOREIGN KEY ([DepartmentDepartmentId])
    REFERENCES [dbo].[Departments]
        ([DepartmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeDepartment'
CREATE INDEX [IX_FK_EmployeeDepartment]
ON [dbo].[Employees]
    ([DepartmentDepartmentId]);
GO

-- Creating foreign key on [Buildings_BuildingId] in table 'BuildingDepartment'
ALTER TABLE [dbo].[BuildingDepartment]
ADD CONSTRAINT [FK_BuildingDepartment_Building]
    FOREIGN KEY ([Buildings_BuildingId])
    REFERENCES [dbo].[Buildings]
        ([BuildingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Departments_DepartmentId] in table 'BuildingDepartment'
ALTER TABLE [dbo].[BuildingDepartment]
ADD CONSTRAINT [FK_BuildingDepartment_Department]
    FOREIGN KEY ([Departments_DepartmentId])
    REFERENCES [dbo].[Departments]
        ([DepartmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingDepartment_Department'
CREATE INDEX [IX_FK_BuildingDepartment_Department]
ON [dbo].[BuildingDepartment]
    ([Departments_DepartmentId]);
GO

-- Creating foreign key on [BuildingBuildingId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_BuildingEmployee]
    FOREIGN KEY ([BuildingBuildingId])
    REFERENCES [dbo].[Buildings]
        ([BuildingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingEmployee'
CREATE INDEX [IX_FK_BuildingEmployee]
ON [dbo].[Employees]
    ([BuildingBuildingId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------