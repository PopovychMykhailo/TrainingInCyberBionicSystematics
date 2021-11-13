/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson IV  ******      Scalar Functions       ************************
****************************************************************************/

--5. Date and Time Functions
----CURRENT_TIMESTAMP и GETDATE
SELECT CURRENT_TIMESTAMP,
	   GETDATE()

USE ITVDNdb
GO
--DATENAME, DATEPART, DAY, MONTH, YEAR
--Ќайти сотрудников, которые радились в декабре
SELECT Id, LName, BirthDate 
FROM Employees
WHERE DATEPART(MONTH, BirthDate) = 12

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