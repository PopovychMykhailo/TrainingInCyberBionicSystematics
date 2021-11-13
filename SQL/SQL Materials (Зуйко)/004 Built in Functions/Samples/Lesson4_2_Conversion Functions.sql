/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson IV  ******      Scalar Functions       ************************
****************************************************************************/

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

