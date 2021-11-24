
-- �������� ���� ������ � ������ �MyJoinsDB�.
CREATE DATABASE MyJoinsDB
GO

USE MyJoinsDB
GO



/*	� ������ ���� ������ �������� 3 �������,
	� 1-� ������� ���������� ����� � ������ ��������� ����������� ��������.
	� 2-� ������� ���������� ��������� � �������� � ���������� �����������: ������� ��������, ��������, �������.
	� 3-� ������� ���������� ���������� � �������� ���������, ���� ��������, � ����� ����������		*/

CREATE TABLE Employees 
(
	 [Id] int NOT NULL IDENTITY CONSTRAINT PK_Employees_Id PRIMARY KEY
	,[FName] varchar(50) NOT NULL
	,[LName] varchar(50) NOT NULL
	,[MName] varchar(50) NULL
	,[Phone] varchar(13) NOT NULL UNIQUE
)
GO
CREATE TABLE Positions 
(
	 [Id] int NOT NULL IDENTITY  CONSTRAINT PK_Positions_Id PRIMARY KEY
	,[Position] varchar(50) NOT NULL UNIQUE
	,[Salary] money NOT NULL
)
GO
CREATE TABLE EmployeesDetails
(
	 [EmployeeId] int NOT NULL 
		CONSTRAINT FK_EmployeesDetails_Id FOREIGN KEY REFERENCES Employees(Id)
		ON UPDATE  CASCADE 
		ON DELETE  CASCADE
	,[PositionId] int NULL
		CONSTRAINT FK_EmployeesDetails_Position FOREIGN KEY REFERENCES Positions(Id)
		ON UPDATE  CASCADE 
		ON DELETE  SET NULL
	,[Birthday] date NOT NULL
	,[Residence] varchar(10) NOT NULL
	,[FamilyStatus] varchar(100) NULL
) 
GO

-- Fill in the tables with data
INSERT INTO Employees	
	 (FName,		LName,	MName,			Phone)
VALUES
	 ('Mykhailo',	'Po',	'Mykhailovych',	'+380971111111')
	,('Anna',		'Ka',	'Yaroslavivna',	'+380973333333')
	,('Ilya',		'Ky',	NULL,			'+380972222222')
GO
INSERT INTO Positions	
	 (Position,			Salary)
VALUES
	  ('Director',		3500)
	 ,('Manager',		5000)
	 ,('Developer',		2000)
GO
INSERT INTO EmployeesDetails	
	 (EmployeeId,	PositionId,	Birthday,	Residence,	FamilyStatus)
VALUES
	 (1,			2,			'20030415', 'Kyiv',		'Not married')
	,(2,			1,			'20041215', 'Lviv',		'Not married')
	,(3,			3,			'20040924', 'Dnipro',	'Married')
GO



/*	�������� ������� ��� ������ ��������� �������� ��� ����� �����:: (1, 2, 3)	*/

-- 1) ��������� ������ ���������� ������ ����������� (������ ���������, ����� ����������). 
SELECT 
	 emp.Id
	,emp.FName
	,emp.LName 
	,emp.Phone
	,(SELECT Residence FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id) AS Residence
FROM Employees AS emp
GO

-- 2) ��������� ������ ���������� � ���� �������� ���� �� ������� ����������� � ������ ��������� ���� �����������.
SELECT 
	 emp.Id
	,emp.FName
	,emp.LName 
	,(SELECT Birthday FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id) AS Birthday
	,emp.Phone
FROM Employees AS emp
	WHERE 
		(SELECT FamilyStatus FROM EmployeesDetails AS empD WHERE emp.Id = empD.EmployeeId) != 'Married'
GO

-- 3) ��������� ������ ���������� � ���� �������� ���� ����������� � ���������� �������� � ������ ��������� ���� �����������.
SELECT 
	 emp.Id
	,emp.FName
	,emp.LName 
	,(SELECT Birthday FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id) AS Birthday
	,emp.Phone
	,(SELECT (SELECT Position FROM Positions AS pos WHERE pos.Id = empD.PositionId) AS Position
		FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id) AS Position
FROM Employees AS emp
	WHERE 
		(SELECT		-- position of the employee
			(SELECT pos.Position FROM Positions AS pos WHERE empD.PositionId = pos.Id) AS Position 
		FROM EmployeesDetails AS empD
			WHERE empD.EmployeeId = emp.Id
		) 
		LIKE 'Manager'
GO

-- 4* ��� �������� (��������): 
-- ������� ���������� � ����������� (���, ���� ��������, �������, ���������) ������� �� ������, � ��������� �� ��������� Managet ��� Director
SELECT 
	 emp.Id
	,emp.FName
	,emp.LName 
	,(SELECT Birthday FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id) AS Birthday
	,emp.Phone
	,(SELECT (SELECT Position FROM Positions AS pos WHERE pos.Id = empD.PositionId) AS Position
		FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id) AS Position
FROM Employees AS emp
	WHERE 
		(SELECT empD.FamilyStatus FROM EmployeesDetails AS empD 
			WHERE 
				emp.Id = empD.EmployeeId 
				AND 
				(SELECT pos.Position FROM Positions AS pos WHERE empD.PositionId = pos.Id) IN ('Manager', 'Director')
		) != 'Married'
GO