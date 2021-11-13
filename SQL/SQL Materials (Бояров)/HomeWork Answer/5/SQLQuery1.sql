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
	Phone char(12) NOT NULL
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
--                            Сделайте выборку при помощи JOIN’s (Задание №4).
--********************************************************************************
--1) Получите контактные данные сотрудников
-- (номера телефонов, место жительства).                  

SELECT Name, Phone, Locations FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать. 
GO

--2) Получите информацию о дате рождения всех холостых сотрудников и их номера.  

SELECT Name, BirthDate, Phone FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID
WHERE MaritalStatus = 'Не женат';
GO

--3) Получите информацию обо всех менеджерах компании: дату рождения и номер телефона. 

SELECT Name, BirthDate, Phone FROM 
(Employees  
INNER JOIN  -- Оператор объединения.
Salary	
ON Employees.EmployeesID = Salary.EmployeesID) -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать. 
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID
WHERE Post = 'Менеджер';
GO