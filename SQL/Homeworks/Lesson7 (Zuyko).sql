USE HomeTask;
GO



-- Task 1
-- Нормализовать все таблицы базы. Аргументировать необходимость нормальных форм для каждой таблицы.

-- Add table in the DB
CREATE TABLE Customers
(
	 [Id] int NOT NULL IDENTITY CONSTRAINT PK_Customers_Id PRIMARY KEY
	,[FName] nvarchar(100) NOT NULL
	,[LName] nvarchar(100) NOT NULL
	,[Phone] nvarchar(15) NOT NULL CONSTRAINT CK_Customers_Contacts CHECK(Phone LIKE '+38 ([0-9][0-9][0-9])-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]')
	,[Email] nvarchar(70) NOT NULL
)
GO

CREATE TABLE Ways
(
	 [Id] int NOT NULL IDENTITY CONSTRAINT PK_Ways_Id PRIMARY KEY
	,[From] nvarchar(100) NOT NULL
	,[Where] nvarchar(100) NOT NULL
	,[Distance] decimal(9, 3) NOT NULL
)
GO

-- Add table in the DB
CREATE TABLE BookedTicketsFlights 
(
	[Id] int NOT NULL IDENTITY		CONSTRAINT PK_BookedTicketsFlights_Id PRIMARY KEY,
	[Qty] int NOT NULL				,--CONSTRAINT CK_BookedTicketsFlights_Qty CHECK(Qty >= 1),
	[Cost] smallmoney NOT NULL		CONSTRAINT CK_BookedTicketsFlights_Cost CHECK(Cost >= 1),
	[CustomerId] int NOT NULL		CONSTRAINT FK_BookedTicketsFlights_CustomerId FOREIGN KEY  REFERENCES Customers(Id),
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