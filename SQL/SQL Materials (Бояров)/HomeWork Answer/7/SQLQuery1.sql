--********************************************************************************
--                            Задание 2.
--********************************************************************************
/*Зайдите в базу данных “MyJoinsDB”, под созданным в предыдущем уроке пользователем. 
Проанализируйте, какие типы индексов заданы на созданных в предыдущем домашнем 
задании таблицах.*/
USE MyJoinsDB           
GO  
 
--Анализ индексов для таблицы Employees
SELECT * FROM sys.indexes
WHERE object_id = (SELECT object_id FROM sys.tables
				   WHERE name = 'Employees')
GO	

--Анализ индексов для таблицы Salary
SELECT * FROM sys.indexes
WHERE object_id = (SELECT object_id FROM sys.tables
				   WHERE name = 'Salary')
GO	


--Анализ индексов для таблицы InfoEmployees
SELECT * FROM sys.indexes
WHERE object_id = (SELECT object_id FROM sys.tables
				   WHERE name = 'InfoEmployees')
GO	
--********************************************************************************
--                            Задание 3.
--********************************************************************************
/*Задайте свои индексы на таблицах, созданных в предыдущем домашнем задании 
и обоснуйте их необходимость.*/ 
drop table Employees
drop table Salary
drop table InfoEmployees

--Создание таблицы сотрудники.
CREATE TABLE Employees
(                                      
	EmployeesID int IDENTITY NOT NULL 
    PRIMARY KEY,
	Name varchar(25) NOT NULL,				  
	Phone char(12) Not NULL UNIQUE
)
GO	

--Анализ индексов для таблицы Employees

SELECT * FROM sys.indexes
WHERE object_id = (SELECT object_id FROM sys.tables
				   WHERE name = 'Employees')
GO	

--Создание таблицы о зарплате.  

CREATE TABLE Salary
(                                      
	SalaryID int IDENTITY NOT NULL 
    UNIQUE,				  
	Post varchar(25) NOT NULL,
	Salary money NOT NULL,
	EmployeesID int NOT NULL						                        
    FOREIGN KEY REFERENCES Employees(EmployeesID)-- Связь Один ко Многим.
)
GO		

--Анализ индексов для таблицы Salary
SELECT * FROM sys.indexes
WHERE object_id = (SELECT object_id FROM sys.tables
				   WHERE name = 'Salary')
GO	

--Создание таблицы информация о сотрудниках.

CREATE TABLE InfoEmployees
(                                      
	InfoEmployeesID int IDENTITY NOT NULL 
    ,				  
	MaritalStatus varchar(25) NOT NULL,
	BirthDate date NOT NULL, 
	Locations Varchar (30) NOT NULL,
	EmployeesID int NOT NULL						                        
    FOREIGN KEY REFERENCES Employees(EmployeesID) -- Связь Один ко Многим.
)
GO	

--Анализ индексов для таблицы InfoEmployees
SELECT * FROM sys.indexes
WHERE object_id = (SELECT object_id FROM sys.tables
				   WHERE name = 'InfoEmployees')
GO	

/*Индексы в таблице позволяют получить данные из определенной записи без перебора всех записей в таблице.*/

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

Select * From InfoEmployees

--********************************************************************************
--                            Задание 4.
--********************************************************************************

USE MyJoinsDB           
GO   

/*Создайте представления для таких заданий: 
1. Необходимо узнать контактные данные сотрудников (номера телефонов, место жительства). 
2. Необходимо узнать информацию о дате рождения всех не женатых сотрудников и номера телефонов этих сотрудников. 
3. Необходимо узнать информацию о дате рождения всех сотрудников с должностью менеджер и номера телефонов этих сотрудников. 
*/

--1. Необходимо узнать контактные данные сотрудников (номера телефонов, место жительства). 

CREATE VIEW InfoEmployees1   -- Создание представления
AS 
SELECT  Name, Phone, Locations FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать.
GO

SELECT * FROM InfoEmployees1; -- выборка из представления

--2. Необходимо узнать информацию о дате рождения всех не женатых сотрудников и номера телефонов этих сотрудников. 

CREATE VIEW InfoEmployees2   -- Создание представления
AS 
SELECT  Name, BirthDate, Phone FROM 
Employees  
INNER JOIN  -- Оператор объединения.
InfoEmployees 
ON Employees.EmployeesID = InfoEmployees.EmployeesID
WHERE MaritalStatus = 'Не женат';
GO

SELECT * FROM InfoEmployees2; -- выборка из представления

--3. Необходимо узнать информацию о дате рождения всех сотрудников с должностью менеджер и номера телефонов этих сотрудников. 

CREATE VIEW InfoEmployees3   -- Создание представления
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

SELECT * FROM InfoEmployees3; -- выборка из представления