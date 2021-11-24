
-- Используя изученные на занятии функции получить следующие результаты: 
-- Даты: сегодня, три месяца назад и 5 дней назад, так же, представить все эти даты в виде составляющих частей
DECLARE @today DATETIME = GETDATE();
DECLARE @3MonthsAgo DATETIME = DATEADD(MONTH, -3, GETDATE());
DECLARE @5DaysAgo DATETIME = DATEADD(DAY, -5, GETDATE());

SELECT	@today AS [Today], 
		@3MonthsAgo AS [3 months ago], 
		@5DaysAgo AS [5 days ago];

SELECT @today AS [Today], 
		DATEPART(YEAR, @today) AS [YEAR], 
		DATEPART(MONTH, @today) AS [MONTH], 
		DATEPART(DAY, @today) AS [DAY], 
		DATEPART(HOUR, @today) AS [HOUR], 
		DATEPART(MINUTE, @today) AS [MINUTE], 
		DATEPART(SECOND, @today) AS [SECOND], 
		DATEPART(MILLISECOND, @today) AS [MILLISECOND];

SELECT @3MonthsAgo AS [3 months ago], 
		DATEPART(YEAR, @3MonthsAgo) AS [YEAR], 
		DATEPART(MONTH, @3MonthsAgo) AS [MONTH], 
		DATEPART(DAY, @3MonthsAgo) AS [DAY], 
		DATEPART(HOUR, @3MonthsAgo) AS [HOUR], 
		DATEPART(MINUTE, @3MonthsAgo) AS [MINUTE], 
		DATEPART(SECOND, @3MonthsAgo) AS [SECOND], 
		DATEPART(MILLISECOND, @3MonthsAgo) AS [MILLISECOND];

SELECT @5DaysAgo AS [5 days ago], 
		DATEPART(YEAR, @5DaysAgo) AS [YEAR], 
		DATEPART(MONTH, @5DaysAgo) AS [MONTH], 
		DATEPART(DAY, @5DaysAgo) AS [DAY], 
		DATEPART(HOUR, @5DaysAgo) AS [HOUR], 
		DATEPART(MINUTE, @5DaysAgo) AS [MINUTE], 
		DATEPART(SECOND, @5DaysAgo) AS [SECOND], 
		DATEPART(MILLISECOND, @5DaysAgo) AS [MILLISECOND];

GO



/*	Используя изученные на занятии функции получить следующие результаты:
	- Получить выборку всех объектов бронирования, что были осуществлены за последний месяц.
	Реализовать несколько вариантов.

	- Получить выборку из таблицы билетов, заменить все отсутствующие значения контактной
	информации пользователя на строку "Undefined"											*/

-- P.S. Буль ласка, додайте до матеріалів уроку таблицю з данними, бо не хочеться її створювати для виконання цих завданнь (для цього уроки я її все ж таки зробив)

-- Create and use DB
CREATE DATABASE BookingDB
COLLATE Cyrillic_General_CI_AS
GO
USE BookingDB;
GO

-- Create tables
CREATE TABLE BookedTickets 
(
	[ID] int NOT NULL IDENTITY,
	[CustomerID] nvarchar(100) NOT NULL,
	[Place] nvarchar(100) NOT NULL,
	[Qty] int NOT NULL,
	[Cost] smallmoney NOT NULL,
	[DateBooking] datetime NOT NULL
)
GO

ALTER TABLE BookedTickets
ADD [Phone] nvarchar(13)

ALTER TABLE BookedTickets
ADD [Email] nvarchar(70)
GO

-- Fill the table
INSERT BookedTickets	(CustomerID,	Place,				Qty,	Cost,	DateBooking,					Phone,				Email)
VALUES
						('Mykhailo',	'Kyiv museum',		2,		100,	'20211119 10:15:34',			NULL,				'mykhailo@gmail.com'),
						('Taras',		'Lviv museum',		4,		250,	DATEADD(DAY, -7, GETDATE()),	'+381111111111',	NULL),
						('Larisa',		'Odessa museum',	1,		75,		DATEADD(DAY, -20, GETDATE()),	'+383333333333',	NULL),
						('Anna',		'Lviv cinema',		3,		400,	DATEADD(DAY, -32, GETDATE()),	'+389696969696',	'anna@gmail.com');
GO


-- Получить выборку всех объектов бронирования, что были осуществлены за последний месяц.
-- 1 variant
SELECT Place FROM BookedTickets
WHERE DATEDIFF(DAY, DateBooking, GETDATE()) <= 31

-- 2 variant
SELECT Place FROM BookedTickets
WHERE DATEADD(DAY, 31, DateBooking) >= GETDATE()

GO


-- Получить выборку из таблицы билетов, заменить все отсутствующие значения контактной
-- информации пользователя на строку "Undefined"
-- 1 variant
SELECT ID, CustomerID, Place, Qty, Cost, DateBooking, COALESCE(Phone, Email, 'Undefined') AS [Contats]
FROM BookedTickets
GO

-- 2 variant
SELECT ID, CustomerID, Place, Qty, Cost, DateBooking, ISNULL(Phone, 'Undefined') AS [Phone], ISNULL(Email, 'Undefined') AS [Email]
FROM BookedTickets
GO
