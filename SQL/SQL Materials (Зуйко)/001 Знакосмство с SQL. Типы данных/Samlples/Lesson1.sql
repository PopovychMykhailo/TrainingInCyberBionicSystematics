/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson I  *******      INTRO. DATA TYPES      ************************
****************************************************************************/

--		  Однострочный комментарий.

/*
	...   Многострочный комментарий.
*/


--Data Types
----BIT
DECLARE @someBit bit = 0 --объявление и инициализация переменной типа bit 
PRINT @someBit

SET @someBit = 123
PRINT @someBit

----INTEGER
DECLARE @someInt int = 123 --объявление и инициализация переменной типа bit 
PRINT @someInt

SET @someInt = 2147483647 + 1
PRINT @someInt

----DECIMAL (NUMERIC)
DECLARE @someDecimal1 decimal = 123.56 --значения по умолчанию (18, 0) 
PRINT @someDecimal

DECLARE @someDecimal2 decimal(8,5) = 123.56
PRINT @someDecimal2

SET @someDecimal2 = 123.123456 -- округление
PRINT @someDecimal2

SET @someDecimal2 = 1234.56 -- ошибка
PRINT @someDecimal2

----DATE
DECLARE @someDate date = '01-17-2017'
PRINT @someDate

SET @someDate = '20170117'
PRINT @someDate

SET @someDate = '17-01-2017'
PRINT @someDate

----DATETIME
DECLARE @someDateTime datetime = '01-17-2017 03:36:49'
PRINT @someDateTime

SET @someDateTime = '20170117 03:36:49:123'
PRINT @someDateTime

----TIME
DECLARE @someTime time = '03:36:49:1'
PRINT @someTime

SET @someTime = '03:36:49.1234567'
PRINT @someTime

----NCHAR
DECLARE @someNChar nchar(15) = N'какой-то текст'
PRINT @someNChar

----NVARCHAR
DECLARE @someNVarChar nvarchar(15) = N'какой-то текст'
PRINT @someNVarChar

--Arithmetic operators
--Приоритет типов данных https://msdn.microsoft.com/library/ms190309(SQL.130).aspx

---- Оператор + (сложение)

DECLARE @x int = 123, @y int = 456
SELECT @x + @y

DECLARE @date datetime = '20170117 12:00'
SELECT @date + 1.25

SELECT 'Hello, ' + 'world!' --конкатенация

 ---- Оператор - (вычитание)
 ---- Оператор * (умножение)
 ---- Оператор / (деление)

SELECT  10/3,
		17/10,
		10./3,
		10/3.

SELECT 1/0 -- Divide by zero error encountered. 

 ---- Оператор % (остаток от деления)

SELECT  7/5,
		7%5