/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson VI  ******      Data Integrity.        ************************
*****************************************************************************
****************************************************************************/
-- Дополнительно: 	https://metanit.com/sql/sqlserver/3.4.php, 
--					https://metanit.com/sql/sqlserver/3.5.php
-- Ограничения могут носить произвольные названия, но, как правило, для 
-- применяются следующие префиксы:
--		"PK_" - для PRIMARY KEY
--		"FK_" - для FOREIGN KEY
--		"CK_" - для CHECK
--		"UQ_" - для UNIQUE
--		"DF_" - для DEFAULT

USE TEST_DB
GO
-- Domain integrity

--IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Employees'))
--BEGIN;
--    DROP TABLE Employees;
--END;
--GO

IF OBJECT_ID('Employees') IS NOT NULL
  DROP TABLE Employees;
GO

CREATE TABLE Employees (
	Id int IDENTITY NOT NULL,
	FName varchar(50),
	LName varchar(50), 
	Phone char(15) CONSTRAINT CK_Employees_Phone CHECK (Phone LIKE '([0-9][0-9][0-9]) [0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'),
	Salary decimal(10,4),
	Bonus decimal(10,4),
	Sex varchar(6) CHECK (Sex IN ('male', 'female', 'm', 'f'))
	,StartDate date CONSTRAINT DF_Employees_StartDate DEFAULT GETDATE()
);
GO

--CHECK
INSERT Employees
(FName, LName, Phone, Salary, Bonus, Sex)
 VALUES
	('Alex', 'Po', '(000) 100-20-30', 1000, 200, 'm')
GO

ALTER TABLE Employees WITH NOCHECK -- отключение проверки существующих данных в столбце
ADD CONSTRAINT CK_Employees_Bonus
CHECK (Bonus <= Salary*0.1)

INSERT Employees 
(FName, LName, Phone, Salary, Sex)
 VALUES
	('Linda1', 'Wong', '(000) 300-20-10', 1000, 'f')
GO

ALTER TABLE Employees
DROP CONSTRAINT CK__Employees__69FBBC1F
GO

ALTER TABLE Employees
NOCHECK CONSTRAINT CK_Employees_Bonus -- отключение / включение ограничения
GO

--DEFAULT
ALTER TABLE Employees
ADD --CONSTRAINT DF_Employees_Bonus 
DEFAULT 0 FOR Bonus
GO

--ALTER TABLE Employees
--NOCHECK CONSTRAINT DF__Employees__Bonus__0A688BB1

ALTER TABLE Employees
DROP CONSTRAINT DF__Employees__Bonus__0A688BB1
GO

/****************************************************************************
****************************************************************************/

-- Entity integrity

IF OBJECT_ID('Employees') IS NOT NULL
  DROP TABLE Employees;
GO

CREATE TABLE Employees (
	Id int  /*IDENTITY*/ --CONSTRAINT PK_Employees_Id PRIMARY KEY --CLUSTERED
	,FName varchar(50) NOT NULL
	,LName varchar(50) NOT NULL
	,Phone char(15) CONSTRAINT UQ_Employees_Phone UNIQUE --NONCLUSTERED
	--,CONSTRAINT UQ_Employees_FullName UNIQUE (FName, LName)
	--,CONSTRAINT PK_Employees_FName_LName PRIMARY KEY (FName, LName)
);
GO

--PRIMARY KEY
-- РК может быть только один на таблицу.
-- Столбцы, входящие в РК, не допускают значений NULL.
INSERT Employees VALUES
(2, 'Robert', 'Wu', '(000) 100-20-30')
GO

INSERT Employees VALUES
(2, 'Dmitry', 'Yang', '(000) 100-20-33')
GO

--ALTER TABLE Employees
--NOCHECK CONSTRAINT PK_Employees_Id
--GO

ALTER TABLE Employees
DROP CONSTRAINT PK_Employees_Id
GO

ALTER TABLE Employees
ADD CONSTRAINT PK_Employees_FName_LName PRIMARY KEY (FName, LName) --CLUSTERED 
GO

--UNIQUE
--В отличие от PRIMARY KEY, ограничения UNIQUE допускают значение NULL. 
--Однако, как и всякое другое значение столбца с ограничением UNIQUE, 
--NULL может встречаться только один раз. 

INSERT Employees VALUES
('Sarah', 'Lee', '(000) 100-20-30')
GO

INSERT Employees VALUES
('Mary', 'Lee', '(001) 100-20-30')
GO

--ALTER TABLE Employees
--NOCHECK CONSTRAINT UQ_Employees_FullName
--GO

ALTER TABLE Employees
DROP CONSTRAINT UQ_Employees_FullName
GO

ALTER TABLE Employees
ADD CONSTRAINT UQ_Employees_FullName UNIQUE (FName, LName)
GO

/****************************************************************************
****************************************************************************/

-- Referential integrity

IF OBJECT_ID('dbo.Employees') IS NOT NULL
  DROP TABLE Employees;
GO

CREATE TABLE Employees (
	Id int NOT NULL IDENTITY PRIMARY KEY
	,FName varchar(50) 
	,LName varchar(50)
	,Phone char(15)
);
GO

IF OBJECT_ID('Orders') IS NOT NULL
  DROP TABLE Orders;
GO

CREATE TABLE Orders (
	Id int NOT NULL IDENTITY PRIMARY KEY
	,[Date] date DEFAULT GETDATE()
	,TotalSum decimal(10,4) DEFAULT 0
	,EmployeeId int CONSTRAINT FK_Orders_Employees FOREIGN KEY 
		REFERENCES Employees(Id)
		ON DELETE CASCADE --{CASCADE|NO ACTION|SET NULL|SET DEFAULT}    
		ON UPDATE CASCADE-- {CASCADE|NO ACTION|SET NULL|SET DEFAULT}
	-- ,EmployeeId int FOREIGN KEY REFERENCES Employees(Id)
);
GO

-- FOREIGN KEY
INSERT Employees 
(FName, LName, Phone) 
VALUES
	('Robert', 'Wu', '(000) 100-20-30')
	,('Sarah', 'Lee', '(002) 100-20-30')
	,('Mary', 'Lee', '(001) 100-20-30')
GO

INSERT Orders 
(EmployeeId)
VALUES
	(1),(3),(1),(2)
GO

INSERT Orders 
(EmployeeId)
VALUES 
	(4)
GO

ALTER TABLE Orders
NOCHECK CONSTRAINT FK_Orders_Employees
GO

ALTER TABLE Orders
DROP CONSTRAINT FK_Orders_Employees
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id)
	--	ON DELETE {CASCADE|NO ACTION|SET NULL|SET DEFAULT}   
	--	ON UPDATE {CASCADE|NO ACTION|SET NULL|SET DEFAULT} 
GO

--Запрещено удалять колонки, на которых есть ограничения
ALTER TABLE Orders
DROP COLUMN TotalSum
GO

ALTER TABLE Orders
DROP COLUMN Id
GO

ALTER TABLE Orders
DROP COLUMN EmployeeId
GO

/****************************************************************************
****************************************************************************/

-- Types of relationships
--1. One to Many
--2. One to One

CREATE TABLE Products (
	Id int NOT NULL IDENTITY PRIMARY KEY
	,Name varchar(30)	
);
GO

CREATE TABLE ProductDescr (
	Id int UNIQUE FOREIGN KEY REFERENCES Products(Id)
	,Color varchar(20)
	,[Weight] decimal(10,4)
);
GO

CREATE TABLE Stock (
	Id int NOT NULL IDENTITY PRIMARY KEY
	,QTY int 
	,ProductId int UNIQUE FOREIGN KEY REFERENCES Products(Id)
);
GO

--CREATE TABLE Stock (
--	Id int NOT NULL 
--	,QTY int 
--	,ProductId int FOREIGN KEY REFERENCES Products(Id)
--	, PRIMARY KEY (Id, ProductId)
--);
--GO

INSERT Products VALUES
('Product1'), ('Product2'), ('Product3')
GO

INSERT ProductDescr VALUES
(1, 'red', 2.2), (2, 'black', 3.1), (3, 'yellow', 1.7)
GO

INSERT Stock VALUES
(117, 1), (124, 2), (86, 3)
GO


--3. Many to Many
CREATE TABLE OrderProducts (
	OrderId int NOT NULL
	,ProductId int NOT NULL
	,PRIMARY KEY (OrderId, ProductId)
	,FOREIGN KEY (OrderId) REFERENCES Orders(Id)
	,FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO

INSERT OrderProducts VALUES
(1, 1), (1, 3), (2, 3), (3,2)
GO

--4. Self Referencing

ALTER TABLE Employees
ADD EmployeeId int FOREIGN KEY REFERENCES Employees(Id)
GO

-- Ограничение внешнего ключа
DELETE Employees
WHERE Id = 1
GO

--SET DEFAULT
ALTER TABLE Orders
DROP CONSTRAINT FK_Orders_Employees
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id)
	ON DELETE SET DEFAULT

--CASCADE
ALTER TABLE Orders
DROP CONSTRAINT FK_Orders_Employees
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id)
	ON DELETE CASCADE    

SELECT * FROM Orders
SELECT * FROM Employees

--SET NULL
ALTER TABLE Orders
DROP CONSTRAINT FK_Orders_Employees
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id)
	ON DELETE SET NULL

