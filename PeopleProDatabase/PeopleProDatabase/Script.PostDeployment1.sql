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
MERGE INTO Departments AS Target 
USING (VALUES 
        (1, 'History'), 
        (2, 'Math'), 
        (3, 'Engineering')
) 
AS Source (DepartmentId, Name) 
ON Target.DepartmentId = Source.DepartmentId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name) 
VALUES (Name);

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

MERGE INTO Employees AS Target
USING (VALUES 
(1, 'Hank', 'Derry', 1, 2),
(2, 'Mary', 'Jane', 2,3),
(3, 'Jake', 'Feng', 2,2),
(4, 'Emily', 'Hamil', 1,2),
(5, 'Amy', 'Smith', 1,3)

)
AS Source (EmployeeId, FirstName, LastName, DepartmentId, BuildingId)
ON Target.EmployeeId = Source.EmployeeId
WHEN NOT MATCHED BY TARGET THEN
INSERT (FirstName, LastName, DepartmentId, BuildingId)
VALUES (FirstName, LastName, DepartmentId, BuildingId);