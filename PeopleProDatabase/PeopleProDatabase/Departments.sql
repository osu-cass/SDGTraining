﻿CREATE TABLE [dbo].[Departments]
(
	[DepartmentId] INT NOT NULL IDENTITY (1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([DepartmentId] ASC),

)
