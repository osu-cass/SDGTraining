﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Department AS TARGET
USING (VALUES
	(1, 'School of Engineering'),
	(2, 'School of Liberal Arts'),
	(3, 'School of Science and Mathematics')
)
AS SOURCE (DepartmentId, [Name])
ON TARGET.DepartmentId = SOURCE.DepartmentId
WHEN NOT MATCHED BY TARGET THEN
INSERT([Name]) VALUES ([Name]);

MERGE INTO Building AS Target
USING (VALUES
	(1, '1 Campus Wy', 'Kelley Engineering Center', 1),
	(2, '2 Campus Wy', 'Bexell Hall', 2),
	(3, '3 Campus Wy', 'Kidder Hall', 3)
)
AS Source (BuildingId, [Address], [Name], [DepartmentId])
ON Target.BuildingId = Source.BuildingId
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Address], [Name], [DepartmentId]) VALUES([Address], [Name], [DepartmentId]);

MERGE INTO Employee AS Target
USING (VALUES
	(1, 'Drew', 1),
	(2, 'Max', 2),
	(3, 'Jeff', 3)
)
AS Source (EmployeeId, [FirstName], [DepartmentId])
ON Target.EmployeeId = Source.EmployeeId
WHEN NOT MATCHED BY TARGET THEN
INSERT ([FirstName], [DepartmentId]) VALUES([FirstName], [DepartmentId]);
GO