CREATE TABLE [dbo].[Departments]
(
	[DepartmentId] INT NOT NULL IDENTITY (1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	[EmployeeId] INT NOT NULL,
	[BuildingId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([DepartmentId] ASC),
	CONSTRAINT Deparment_Employee FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeID]) ON DELETE CASCADE,
	CONSTRAINT Deparment_Building FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Buildings] ([BuildingID]) ON DELETE CASCADE

)
