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
--                            Задание №4.
--********************************************************************************
/*Создайте все виды триггеров на этих таблицах, задав проверки на правильность вводимых данных. */

--триггер на  добавление записей


CREATE TRIGGER TR_InfoEmployees ON InfoEmployees
FOR INSERT
AS
 IF EXISTS (SELECT *
            FROM inserted
            WHERE MaritalStatus != 'Женат' AND MaritalStatus !='Не женат')
  BEGIN 
   RAISERROR('ОШИБКА!!!', 1, 16);
   ROLLBACK TRANSACTION
  END

INSERT INTO InfoEmployees																			   
(MaritalStatus, Locations, BirthDate, EmployeesID)
VALUES
('Неженат','Кие', '08/15/1975', 5);

SELECT * FROM InfoEmployees

--триггер на обновление

CREATE TRIGGER TR_Employees ON Employees
FOR UPDATE
AS
 IF UPDATE (Name) 
  BEGIN
   RAISERROR('Нельзя изменять фамилию и инициалы!!!', 1, 16);
   ROLLBACK TRANSACTION
  END

UPDATE Employees
SET Name = 'Мищенко А. В.' 
WHERE Name = 'Бойко M. К.'

SELECT * FROM Employees
--триггер на удаление

CREATE TRIGGER TR_Salary ON Salary
FOR DELETE
AS
 IF EXISTS (SELECT *
            FROM deleted)
  BEGIN 
   RAISERROR('Нельзя удалять данные!!!', 1, 16);
   ROLLBACK TRANSACTION
  END

DELETE FROM Salary
WHERE Post = 'Менеджер';

SELECT * FROM Salary
--********************************************************************************
--                            Задание №4.
--********************************************************************************
/*Выполните ряд записей, изменений и удалений в контексте 1-й транзакции. 
Проследите правильность работы триггера и отката транзакций при неверном формате ввода или изменения данных.*/
drop TRIGGER TR_InfoEmployees
drop TRIGGER TR_Employees
drop TRIGGER TR_Salary

SELECT * FROM InfoEmployees;
SELECT * FROM Salary;

BEGIN TRANSACTION; -- начало транзакции

INSERT INTO InfoEmployees																			   
(MaritalStatus, Locations, BirthDate, EmployeesID)
VALUES
('Не женат','Тернополь', '08/11/1975', 5);

UPDATE Salary
SET Salary = '$300' 
WHERE Post = 'Рабочий'

DELETE FROM InfoEmployees
WHERE Locations = 'Киев';

ROLLBACK TRANSACTION; --  -- происходит откат транзакции  

SELECT * FROM InfoEmployees;
SELECT * FROM Salary;



BEGIN TRANSACTION; -- начало транзакции

INSERT INTO InfoEmployees																			   
(MaritalStatus, Locations, BirthDate, EmployeesID)
VALUES
('Не женат','Тернополь', '08/11/1975', 5);

UPDATE Salary
SET Salary = '$300' 
WHERE Post = 'Рабочий'

DELETE FROM InfoEmployees
WHERE Locations = 'Киев';

COMMIT TRANSACTION; -- успешное завершение транзакции   

SELECT * FROM InfoEmployees;
SELECT * FROM Salary;