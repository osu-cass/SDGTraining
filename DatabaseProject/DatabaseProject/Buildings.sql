CREATE TABLE [dbo].[Buildings]
(

	[BuildingId] INT NOT NULL IDENTITY (1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([BuildingId] ASC)
)

