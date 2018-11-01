CREATE TABLE [dbo].[Employee]
(
	[EmployeeId] INT IDENTITY (1, 1) NOT NULL,
	[FirstName] NVARCHAR (50) NULL,
	PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
	CONSTRAINT [FK_dbo.Employee_dbo.Department_DepartmentId] FOREIGN KEY ([DepartmentId])
		REFERENCES [dbo].[Department] ([DepartmentId]) ON DELETE CASCADE,
)