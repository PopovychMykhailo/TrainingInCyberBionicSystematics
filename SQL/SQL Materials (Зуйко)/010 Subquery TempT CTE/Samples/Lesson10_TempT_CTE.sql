/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****   Lesson X   *****  SUBQUERY, TEMP TABLE, CTE  ************************
*****************************************************************************
****************************************************************************/

USE GrandSlamDB
GO

-- Table variable
DECLARE @MyTableVar table (
	Id int,
	Name varchar(30),
	Rank int
)

INSERT INTO @MyTableVar
SELECT TOP 5 Id, LName, Rank FROM Players
WHERE Rank IS NOT NULL
ORDER BY Rank

SELECT * FROM @MyTableVar

-- Temporary table
--local  #
--global ##
CREATE TABLE #tPlayers(
	Id int,
	Name varchar(30),
	YearsOld int
)
GO

INSERT #tPlayers
SELECT p.Id, p.LName, DATEDIFF(YEAR, pi.BirthDate, GETDATE()) YearsOld FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId
GO

SELECT * FROM #tPlayers

DELETE #tPlayers

DROP TABLE #tPlayers

SELECT t.Id, t.LName, t.YearsOld
INTO #tPlayers
FROM (SELECT p.Id, p.LName, DATEDIFF(YEAR, pi.BirthDate, GETDATE()) YearsOld FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId) t

--##

--Common table expression (CTE)

-- Define the CTE expression name and column list. 
;WITH Players_CTE (Id, LName, YearsOld)
AS
-- Define the CTE query.
(SELECT p.Id, p.LName, DATEDIFF(YEAR, pi.BirthDate, GETDATE()) YearsOld FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId)
-- Define the outer query referencing the CTE name.
SELECT * FROM Players_CTE


;WITH Players_CTE --(Id, LName, YearsOld)
AS
-- Define the CTE query.
(SELECT p.Id, p.LName, DATEDIFF(YEAR, pi.BirthDate, GETDATE()) YearsOld FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId)
-- Define the outer query referencing the CTE name.
SELECT * FROM Players_CTE


;WITH Tall_Players AS(
	SELECT p.Id, p.LName FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId
		WHERE pi.Height >= (SELECT AVG(Height) FROM PlayerInfos)
),
Heavy_Players AS(
	SELECT p.Id, p.LName FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId
		WHERE pi.Weight >= (SELECT AVG(Weight) FROM PlayerInfos)
)
SELECT * FROM Tall_Players 
UNION 
SELECT * FROM Heavy_Players



	SELECT p.Id, p.LName FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId
		WHERE pi.Height >= (SELECT AVG(Height) FROM PlayerInfos)

UNION

	SELECT p.Id, p.LName FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId
		WHERE pi.Weight >= (SELECT AVG(Weight) FROM PlayerInfos)
