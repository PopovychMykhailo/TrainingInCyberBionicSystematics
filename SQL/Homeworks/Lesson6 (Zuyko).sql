CREATE DATABASE HomeTask
COLLATE Cyrillic_General_CI_AS
GO
USE HomeTask;
GO



-- Task 0
-- ѕроанализировав таблицы базы HomeTask обеспечить целостность сущностей/ссылочную с
-- использованием изученных подходов

-- Add table in the DB
CREATE TABLE Customers
(
	[Id] int NOT NULL IDENTITY CONSTRAINT PK_Customers_Id PRIMARY KEY
	,[FName] nvarchar(100) NOT NULL
	,[LName] nvarchar(100) NOT NULL
)
GO
-- Add table in the DB
CREATE TABLE BookedTicketsFlights 
(
	[Id] int NOT NULL IDENTITY		CONSTRAINT PK_BookedTicketsFlights_Id PRIMARY KEY,
	[From] nvarchar(100) NOT NULL,
	[Where] nvarchar(100) NOT NULL,
	[Distance] decimal(9, 3) NOT NULL,	-- 123456.123 km
	[Qty] int NOT NULL				,--CONSTRAINT CK_BookedTicketsFlights_Qty CHECK(Qty >= 1),
	[Cost] smallmoney NOT NULL		CONSTRAINT CK_BookedTicketsFlights_Cost CHECK(Cost >= 1),
	[CustomerId] int NOT NULL		CONSTRAINT FK_BookedTicketsFlights_CustomerId FOREIGN KEY  REFERENCES Customers(Id),
	[Contacts] varchar(100)			CONSTRAINT CK_BookedTicketsFlights_Contacts CHECK(Contacts LIKE '+38 ([0-9][0-9][0-9])-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'),
	[DateBooking] datetime NOT NULL CONSTRAINT DF_BookedTicketsFlights_DateBooking DEFAULT GETDATE()
)
GO

-- Fill the DB
INSERT INTO Customers (FName, LName)
VALUES
 ('Mykhailo',	'Po')
,('Maria',		'Ve')
,('Tymofiy',	'Ka')
,('Anna',		'Kra');
GO
-- Fill the DB
INSERT INTO BookedTicketsFlights ([From], [Where], Distance, Qty, Cost, CustomerId, Contacts, DateBooking)
VALUES
 ('Kyiv',		'Lviv',		'600',	'0',	'1300',	'3',	'+38 (097)-333-33-33',	'20210919 11:35:05.000')
,('Lviv',		'Dnipro',	'900',	'1',	'950',	'1',	'+38 (097)-111-11-11',	'20211017 19:11:59.000')
,('Dnipro',		'Kharkiv',	'600',	'3',	'1850',	'4',	NULL,					'20211101 06:01:02.000')
,('Kharkiv',	'Kyiv',		'700',	'1',	'750',	'2',	'+38 (097)-222-22-22',	'20211215 23:59:59.997');
GO


-- Task 1
-- ƒобавить несколько пользовательских ограничений на вводимые данные дл€ обработки возможных
-- некорректных значений.

-- Add constraint
ALTER TABLE BookedTicketsFlights --WITH NOCHECK		-- 'WITH NOCHECK'- Optional parameter for checking existing values
	ADD CONSTRAINT CK_BookedTicketsFlights_Qty 
		CHECK(Qty >= 1)
GO

-- Disable CK_BookedTicketsFlights_Qty check
ALTER TABLE BookedTicketsFlights
NOCHECK CONSTRAINT CK_BookedTicketsFlights_Qty
GO

-- Drop CK_BookedTicketsFlights_Qty check
ALTER TABLE BookedTicketsFlights
DROP CONSTRAINT CK_BookedTicketsFlights_Qty
GO



-- Task 2
-- ѕроанализировав таблицы и варианты возможных запросов к ним, наложить ограничени€ на
-- уникальность значений дл€ возможных целевых полей таблиц.

-- Add constraint
ALTER TABLE BookedTicketsFlights --WITH NOCHECK		-- 'WITH NOCHECK'- Optional parameter for checking existing values
	ADD CONSTRAINT UQ_BookedTicketsFlights_Contacts 
		UNIQUE (Contacts)
GO
