/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson XII  *****      Procedural T-SQL       ************************
*****************************************************************************
****************************************************************************/

/****************************************************************************
*								Local variables								*
****************************************************************************/

DECLARE @name varchar(10); 
PRINT ISNULL(@name, 'NULL')

DECLARE @age smallint = 2; 
PRINT @age

--SET
SET @name = 'Elijah';
PRINT @name

--SELECT
--1
SELECT @age = 5;
PRINT @age

--2
SELECT @name = LName FROM GrandSlamDB.dbo.Players 
							WHERE Id = 3
PRINT @name

--3
SELECT @name = LName FROM GrandSlamDB.dbo.Players 
							--WHERE Id = 3
PRINT @name

--4
SELECT @name = LName FROM GrandSlamDB.dbo.Players 
							WHERE Id = 100
PRINT @name

--5
SELECT @name = (SELECT LName FROM GrandSlamDB.dbo.Players 
				WHERE Id = 3)
PRINT @name

--6
SELECT @name = (SELECT LName FROM GrandSlamDB.dbo.Players) 
							--WHERE Id = 3)
PRINT @name

--7
SELECT @name = (SELECT LName FROM GrandSlamDB.dbo.Players 
							WHERE Id = 100)
PRINT ISNULL(@name, 'NULL')


/****************************************************************************
*			Инструкции управлениЯ потоком (control-of-flow statements)		*
****************************************************************************/

--1) Условные конструкции

DECLARE @number int = 18

IF @number >= 18
	PRINT('number is equal to or greater than 18')

SET @number = 5
IF @number >= 18
	PRINT('number is equal to or greater than 18')
ELSE
	PRINT('number is less than 18')

SET @number = 3
IF @number = 1
	PRINT('One')
ELSE IF @number = 2
	PRINT('Two')
ELSE IF @number = 3
	PRINT('Three')
ELSE
	PRINT('number is not equal to 1, 2 or 3')

IF @number >= 18
	PRINT('number is equal to or greater than 18')
ELSE
BEGIN
	PRINT(@number)
	PRINT('number is less than 18')
END

DECLARE @name varchar(20);

IF @name IS NOT NULL
BEGIN
	IF @number >= 18
		PRINT('number is equal to or greater than 18')
	ELSE
		PRINT('number is less than 18')
END

--SWITCH
-- 1) простое выражение CASE
--CASE @number
--	WHEN 1 THEN PRINT('One')
--	WHEN 2 THEN PRINT ('Two')
--	WHEN 3 THEN PRINT ('Three')
--	ELSE PRINT('number is not equal to 1, 2 or 3')
--END

PRINT CASE @number
		WHEN 1 THEN 'One'
		WHEN 2 THEN 'Two'
		WHEN 3 THEN 'Three'
		ELSE 'number is not equal to 1, 2 or 3'
	END

-- IF - EXISTS
USE GrandSlamDB
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Courts'))
BEGIN
    PRINT 'Table Courts already exists'
END
GO

IF OBJECT_ID('Courts') IS NOT NULL
	PRINT 'Table Courts already exists'
GO

--2) Циклические конструкции

DECLARE @counter int = 0

WHILE @counter < 10
BEGIN	
	SET @counter = @counter + 1
	PRINT 'counter: ' + CAST(@counter as varchar)
END

---- CONTINUE
PRINT '--continue--'

SET @counter = 0
WHILE @counter < 10
BEGIN	
	SET @counter = @counter + 1
	
	IF @counter % 2 = 0
		CONTINUE

	PRINT 'counter: ' + CAST(@counter as varchar)
END

---- BREAK
PRINT '--break--'

SET @counter = 0
WHILE @counter < 10
BEGIN	
	SET @counter = @counter + 1
	
	IF @counter = 6
		BREAK

	PRINT 'counter: ' + CAST(@counter as varchar)
END

--3. Обработка ошибок
---- 1) TRY..CATCH
BEGIN TRY
    SELECT 1/0;
    --DROP TABLE NonexistentTable;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber
        ,ERROR_SEVERITY() AS ErrorSeverity
        ,ERROR_STATE() AS ErrorState
        ,ERROR_PROCEDURE() AS ErrorProcedure
        ,ERROR_LINE() AS ErrorLine
        ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

---- 2) RAISERROR
BEGIN TRY
    SELECT 1/0;
END TRY
BEGIN CATCH
   RAISERROR('Деление на ноль', 11, 2);  --message, severity, state 
END CATCH;
GO

BEGIN TRY
    SELECT 1/0;
END TRY
BEGIN CATCH
   RAISERROR('Ошибка %s %d', 11, 2, N'номер', 10);  --message, severity, state 
END CATCH;
GO

---- 3) SEVERITY
BEGIN TRY
    RAISERROR('Деление на ноль', 11, 3);
	PRINT 'TRY'
END TRY
BEGIN CATCH
   PRINT 'CATCH'
END CATCH;
GO

BEGIN TRY	     
    RAISERROR('Деление на ноль', 10, 3);
	PRINT 'TRY'
END TRY
BEGIN CATCH
   PRINT 'CATCH'
END CATCH;
GO

---- 4) THROW
BEGIN TRY
    SELECT 1/0;
END TRY
BEGIN CATCH
   THROW 51000, 'Деление на ноль', 2;  --error number, message, state 
END CATCH;
GO

BEGIN TRY
    THROW 51000, 'Деление на ноль', 2;
END TRY
BEGIN CATCH
   SELECT
        ERROR_NUMBER() AS ErrorNumber
        ,ERROR_SEVERITY() AS ErrorSeverity
        ,ERROR_STATE() AS ErrorState
        ,ERROR_PROCEDURE() AS ErrorProcedure
        ,ERROR_LINE() AS ErrorLine
        ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO