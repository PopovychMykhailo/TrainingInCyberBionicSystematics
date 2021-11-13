/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson IV  ******      Scalar Functions       ************************
****************************************************************************/

USE TEST_DB

--GO - информирует об окончании пакета инструкций Transact-SQL.
--GO - это не инструкция Transact-SQL; эта команда распознается редактором SQL Server Management Studio.
--Пакет (batch) - это последовательность инструкций Transact-SQL и процедурных расширений, 
--которые направляются системе базы данных для совместного их выполнения. Преимущество пакета 
--над группой отдельных инструкций состоит в том, что одновременное исполнение всех инструкций 
--позволяет получить значительное улучшение производительности. 

--1. System Functions
--@@ERROR
DECLARE @myint int;  
SET @myint = 'ABC';  
GO

SELECT @@ERROR; 
GO

BEGIN TRY
	DECLARE @myint int;  
	SET @myint = 1/0
END TRY
BEGIN CATCH
	SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage
END CATCH

--@@IDENTITY - возвращает значение последнего вставленного идентификатора
--SCOPE_IDENTITY, IDENT_CURRENT - похожие функции
TRUNCATE  TABLE Students
GO

INSERT Students
VALUES 
('Alex', 'Li', NULL, NULL);  
GO

SELECT * FROM Students
GO

SELECT @@IDENTITY;  
GO  

--@@ROWCOUNT - возвращает число строк, затронутых при выполнении последней инструкции.
UPDATE Students
SET LName = 'Po'
--WHERE Id = 6
GO 

SELECT * FROM Students
GO

SELECT @@ROWCOUNT;  
GO

DELETE Students
GO  
SELECT @@ROWCOUNT;  
GO

-- NEWID - cоздает уникальное значение типа uniqueidentifier. 
DECLARE @myId uniqueidentifier  
SET @myId = NEWID()  
PRINT @myId

-- ISNUMERIC - определяет, имеет ли переданное выражение допустимый числовой тип (int, decimal и др.),
-- возвращает 1, если при оценке входного выражения получается допустимый числовой тип данных, иначе - 0.
SELECT 
	ISNUMERIC('33')
	,ISNUMERIC(17)
	,ISNUMERIC('3abc')
	,ISNUMERIC(@myId)
	,ISNUMERIC('+')
	,ISNUMERIC('$')
	
-- ISNULL - заменяет значение NULL указанным замещающим значением.

SELECT Id, LName, ISNULL(Salary, 0.0) AS Salary
FROM Employees

DECLARE @myInt int;
SELECT 3 + @myInt, 3 + ISNULL(@myInt, 0)

-- COALESCE - принимает список значений и возвращает первое из них, которое не равно NULL.
-- Форма записи: COALESCE(выражение_1, выражение_2, выражение_N)
-- (переписывается оптимизатором запросов в выражение case)

INSERT INTO Students 
(FName, LName, Phone, EMail)
	VALUES
		(N'Александр', N'Македонский', '(012)3456789', 'alex@imperium.com'),
		(N'Диоген', N'Синопский', NULL, 'sinop@pithos.com'),
		(N'Диоген2', N'Синопский', NULL, NULL)

SELECT Id, 
		(FName + ' ' + LName) AS [Name],
		--Concat(FName, ' ', LName) AS [Name],
         COALESCE(Phone, Email, 'не определено') AS Contacts
FROM Students

/**********************************************************************************************************
**********************************************************************************************************/
--2. Conversion Functions
----CAST and CONVERT - преобразуют выражение одного типа данных в другой

SELECT 10/3,
	   10./3,
	   CAST(10 as decimal)/3,
	   CONVERT(decimal, 10)/3

SELECT CONVERT(datetime, '20170101 13:45')

SELECT   
   GETDATE() AS UnconvertedDateTime,  
   CAST(GETDATE() AS nvarchar(30)) AS UsingCast,  
   CONVERT(nvarchar(30), GETDATE(), 126) AS UsingConvertTo_ISO8601  ;  
GO  

--PARSE

--TRY_CAST, TRY_CONVERT, TRY_PARSE - работают как предыдущие, но в случае
--невозможности приведения возвращают NULL

SELECT TRY_CAST('12/31/2016' as date),
	   TRY_CAST('31/12/2016' as date),
	   TRY_CONVERT(date, '12/31/2016'),
	   TRY_CONVERT(date, '31/12/2016')
	   

/**********************************************************************************************************
**********************************************************************************************************/	   
--3. String Functions

----ASCII / UNICODE - возвращает код ASCII / UNICODE первого символа указанного 
--  символьного выражени¤.

SELECT ASCII('hello') [ASCII],
	   UNICODE(N'быть') [UNICODE]

----CHAR / NCHAR - преобразует int код ASCII / UNICODE в символ.

SELECT CHAR(104) [CHAR],
	   NCHAR(1073) [NCHAR]


SELECT LEFT('abcdefg',2) [LEFT],
	   RIGHT('abcdefg',2) [RIGHT],
	   LOWER('ABCDEFG') [LOWER],
	   UPPER('abcdefg') [UPPER],
	   LEN('12345   ') [LEN],
	   REVERSE('12345') [REVERSE]

--STUFF, SUBSTRING
SELECT STUFF('abcdefg', 3, 2, '!!!') [STUFF],
	   SUBSTRING('abcdefg', 3, 2) [SUBSTRING]

PRINT LTRIM('    hello')
PRINT RTRIM('world    ')
PRINT 'Hello,' + SPACE(5) + 'world'
PRINT REPLICATE('&', 7)

SELECT CHARINDEX('Two', 'One Two Three Two Four'),
	   CHARINDEX('Two', 'One Two Three Two Four', 6),
	   PATINDEX('%Th_ee%', 'One Two Three Two Four')

SELECT REPLACE('One Two Three Two Four', 'Two', '2')

SELECT N'јйседора' + ' ' + N'ƒункан',
	   N'јйседора' + ' ' + NULL,
	   N'јйседора' + ' ' + ISNULL(NULL, ''),
	   CONCAT(N'јйседора', ' ', NULL)

--STRING_AGG, STRING_SPLIT - SQL Server 2016
SELECT value
FROM STRING_SPLIT('PRODUCTION & ENGINEERING|SUPPLY|LOGISTICS|
PLANNED-ECONOMIC|QUALITY ASSURANCE & CONTROL|ADMINISTRATION & SUPPORT|
MARKETING|HR MANAGEMENT|SALES|FINANCE & ACCOUNTING|LAW', '|')


/**********************************************************************************************************
**********************************************************************************************************/

--4. Mathematical Functions

SELECT  ABS(-123),
		SQRT(144), 
		SQUARE(12), 
		POWER(2, 8),
		FLOOR (123.4), 
		FLOOR (123.6),
		CEILING (123.4), 
		CEILING (123.6),
		ROUND (123.4, 0), 
		ROUND (123.6, 0),
		ROUND (123.4567, 3), 
		ROUND (123.4567, 3, 1),
		PI() 

--Также есть функции:
----COS: возвращает косинус угла, выраженного в радианах
----SIN: возвращает синус угла, выраженного в радианах
----TAN: возвращает тангенс угла, выраженного в радианах

/**********************************************************************************************************
**********************************************************************************************************/

--5. Date and Time Functions
-- Дополнительно посмотреть: https://metanit.com/sql/sqlserver/8.3.php
----CURRENT_TIMESTAMP и GETDATE
SELECT CURRENT_TIMESTAMP,
	   GETDATE()

USE ITVDN_DB
GO

--DATENAME, DATEPART, DAY, MONTH, YEAR
--Найти сотрудников, которые радились в декабре
SELECT Id, LName, BirthDate 
FROM Employees
WHERE DATEPART(MONTH, BirthDate) = 12

--Для определения части даты можно использовать следующие параметры
--в скобках указаны их сокращенные версии):
----year (yy, yyyy): год
----quarter (qq, q): квартал
----month (mm, m): месяц
----dayofyear (dy, y): день года
----day (dd, d): день месяца
----week (wk, ww): неделя
----weekday (dw): день недели
----hour (hh): час
----minute (mi, n): минута
----second (ss, s): секунда
----millisecond (ms): миллисекунда
----microsecond (mcs): микросекунда
----nanosecond (ns): наносекунда
----tzoffset (tz): смешение в минутах относительно гринвича (для объекта datetimeoffset)

DECLARE @today date = GETDATE()

SELECT DATENAME(yy, @today),
	   DATENAME(MONTH, @today),
	   DATEPART(MONTH, @today),
	   DATEPART(QUARTER, @today),
	   DAY(@today) [DAY],
	   MONTH(@today) [MONTH],
	   YEAR(@today) [YEAR]

--DATEFROMPARTS, DATETIMEFROMPARTS, TIMEFROMPARTS
SELECT DATEFROMPARTS(2017, 05, 17),
	   DATETIMEFROMPARTS(2017, 05, 17, 04, 30, 12, 123),
	   TIMEFROMPARTS(04, 30, 12, 1234567, 7)

SELECT DATEDIFF(MONTH, '20160901', '20161201'),
	   DATEDIFF(MONTH, '20160831', '20161201'),
	   DATEADD(MONTH, -3, GETDATE())

SELECT Id, LName, BirthDate 
FROM Employees
WHERE DATEDIFF(YEAR, BirthDate, GETDATE()) < 30

SELECT Id, LName, BirthDate 
FROM Employees
WHERE BirthDate > DATEADD(YEAR,-30, GETDATE())

/**********************************************************************************************************
**********************************************************************************************************/

--6. Logical Functions
----CHOOSE - возвращает элемент по указанному индексу из списка значений
SELECT Id, LName, BirthDate,
CHOOSE(MONTH(BirthDate), 'Winter','Winter', 'Spring','Spring','Spring','Summer','Summer',   
'Summer','Autumn','Autumn','Autumn','Winter') 
FROM Employees


/**********************************************************************************************************
**********************************************************************************************************/

--7. Metadata Functions
----OBJECT_ID и OBJECT_NAME
IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Cars'))
BEGIN
    CREATE TABLE Cars
	(
		Id int IDENTITY,
		Name varchar(20)
	)
END
GO

SELECT OBJECT_ID('Cars'),
       OBJECT_NAME(OBJECT_ID('Cars'))

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Cars'))
BEGIN
    DROP TABLE Cars
END
GO
