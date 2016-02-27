CREATE TABLE [dbo].[Departments] (
    [StaffCount]     INT NULL,
    [DepartmentName] NVARCHAR (MAX) NOT NULL,
    [DepartmentId]   INT            NOT NULL IDENTITY,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);



