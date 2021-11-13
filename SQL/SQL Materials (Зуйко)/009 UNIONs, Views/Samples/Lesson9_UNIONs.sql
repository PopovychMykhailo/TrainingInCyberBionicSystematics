/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson IX   *****        UNIONs, VIEWs        ************************
*****************************************************************************
****************************************************************************/
CREATE DATABASE UnionsDB
GO 

USE UnionsDB
GO

CREATE TABLE dbo.Customers
(
    Id int NOT NULL IDENTITY,
    Name varchar(100),
	Mobile varchar(20),
	EMail varchar(100)
);
GO

CREATE TABLE dbo.Suppliers
(
    Id int NOT NULL IDENTITY,
    FullName varchar(100),
	Phone varchar(15),
	Address varchar(50),
	City varchar(30)
);
GO

INSERT Customers VALUES
('Fryderyk Chopin', '(050) 196-00-32', 'chopin@warsaw.dw'),
('Peter Tchaikovsky', '(050) 196-00-34', 'ilyich@speter.re'),
('Camille Saint-Saens', '(050) 196-00-33', 'saintsaens@paris.fr'),
('George Handel', '(050) 196-00-31', 'handel@halle.sri');
GO

INSERT Suppliers VALUES
('Camille Saint-Saens', '(050) 196-00-33', 'rue du Jardinet', 'Paris'),
('George Handel', '050-196-00-31', 'Westminster Abbey', 'London'),
('Sergei Rachmaninoff', '(050) 196-00-35', '505 West End Avenue', 'New York'),
('Antonio Vivaldi', '(050) 196-00-36', 'Ospedale della Pieta', 'Venice');
GO

--UNION
--#1
SELECT Name FROM Customers
UNION
SELECT FullName FROM Suppliers

--#2
INSERT Customers (Name)  VALUES
('Fryderyk Chopin');
GO

SELECT Name FROM Customers
UNION
SELECT FullName FROM Suppliers

DELETE Customers
WHERE Id = 5
GO

--#3
SELECT Id, Name FROM Customers
UNION
SELECT Id, FullName FROM Suppliers

--#4
SELECT Name, Mobile FROM Customers
UNION
SELECT FullName, Phone FROM Suppliers

--#5
SELECT Name, Mobile, EMail FROM Customers
UNION
SELECT FullName, Phone, 'no email' FROM Suppliers

--#6
SELECT Name, Mobile, EMail FROM Customers
UNION
SELECT FullName, Phone, Address + ', ' + City FROM Suppliers

--UNION ALL
--#1
SELECT Name FROM Customers
UNION ALL
SELECT FullName FROM Suppliers

--#2
SELECT Name, Mobile, EMail, NULL Address, NULL City FROM Customers
UNION ALL
SELECT FullName, Phone, 'no email', Address, City FROM Suppliers

--#3
(SELECT Name FROM Customers
UNION ALL
SELECT FullName FROM Suppliers)
UNION
SELECT FullName FROM Suppliers

--EXCEPT
(SELECT Name FROM Customers
EXCEPT
SELECT FullName FROM Suppliers)
UNION ALL
(SELECT FullName FROM Suppliers
EXCEPT
SELECT Name FROM Customers)

--INTERSECT
--#1
SELECT Name FROM Customers
INTERSECT
SELECT FullName FROM Suppliers

--#2
CREATE TABLE dbo.EmployeeNames
(
    Id int NOT NULL IDENTITY,
    Name varchar(100),
);
GO

INSERT EmployeeNames VALUES
('Fryderyk Chopin'),
('George Handel'),
('Antonio Vivaldi');
GO

(SELECT Name FROM Customers
EXCEPT
SELECT FullName FROM Suppliers)
INTERSECT
SELECT Name FROM EmployeeNames