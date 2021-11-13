/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson V  *******      System Catalog.        ************************
************************    Aggregate functions      ************************
****************************************************************************/

USE ITVDNdb

-- 1. SUM()
SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
GROUP BY ProductId

SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductId

SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
GROUP BY ProductId
HAVING SUM(Qty) >= 10

SELECT ProductId, SUM(Qty) Total_Qty FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductId
HAVING SUM(Qty) >= 10

-- 2. MIN(), MAX()
SELECT ProductId, MIN(Price) MIN_Price, MAX(Price) MAX_Price FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductId

-- 3. AVG()
SELECT ProductId, 
MIN(Price) MIN_Price, 
MAX(Price) MAX_Price,
AVG(Price) AVG_Price
FROM Orders
GROUP BY ProductId

SELECT ProductId, 
MIN(Price) MIN_Price, 
MAX(Price) MAX_Price,
SUM(Price*Qty)/SUM(Qty) AVG_Price
FROM Orders
GROUP BY ProductId

-- 4. COUNT()
SELECT COUNT(*) FROM Orders

SELECT COUNT(City) FROM Orders

SELECT COUNT(DISTINCT City) FROM Orders

SELECT 
COUNT(DISTINCT ProductId) Products,
COUNT(DISTINCT City) Cities
FROM Orders

SELECT City, COUNT(*) Sales FROM Orders
GROUP BY City

SELECT City, COUNT(City) Sales FROM Orders
GROUP BY City

SELECT City, COUNT(City) Sales FROM Orders
WHERE City IS NOT NULL
GROUP BY City

-- Вывести статистику по товарам: в скольких заказаз, в каком кол-ве, 
-- на какую сумму, по какой мин, макс цене, средняя цена
SELECT ProductID,
COUNT(Id), 
SUM(Qty) Total_Qty,
SUM(Price*Qty) Total_Sum,
MIN(Price) MIN_Price, 
MAX(Price) MAX_Price,
SUM(Price*Qty)/SUM(Qty) AVG_Price
FROM Orders
WHERE City IS NOT NULL
GROUP BY ProductID

-- Вывести статистику по продажам: средняя сумма заказа из каждого города
SELECT City,
AVG(Qty * Price) AVG_Sale
FROM Orders
GROUP BY City