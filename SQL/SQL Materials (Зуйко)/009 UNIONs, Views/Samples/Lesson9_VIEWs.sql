/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson IX   *****        UNIONs, VIEWs        ************************
*****************************************************************************
****************************************************************************/

USE GrandSlamDB
GO

--CREATE, ALTER, DROP
--#1
CREATE VIEW Games
AS
	SELECT c.Name, m1.Round, m1.Date, m1.Time, p1.FName + ' ' + p1.LName Winner, p2.FName + ' ' + p2.LName Loser
		FROM Matches m1
		JOIN PlayerStats ps1
			ON m1.Id = ps1.MatchId AND ps1.Win = 1
		JOIN PlayerStats ps2
			ON m1.Id = ps2.MatchId AND ps2.Win = 0
		JOIN Players p1 
			ON p1.Id = ps1.PlayerId
		JOIN Players p2
			ON p2.Id = ps2.PlayerId
		JOIN Courts c ON c.Id = m1.CourtId
GO

SELECT * FROM Games

--#2
CREATE VIEW Players_TOP100
	(Rank, FullName, BirthDate, Weight, Height)
AS
	SELECT p.Rank, p.FName + ' ' + p.LName, pli.BirthDate, pli.Weight, pli.Height 
	FROM Players p
		JOIN PlayerInfos pli
		ON p.Id = pli.PlayerId
	--ORDER BY p.Rank    
GO

SELECT Rank, FullName FROM Players_TOP100
ORDER BY Rank

ALTER VIEW Players_TOP100
	(FullName, BirthDate, Weight, Height)
AS
	SELECT TOP(100) p.FName + ' ' + p.LName, pli.BirthDate, pli.Weight, pli.Height 
	FROM Players p
		JOIN PlayerInfos pli
		ON p.Id = pli.PlayerId
	ORDER BY p.Rank  
GO

SELECT * FROM Players_TOP100

--#3 WITH SCHEMABINDING
USE UnionsDB
GO

CREATE VIEW Counterparties
AS
SELECT cs.Name, ISNULL(c.Mobile, s.Phone) Phone, c.EMail, s.Address, s.City FROM
	(SELECT Name FROM Customers
	UNION
	SELECT FullName FROM Suppliers) cs
		LEFT JOIN (SELECT Name,  Mobile, EMail FROM Customers WHERE EMail IS NOT NULL) c
		ON cs.Name = c.Name
		LEFT JOIN (SELECT FullName,  Phone, Address, City FROM Suppliers WHERE Address IS NOT NULL) s
		ON cs.Name = s.FullName
GO

SELECT * FROM Counterparties

DROP TABLE Suppliers
GO

ALTER VIEW Counterparties
WITH SCHEMABINDING
AS
SELECT cs.Name, ISNULL(c.Mobile, s.Phone) Phone, c.EMail, s.Address, s.City FROM
	(SELECT Name FROM dbo.Customers
	UNION
	SELECT FullName FROM dbo.Suppliers) cs
		LEFT JOIN (SELECT Name,  Mobile, EMail FROM dbo.Customers WHERE EMail IS NOT NULL) c
		ON cs.Name = c.Name
		LEFT JOIN (SELECT FullName,  Phone, Address, City FROM dbo.Suppliers WHERE Address IS NOT NULL) s
		ON cs.Name = s.FullName
GO

DROP TABLE Suppliers
GO

DROP VIEW Counterparties
GO

--INSERT, UPDATE, DELETE
--#4
USE GrandSlamDB
GO

SELECT * FROM Players_TOP100

INSERT Players_TOP100 
(FName, LName)
VALUES
('Yoshihito Nishioka')
GO

ALTER VIEW Players_TOP100
	(FName, LName, BirthDate, Weight, Height)
AS
	SELECT TOP(100) p.FName, p.LName, pli.BirthDate, pli.Weight, pli.Height 
	FROM Players p
		LEFT JOIN PlayerInfos pli
		ON p.Id = pli.PlayerId
	ORDER BY p.Rank  
GO

--#5 WITH CHECK OPTION
CREATE VIEW Courts_over10000
AS
	SELECT Name, City, Capacity, Surface FROM Courts
	WHERE Capacity >= 10000
GO

SELECT * FROM Courts_over10000

INSERT Courts_over10000
VALUES ('No. 3 Court','London', 2000,'Grass')

SELECT * FROM Courts

DELETE Courts WHERE Id = 11

ALTER VIEW Courts_over10000
AS
	SELECT Name, City, Capacity, Surface FROM Courts
	WHERE Capacity >= 10000
WITH CHECK OPTION
GO

INSERT Courts_over10000
VALUES ('No. 3 Court','London', 2000,'Grass')