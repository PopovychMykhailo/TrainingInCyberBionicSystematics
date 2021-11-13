/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson III  *****            SELECT           ************************
****************************************************************************/

USE TEST_DB

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

SELECT ID, LName, Salary 
INTO EmpSalaries -- или #EmpSalaries (во временную таблицу)
FROM Employees

/****************************************************************************
*****************************************************************************
****************************************************************************/

-- WHERE - условие выборки строк

--1. Нахождение строки с помощью простого равенства
SELECT * FROM Employees
WHERE Salary = 10000

SELECT * FROM Employees
WHERE Department = 'sales'

-- Операторы сравнения (=, <> или !=, >, <, >=, <=, !<, !>)
--2. Нахождение строк с использованием оператора сравнения
SELECT * FROM Employees
WHERE BirthDate > '19900101'

SELECT * FROM Employees
WHERE BirthDate !> '19900101'

-- Логические операторы (ALL, AND, ANY, BETWEEN, EXISTS, IN, LIKE, NOT, OR, SOME)
--3. Нахождение строк, которые должны удовлетвор¤ть нескольким условиям
SELECT * FROM Employees
WHERE Department = 'sales' AND Salary >= 6000 
--4. Нахождение строк, удовлетворяющих любому из нескольких условий
SELECT * FROM Employees
WHERE Department = 'sales' OR Department = 'supply'

SELECT * FROM Employees
--WHERE Department = 'sales' OR Department = 'supply' AND Salary >= 6000 -- not correct
WHERE Salary >= 6000 AND (Department = 'sales' OR Department = 'supply')

--5. IN - нахождение строк, находящихся в списке значений
SELECT * FROM Employees
WHERE Department IN ('sales', 'supply', 'law', 'logistics')

SELECT * FROM Employees
WHERE Department NOT IN ('sales', 'supply', 'law', 'logistics') -- см. подзапросы
-- ALL, ANY | SOME, EXISTS - см. подзапросы

--6. BETWEEN - нахождение строк, содержащих значение, расположенное между двумя значениями
SELECT * FROM Employees
WHERE BirthDate > '19900101' AND BirthDate < '19930101'

SELECT * FROM Employees
WHERE BirthDate BETWEEN '19900101' AND '19930101'

--7. -- LIKE - нахождение строк, содержащих значение как часть строки
SELECT * FROM Employees
WHERE Department LIKE 'sales'

-- Wildcard Characters - подстановочные символы (%, _, [], [^])

SELECT * FROM Employees
WHERE Phone LIKE '063%'

SELECT * FROM Employees
WHERE Id LIKE '_2'

SELECT * FROM Employees
WHERE Id LIKE '[2,4]2'

SELECT * FROM Employees
WHERE Id LIKE '[2-5]2'

SELECT * FROM Employees
WHERE Id LIKE '[^2-5]2'

--ESCAPE - самостоятельно
---- Позволяют использовать зарезервированные символы (%, _, ...) в шаблонах

--8. Сравнение с NULL
SELECT * FROM Employees
WHERE Salary IS NULL

SELECT * FROM Employees
WHERE Salary IS NOT NULL

SELECT * FROM Employees
WHERE Salary IN (4000, 7000, NULL) -- NULL не войдет

SELECT * FROM Employees
WHERE Salary IN (4000, 7000) 
OR Salary IS NULL

/****************************************************************************
*****************************************************************************
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