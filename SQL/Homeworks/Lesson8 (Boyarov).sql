
-- Создать базу данных с именем "MyFuncDB"
CREATE DATABASE MyFuncDB
GO

USE MyFuncDB
GO



/*	В данной базе данных создать 3 таблиц,
	В 1-й содержатся имена и номера телефонов сотрудников некой компании
	В 2-й Ведомости об их зарплате, и должностях: главный директор, менеджер, рабочий.
	В 3-й семейном положении, дате рождения, где они проживают. 		*/

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
	 [Id] int NOT NULL IDENTITY	
		CONSTRAINT PK_Positions_Id PRIMARY KEY
	,[Position] varchar(50) NOT NULL UNIQUE
	,[Salary] money NOT NULL
)
GO
CREATE TABLE EmployeesDetails
(
	 [EmployeeId] int NOT NULL UNIQUE 
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



/*	Создайте функции / процедуры для таких заданий:
	1) Требуется узнать контактные данные сотрудников (номера телефонов, место жительства).
	2) Требуется узнать информацию о дате рождения всех не женатых сотрудников и номера
	телефонов этих сотрудников.
	3) Требуется узнать информацию о дате рождения всех сотрудников с должностью менеджер и
	номера телефонов этих сотрудников. 	*/


-- 1) Требуется узнать контактные данные сотрудников (номера телефонов, место жительства).
CREATE FUNCTION GetEmployees_PhoneResidence(@EmployeeId int = NULL)
RETURNS @result TABLE (StaffId int, FullName varchar(100), Phone varchar(13), Residence varchar(100))
AS
BEGIN

-- IF
	IF @EmployeeId IS NULL
	BEGIN
		INSERT @result
		SELECT emp.Id, emp.FName+' '+emp.LName, emp.Phone, 
					(SELECT Residence FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id)
		FROM Employees AS emp
	END
	
-- ELSE
	ELSE
	BEGIN
		INSERT @result
		SELECT emp.Id, emp.FName+' '+emp.LName, emp.Phone AS [Phone], 
					(SELECT Residence FROM EmployeesDetails AS empD WHERE empD.EmployeeId = emp.Id)
		FROM Employees AS emp
		WHERE emp.Id = @EmployeeId
	END

-- RETURN
	RETURN
END
GO

SELECT * FROM GetEmployees_PhoneResidence(NULL) AS emp;
GO


-- 2) Требуется узнать информацию о дате рождения всех не женатых сотрудников и номера телефонов этих сотрудников.
CREATE FUNCTION GetEmployees_FamilyStatusPhone(@EmployeeId int = NULL)
RETURNS @result TABLE (StaffId int, FullName varchar(100), FamilyStatus varchar(100), Phone varchar(13))
AS
BEGIN

-- IF
	IF @EmployeeId IS NULL
	BEGIN
		INSERT @result
		SELECT emp.Id, emp.FName+' '+emp.LName AS [Fullname], empD.FamilyStatus, emp.Phone
		FROM Employees AS emp
			JOIN EmployeesDetails AS empD
			ON empD.EmployeeId = emp.Id
	END
	
-- ELSE
	ELSE
	BEGIN
		INSERT @result
		SELECT emp.Id, emp.FName+' '+emp.LName AS [Fullname], empD.FamilyStatus, emp.Phone
		FROM Employees AS emp
			JOIN EmployeesDetails AS empD
			ON empD.EmployeeId = emp.Id
		WHERE emp.Id = @EmployeeId
	END

-- RETURN
	RETURN
END
GO

SELECT * FROM GetEmployees_FamilyStatusPhone(NULL) AS emp;
GO


-- 3) Требуется узнать информацию о дате рождения всех сотрудников с должностью менеджер и 	номера телефонов этих сотрудников.
CREATE FUNCTION GetEmployees_ManagersBirthdayPhone()
RETURNS @result TABLE (StaffId int, FullName varchar(100), Birthday date, Phone varchar(13), Position varchar(50))
AS
BEGIN

-- Looking for result
	INSERT @result
	SELECT emp.Id, emp.FName+' '+emp.LName AS [Fullname], empD.Birthday, emp.Phone, pos.Position
	FROM Employees AS emp
		JOIN EmployeesDetails AS empD
		ON empD.EmployeeId = emp.Id
		JOIN Positions AS pos
		ON pos.Id = empD.PositionId
	WHERE pos.Position LIKE 'Manager'

-- RETURN
	RETURN
END
GO

SELECT * FROM GetEmployees_ManagersBirthdayPhone() AS emp;
GO