/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIV *******        TRANSACTIONS         ************************
************************          TRIGGERS           ************************
****************************************************************************/

USE GrandSlamDB

/****************************************************************************
*								TRANSACTIONS								*
****************************************************************************/

-- Дополнительно:
--		https://docs.microsoft.com/ru-ru/sql/relational-databases/sql-server-transaction-locking-and-row-versioning-guide?view=sql-server-2017
--		http://professorweb.ru/my/sql-server/2012/level3/3_14.php
--1)

BEGIN TRANSACTION

UPDATE Courts SET Capacity = 4500 WHERE Id = 10

SELECT * FROM Courts

ROLLBACK TRANSACTION

SELECT * FROM Courts

--2)

BEGIN TRAN

UPDATE Courts SET Capacity = 4000 WHERE Id = 10

SELECT * FROM Courts

COMMIT

UPDATE Courts  SET Capacity = 5000 WHERE Id = 10

ROLLBACK	-- Ошибка нету открытой транзакции

SELECT * FROM Courts

--3)
BEGIN TRAN
UPDATE Courts SET City = 'London' WHERE Id = 10

	BEGIN TRAN
	UPDATE Courts SET Capacity = 1000 WHERE Id = 10
	--PRINT @@TRANCOUNT		-- @@TRANCOUNT показывает сколько раз был вызван BEGIN TRAN
	--ROLLBACK		-- при вызове ROLLBACK @@TRANCOUNT принимает значение 0
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
	UPDATE Courts SET Capacity = 1000 WHERE Id = 10

--PRINT @@TRANCOUNT
ROLLBACK TRAN save1		-- не уменьшает значение @@TRANCOUNT
--PRINT @@TRANCOUNT
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

-- рассмотреть скрипты в файлах 014_1_0_Tran.sql и 014_1_1_Tran.sql

/****************************************************************************
*								TRIGGERS									*
****************************************************************************/

--1) FOR / AFTER
CREATE TRIGGER trSomeTrigger
ON Courts
AFTER INSERT, UPDATE, DELETE
AS
	-- если добавления, обновления и удаления не просходит, 
	-- то делать ничего не нужно
	IF @@ROWCOUNT = 0	
		RETURN

	SET NOCOUNT ON

	SELECT * FROM inserted;
	SELECT * FROM deleted;
		
	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
		BEGIN
			IF NOT UPDATE(City)		-- если нужно проверять обновление определённого поля
				RETURN
			PRINT 'UPDATE'		
		END
	ELSE IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
		BEGIN
			PRINT 'INSERT'
		END
	ELSE IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
		BEGIN
			PRINT 'DELETE'
		END
GO

INSERT Courts VALUES
('No. 3 Court', 'NY', 1000, 'Grass'),
('No. 4 Court', 'NY', 900, 'Grass')

UPDATE Courts
SET Capacity = 'London'
WHERE Id IN (11, 12)

UPDATE Courts
SET Capacity = 500
WHERE Id IN (11, 12)

DELETE Courts
WHERE Id IN (11, 12)


--2) INSTEAD OF
CREATE TRIGGER trAllowDeleteCourts
ON Courts
INSTEAD OF DELETE
AS
	IF @@ROWCOUNT = 0
		RETURN

	SET NOCOUNT ON

	IF EXISTS (SELECT 1 FROM deleted 
							WHERE Capasity >= 1000)
		THROW 51000, 'Нельзя удалить корт с вместимостью больше 1000', 11

	ELSE
		DELETE Courts WHERE Id IN (SELECT Id FROM deleted)
GO

DELETE Courts
WHERE Id IN (13, 14)