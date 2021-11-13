/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****   Lesson X   *****  SUBQUERY, TEMP TABLE, CTE  ************************
*****************************************************************************
****************************************************************************/

USE GrandSlamDB
GO

--����������� ����������
SELECT p.LName, t.Name, ISNULL(tb.Wins, 0) Wins FROM Players p
		CROSS JOIN Tournaments t
		LEFT JOIN 
		(SELECT ps.PlayerId, COUNT(ps.Win) Wins, m.TournamentId FROM PlayerStats ps 
				JOIN Matches m 
				ON ps.MatchId = m.Id AND ps.Win = 1 
				GROUP BY ps.PlayerId, m.TournamentId) tb -- ����������� �������
		ON tb.PlayerId = p.Id AND tb.TournamentId = t.Id
		ORDER BY p.LName

-- ������� ���������� �� �����, ������� ��������� �� ������� 'Wimbledon'
SELECT * FROM Matches
WHERE TournamentId = (SELECT Id FROM Tournaments WHERE Name = 'Wimbledon')

-- ������ - ��������� ������ ���������� ��������� �������� Id
--SELECT * FROM Matches
--WHERE TournamentId = (SELECT Id FROM Tournaments)

--������� ���������� �� ����� ���������� ������
SELECT * FROM PlayerInfos
WHERE BirthDate = (SELECT MIN(BirthDate) FROM PlayerInfos)

--������� ��������� � ������� �������
SELECT * FROM PlayerInfos
WHERE Height >= (SELECT AVG(Height) FROM PlayerInfos)

--������� ��������� �� ������� � ������ 198 ��.
SELECT * FROM Players
WHERE Id IN (SELECT Id FROM PlayerInfos WHERE Height = 198)

SELECT * FROM Players p
	JOIN PlayerInfos pi ON p.Id = pi.PlayerId
	WHERE pi.Height = 198

--������� ���������� � ����� ������� ������� 
SELECT * FROM Players
WHERE Id IN (SELECT Id FROM PlayerInfos 
			WHERE Height = (SELECT MAX(Height) FROM PlayerInfos))


--ALL, ANY (SOME), EXIST
--������� ��������� �� �������, ������� �� ������ � �������
SELECT * FROM Players
WHERE Id != ALL (SELECT ps.PlayerId FROM Matches m
					JOIN PlayerStats ps ON m.Id = ps.MatchId
					WHERE m.Round = 'FINALS')

--������� ���������� � ������, �� ������� �� ��������� ����
SELECT * FROM Courts
WHERE Id != ALL (SELECT /*DISTINCT*/CourtId FROM Matches)
 
-- ������ � ��� ������ � ������� ���� ����� �� ������������ DISTINCT: 
-- http://www.sqlservercentral.com/blogs/sqlinthewild/2011/01/18/distincting-an-in-subquery/

SELECT * FROM Courts
WHERE Id NOT IN (SELECT CourtId FROM Matches)

SELECT * FROM Courts c1
WHERE NOT EXISTS (SELECT * FROM Matches m
								JOIN Courts c2 ON m.CourtId = c2.Id AND c1.Id = c2.Id)

--������� ���������� � ������, �� ������� ��������� ����
SELECT * FROM Courts
WHERE Id = ANY (SELECT CourtId FROM Matches)

SELECT * FROM Courts
WHERE Id IN (SELECT CourtId FROM Matches)

SELECT DISTINCT c.Id, c.Name FROM Courts c 
			JOIN Matches m ON m.CourtId = c.Id


/****************************************************************************
****************************************************************************/

--��������� ����������
--1. ������� ������ �� �������, ��������� �� ������� �������. ��� ����� ������� 
--	 ������-��������.
--2. ��������� �������� �� ���� ������-��������� �� ��������� ������.
--3. ��������� ���������. ��� ������ ������� ������������ ������-��������.
--4. ��������� ������� �� ������� �������, �� ������ ����������� ����������� 
--	 ����������, ������������ � �.3. ���������� ���������� �� ������-��������
--	 ��� ������.
--5. ��������� ��������� ��� ���� �����.

--������� ����, � ������� ����� ������ ���������� ���������� "����� �������"
SELECT * FROM PlayerStats ps1
WHERE Aces = (SELECT MAX(Aces) FROM PlayerStats ps2 WHERE ps1.PlayerId = ps2.PlayerId)

--������� ���� ����, ������� ������ � ������� ����� ������ ����� � ���� ����
SELECT Id, 
(SELECT Date FROM Matches m WHERE m.Id = ps.MatchId) Date,
(SELECT LName FROM Players p WHERE p.Id = ps.PlayerId) Player,
Aces
FROM PlayerStats ps 

SELECT ps.Id, m.Date, p.LName, ps.Aces FROM PlayerStats ps 
			JOIN Matches m ON m.Id = ps.MatchId
			JOIN Players p ON p.Id = ps.PlayerId

-- ������� �� ������� ������ ��� ������������ ���������� ��������� ����� �� ����
SELECT LName,
(SELECT MAX(Aces) FROM PlayerStats ps WHERE ps.PlayerId = p.Id) MAX_Aces
FROM Players p

--������� �������, ������� �� ������
SELECT * FROM Players p
WHERE NOT EXISTS (SELECT * FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 

SELECT * FROM Players p
WHERE p.Id NOT IN (SELECT PlayerId FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 

SELECT * FROM Players p
WHERE p.Id != ALL (SELECT PlayerId FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 


--APPLY (CROSS APPLY, OUTER APPLY)
-- ���������: 
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

-- ������ �� msdn https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/ms175156(v=sql.105)

CREATE TABLE Employees
(
    empid   int         NOT NULL  PRIMARY KEY	-- id ����������
    ,mgrid   int         NULL	-- id ����������, �������� ������ ��������� �����������
    ,empname varchar(25) NOT NULL	-- ��� ����������
    ,salary  money       NOT NULL	-- �������� ����������
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
    deptid    INT NOT NULL PRIMARY KEY	-- id ������ 
    ,deptname  VARCHAR(25) NOT NULL		-- �������� ������
    ,deptmgrid INT NULL REFERENCES Employees(empid)	-- ������ �� id ���������� ������
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

-- �������, ������� �������� id ����������, ������� ���� ����������� ������� ��� �����������
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

-- �������� ��� ����������, ������� �������� ��� ������� ����������� ���������� � id 1
SELECT * FROM dbo.fn_getsubtree(1)	

-- ������� ���� ����������� �� �������
SELECT D.deptid, D.deptname, D.deptmgrid
    ,ST.empid, ST.empname, ST.mgrid
FROM Departments AS D
    CROSS APPLY fn_getsubtree(D.deptmgrid) AS ST;
	
-- ������� ���� ����������� �� ������� + ������� ������ � ������� ���� �����������
SELECT D.deptid, D.deptname, D.deptmgrid
    ,ST.empid, ST.empname, ST.mgrid
FROM Departments AS D
    OUTER APPLY fn_getsubtree(D.deptmgrid) AS ST;



