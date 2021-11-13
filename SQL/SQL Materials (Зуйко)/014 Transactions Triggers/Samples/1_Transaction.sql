/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIV *******        TRANSACTIONS         ************************
************************          TRIGGERS           ************************
****************************************************************************/

--1.TRANSACTIONS
--1)
BEGIN TRANSACTION

UPDATE Courts SET Capasity = 4500 WHERE Id = 10

SELECT * FROM Courts

ROLLBACK TRANSACTION

SELECT * FROM Courts

--2)

BEGIN TRAN

UPDATE Courts SET Capasity = 4000 WHERE Id = 10

SELECT * FROM Courts

COMMIT

UPDATE Courts SET Capasity = 5000 WHERE Id = 10

ROLLBACK

SELECT * FROM Courts

--3)
BEGIN TRAN
UPDATE Courts SET City = 'London' WHERE Id = 10

	BEGIN TRAN
	UPDATE Courts SET Capasity = 1000 WHERE Id = 10
	--PRINT @@TRANCOUNT
	--ROLLBACK 
	COMMIT TRAN
--PRINT @@TRANCOUNT
--COMMIT
ROLLBACK
--COMMIT
--PRINT @@TRANCOUNT

--4) SAVE TRAN

BEGIN TRAN
UPDATE Courts SET City = 'London' WHERE Id = 10

SAVE TRAN save1

	BEGIN TRAN
	UPDATE Courts SET Capasity = 1000 WHERE Id = 10

ROLLBACK TRAN save1
COMMIT
COMMIT
SELECT * FROM Courts

--5)
ALTER TABLE PlayerInfos
ADD CONSTRAINT UQ_PlayerInfos_BirthDate UNIQUE (BirthDate)

EXEC spAddPlayer @FName = 'Alexander', @LName = 'Zverev', @BirthDate = '19871007'

DELETE Players WHERE Id = 22

ALTER PROC spAddPlayer
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
BEGIN TRY
	BEGIN TRAN
		INSERT Players VALUES
		(@FName, @LName, @Rank)
	
		SET @Id = @@IDENTITY

		INSERT PlayerInfos VALUES
		(@Id, @BirthDate, @Weight, @Height, @Country, @BirthPlace, @Residence)
	COMMIT
END TRY
BEGIN CATCH
	SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage
	ROLLBACK
END CATCH
GO

