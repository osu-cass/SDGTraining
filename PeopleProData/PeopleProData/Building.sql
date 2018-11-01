CREATE TABLE [dbo].[Building]
(
	[BuildingId] INT IDENTITY (1, 1) NOT NULL,
	[Address] NVARCHAR (50) NULL,
	[Name] NVARCHAR (50) NULL,
	[DepartmentId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([BuildingId] ASC),
	CONSTRAINT [FK_dbo.Building_dbo.Department_DepartmentId] FOREIGN KEY ([DepartmentId])
		REFERENCES [dbo].[Department] ([DepartmentId]) ON DELETE CASCADE,
)
