/*
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
MERGE INTO Employees AS Target 
USING (VALUES 
        (1, 'John', 'Doe'), 
        (2, 'Jane', 'Smith'), 
        (3, 'Mary', 'Carp')
) 
AS Source (EmployeeId, FirstName, LastName) 
ON Target.EmployeeId = Source.EmployeeId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (FirstName, LastName) 
VALUES (FirstName, LastName);

MERGE INTO Buildings AS Target
USING (VALUES 
        (1, 'STAG', '1400 SW Way'), 
        (2, 'LINK', '1000 NE Road'), 
(3, 'MILNE', '200 NW Lane')
)
AS Source (BuildingId, Name, Address)
ON Target.BuildingId = Source.BuildingId
WHEN NOT MATCHED BY TARGET THEN
INSERT (Name, Address)
VALUES (Name, Address);

MERGE INTO Departments AS Target
USING (VALUES 
(1, 'Computer Science', 1, 2),
(2, 'History', 2,2)

)
AS Source (DepartmentId, Name, EmployeeId, BuildingId)
ON Target.DepartmentId = Source.DepartmentId
WHEN NOT MATCHED BY TARGET THEN
INSERT (Name, EmployeeId, BuildingId)
VALUES (Name, EmployeeId, BuildingId);