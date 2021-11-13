--********************************************************************************
--                            Дополнительное задание.
--********************************************************************************
/*Задание  
Спроектируйте базу данных для системы отдела кадров.*/

--Создание БД для отдела кадров предприятия с названием CompanyDB

CREATE DATABASE CompanyDB 
ON							  -- Задаем параметры Базы Данных.
(
	NAME = 'CompanyDB',				-- Указываем логическое имя БД (используется при обращении к БД).
	FILENAME = 'D:\CompanyDB.mdf',	-- Указываем Физическое полное имя файла БД.
	SIZE = 30MB,                    -- Задаем начальный размер файла БД.
	MAXSIZE = 100MB,				-- Задаем максимальный размер файла БД.
	FILEGROWTH = 10MB				-- Задаем значение, на которое будет увеличиваться размер файла БД.
)
LOG ON						  -- Задаем параметры журнала Базы Данных.
( 
	NAME = 'LogCompanyDB',		       -- Указываем логическое имя журнала БД (используется при обращении к журналу БД).
	FILENAME = 'X:\CompanyDB.ldf',      -- Указываем Физическое полное имя файла журнала БД.
	SIZE = 5MB,                        -- Задаем начальный размер файла журнала БД.
	MAXSIZE = 50MB,                    -- Задаем максимальный размер файла журнала БД.
	FILEGROWTH = 5MB                   -- Задаем значение, на которое будет увеличиваться размер файла журнала БД.
)               
COLLATE Cyrillic_General_CI_AS

--Таблицы которые входят в CompanyDB:
--1я таблица "ОТДЕЛ" с колонками: Код отдела, название отдела.
--2я таблица "СОТРУДНИКИ" с колонками: Код сотрудника, фамилия,
--имя, отчество, дата рождения, адрес, телефон, код отдела.
--3я таблица "ЗАДАНИЕ" с колонками: Код задания, название,
--дата начала работы, код сотрудника. 

USE CompanyDB             
GO   

--Создание таблиц.

CREATE TABLE Department
(                                      
	DepartmentID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	DepartmentName varchar(30) NOT NULL
)
GO	  

CREATE TABLE Employees
(                                      
	EmployeesID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	FrsName varchar(25) NOT NULL,
	LastName varchar(25) NOT NULL,
	SecName varchar(25) NOT NULL,
	BirthDate date NOT NULL,
	Address1 varchar(25) NOT NULL,
	Phone char(12) NOT NULL,
	DepartmentID int NOT NULL						                        
    FOREIGN KEY REFERENCES Department(DepartmentID) -- Связь Один ко Многим.
)
GO	


CREATE TABLE Task
(                                      
	TaskID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	Task varchar(50) NOT NULL,
	DateBegin date NOT NULL,
	EmployeesID int NOT NULL						                        
    FOREIGN KEY REFERENCES Employees(EmployeesID) -- Связь Один ко Многим.
)
GO	

--Вставка данных в таблицы

INSERT INTO Department																			   
VALUES
('Отдел маркетинга'),
('Отдел сбыта');	
GO

Select * From Department	

INSERT INTO Employees																			   
(FrsName, SecName, LastName, BirthDate, Address1, Phone, DepartmentID)
VALUES
('Артем', 'Олегович', 'Бойко',   '08/08/1987', 'Просвещение 22','(093)1231212',1),
('Денис', 'Викторович', 'Гусев', '05/12/1985', 'Саксаганского 100, 2','(063)1161232',1),	
('Мария', 'Cергеевна', 'Кравец', '05/12/1985', 'Uригоренко 28, 34','(067)2261734',2);
GO

Select * From Employees

INSERT INTO Task	
(Task, DateBegin, EmployeesID)																	   
VALUES
('Создание имиджа','05/02/2012', 1),
('Анализ информации','07/01/2014', 2),
('Разработка прогнозов продаж','07/01/2014', 2),
('Продажа товара','05/01/2013', 3);
GO

Select * From Department
Select * From Employees
Select * From Task
--********************************************************************************
--                            Создание Базы Данных (Задание №2).
--********************************************************************************

/*Создайте базу данных максимальной размерностью 100 МБ, 
предполагается что будет использоваться около 30 МБ. 
Введите все необходимые настройки. Журнал транзакций 
должен быть расположен на другом физическом диске (если такой имеется).*/

CREATE DATABASE StokDB -- Склад
ON							  -- Задаем параметры Базы Данных.
(
	NAME = 'StokDB',				-- Указываем логическое имя БД (используется при обращении к БД).
	FILENAME = 'D:\StokDB.mdf',	-- Указываем Физическое полное имя файла БД.
	SIZE = 30MB,                    -- Задаем начальный размер файла БД.
	MAXSIZE = 100MB,				-- Задаем максимальный размер файла БД.
	FILEGROWTH = 10MB				-- Задаем значение, на которое будет увеличиваться размер файла БД.
)
LOG ON						  -- Задаем параметры журнала Базы Данных.
( 
	NAME = 'LogStokDB',		       -- Указываем логическое имя журнала БД (используется при обращении к журналу БД).
	FILENAME = 'X:\StokDB.ldf',      -- Указываем Физическое полное имя файла журнала БД.
	SIZE = 5MB,                        -- Задаем начальный размер файла журнала БД.
	MAXSIZE = 50MB,                    -- Задаем максимальный размер файла журнала БД.
	FILEGROWTH = 5MB                   -- Задаем значение, на которое будет увеличиваться размер файла журнала БД.
)               
COLLATE Cyrillic_General_CI_AS -- Задаем кодировку для базы данных по умолчанию



--********************************************************************************
--                  Проектирование базы данных (Задание №2).
--********************************************************************************

USE StokDB             
GO   

/*Спроектируйте базу данных для оптового склада, у которого есть поставщики товаров, 
персонал, постоянные заказчики. Поля таблиц продумать самостоятельно. */ 

--Создание таблицы персоанал.

 CREATE TABLE Staff 
(                                      
	StaffID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	Name varchar(25) NOT NULL,
	Post varchar(40) NOT NULL,
	Contact  varchar(25) NOT NULL,
	Phone char(12) NOT NULL
)
GO	

 --Создание таблицы поставщик.  

CREATE TABLE Provider 
(                                      
	ProvaiderID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	ProviderName varchar(25) NOT NULL,
	Product varchar(25) NOT NULL,
	Address1 varchar(25) NOT NULL,
	Contact  varchar(25) NOT NULL,
	City     varchar(15) NOT NULL,
	Phone char(12) NOT NULL,
	StaffID int NOT NULL						                        
    FOREIGN KEY REFERENCES Staff(StaffID)
)
GO		


--Создание таблицы заказчики.

CREATE TABLE Customers
(                                      
	CustomerID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	Name varchar(25) NOT NULL,
	Address1 varchar(25) NOT NULL,
	City     varchar(15) NOT NULL,
	Contact  varchar(25) NOT NULL,
	Phone char(12) NOT NULL,
	StaffID int NOT NULL						                        
    FOREIGN KEY REFERENCES Staff(StaffID) -- Связь Один ко Многим.
)
GO	

--Вставка данных в таблицы


INSERT INTO Staff 																			   
(Name, Post, Contact, Phone)
VALUES
('Андреев А. В.', 'Менеджер по закупкам','Andreev32@mail.ru','(093)9831282'),
('Тарасенко В. О.', 'Менеджер по продажам','Tarasov@gmail.ru','(093)1991252');
GO

Select * From Staff 

INSERT INTO Provider 																			   
(ProviderName, Product, Address1, City, Contact, Phone, StaffID )
VALUES
('XCompany', 'Ноутбуки','Васильковская 1','Киев', 'xcompany@gmail.ru','(098)2391555', 1),
('YCompany', 'Мобильные телефоны','Аврамова 25','Львов', 'ycom@gmail.ru','(063)1411525', 1);
GO

Select * From Provider 

INSERT INTO Customers 																			   
(Name, Address1, City, Contact, Phone, StaffID )
VALUES
('Гармаш Д. Н.', 'Антонова 3','Киев', 'garmash90@mail.ru','(067)4591335', 2);
GO


Select * From Staff 
Select * From Provider
Select * From Customers