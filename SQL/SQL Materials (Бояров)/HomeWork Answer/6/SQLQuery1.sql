--********************************************************************************
--                            Дополнительное задание.
--********************************************************************************
/*Рассмотрите схему базы данных AdventureWorks2012, найдите 4 взаимосвязанные таблицы.*/

--4 взаимосвязанные таблицы:
--1.Production.ProductModel
--2.Production.ProductModelIllustration
--3.Production.ProductModelProductDescriptionCulture
--4.Production.ProductDescription
--********************************************************************************
--                            Создание Базы Данных (Задание №2).
--********************************************************************************

/*Создайте базу данных с именем “MyJoinsDB”. */

CREATE DATABASE MyJoinsDB
ON							  -- Задаем параметры Базы Данных.
(
	NAME = 'MyJoinsDB',				-- Указываем логическое имя БД (используется при обращении к БД).
	FILENAME = 'D:\MyJoinsDB.mdf',	-- Указываем Физическое полное имя файла БД.
	SIZE = 5MB,                    -- Задаем начальный размер файла БД.
	MAXSIZE = 30MB,				-- Задаем максимальный размер файла БД.
	FILEGROWTH = 5MB				-- Задаем значение, на которое будет увеличиваться размер файла БД.
)
LOG ON						  -- Задаем параметры журнала Базы Данных.
( 
	NAME = 'LogMyJoinsDB',		       -- Указываем логическое имя журнала БД (используется при обращении к журналу БД).
	FILENAME = 'X:\MyJoinsDB.ldf',      -- Указываем Физическое полное имя файла журнала БД.
	SIZE = 5MB,                        -- Задаем начальный размер файла журнала БД.
	MAXSIZE = 30MB,                    -- Задаем максимальный размер файла журнала БД.
	FILEGROWTH = 5MB                   -- Задаем значение, на которое будет увеличиваться размер файла журнала БД.
)               
COLLATE Cyrillic_General_CI_AS -- Задаем кодировку для базы данных по умолчанию



--********************************************************************************
--                            Проектирование Базы Данных (Задание №3).
--********************************************************************************

USE MyJoinsDB          
GO   

/*В базе данных “MyJoinsDB”, создайте 3 таблицы. 
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

--Создание таблицы информация о сотрудниках.

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
('Бойко M. К.','(067)9831311'),
('Гусев О. А.','(098)9831411'),
('Кравец Н. Н.','(097)9811182'),
('Тарасенко В. О.', '(063)1491352');
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
--                            Выборка при помощи вложенных запросов (Задание №4).
--********************************************************************************
--Сделайте выборку при помощи вложенных запросов для таких задач:  
--1) Требуется узнать контактные данные сотрудников 
--(номера телефонов, место жительства).  

SELECT Name, Phone, Locations FROM Employees AS emp, InfoEmployees AS info
WHERE emp.EmployeesID IN 
                     (SELECT EmployeesID FROM InfoEmployees    -- вложенный запрос
					  WHERE emp.EmployeesID = info.InfoEmployeesID); 

--2) Требуется узнать информацию о дате рождения всех не женатых сотрудников
-- и номера телефонов этих сотрудников.

SELECT  Name, BirthDate, Phone FROM Employees AS emp, InfoEmployees AS info
WHERE emp.EmployeesID IN 
                     (SELECT EmployeesID FROM InfoEmployees    -- вложенный запрос
					  WHERE emp.EmployeesID = info.InfoEmployeesID)
					  AND  MaritalStatus = 'Не женат';

--3) Требуется узнать информацию о дате рождения всех сотрудников 
--с должностью менеджер и номера телефонов этих сотрудников. 

SELECT Name, BirthDate, Phone 
FROM Employees AS emp, InfoEmployees 
WHERE emp.EmployeesID = 
                     (SELECT sal.EmployeesID FROM Salary AS sal -- вложенный запрос
                     WHERE sal.SalaryID =(SELECT info.EmployeesID
					 FROM InfoEmployees AS info    WHERE sal.SalaryID = info.EmployeesID)
                     AND emp.EmployeesID = sal.EmployeesID
					 AND emp.EmployeesID = InfoEmployeesID
					 AND Post = 'Менеджер');












--1
SELECT Phone, Locations FROM Employees AS emp, InfoEmployees AS info
WHERE emp.EmployeesID = 
                     (SELECT EmployeesID FROM Salary AS sal -- вложенный запрос
                     WHERE emp.EmployeesID = sal.EmployeesID 
                     and emp.EmployeesID = info.InfoEmployeesID);			
--2
SELECT  BirthDate, Phone FROM Employees AS emp, InfoEmployees AS info
WHERE emp.EmployeesID = 
                     (SELECT sal.EmployeesID FROM Salary AS sal -- вложенный запрос
                     WHERE emp.EmployeesID = sal.EmployeesID 
                     AND emp.EmployeesID = info.InfoEmployeesID)
					 AND  MaritalStatus = 'Не женат';
--3
SELECT  BirthDate, Phone 
FROM Employees AS emp, InfoEmployees 
WHERE emp.EmployeesID = 
                     (SELECT sal.EmployeesID FROM Salary AS sal -- вложенный запрос
                     WHERE sal.SalaryID =(Select info.SalaryID
					 From InfoEmployees AS info    WHERE sal.SalaryID = info.SalaryID)
                     AND emp.EmployeesID = sal.EmployeesID
					 AND emp.EmployeesID = InfoEmployeesID
					 AND Post = 'Менеджер');

--!!!
SELECT  Name,BirthDate, Phone FROM Employees AS emp, InfoEmployees AS info 
WHERE emp.EmployeesID IN
                     (SELECT EmployeesID FROM Salary as Sal   -- вложенный запрос
					  WHERE emp.EmployeesID IN (
					  SELECT EmployeesID FROM InfoEmployees       -- вложенный запрос
					  WHERE emp.EmployeesID = info.InfoEmployeesID)
					  AND emp.EmployeesID = sal.EmployeesID  AND Post = 'Менеджер');



