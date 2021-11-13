/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIII ******  CURSORS. STORED PROCEDURE  ************************
************************    USER DEFINED FUNCTIONS   ************************
****************************************************************************/

/****************************************************************************
*									CURSORS									*
****************************************************************************/
-- Дополнительно о курсорах: 
--		https://docs.microsoft.com/en-us/sql/t-sql/language-elements/cursors-transact-sql?view=sql-server-2017

USE GrandSlamDB

--1)
DECLARE cursor_name CURSOR  
	FOR SELECT * FROM Players --Любой курсор создается на основе некоторого оператора SELECT.

OPEN cursor_name -- Для того, чтобы с помощью курсора можно было читать строки, его необходимо открыть.

FETCH NEXT FROM cursor_name	-- извлечь строку

CLOSE cursor_name	-- закрыть курсор

DEALLOCATE cursor_name	-- удалить курсор

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

FETCH NEXT FROM courts_cursor			-- вывести следующий 
FETCH PRIOR FROM courts_cursor			-- вывести предыдущий 
FETCH LAST FROM courts_cursor			-- вывести последнюю запись в выборке
FETCH FIRST FROM courts_cursor			-- вывести первую запись в выборке

-- вывести 2 запись в выборке (зависит от того, что поставили после ABSOLUTE)
FETCH ABSOLUTE 2 FROM courts_cursor		

-- если текщий номер записи равен N, тогда вывести (N + 3) запись (зависит от того, что поставили после RELATIVE)
FETCH RELATIVE 3 FROM courts_cursor		
FETCH RELATIVE -2 FROM courts_cursor

CLOSE courts_cursor

DEALLOCATE courts_cursor

SELECT * FROM Courts

/****************************************************************************
*							STORED PROCEDURE								*
****************************************************************************/

USE pizzeriaDB

-- Названия пользовательских хранимых процедур принято начинать с префикса "sp".
-- Но не рекомендуется использовать префикс "sp_" ,поскольку это префикс используется
-- в системных хранимых процедурах.

CREATE PROCEDURE spGetAllEmployees
AS
	SELECT * FROM Employees
GO

EXECUTE spGetAllEmployees
GO

-- Из процедур нельязя выбиратся и также фиьтровать запросы
--SELECT * FROM EXECUTE spGetAllEmployees		-- Ошибка
--EXEC spGetAllEmployees WHERE Id = 1			-- Ошибка

-- для такого запуска процедуры она должна находится первой командой в пакете,
-- иначе будет ошибка
spGetAllEmployees		

-- Выборки в проуедурах можно записывать в таблицы, но требуется явно указать 
-- все столбцы в которые будет происходить запись
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

-- процедуру можно использовать для инкапсулирования (сокрытия) данных
CREATE PROC spGetPlayers
	@BirthDate date = '19900101'
AS
	-- отключакет вывод сообщений о том, сколько строк было обработано в выборках (внутри процедуры)
	SET NOCOUNT ON

	SELECT p.Id, p.FName, p.LName, pi.Country FROM Players p
			JOIN PlayerInfos pi ON p.Id = pi.PlayerId
			WHERE pi.BirthDate > @BirthDate;
GO

-- параметры в процедуры передаются без круглых скобок
spGetPlayers '19900101'

--wildcard parameters	-	опциональные параметры (параметры имеющие значения по умолчанию)
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

--OUT, OUTPUT	-	выходные параметры
CREATE PROC spGetPlayerRank
	@Id int,
	@Rank int OUT
AS
	SET NOCOUNT ON
	SET @Rank = (SELECT TOP 1 Rank FROM Players
			WHERE Id = @Id);
	
	--RETURN -1		-- через RETURN можно возрвращать только значения типа int
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

-- зачастую процедуры создаются для удобной вствавки/обновления данных в
-- нескольких связанных между собой таблиц
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

-- Пользовательские функции бывают двох видов: скалярыне и табличные.

-- Табличные функции  - это функции, которые в качестве результата своей работы
-- возвращают таблицу (выборку).

-- Скалярные функции - это функции, которые возвращают что угодно, но не таблицу.

-- Названия пользовательских функций принято начинать с префикса "fn".

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

-- Рекомендуется при обращении к функциям (таблицам,...) явно писать название 
-- схем в которых они находятся. Это позволяет серверу быстрее их находить
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

-- Если для опционального параметра нужно подставить значение по умолчанию,
-- то на его позиции в списке параметров обязательно нужно написать DEFAULT
SELECT * FROM fnGetPlayersMatches(DEFAULT);
GO

SELECT * FROM fnGetPlayersMatches('Roland Garros', '20160601', '20160603');
GO

SELECT Court, Winner FROM fnGetPlayersMatches(DEFAULT, '20160601', '20160603');
GO