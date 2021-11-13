/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson III  *****            SELECT           ************************
****************************************************************************/

-- DISTINCT - выборка уникальных строк (без дубликатов)
SELECT DISTINCT Department FROM Employees

-- TOP - выборка заданного числа строк
SELECT TOP 10 * FROM Employees

SELECT TOP 25 PERCENT * FROM Employees

-- ORDER BY - сортировка
SELECT * FROM Employees
ORDER BY LName

SELECT * FROM Employees
ORDER BY LName, FName

SELECT * FROM Employees
ORDER BY BirthDate

SELECT * FROM Employees
ORDER BY BirthDate DESC

SELECT * FROM Employees
ORDER BY 7, 3 -- указание номеров столбцов (а не названий)

-- WITH TIES - для включения строк, соответствующих значениям в последней строке
SELECT TOP 30 WITH TIES FName, LName, Salary FROM Employees
ORDER BY Salary DESC

SELECT TOP 30 FName, LName, Salary FROM Employees
ORDER BY Salary DESC


-- SELECT ... INTO ... - сохранить результаты выборки в новой таблице

SELECT EmployeesID, LName, Salary 
INTO EmpSalaries -- или #EmpSalaries (во временную таблицу)
FROM Employees
