/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson III  *****            SELECT           ************************
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
--3. Нахождение строк, которые должны удовлетвор€ть нескольким условиям
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