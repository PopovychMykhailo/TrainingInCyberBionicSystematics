
-- 1) C������ �� OrdersDB
CREATE DATABASE OrdersDB  ON 
(
	NAME = 'OrdersDB', 					-- ���������� ��� ����� ��
	FILENAME = 'D:\Work\DBs\OrdersDB.mdf', -- ���������� ��� ��
	SIZE = 5MB,                         -- ��������� ������
	MAXSIZE = 10MB,                     -- ������������ ������
	FILEGROWTH = 1MB				    -- �������
)
LOG ON
(
	NAME = 'OrdersDBLog', 				-- ���������� ��� ����� �������
	FILENAME = 'D:\Work\DBs\OrdersDB.ldf', -- ���������� ��� ������� ��
	SIZE = 1MB,                         -- ��������� ������ �������
	MAXSIZE = 3MB,                      -- ������������ ������ �������
	FILEGROWTH = 1MB                    -- �������
)
COLLATE Cyrillic_General_CS_AS
USE OrdersDB
Go

-- 2) ������� ������� Orders �� ���������� ���������:
	--Id, Date, Employee, Customer, PaidAmount, Product
	--*��� �������� ����� ��������� ���������� ����
CREATE TABLE Orders
(
    [Id] int NOT NULL IDENTITY,
    [Date] datetime NOT NULL,
	[Employee] nvarchar(50) NOT NULL,
	[Customer] nvarchar(50) NOT NULL,
	[PaidAmount] smallmoney NOT NULL,
	[Product] nvarchar(50) NOT NULL
);
GO


-- 3) �������� ������� Qty (������� ��. ������ ������) � ������� Orders
ALTER TABLE Orders ADD [Qty] int NOT NULL Default 1
Go

-- 4) �������� � ������� 10 ������� (����� ������ ����� ����� � �������� �� 10 �� 300)
INSERT INTO Orders
	([Date],[Employee],[Customer],[PaidAmount],[Product],[Qty]) 
VALUES
	('20110101 01:16:42:123', 'Mykhailo',	'Taras', '150.57', 'Tomatos', '5'),
	('20120202 03:45:43:123', 'Anna',		'Robert', '50.99', 'Bread', '3'),
	('20130303 04:38:49:123', 'Larisa',		'Alex', '40.29', 'Pateta', '10'),
	('20140404 06:32:45:123', 'Ilon',		'Robert', '270.63', 'Notebook', '1'),
	('20150505 08:13:48:123', 'Larisa',		'Ben', '90.87', 'Chair', '2'),
	('20160606 10:54:49:123', 'Anna',		'Alex', '290.24', 'Phone', '2'),
	('20170707 12:34:43:123', 'Ilon',		'Robert', '10.01', 'Tomatos', '2'),
	('20180808 14:37:46:123', 'Mykhailo',	'Ben', '99.99', 'Water', '50'),
	('20190909 18:59:42:123', 'Anna',		'Taras', '147.75', 'Watch', '3'),
	('20201010 23:01:47:123', 'Ilon',		'Alex', '299.99', 'Box snekers', '1')
GO


-- 5) ������� 5 ������ (Id = 5)
DELETE Orders
WHERE Id = 5
GO


-- 6) �������� 7 ������ �������� � ��� PaidAmount � 2 ���� (Id = 7)
UPDATE Orders
SET PaidAmount = (PaidAmount * 2)
OUTPUT inserted.Id, inserted.Date, inserted.Employee, inserted.Customer, deleted.PaidAmount [OLD PaidAmount], inserted.PaidAmount [NEW PaidAmount], inserted.Product, inserted.Qty
WHERE Id = 7
GO


-- 7) ������� ������� ������� � ������� ����� ������ ������ 100 
SELECT * FROM Orders
WHERE PaidAmount > 100
GO


-- 8) ������� ���� ����������� (��� ����������)
SELECT Employee FROM Orders
GROUP BY Employee
GO


-- 9) ������� ���� �������� (��� ����������)
SELECT DISTINCT Customer FROM Orders
GO


-- 10) ������� ��� ������ � ������� (2 �������)
TRUNCATE TABLE Orders	-- 1 variant (recommended)
DELETE FROM Orders		-- 2 variant
GO


-- 11) ������� �������
DROP TABLE Orders


-- 12) ������� ��
DROP DATABASE OrdersDB