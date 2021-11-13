/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIII ******       STORED PROCEDURE      ************************
************************    USER DEFINED FUNCTIONS   ************************
****************************************************************************/

--2. STORED PROCEDURE

CREATE PROCEDURE spGetAllEmployees
AS
	SELECT * FROM Employees
GO

EXECUTE spGetAllEmployees
GO
--SELECT * FROM EXECUTE spGetAllEmployees

--EXEC spGetAllEmployees WHERE Id = 1

spGetAllEmployees

INSERT INTO Employees
EXEC spGetAllEmployees

ALTER PROC spGetAllEmployees
AS
	SELECT * FROM Employees
	SELECT * FROM Customers
GO

USE GrandSlamDB
GO

--parameters
ALTER PROC spGetPlayers
	@BirthDate date = '19900101'
AS
	SET NOCOUNT ON
	SELECT p.Id, p.FName, p.LName, pi.Country FROM Players p
			JOIN PlayerInfos pi ON p.Id = pi.PlayerId
			WHERE pi.BirthDate > @BirthDate;
GO

spGetPlayers '19900101'

--wildcard parameters
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

--OUT, OUTPUT
ALTER PROC spGetPlayerRank
	@Id int,
	@Rank int OUT
AS
	SET NOCOUNT ON
	SET @Rank = (SELECT TOP 1 Rank FROM Players
			WHERE Id = @Id);
	
	--RETURN -1
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