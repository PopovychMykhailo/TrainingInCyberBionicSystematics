/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson V  *******    Aggregate functions      ************************
****************************************************************************/

CREATE DATABASE AggregateDB ON
(
	NAME = 'AggregateDB',
	FILENAME = 'D:\\DBs\AggregateDB.mdf'
)
COLLATE Cyrillic_General_CI_AS

USE AggregateDB

CREATE TABLE Orders		--������� �������
(
	Id int NOT NULL IDENTITY,					-- ����� ������
	Date datetime NOT NULL DEFAULT GetDate(),	-- ����� ���������� ������
	ProductId int NOT NULL,						-- ����� ������
	Qty int NOT NULL,							-- ���. ��. ������ � ������
	Price  decimal(6, 2) NOT NULL,				-- ���� 1 ��. ������
	City nvarchar(30) NULL						-- NULL - ����� ������
)

TRUNCATE TABLE Orders

INSERT INTO Orders
(ProductId, Date, Qty, Price, City)
VALUES
	(1,	GetDate() + 1,	1,	1000,	'Kiev'),
	(1,	GetDate() + 2,	1,	900,	'Lviv'),
	(2,	GetDate() + 2,	1,	1100,	'Lviv'),
	(3,	GetDate() + 4,	2,	2000,	NULL),
	(2,	GetDate() + 5,	1,	1000,	'Kiev'),
	(3,	GetDate() + 5,	4,	2200,	'Lviv'),
	(2,	GetDate() + 7,	2,	800,	NULL)

SELECT * FROM Orders

-- 1. SUM()
SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
GROUP BY ProductId

SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductId

SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
GROUP BY ProductId
HAVING SUM(Qty) >= 3

SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductId
HAVING SUM(Qty) >= 3

-- 2. MIN(), MAX()
SELECT ProductId, MIN(Price) MIN_Price, MAX(Price) MAX_Price FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductId

-- 3. AVG()
SELECT ProductId, 
MIN(Price) MIN_Price, 
MAX(Price) MAX_Price,
AVG(Price) AVG_Price
FROM Orders
GROUP BY ProductId

SELECT ProductId, 
MIN(Price) MIN_Price, 
MAX(Price) MAX_Price,
SUM(Price*Qty)/SUM(Qty) AVG_Price
FROM Orders
GROUP BY ProductId

-- 4. COUNT()
SELECT COUNT(*) FROM Orders

SELECT COUNT(City) FROM Orders

SELECT COUNT(DISTINCT City) FROM Orders

SELECT 
COUNT(DISTINCT ProductId) Products,
COUNT(DISTINCT City) Cities
FROM Orders

SELECT City, COUNT(*) Sales FROM Orders
GROUP BY City

SELECT City, COUNT(City) Sales FROM Orders
GROUP BY City

SELECT City, COUNT(City) Sales FROM Orders
WHERE City IS NOT NULL
GROUP BY City

-- ������� ���������� �� �������: � �������� �������, � ����� ���-��, 
-- �� ����� �����, �� ����� ���, ���� ����, ������� ����
SELECT ProductID,
COUNT(Id), 
SUM(Qty) Total_Qty,
SUM(Price*Qty) Total_Sum,
MIN(Price) MIN_Price, 
MAX(Price) MAX_Price,
SUM(Price*Qty)/SUM(Qty) AVG_Price
FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductID

-- ������� ���������� �� ��������: ������� ����� ������ �� ������� ������
SELECT City,
AVG(Qty * Price) AVG_Sale
FROM Orders
GROUP BY City