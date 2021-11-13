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
	[Rank] int
)

INSERT INTO @MyTableVar
	SELECT TOP 5 Id, LName, [Rank] FROM Players
	WHERE [Rank] IS NOT NULL
	ORDER BY [Rank]

SELECT * FROM @MyTableVar

-- Temporary table

---- В дополнение к табличным переменным можно определять временные таблицы. 
---- Такие таблицы могут быть полезны для хранения табличных данных внутри 
---- сложного комплексного скрипта.

---- Временные таблицы существуют на протяжении сессии базы данных. Если такая 
---- таблица создается в редакторе запросов (Query Editor) в SQL Server Management
---- Studio, то таблица будет существовать пока открыт редактор запросов. Таким 
---- образом, к временной таблице можно обращаться из разных скриптов внутри 
---- редактора запросов.

---- После создания все временные таблицы сохраняются в таблице tempdb, которая 
---- имеется по умолчанию в MS SQL Server.

---- Если необходимо удалить таблицу до завершения сессии базы данных, то для 
---- этой таблицы следует выполнить команду DROP TABLE.

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
---- Кроме временных таблиц MS SQL Server позволяет создавать производные таблицы,
---- которые в плане производительности являются более эффективным решением,
---- чем временные.

---- В отличие от временных таблиц производные хранятся в оперативной памяти и 
---- существуют только во время первого выполнения запроса, который представляет
---- эту таблицу.

---- Дополнительно: http://professorweb.ru/my/sql-server/2012/level2/2_14.php

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


-- эквивалентно запросу выше
	SELECT p.Id, p.LName FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId
		WHERE pi.Height >= (SELECT AVG(Height) FROM PlayerInfos)
UNION
	SELECT p.Id, p.LName FROM Players p
		LEFT JOIN PlayerInfos pi ON p.Id = pi.PlayerId
		WHERE pi.Weight >= (SELECT AVG(Weight) FROM PlayerInfos)
