/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIII ******  CURSORS. STORED PROCEDURE  ************************
************************    USER DEFINED FUNCTIONS   ************************
****************************************************************************/

/****************************************************************************
*									CURSORS									*
****************************************************************************/
-- ������������� � ��������: 
--		https://docs.microsoft.com/en-us/sql/t-sql/language-elements/cursors-transact-sql?view=sql-server-2017

USE GrandSlamDB

--1)
DECLARE cursor_name CURSOR  
	FOR SELECT * FROM Players --����� ������ ��������� �� ������ ���������� ��������� SELECT.

OPEN cursor_name -- ��� ����, ����� � ������� ������� ����� ���� ������ ������, ��� ���������� �������.

FETCH NEXT FROM cursor_name	-- ������� ������

CLOSE cursor_name	-- ������� ������

DEALLOCATE cursor_name	-- ������� ������

--2)
DECLARE @lName VARCHAR(50), @rank INT, @players_cursor CURSOR

SET @players_cursor = CURSOR
	FOR SELECT LName, [Rank] FROM Players

OPEN @players_cursor 

FETCH NEXT FROM @players_cursor INTO @lName, @rank
	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT 'Player: ' + ISNULL(@lName, 'undefined') + ', rank: ' + ISNULL(CAST(@rank AS VARCHAR), 'undefined')  
		FETCH NEXT FROM @players_cursor INTO @lName, @rank
	END

CLOSE @players_cursor

DEALLOCATE @players_cursor

--3)
DECLARE courts_cursor CURSOR 
	SCROLL 
	FOR SELECT * FROM Courts

OPEN courts_cursor

FETCH NEXT FROM courts_cursor			-- ������� ��������� 
FETCH PRIOR FROM courts_cursor			-- ������� ���������� 
FETCH LAST FROM courts_cursor			-- ������� ��������� ������ � �������
FETCH FIRST FROM courts_cursor			-- ������� ������ ������ � �������

-- ������� 2 ������ � ������� (������� �� ����, ��� ��������� ����� ABSOLUTE)
FETCH ABSOLUTE 2 FROM courts_cursor		

-- ���� ������ ����� ������ ����� N, ����� ������� (N + 3) ������ (������� �� ����, ��� ��������� ����� RELATIVE)
FETCH RELATIVE 3 FROM courts_cursor		
FETCH RELATIVE -2 FROM courts_cursor

CLOSE courts_cursor

DEALLOCATE courts_cursor

SELECT * FROM Courts

/****************************************************************************
*							STORED PROCEDURE								*
****************************************************************************/

USE pizzeriaDB

-- �������� ���������������� �������� �������� ������� �������� � �������� "sp".
-- �� �� ������������� ������������ ������� "sp_" ,��������� ��� ������� ������������
-- � ��������� �������� ����������.

CREATE PROCEDURE spGetAllEmployees
AS
	SELECT * FROM Employees
GO

EXECUTE spGetAllEmployees
GO

-- �� �������� ������� ��������� � ����� ���������� �������
--SELECT * FROM EXECUTE spGetAllEmployees		-- ������
--EXEC spGetAllEmployees WHERE Id = 1			-- ������

-- ��� ������ ������� ��������� ��� ������ ��������� ������ �������� � ������,
-- ����� ����� ������
spGetAllEmployees		

-- ������� � ���������� ����� ���������� � �������, �� ��������� ���� ������� 
-- ��� ������� � ������� ����� ����������� ������
INSERT INTO Employees --(Id, FullName, PositionId)
EXEC spGetAllEmployees

ALTER PROC spGetAllEmployees
AS
	SELECT * FROM Employees
	SELECT * FROM Customers
GO

USE GrandSlamDB
GO

--parameters

-- ��������� ����� ������������ ��� ���������������� (��������) ������
CREATE PROC spGetPlayers
	@BirthDate date = '19900101'
AS
	-- ���������� ����� ��������� � ���, ������� ����� ���� ���������� � �������� (������ ���������)
	SET NOCOUNT ON

	SELECT p.Id, p.FName, p.LName, pi.Country FROM Players p
			JOIN PlayerInfos pi ON p.Id = pi.PlayerId
			WHERE pi.BirthDate > @BirthDate;
GO

-- ��������� � ��������� ���������� ��� ������� ������
spGetPlayers '19900101'

--wildcard parameters	-	������������ ��������� (��������� ������� �������� �� ���������)
ALTER PROC spGetPlayers
	@FName varchar(50) = N'%',
	@LName varchar(50) = N'%'
AS
	SET NOCOUNT ON
	SELECT p.Id, p.FName, p.LName, pi.BirthDate, pi.Country FROM Players p
			JOIN PlayerInfos pi ON p.Id = pi.PlayerId
			WHERE p.FName LIKE @FName AND p.LName LIKE @LName;
GO

EXEC spGetPlayers @LName = 'M%'
EXEC spGetPlayers 'Andy', 'Murray'

--OUT, OUTPUT	-	�������� ���������
CREATE PROC spGetPlayerRank
	@Id int,
	@Rank int OUT
AS
	SET NOCOUNT ON
	SET @Rank = (SELECT TOP 1 Rank FROM Players
			WHERE Id = @Id);
	
	--RETURN -1		-- ����� RETURN ����� ����������� ������ �������� ���� int
GO

DECLARE @R int;
EXEC spGetPlayerRank 1, @R --OUTPUT
PRINT @R

--DECLARE @str varchar(10);
--EXEC @str = spGetPlayerRank 1, 1 
--PRINT @str

DECLARE @str int;
EXEC @str = spGetPlayerRank 1, 1 
PRINT @str

-- �������� ��������� ��������� ��� ������� ��������/���������� ������ �
-- ���������� ��������� ����� ����� ������
CREATE PROC spAddPlayer
	@FName varchar(50) = NULL,
	@LName varchar(50),
	@Rank int = NULL,
	@BirthDate date = NULL,
	@Weight smallint = NULL,
	@Height smallint = NULL,
	@Country varchar(50) = NULL,
	@BirthPlace varchar(50) = NULL,
	@Residence varchar(50) = NULL
AS
	SET NOCOUNT ON;
	DECLARE @Id int;

	INSERT Players VALUES
	(@FName, @LName, @Rank)
	
	SET @Id = @@IDENTITY

	INSERT PlayerInfos VALUES
	(@Id, @BirthDate, @Weight, @Height, @Country, @BirthPlace, @Residence)
GO

EXEC spAddPlayer @LName = 'Dolgopolov', @Country = 'Ukraine'

USE pizzeriaDB
GO

CREATE PROC spUpdateMinSalary
	@MinSalary decimal(9,4),
	@RowCount int OUT
AS
	SET NOCOUNT ON;
	UPDATE Salaries
		SET Rate = @MinSalary
		WHERE Rate < @MinSalary;

	SET @RowCount = @@ROWCOUNT;
GO

DECLARE @RowsUpdated int;
EXEC spUpdateMinSalary 1700, @RowsUpdated OUT
PRINT @RowsUpdated


/****************************************************************************
*						USER DEFINED FUNCTIONS								*
****************************************************************************/

-- ���������������� ������� ������ ���� �����: ��������� � ���������.

-- ��������� �������  - ��� �������, ������� � �������� ���������� ����� ������
-- ���������� ������� (�������).

-- ��������� ������� - ��� �������, ������� ���������� ��� ������, �� �� �������.

-- �������� ���������������� ������� ������� �������� � �������� "fn".

USE GrandSlamDB
GO

CREATE FUNCTION fnGetPlayerAvgAces (@playerId int)
	RETURNS int
AS
	BEGIN
		DECLARE @avgAces int;
		SET @avgAces = (SELECT AVG(Aces) FROM PlayerStats WHERE PlayerId = @playerId)
		RETURN @avgAces
	END
GO

-- ������������� ��� ��������� � �������� (��������,...) ���� ������ �������� 
-- ���� � ������� ��� ���������. ��� ��������� ������� ������� �� ��������
PRINT dbo.fnGetPlayerAvgAces(5)

SELECT FName, LName, dbo.fnGetPlayerAvgAces(Id) AVGAces FROM Players

SELECT FName, LName, f.AVGAces FROM Players
CROSS APPLY
(SELECT dbo.fnGetPlayerAvgAces(Id) AVGAces) f
GO

CREATE FUNCTION fnGetPlayersMatches()
	RETURNS TABLE
AS
	RETURN 
	(
		SELECT t.Name Tournament, c.Name Court, m1.Date, m1.Time, p1.FName + ' ' + p1.LName Winner, p2.FName + ' ' + p2.LName Loser
		FROM Matches m1
		JOIN Tournaments t 
			ON t.Id = m1.TournamentId
		JOIN PlayerStats ps1
			ON m1.Id = ps1.MatchId AND ps1.Win = 1
		JOIN PlayerStats ps2
			ON m1.Id = ps2.MatchId AND ps2.Win = 0
		JOIN Players p1 
			ON p1.Id = ps1.PlayerId
		JOIN Players p2
			ON p2.Id = ps2.PlayerId
		JOIN Courts c ON c.Id = m1.CourtId
	)
GO

SELECT * FROM fnGetPlayersMatches();
GO

ALTER FUNCTION fnGetPlayersMatches(@TournamentName varchar(50) = '%'/*, @DateFrom date, @DateTo date*/)
	RETURNS TABLE
AS
	RETURN 
	(
		SELECT c.Name Court, m1.Date, m1.Time, p1.FName + ' ' + p1.LName Winner, p2.FName + ' ' + p2.LName Loser
		FROM Matches m1
		JOIN Tournaments t 
			ON t.Id = m1.TournamentId AND t.Name LIKE @TournamentName
		JOIN PlayerStats ps1
			ON m1.Id = ps1.MatchId AND ps1.Win = 1
		JOIN PlayerStats ps2
			ON m1.Id = ps2.MatchId AND ps2.Win = 0
		JOIN Players p1 
			ON p1.Id = ps1.PlayerId
		JOIN Players p2
			ON p2.Id = ps2.PlayerId
		JOIN Courts c ON c.Id = m1.CourtId
		--WHERE m1.Date BETWEEN @DateFrom AND @DateTo
	)
GO

SELECT * FROM fnGetPlayersMatches('Roland Garros');
GO

-- ���� ��� ������������� ��������� ����� ���������� �������� �� ���������,
-- �� �� ��� ������� � ������ ���������� ����������� ����� �������� DEFAULT
SELECT * FROM fnGetPlayersMatches(DEFAULT);
GO

SELECT * FROM fnGetPlayersMatches('Roland Garros', '20160601', '20160603');
GO

SELECT Court, Winner FROM fnGetPlayersMatches(DEFAULT, '20160601', '20160603');
GO