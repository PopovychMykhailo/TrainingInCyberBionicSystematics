
-- Создайте базу данных с именем “MyJoinsDB”.
CREATE DATABASE MyJoinsDB
GO

USE MyJoinsDB
GO



/*	В данной базе данных создайте 3 таблицы,
	В 1-й таблице содержатся имена и номера телефонов сотрудников компании.
	В 2-й таблице содержатся ведомости о зарплате и должностях сотрудников: главный директор, менеджер, рабочий.
	В 3-й таблице содержится информация о семейном положении, дате рождения, и месте проживания		*/

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



/*	Сделайте выборку при помощи JOIN’s для таких заданий: (1, 2, 3)	*/

-- 1) Получите контактные данные сотрудников (номера телефонов, место жительства).
SELECT emp.Id, emp.FName, emp.LName, emp.Phone, empD.Residence 
	FROM Employees emp
	LEFT JOIN EmployeesDetails empD
	ON emp.Id = empD.EmployeeId
GO

-- 2) Получите информацию о дате рождения всех холостых сотрудников и их номера телефона.
SELECT emp.Id, emp.FName, emp.LName, emp.Phone
	FROM Employees emp
	LEFT JOIN EmployeesDetails empD
	ON emp.Id = empD.EmployeeId
	WHERE empD.FamilyStatus LIKE '%Not married%'
GO

-- 3) Получите информацию обо всех менеджерах компании: дату рождения и номер телефона.
SELECT emp.Id, emp.FName, emp.LName, empD.Birthday, emp.Phone
FROM Employees emp
	LEFT JOIN EmployeesDetails empD
	ON emp.Id = empD.EmployeeId
		LEFT JOIN Positions pos
		ON empD.PositionId = pos.Id
			WHERE pos.Position LIKE '%Director%'
GO