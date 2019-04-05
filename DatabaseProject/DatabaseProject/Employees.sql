CREATE TABLE [dbo].[Employees]
(
	[EmployeeId] INT NOT NULL IDENTITY (1, 1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
)
