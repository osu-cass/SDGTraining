CREATE TABLE [dbo].[Buildings] (
    [BuildingId]   INT            IDENTITY (1, 1) NOT NULL,
    [BuildingName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED ([BuildingId] ASC)
);

