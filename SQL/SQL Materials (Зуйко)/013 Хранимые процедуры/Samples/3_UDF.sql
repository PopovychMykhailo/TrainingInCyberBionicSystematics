/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIII ******       STORED PROCEDURE      ************************
************************    USER DEFINED FUNCTIONS   ************************
****************************************************************************/

--3. USER DEFINED FUNCTIONS

CREATE FUNCTION fnGetPlayerAvgAces (@playerId int)
	RETURNS int
AS
	BEGIN
		DECLARE @avgAces int;
		SET @avgAces = (SELECT AVG(Aces) FROM PlayerStats WHERE PlayerId = @playerId)
		RETURN @avgAces
	END
GO

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

ALTER FUNCTION fnGetPlayersMatches(@TournamentName varchar(50) = '%', @DateFrom date, @DateTo date)
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
		WHERE m1.Date BETWEEN @DateFrom AND @DateTo
	)
GO

SELECT * FROM fnGetPlayersMatches('Roland Garros');
GO

SELECT * FROM fnGetPlayersMatches('Roland Garros', '20160601', '20160603');
GO

SELECT Court, Winner FROM fnGetPlayersMatches(DEFAULT, '20160601', '20160603');
GO