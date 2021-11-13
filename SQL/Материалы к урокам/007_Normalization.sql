/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson VII  *****       Normalization.        ************************
*****************************************************************************
****************************************************************************/

USE master
GO

CREATE DATABASE pizzeriaDB
GO

USE pizzeriaDB
GO

CREATE TABLE pizzeriaData(
	OrderNo int IDENTITY
	,[Date] date
	,Customer varchar(100)
	,CustomerData varchar(max)
	,OrderInfo varchar(max)
	,Courier varchar(100))
GO

INSERT pizzeriaData VALUES
('20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4, tel. 3-15-64', 'Pepperoni pizza - 1, beer SA - 2 (0.5)', 'Norma Mortenson')
,('20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17, tel. 3-22-81', 'Veggie pizza - 3, Caesar salad - 4', 'Norma Mortenson')
,('20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26, tel. 3-25-70, mob. (077)444-15-17', 'beer B Premium - 10 (0.5), Meat pizza - 2, Cheese pizza - 3', 'Cassius Clay')
GO

SELECT * FROM pizzeriaData 
GO

DROP TABLE pizzeriaData 
GO

--������� � ���������� ���������
--	-	OrderNO
--	-	Date
--	-	Customer
--	-	Address
--	-	Phone
--	-	MobPhone
--	-	Email
--	-	Product1:
--		-	ProductName
--		-	Qty
--		-	Price
--	-	Product2
--		-	ProductName
--		-	Qty
--		-	Price
--	-	Product3:
--		-	ProductName
--		-	Qty
--		-	Price
--	-	Courier
/****************************************************************************
****************************************************************************/

CREATE TABLE pizzeriaData(
	OrderNo int IDENTITY
	,[Date] date
	,Customer varchar(100)
	,CustomerAddress varchar(max)
	,CustomerPhone varchar(15)
	,CustomerMob varchar(15)
	,Product1 varchar(20)
	,Qty1 tinyint
	,Product2 varchar(20)
	,Qty2 tinyint
	,Product3 varchar(20)
	,Qty3 tinyint
	,Courier varchar(100))
GO

INSERT pizzeriaData VALUES
('20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4', '3-15-64', NULL, 'Pepperoni pizza', 1, 'beer SA', 2, NULL, NULL, 'Norma Mortenson')
,('20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17', '3-22-81', NULL, 'Veggie pizza', 3, 'Caesar salad', 4, NULL, NULL, 'Norma Mortenson')
,('20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'beer B Premium', 10, 'Meat pizza', 2, 'Cheese pizza', 3, 'Cassius Clay')
GO

SELECT * FROM pizzeriaData 
GO

DROP TABLE pizzeriaData 
GO

/****************************************************************************
****************************************************************************/

CREATE TABLE pizzeriaData(
	OrderNo int
	,OrderItem int
	,[Date] date
	,Customer varchar(100)
	,CustomerAddress varchar(max)
	,CustomerPhone varchar(15)
	,CustomerMob varchar(15)
	,Product varchar(20)
	,ProductName varchar(20)
	,Qty tinyint
	,Courier varchar(100))
GO

INSERT pizzeriaData VALUES
(1, 1, '20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4', '3-15-64', NULL, 'pizza', 'Pepperoni', 1, 'Norma Mortenson')
,(1, 2, '20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4', '3-15-64', NULL, 'beer', 'SA', 2, 'Norma Mortenson')
,(2, 1, '20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17', '3-22-81', NULL, 'pizza', 'Veggie', 3, 'Norma Mortenson')
,(2, 2, '20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17', '3-22-81', NULL, 'salad', 'Caesar', 4, 'Norma Mortenson')
,(3, 1, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'beer', 'B Premium', 10, 'Cassius Clay')
,(3, 2, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'pizza', 'Meat', 2, 'Cassius Clay')
,(3, 3, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'pizza','Cheese', 3, 'Cassius Clay')
GO

SELECT * FROM pizzeriaData 
GO

DROP TABLE pizzeriaData 
GO

/****************************************************************************
****************************************************************************/

CREATE TABLE Orders(
	OrderNo int IDENTITY
	,[Date] date
	,CustomerId int
	,Courier varchar(100))
GO

CREATE TABLE OrderInfo(
	OrderNo int
	,OrderItem int
	,Product varchar(20)
	,ProductName varchar(20)
	,Qty tinyint)
GO

CREATE TABLE Customers(
	Id int IDENTITY
	,FullName varchar(100)
	,CustomerAddress varchar(max)
	,CustomerPhone varchar(15)
	,CustomerMob varchar(15))
GO

INSERT Orders VALUES
('20170407', 1, 'Norma Mortenson')
,('20170407', 2, 'Norma Mortenson')
,('20170408', 3, 'Cassius Clay')
GO

INSERT OrderInfo VALUES
(1, 1, 'pizza', 'Pepperoni', 1)
,(1, 2, 'beer', 'SA', 2)
,(2, 1, 'pizza', 'Veggie', 3)
,(2, 2, 'salad', 'Caesar', 4)
,(3, 1, 'beer', 'B Premium', 10)
,(3, 2, 'pizza', 'Meat', 2)
,(3, 3, 'pizza','Cheese', 3)
GO

INSERT Customers VALUES
('Tony Wang', 'Sportivnaya str., 15, ap.4', '3-15-64', NULL)
,('Amy Yang', 'Shevchenko av., 2, ap.17', '3-22-81', NULL)
,('Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17')
GO

--SELECT * FROM Orders
--GO

--SELECT * FROM OrderInfo
--GO

--SELECT * FROM Customers
--GO

--SELECT * FROM Employees
--GO

--SELECT * FROM Salaries
--GO


/****************************************************************************
****************************************************************************/

-- �������� ������� Employees, � ����� ���������� � ����������� � �������� � 
-- ��������� ����������:

CREATE TABLE Employees(
	Id int IDENTITY
	,FullName varchar(100)
	,Position varchar(20)
	,Salary decimal(9,4))
GO

INSERT Employees VALUES
(1, 'Norma Mortenson', 'courier', 1000.00)
,(2, 'Cassius Clay', 'courier', 1000.00)
,(3, 'Samuel Clemens', 'chief manager', 2000.00)
,(4, 'Anna Gorenko', 'accountant', 1500.00)
GO

DROP TABLE Employees
GO

/****************************************************************************
****************************************************************************/

-- ������� Employees ����� ��� ���������������, � ������ ������� ����������
-- � ���������:

CREATE TABLE Employees(
	Id int IDENTITY
	,FullName varchar(100)
	,PositionId int)
GO

--INSERT Employees VALUES
--(1, 'Norma Mortenson', 1)
--,(2, 'Cassius Clay', 1)
--,(3, 'Samuel Clemens', 2)
--,(4, 'Anna Gorenko', 3)
--GO

CREATE TABLE Salaries(
	Id int IDENTITY
	,Position varchar(100)
	,Rate decimal(9,4))
GO

-- ������� Salaries ������� ����� ��������� �������, � ������� Employees
-- ����� ��������� ��� ����� INSERT ����, ��� � ����� ����������, 
-- �� ������ ������ ����� ������������ ����������:
--	-	� ����� �����������: Samuel Clemens � Anna Gorenko4
-- �� �� ����� ����� ������ �������.

INSERT Salaries VALUES
('courier', 1000.00),
('chief manager', 2000.00),
('accountant', 1500.00)
GO

INSERT Employees(FullName, PositionId)
	SELECT DISTINCT 
					Courier,
					(SELECT Id FROM Salaries WHERE Position = 'courier') 
	FROM Orders
GO

INSERT Employees VALUES
('Samuel Clemens', 2),
('Anna Gorenko', 3)
GO

-- ���������� ������� � ������� Orders �������� id �������
ALTER TABLE Orders 
ADD CourierId int
GO

-- ������������ id �������� � ������� CourierId � ������� Orders
UPDATE Orders 
SET CourierId = (Select Id FROM Employees WHERE Courier = Employees.FullName)
GO

-- �������� �������� ������ �������
ALTER TABLE Orders
DROP COLUMN Courier
GO

--SELECT * FROM Employees
--GO

--SELECT * FROM Salaries
--GO

/****************************************************************************
****************************************************************************/

-- ����� ���������� � �������� �� ������� OrderInfo

CREATE TABLE ProductTypes
(
	Id int IDENTITY,
	[Name] varchar(20)
)
GO

CREATE TABLE Products
(
	Id int IDENTITY,
	TypeId int,
	[Name] varchar(20)
)
GO

-- ���������� ������ ProductTypes � Products �������
INSERT ProductTypes([Name])
	 (SELECT DISTINCT Product FROM OrderInfo)
GO

INSERT Products(TypeId, [Name])
	(SELECT 
		(SELECT Id FROM ProductTypes pt WHERE oi.Product = pt.[Name]),
		ProductName
	FROM OrderInfo oi)
GO
-- ���������� ������� OrderInfo

ALTER TABLE OrderInfo
ADD ProductId int
GO

UPDATE OrderInfo 
SET ProductId = 
	(SELECT Id FROM Products p  
	WHERE ProductName = p.Name
		AND Product = (SELECT pt.[Name] FROM ProductTypes pt WHERE p.TypeId = pt.Id)	-- ����� ���� �������������� ��������
	)
GO

ALTER TABLE OrderInfo
DROP COLUMN Product, ProductName
GO
/****************************************************************************
****************************************************************************/

-- ��������� �����������

---- ��������� �������� �� ����������� ����� NULL ��������:
-- � ����������� �� ������ (� �� ���� ��� ����������� FK_Orders_Customers)
--ALTER TABLE Orders
--ALTER COLUMN CustomerId int NOT NULL

ALTER TABLE Orders
ALTER COLUMN [Date] date NOT NULL

-- �ourierId � ������� Orders ����� ���� NULL - ��� ����� ��������, 
-- ��� ����� ��� ������, ����� ����� ��� ����� ����� �������� �� ���� ��� 
-- ����������� FK_Orders_Employees

ALTER TABLE OrderInfo
ALTER COLUMN OrderNo int NOT NULL
GO

ALTER TABLE OrderInfo
ALTER COLUMN OrderItem int NOT NULL
GO

ALTER TABLE OrderInfo
ALTER COLUMN Qty int NOT NULL
GO

ALTER TABLE OrderInfo
ALTER COLUMN ProductId int NOT NULL
GO

ALTER TABLE Employees
ALTER COLUMN FullName varchar(100) NOT NULL
GO

ALTER TABLE Customers
ALTER COLUMN CustomerAddress varchar(max) NOT NULL
GO

ALTER TABLE Customers
ALTER COLUMN CustomerPhone varchar(15) NOT NULL
GO

ALTER TABLE Products
ALTER COLUMN [Name] varchar(30) NOT NULL
GO

ALTER TABLE ProductTypes
ALTER COLUMN [Name] varchar(30) NOT NULL
GO

ALTER TABLE Salaries
ALTER COLUMN Position varchar(30) NOT NULL
GO

ALTER TABLE Salaries
ALTER COLUMN Rate decimal(9,4) NOT NULL
GO

---- ��������� PRIMARY KEYS �� �������:

ALTER TABLE Orders 
ADD CONSTRAINT PK_Orders_OrderNo PRIMARY KEY (OrderNo) 
GO

ALTER TABLE OrderInfo
ADD CONSTRAINT PK_OrederInfo_OrderNo_OrderItem 
PRIMARY KEY (OrderNo, OrderItem)
GO

ALTER TABLE Customers
ADD CONSTRAINT PK_Customers_Id PRIMARY KEY (Id)
GO

ALTER TABLE Employees
ADD CONSTRAINT PK_Employees_Id PRIMARY KEY (Id)
GO

ALTER TABLE Salaries
ADD CONSTRAINT PK_Salaries_Id PRIMARY KEY (Id)
GO

ALTER TABLE Products
ADD CONSTRAINT PK_Products_Id PRIMARY KEY (Id)
GO

ALTER TABLE ProductTypes
ADD CONSTRAINT PK_ProductTypes_Id PRIMARY KEY (Id)
GO

---- ��������� UNIQUE �� �������:
-- ���� ����������� ������������ ���� ���. ��������, ����� 
-- ����������� ������ ���� ���������
--ALTER TABLE Customers 
--ADD CONSTRAINT UQ_Customers_CustomerMob UNIQUE (CustomerMob)
--GO

-- ��� ����������� ����� ������������� ���� ��������� �������� �����
-- ����� ���� � ��� �� ���. ����� ��������, ���� ����� �������� ������ CustomerAdress
ALTER TABLE Customers 
ADD CONSTRAINT UQ_Customers_CustomerPhone UNIQUE (CustomerPhone)
GO

--� ����������� �� ������
ALTER TABLE Salaries 
ADD CONSTRAINT UQ_Salaries_Position UNIQUE (Position)
--ADD CONSTRAINT UQ_Salaries_Position_Rate UNIQUE (Position, Rate)
GO

ALTER TABLE ProductTypes 
ADD CONSTRAINT UQ_ProductTypes_Name UNIQUE ([Name])
GO

---- ��������� FOREIGN KEYS �� �������:

ALTER TABLE Orders 
ADD CONSTRAINT FK_Orders_Customers
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
	ON DELETE SET NULL
	ON UPDATE CASCADE
GO

ALTER TABLE Orders 
ADD CONSTRAINT FK_Orders_Employees
	FOREIGN KEY (CourierId) REFERENCES Employees(Id)
	ON DELETE SET NULL
	ON UPDATE CASCADE
GO

ALTER TABLE OrderInfo 
ADD CONSTRAINT FK_OrderInfo_Products
	FOREIGN KEY (ProductId) REFERENCES Products(Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

ALTER TABLE OrderInfo 
ADD CONSTRAINT FK_OrderInfo_Orders
	FOREIGN KEY (OrderNo) REFERENCES Orders(OrderNo)
	ON DELETE CASCADE -- NO ACTION
	ON UPDATE CASCADE
GO
	
ALTER TABLE Employees 
ADD CONSTRAINT FK_Employees_Salaries
	FOREIGN KEY (PositionId) REFERENCES Salaries(Id)
	ON DELETE SET NULL
	ON UPDATE CASCADE
GO

ALTER TABLE Products 
ADD CONSTRAINT FK_Products_ProductTypes
	FOREIGN KEY (TypeId) REFERENCES ProductTypes(Id)
	ON DELETE SET NULL
	ON UPDATE CASCADE
GO

---- ��������� DEFAULT �� �������:

ALTER TABLE Orders
ADD CONSTRAINT DF_Orders_Date DEFAULT GETDATE() FOR [Date]
GO

ALTER TABLE OrderInfo
ADD CONSTRAINT DF_OrderInfo_Qty DEFAULT 0 FOR Qty
GO

---- ��������� CHECK �� �������:

ALTER TABLE Customers
ADD CONSTRAINT CK_Customers_CustomerPhone 
CHECK (CustomerPhone LIKE '[0-9]-[0-9][0-9]-[0-9][0-9]')
GO

ALTER TABLE Customers
ADD CONSTRAINT CK_Customers_CustomerMob
CHECK (CustomerMob IS NULL OR CustomerMob LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]')
GO

/****************************************************************************
****************************************************************************/

SELECT * FROM Orders
SELECT * FROM OrderInfo
SELECT * FROM Customers
SELECT * FROM Employees
SELECT * FROM Salaries
SELECT * FROM Products
SELECT * FROM ProductTypes