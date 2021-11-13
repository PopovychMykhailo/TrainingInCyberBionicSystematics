/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson XII  *****      Procedural T-SQL       ************************
*****************************************************************************
****************************************************************************/

--1. Local variables

DECLARE @name varchar(10); 
PRINT ISNULL(@name, 'NULL')
--GO

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