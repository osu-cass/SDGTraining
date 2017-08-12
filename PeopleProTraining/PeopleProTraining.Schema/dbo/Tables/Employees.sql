CREATE TABLE [dbo].[Employees] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]              NVARCHAR (MAX) NOT NULL,
    [LastName]               NVARCHAR (MAX) NOT NULL,
    [DepartmentDepartmentId] INT            NOT NULL,
    [BuildingBuildingId]     INT            NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BuildingEmployee] FOREIGN KEY ([BuildingBuildingId]) REFERENCES [dbo].[Buildings] ([BuildingId]),
    CONSTRAINT [FK_EmployeeDepartment] FOREIGN KEY ([DepartmentDepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_BuildingEmployee]
    ON [dbo].[Employees]([BuildingBuildingId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeDepartment]
    ON [dbo].[Employees]([DepartmentDepartmentId] ASC);

