/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson XII  *****      Procedural T-SQL       ************************
*****************************************************************************
****************************************************************************/

--2. Инструкции управления потоком (control-of-flow statements)
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