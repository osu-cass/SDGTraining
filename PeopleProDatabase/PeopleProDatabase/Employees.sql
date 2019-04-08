CREATE TABLE [dbo].[Employees]
(
	[EmployeeId] INT NOT NULL IDENTITY (1, 1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[DepartmentId] INT NOT NULL,
	[BuildingId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
	CONSTRAINT Employee_Department FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]) ON DELETE CASCADE,
	CONSTRAINT Employee_Building FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Buildings] ([BuildingId]) ON DELETE CASCADE
)