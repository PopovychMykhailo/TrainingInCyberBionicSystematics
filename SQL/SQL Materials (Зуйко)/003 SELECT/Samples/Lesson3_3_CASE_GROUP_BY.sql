/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson III  *****            SELECT           ************************
****************************************************************************/

-- Выражение CASE 
-- 1) простое выражение CASE

SELECT Id, LName, Salary,

CASE
	WHEN Salary >= 8000 THEN 'chief'
	WHEN Salary >= 5000 THEN 'manager'
	WHEN Salary IS NULL THEN 'unknown'
	ELSE 'worker'
END AS Position,

CASE
	WHEN Salary >= 8000 THEN 'chief'
	WHEN Salary >= 5000 THEN 'manager'
	WHEN Salary IS NULL THEN 'unknown'
END AS Position2

FROM Employees 

-- 2) поисковое выражение CASE 
SELECT Id, LName, Department, Salary,

CASE Department										--CASE 
	WHEN 'ADMINISTRATION & SUPPORT' THEN '100%'     --    WHEN Department = 'ADMINISTRATION & SUPPORT' THEN '100%'
	WHEN 'LAW' THEN '80%'							--    ...
	WHEN 'FINANCE & ACCOUNTING' THEN '70%'
	ELSE '10%'
END AS [Bonus%],

Salary/100 *
CASE Department
	WHEN 'ADMINISTRATION & SUPPORT' THEN 100
	WHEN 'LAW' THEN 80
	WHEN 'FINANCE & ACCOUNTING' THEN 70
	ELSE 10
END AS Bonus,

(Salary/100 *
CASE Department
	WHEN 'ADMINISTRATION & SUPPORT' THEN 100
	WHEN 'LAW' THEN 80
	WHEN 'FINANCE & ACCOUNTING' THEN 70
	ELSE 10
END) + Salary AS [Salary & Bonus]

FROM Employees 

-- IIF (начиная с SQL Server 2012)
SELECT Id, LName, Department, Salary,

IIF(Salary >= 6000, 'manager', 'woker') AS Position

-- CASE WHEN Salary >= 6000 THEN 'manager' ELSE 'woker'

FROM Employees 


ALTER TABLE Employees
ADD Gender bit

UPDATE Employees
SET Gender = IIF(Id > 50, 1, 0)

SELECT Id, LName,
IIF (Gender = 0, 'woman', 'man') AS Gender
FROM Employees


-- GROUP BY
SELECT Department, Gender FROM Employees
GROUP BY Department, Gender

SELECT DISTINCT Department, Gender FROM Employees

-- HAVING
SELECT Department FROM Employees
GROUP BY Department
	HAVING Department LIKE 'L%'