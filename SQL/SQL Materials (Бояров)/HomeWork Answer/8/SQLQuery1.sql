--********************************************************************************
--                            Создание Базы Данных (Задание №2).
--********************************************************************************

/*Создайте базу данных с именем “MyFunkDB”. */


CREATE DATABASE MyFunkDB
ON							  -- Задаем параметры Базы Данных.
(
	NAME = 'MyFunkDB',				-- Указываем логическое имя БД (используется при обращении к БД).
	FILENAME = 'D:\MyFunkDB.mdf',	-- Указываем Физическое полное имя файла БД.
	SIZE = 5MB,                    -- Задаем начальный размер файла БД.
	MAXSIZE = 30MB,				-- Задаем максимальный размер файла БД.
	FILEGROWTH = 5MB				-- Задаем значение, на которое будет увеличиваться размер файла БД.
)
LOG ON						  -- Задаем параметры журнала Базы Данных.
( 
	NAME = 'LogMyFunkDB',		       -- Указываем логическое имя журнала БД (используется при обращении к журналу БД).
	FILENAME = 'X:\MyFunkDB.ldf',      -- Указываем Физическое полное имя файла журнала БД.
	SIZE = 5MB,                        -- Задаем начальный размер файла журнала БД.
	MAXSIZE = 30MB,                    -- Задаем максимальный размер файла журнала БД.
	FILEGROWTH = 5MB                   -- Задаем значение, на которое будет увеличиваться размер файла журнала БД.
)               
COLLATE Cyrillic_General_CI_AS -- Задаем кодировку для базы данных по умолчанию



--********************************************************************************
--                            Проектирование Базы Данных (Задание №3).
--********************************************************************************

USE MyFunkDB         
GO   

/*В базе данных “MyFunkDB”, создайте 3 таблицы. 
В 1-й таблице укажите имена и номера телефонов сотрудников компании. 
В 2-й таблице укажите ведомости об их зарплате, и должностях: 
главный директор, менеджер, рабочий.  
В 3-й таблице укажите информацию о семейном положении, дате рождения и месте проживания. */

--Создание таблицы сотрудники.

 CREATE TABLE Employees
(                                      
	EmployeesID int IDENTITY NOT NULL 
    PRIMARY KEY,
	Name varchar(25) NOT NULL,				  
	Phone char(12) Not NULL
)
GO	

 --Создание таблицы о зарплате.  

CREATE TABLE Salary
(                                      
	SalaryID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	Post varchar(25) NOT NULL,
	Salary money NOT NULL,
	EmployeesID int NOT NULL						                        
    FOREIGN KEY REFERENCES Employees(EmployeesID)-- Связь Один ко Многим.
)
GO		

--Создание таблицы заказчики.

CREATE TABLE InfoEmployees
(                                      
	InfoEmployeesID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	MaritalStatus varchar(25) NOT NULL,
	BirthDate date NOT NULL, 
	Locations Varchar (30) NOT NULL,
	EmployeesID int NOT NULL						                        
    FOREIGN KEY REFERENCES Employees(EmployeesID) -- Связь Один ко Многим.
)
GO	

--Вставка данных в таблицы

INSERT INTO Employees																			   
(Name, Phone)
VALUES
('Андреев А. В.','(093)9831282'),
('Бойко M. К.','(067)9831312'),
('Гусев О. А.','(098)9831412'),
('Кравец Н. Н.','(097)9811182'),
('Тарасенко В. О.','(063)1491352');
GO

Select * From Employees

INSERT INTO Salary																			   
(Post, Salary, EmployeesID)
VALUES
('Главный директор','$1000',1),
('Менеджер','$500',2),
('Менеджер','$500',3),
('Рабочий','$200',4),
('Рабочий','$200',5);
GO

Select * From Salary

INSERT INTO InfoEmployees																			   
(MaritalStatus, Locations, BirthDate, EmployeesID)
VALUES
('Не женат','Киев', '08/15/1975', 1),
('Женат','Львов',   '01/01/1990', 2),
('Не женат','Киев', '03/11/1985', 3),
('Не женат','Херсон','05/10/1977', 4),
('Женат','Полтава', '02/04/1991', 5);
GO
 
Select * From Employees
Select * From Salary
Select * From InfoEmployees

--********************************************************************************
--                            Создание функци / процедуры.(Задание №4).
--********************************************************************************
--1) Требуется узнать контактные данные сотрудников 
--(номера телефонов, место жительства). 

CREATE PROC spEmployee1 -- Создание хранимой процедуры.
AS
SELECT  Name, Phone, Locations FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать. 
GO 

EXEC spEmployee1; --Вызов хранимой процедуры.
GO

CREATE FUNCTION fnEmployee1()-- Cоздание функции
RETURNS table -- возвращаемый тип TABLE указывает на то что возвращаться будет таблица
AS
RETURN 
(SELECT  Phone, Locations FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID); -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать. 
GO

SELECT * FROM dbo.fnEmployee1(); -- выводим всю информацию из таблицы сформированой при помощи функции ;
GO

--2) Требуется узнать информацию о дате рождения всех не женатых сотрудников и номера телефонов этих сотрудников. 

CREATE PROC spEmployee2 -- Создание хранимой процедуры.
AS
SELECT  Name, BirthDate, Phone FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID
WHERE MaritalStatus = 'Не женат';
GO 

EXEC spEmployee2; --Вызов хранимой процедуры.
GO

CREATE FUNCTION fnEmployee2()-- Создание функции
RETURNS table -- возвращаемый тип TABLE указывает на то что возвращаться будет таблица
AS
RETURN (SELECT Name, BirthDate, Phone FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID
WHERE MaritalStatus = 'Не женат');
GO

SELECT * FROM dbo.fnEmployee2(); -- выводим всю информацию из таблицы сформированой при помощи функции ;
GO

--3) Требуется узнать информацию о дате рождения всех сотрудников с должностью менеджер и номера телефонов этих сотрудников.*/ 

CREATE PROC spEmployee3 -- Создание хранимой процедуры.
AS
SELECT  Name, BirthDate, Phone FROM 
(Employees  
INNER JOIN  -- Оператор объединения.
Salary	
ON Employees.EmployeesID = Salary.EmployeesID) -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать. 
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID
WHERE Post = 'Менеджер';
GO 

EXEC spEmployee3; --Вызов хранимой процедуры.
GO

CREATE FUNCTION fnEmployee3()-- Создание функции
RETURNS table -- возвращаемый тип TABLE указывает на то что возвращаться будет таблица
AS
RETURN (SELECT  Name, BirthDate, Phone FROM 
(Employees  
INNER JOIN  -- Оператор объединения.
Salary	
ON Employees.EmployeesID = Salary.EmployeesID) -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать. 
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID
WHERE Post = 'Менеджер');
GO

SELECT * FROM dbo.fnEmployee3(); -- выводим всю информацию из таблицы сформированой при помощи функции ;
GO