/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****   Lesson X   *****  SUBQUERY, TEMP TABLE, CTE  ************************
*****************************************************************************
****************************************************************************/

USE GrandSlamDB
GO

--НЕЗАВИСИМЫЕ ПОДЗАПРОСЫ
SELECT p.LName, t.Name, ISNULL(tb.Wins, 0) Wins FROM Players p
		CROSS JOIN Tournaments t
		LEFT JOIN 
		(SELECT ps.PlayerId, COUNT(ps.Win) Wins, m.TournamentId FROM PlayerStats ps 
				JOIN Matches m 
				ON ps.MatchId = m.Id AND ps.Win = 1 
				GROUP BY ps.PlayerId, m.TournamentId) tb -- производная таблица
		ON tb.PlayerId = p.Id AND tb.TournamentId = t.Id
		ORDER BY p.LName

-- Вывести информацию по играм, которые проходили на турнире 'Wimbledon'
SELECT * FROM Matches
WHERE TournamentId = (SELECT Id FROM Tournaments WHERE Name = 'Wimbledon')

-- Ошибка - вложенный запрос возвращает несколько значений Id
--SELECT * FROM Matches
--WHERE TournamentId = (SELECT Id FROM Tournaments)

--Вывести информацию об самом возрастном игроке
SELECT * FROM PlayerInfos
WHERE BirthDate = (SELECT MIN(BirthDate) FROM PlayerInfos)

--Вывести инормацию о высоких игроках
SELECT * FROM PlayerInfos
WHERE Height >= (SELECT AVG(Height) FROM PlayerInfos)

--Вывести инормацию об игроках с ростом 198 см.
SELECT * FROM Players
WHERE Id IN (SELECT Id FROM PlayerInfos WHERE Height = 198)

SELECT * FROM Players p
	JOIN PlayerInfos pi ON p.Id = pi.PlayerId
	WHERE pi.Height = 198

--Вывести информацию о самых высоких игроках 
SELECT * FROM Players
WHERE Id IN (SELECT Id FROM PlayerInfos 
			WHERE Height = (SELECT MAX(Height) FROM PlayerInfos))


--ALL, ANY (SOME), EXIST
--Вывести инормацию об игроках, которые не играли в финалах
SELECT * FROM Players
WHERE Id != ALL (SELECT ps.PlayerId FROM Matches m
					JOIN PlayerStats ps ON m.Id = ps.MatchId
					WHERE m.Round = 'FINALS')

--Вывести информацию о кортах, на которых не проходили игры
SELECT * FROM Courts
WHERE Id != ALL (SELECT /*DISTINCT*/CourtId FROM Matches)
 
-- Статья о том почему в запросе выше можно не использовать DISTINCT: 
-- http://www.sqlservercentral.com/blogs/sqlinthewild/2011/01/18/distincting-an-in-subquery/

SELECT * FROM Courts
WHERE Id NOT IN (SELECT CourtId FROM Matches)

SELECT * FROM Courts c1
WHERE NOT EXISTS (SELECT * FROM Matches m
								JOIN Courts c2 ON m.CourtId = c2.Id AND c1.Id = c2.Id)

--Вывести информацию о кортах, на которых проходили игры
SELECT * FROM Courts
WHERE Id = ANY (SELECT CourtId FROM Matches)

SELECT * FROM Courts
WHERE Id IN (SELECT CourtId FROM Matches)

SELECT DISTINCT c.Id, c.Name FROM Courts c 
			JOIN Matches m ON m.CourtId = c.Id


/****************************************************************************
****************************************************************************/

--СВЯЗАННЫЕ ПОДЗАПРОСЫ
--1. Выбрать строку из таблицы, указанной во внешнем запросе. Это будет текущая 
--	 строка-кандидат.
--2. Сохранить значения из этой строки-кандидата во временном буфере.
--3. Выполнить подзапрос. Для отбора записей использовать строку-кандидат.
--4. Вычислить условие во внешнем запросе, на основе результатов внутреннего 
--	 подзапроса, выполняемого в п.3. Определить отбирается ли строка-кандидат
--	 для вывода.
--5. Повторить процедуру для всех строк.

--Вывести игры, в которых игрок сделал наибольшее количество "подач навылет"
SELECT * FROM PlayerStats ps1
WHERE Aces = (SELECT MAX(Aces) FROM PlayerStats ps2 WHERE ps1.PlayerId = ps2.PlayerId)

--Вывести дату игры, фамилию игрока и сколько игрок сделал эйсов в этой игре
SELECT Id, 
(SELECT Date FROM Matches m WHERE m.Id = ps.MatchId) Date,
(SELECT LName FROM Players p WHERE p.Id = ps.PlayerId) Player,
Aces
FROM PlayerStats ps 

SELECT ps.Id, m.Date, p.LName, ps.Aces FROM PlayerStats ps 
			JOIN Matches m ON m.Id = ps.MatchId
			JOIN Players p ON p.Id = ps.PlayerId

-- Вывести по каждому игроку его максимальное количество сделанных эйсов за игру
SELECT LName,
(SELECT MAX(Aces) FROM PlayerStats ps WHERE ps.PlayerId = p.Id) MAX_Aces
FROM Players p

--Вывести игроков, которые не играли
SELECT * FROM Players p
WHERE NOT EXISTS (SELECT * FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 

SELECT * FROM Players p
WHERE p.Id NOT IN (SELECT PlayerId FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 

SELECT * FROM Players p
WHERE p.Id != ALL (SELECT PlayerId FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 


--APPLY (CROSS APPLY, OUTER APPLY)
-- Прочитать: 
--	https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/ms175156(v=sql.105),
--	http://www.t-sql.ru/post/CrossApply.aspx
--  http://professorweb.ru/my/sql-server/2012/level3/3_3.php
SELECT LName,
(SELECT MIN(Aces) FROM PlayerStats ps WHERE ps.PlayerId = p.Id) MIN_Aces,
(SELECT MAX(Aces) FROM PlayerStats ps WHERE ps.PlayerId = p.Id) MAX_Aces
FROM Players p

SELECT LName,
psa.MIN_Aces,
psa.MAX_Aces
FROM Players p
CROSS APPLY
(SELECT MAX(Aces) MAX_Aces, MIN(Aces) MIN_Aces FROM PlayerStats ps WHERE ps.PlayerId = p.Id) psa


/****************************************************************************
****************************************************************************/

-- Пример из msdn https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/ms175156(v=sql.105)

CREATE TABLE Employees
(
    empid   int         NOT NULL  PRIMARY KEY	-- id сотрудника
    ,mgrid   int         NULL	-- id сотрудника, которому данный сотрудник подчиняется
    ,empname varchar(25) NOT NULL	-- имя сотрудника
    ,salary  money       NOT NULL	-- зарплата сотрудника
);
GO

INSERT Employees 
VALUES
	(1 , NULL, 'Nancy'   , $10000.00)
	,(2 , 1   , 'Andrew'  , $5000.00)
	,(3 , 1   , 'Janet'   , $5000.00)
	,(4 , 1   , 'Margaret', $5000.00)
	,(5 , 2   , 'Steven'  , $2500.00)
	,(6 , 2   , 'Michael' , $2500.00)
	,(7 , 3   , 'Robert'  , $2500.00)
	,(8 , 3   , 'Laura'   , $2500.00)
	,(9 , 3   , 'Ann'     , $2500.00)
	,(10, 4   , 'Ina'     , $2500.00)
	,(11, 7   , 'David'   , $2000.00)
	,(12, 7   , 'Ron'     , $2000.00)
	,(13, 7   , 'Dan'     , $2000.00)
	,(14, 11  , 'James'   , $1500.00)
GO

--Create Departments table and insert values.
CREATE TABLE Departments
(
    deptid    INT NOT NULL PRIMARY KEY	-- id отдела 
    ,deptname  VARCHAR(25) NOT NULL		-- название отдела
    ,deptmgrid INT NULL REFERENCES Employees(empid)	-- ссылка на id начальника отдела
);
GO

INSERT 
	Departments 
VALUES
	(1, 'HR',           2),
	(2, 'Marketing',    7),
	(3, 'Finance',      8),
	(4, 'R&D',          9),
	(5, 'Training',     4),
	(6, 'Gardening', NULL)
GO

-- функция, которая принимая id сотрудника, выведит всех сотрудников которые ему подчиняются
CREATE FUNCTION dbo.fn_getsubtree(@empid AS INT) 
    RETURNS @TREE TABLE
				(
					empid   INT NOT NULL
					,empname VARCHAR(25) NOT NULL
					,mgrid   INT NULL
					,lvl     INT NOT NULL
				)
AS
BEGIN
  WITH Employees_Subtree(empid, empname, mgrid, lvl)
  AS
  ( 
    -- Anchor Member (AM)
		SELECT empid, empname, mgrid, 0
		FROM Employees
		WHERE empid = @empid

    UNION all
    
    -- Recursive Member (RM)
		SELECT e.empid, e.empname, e.mgrid, es.lvl+1
		FROM Employees AS e
		  JOIN Employees_Subtree AS es
			ON e.mgrid = es.empid
  )
  INSERT INTO @TREE
    SELECT * FROM Employees_Subtree;

  RETURN
END
GO

-- выедутся все сотрудники, которые напрямую или косвено подчиняются сотруднику с id 1
SELECT * FROM dbo.fn_getsubtree(1)	

-- выведет всех сотрудников по отделах
SELECT D.deptid, D.deptname, D.deptmgrid
    ,ST.empid, ST.empname, ST.mgrid
FROM Departments AS D
    CROSS APPLY fn_getsubtree(D.deptmgrid) AS ST;
	
-- выведет всех сотрудников по отделах + выведет отделы у которых нету сотрудников
SELECT D.deptid, D.deptname, D.deptmgrid
    ,ST.empid, ST.empname, ST.mgrid
FROM Departments AS D
    OUTER APPLY fn_getsubtree(D.deptmgrid) AS ST;



