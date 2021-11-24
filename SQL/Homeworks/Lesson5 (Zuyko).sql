-- Create database
CREATE DATABASE HomeTask
COLLATE Cyrillic_General_CI_AS
GO
USE HomeTask;
GO

USE HomeTask;
GO

-- Add table in the DB
CREATE TABLE BookedTicketsFlights 
(
	[ID] int NOT NULL IDENTITY,
	[From] nvarchar(100) NOT NULL,
	[Where] nvarchar(100) NOT NULL,
	[Distance] decimal(9, 3) NOT NULL,	-- 123456.123 km
	[Qty] int NOT NULL,
	[Cost] smallmoney NOT NULL,
	[Customer] nvarchar(150) NOT NULL,
	[Contacts] varchar(100),
	[DateBooking] datetime NOT NULL
)
GO

/*
1	Kyiv	Lviv	600.000	2	1300,00	Mykhailo	mykhailo@gmail.com	2021-09-19 11:35:05.000
7	Lviv	Dnipro	900.000	1	950,00	Maria		+38333333333		2021-10-17 19:11:59.000
8	Dnipro	Kharkiv	600.000	3	1850,00	Timothy		NULL				2021-11-01 06:01:02.000
9	Kharkiv	Kyiv	700.000	1	750,00	Anna		anna@gmail.com		2021-12-15 23:59:59.997
*/


-- Task 1
-- ѕодключившись к базе HomeTask, при помощи агрегатных функций и системных таблиц, подсчитать
-- количество таблиц в данной базе.
SELECT COUNT(*) FROM sys.tables



-- Task 2
-- ѕолучить среднее значение дальности полета самолетов и среднее значение дл€ уникальных значений
-- дальности.
SELECT 
	SUM(Distance*Qty)/SUM(Qty) AS [AVG_Distances],
	AVG(DISTINCT Distance) AS [Distinct_AVG_Distances]
FROM BookedTicketsFlights 



-- Task 3
-- ѕолучить количество броней и их среднюю стоимость
SELECT 
	SUM(Qty) AS [Count_tickets],
	SUM(Cost)/SUM(Qty) AS [AVG_price_ticket]
FROM BookedTicketsFlights 

