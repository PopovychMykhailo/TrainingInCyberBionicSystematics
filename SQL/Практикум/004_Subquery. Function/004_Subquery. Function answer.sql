/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
************************ P R A C T I C A L   W O R K ************************
*****************************************************************************
*****  Lesson IV  ******      SUBQUERY. FUNCTION     ************************
****************************************************************************/

USE InternetShopDB
GO
   
-- 1) Вывести имена сотрудников, у которых было 4 и более заказов за все время (связанный подзапрос).
SELECT e.FName +' '+ e.LName Employee, COUNT(o.ID) [Count]
FROM Employees e 
	JOIN Orders o
	ON e.ID = o.EmployeeID
GROUP BY e.FName, e.LName
HAVING 4 <= COUNT(o.ID)

SELECT e.FName +' '+ e.LName Employee, (SELECT COUNT(o.ID) FROM Orders o WHERE o.EmployeeID = e.ID) [Count]
FROM Employees e
WHERE  4 <= (SELECT COUNT(o.ID) FROM Orders o WHERE o.EmployeeID = e.ID)

--2) Вывести список покупателей, у которых средняя сумма заказа больше чем среднее значение по всем заказам. 
--!!!!!!!!!!!!!!!!!!!!
SELECT * FROM 
	(SELECT c.ID, 
	c.FName +' '+ c.MName +' '+ c.LName AS Customers, 
	(SELECT AVG(Total) FROM (SELECT SUM(TotalPrice) Total FROM OrderDetails od 
							JOIN Orders o 
							ON od.OrderID = o.ID 
							AND o.CustomerID = c.ID 
							GROUP BY OrderID) inner_table) AS AVGTotalSales,
	(SELECT AVG(Total) FROM (SELECT SUM(TotalPrice) Total FROM OrderDetails 
							GROUP BY OrderID) inner_table) AS AVGTotal_Overall 
	FROM Customers c) cust_sales
WHERE AVGTotalSales > AVGTotal_Overall


--3) Найти разницу суммы покупок по последним двум месяцам.
SELECT 
(SELECT SUM(TotalPrice) FROM Orders 
					JOIN OrderDetails 
					ON ID = OrderID
					WHERE OrderDate >=  DATEADD(month, -1, GETDATE())) as [Последний],
(SELECT SUM(TotalPrice) FROM Orders 
					JOIN OrderDetails 
					ON ID = OrderID
					WHERE OrderDate BETWEEN DATEADD(month, -2, GETDATE()) 
					AND DATEADD(month, -1, GETDATE())) as [Предпоследний],
(SELECT SUM(TotalPrice) FROM Orders 
					JOIN OrderDetails 
					ON ID = OrderID
					WHERE OrderDate >=  DATEADD(month, -1, GETDATE())) -
(SELECT SUM(TotalPrice) FROM Orders 
					JOIN OrderDetails 
					ON ID = OrderID
					WHERE OrderDate BETWEEN DATEADD(month, -2, GETDATE()) 
					AND DATEADD(month, -1, GETDATE())) as [Dfr_SUMM];

--4) Создать функцию нахождения суммы покупки для упрощения запроса.
CREATE FUNCTION fnSumTotalPrice(@DateFrom date, @DateTo date)
RETURNS money
AS
BEGIN
	RETURN
	(
		SELECT SUM(TotalPrice) FROM Orders 
						JOIN OrderDetails 
						ON ID = OrderID
						WHERE OrderDate BETWEEN @DateFrom AND @DateTo
	)
END
GO

-- Запрос
SELECT dbo.fnSumTotalPrice(DATEADD(m, -1, GETDATE()), GETDATE()) as [Последний],
dbo.fnSumTotalPrice(DATEADD(m, -2, GETDATE()), DATEADD(m, -1, GETDATE())) as [Предпоследний],
dbo.fnSumTotalPrice(DATEADD(m, -1, GETDATE()), GETDATE()) -
dbo.fnSumTotalPrice(DATEADD(m, -2, GETDATE()), DATEADD(m, -1, GETDATE())) as [Dfr_SUMM];
GO

--5) Найти разницу по сумме между клиентами, которые сделали заказ самостоятельно и клиентами, 
--   которые воспользовалисть помощью консультанта. 
SELECT
(SELECT SUM (TotalPrice) FROM OrderDetails 
						INNER JOIN Orders ON ID = OrderID
						WHERE EmployeeID IS NULL) as Самостоятельно,
(SELECT SUM (TotalPrice) FROM OrderDetails 
						INNER JOIN Orders ON ID = OrderID
						WHERE EmployeeID IS NOT NULL) as С_помощью, 
(SELECT SUM (TotalPrice) FROM OrderDetails 
						INNER JOIN Orders ON ID = OrderID
						WHERE EmployeeID IS NULL) -
(SELECT SUM (TotalPrice) FROM OrderDetails 
						INNER JOIN Orders ON ID = OrderID
						WHERE EmployeeID IS NOT NULL) as Разница

/* Здесь, также, можно реализовать функцию, которая будет возвращать склееные таблицы и принимать два
   параметра (@DateFrom, @DateTo). Далее, мы сможем подставить функцию в выборку и указать необходимый фильтр.
   Реализуйте данный функционал дома. */

CREATE FUNCTION fnOrdersInfo(@DateFrom date, @DateTo date)
RETURNS table
AS
RETURN
(
	SELECT * FROM Orders 
				JOIN OrderDetails 
				ON ID = OrderID
				WHERE OrderDate BETWEEN @DateFrom AND @DateTo
)
GO

SELECT
(SELECT SUM (TotalPrice) FROM dbo.fnOrdersInfo(DATEADD(YEAR, -1, GETDATE()), GETDATE())
						WHERE EmployeeID IS NULL) as Самостоятельно,
(SELECT SUM (TotalPrice) FROM dbo.fnOrdersInfo(DATEADD(YEAR, -1, GETDATE()), GETDATE())
						WHERE EmployeeID IS NOT NULL) as С_помощью,
(SELECT SUM (TotalPrice) FROM dbo.fnOrdersInfo(DATEADD(YEAR, -1, GETDATE()), GETDATE())
						WHERE EmployeeID IS NULL) -
(SELECT SUM (TotalPrice) FROM dbo.fnOrdersInfo(DATEADD(YEAR, -1, GETDATE()), GETDATE())
						WHERE EmployeeID IS NOT NULL) as Разница
GO

-- Альтернативный вариант - использование представления (см. урок №5), временной таблицы, 
-- обобщенного табличного выражения (msdn.microsoft.com/ru-ru/library/ms175972(v=sql.120).aspx).

-- Представление
CREATE VIEW OrdersInfo
AS
SELECT * FROM Orders 
			JOIN OrderDetails 
			ON ID = OrderID
GO

SELECT
(SELECT SUM (TotalPrice) FROM OrdersInfo
						WHERE EmployeeID IS NULL) as Самостоятельно,
(SELECT SUM (TotalPrice) FROM OrdersInfo
						WHERE EmployeeID IS NOT NULL) as С_помощью,
(SELECT SUM (TotalPrice) FROM OrdersInfo
						WHERE EmployeeID IS NULL) -
(SELECT SUM (TotalPrice) FROM OrdersInfo
						WHERE EmployeeID IS NOT NULL) as Разница
GO

-- Обобщенное табличное выражение
WITH OrdInfo
AS
(
SELECT * FROM Orders 
			JOIN OrderDetails 
			ON ID = OrderID
)
SELECT
(SELECT SUM (TotalPrice) FROM OrdInfo
						WHERE EmployeeID IS NULL) as Самостоятельно,
(SELECT SUM (TotalPrice) FROM OrdInfo
						WHERE EmployeeID IS NOT NULL) as С_помощью,
(SELECT SUM (TotalPrice) FROM OrdInfo
						WHERE EmployeeID IS NULL) -
(SELECT SUM (TotalPrice) FROM OrdInfo
						WHERE EmployeeID IS NOT NULL) as Разница
GO

--6) Создайте функцию, которая будет возвращать таблицу содержащую ID продукта, общее проданное количество продукта,
--   общую сумму и среднюю цену.

CREATE FUNCTION fnProductStatistics()
RETURNS table
AS
RETURN
(
	SELECT ProductID, SUM(Qty) TotalQty, SUM(TotalPrice) TotalPrice, 
	SUM(TotalPrice) / SUM(Qty) AVGPrice
	FROM OrderDetails od1
	GROUP BY ProductID			
)
GO

-- 7) Вывести список нетбуков и их средние цены, средняя стоимость которых превышает среднюю стоимость ноутбука.
--    Логика нахождения средних:
--    так как цена на один и тот же продукт изменяется, необходимо найти среднюю по каждому продукту, а потом по 
--    этим средним вычислять среднюю по группе разных продуктов (в данном случае две группы: Ноутбуки и Нетбуки).

SELECT p.Name, 
(SELECT ps.AVGPrice FROM fnProductStatistics() ps
	WHERE ps.ProductID = p.ID) AVG_Нетбук, 
(SELECT AVG(AVGPrice)  FROM dbo.fnProductStatistics() 
	WHERE ProductID IN (SELECT ID FROM  Products WHERE Name LIKE 'Ноутбук%')) AVG_Ноутбук
FROM Products p
WHERE p.Name LIKE 'Нетбук%' 
AND 
(SELECT ps.AVGPrice FROM fnProductStatistics() ps
		WHERE ps.ProductID = p.ID) > 
(SELECT AVG(AVGPrice) FROM dbo.fnProductStatistics() 
		WHERE ProductID IN (SELECT ID FROM  Products WHERE Name LIKE 'Ноутбук%'))

--8) Найти разницу средней цены ноутбуков и нетбуков, т.e. на сколько в среднем ноутбук стоит дороже, чем нетбук.
SELECT 
(SELECT AVG(AVGPrice) FROM dbo.fnProductStatistics() 
		WHERE ProductID IN 
		(SELECT ID FROM  Products WHERE Name LIKE 'Ноутбук%')) as AVG_Ноутбук,
(SELECT AVG(AVGPrice) FROM dbo.fnProductStatistics() 
		WHERE ProductID IN 
		(SELECT ID FROM  Products WHERE Name LIKE 'Нетбук%')) as AVG_Нетбук,
(SELECT AVG(AVGPrice) FROM dbo.fnProductStatistics() 
		WHERE ProductID IN 
		(SELECT ID FROM  Products WHERE Name LIKE 'Ноутбук%')) -
(SELECT AVG(AVGPrice) FROM dbo.fnProductStatistics() 
		WHERE ProductID IN 
		(SELECT ID FROM  Products WHERE Name LIKE 'Нетбук%')) as Dif_Price;

--9) Вывести минимальную, максимальную, среднюю цены продаж по каждому товару, количество остатков на складе
--   и прогнозируемая выручка (пессимистичный, средний, оптимистчичный прогнозы).

SELECT p.Name, 
(SELECT MIN(od.Price) FROM OrderDetails od WHERE od.ProductID = p.ID) as MINPrice, 
(SELECT MAX(od.Price) FROM OrderDetails od WHERE od.ProductID = p.ID) as MAXPrice, 
(SELECT ps.AVGPrice FROM fnProductStatistics() ps WHERE ps.ProductID = p.ID) as AVGPrice, 
s.Qty, 
(SELECT MIN(od.Price) FROM OrderDetails od WHERE od.ProductID = p.ID) * s.Qty as MIN_Прогноз_Выручка,  
(SELECT MAX(od.Price) FROM OrderDetails od WHERE od.ProductID = p.ID) * s.Qty as MAX_Прогноз_Выручка, 
(SELECT ps.AVGPrice FROM fnProductStatistics() ps WHERE ps.ProductID = p.ID) * s.Qty as AVG_Прогноз_Выручка
FROM Products p
	JOIN Stocks s
	ON p.ID = s.ProductID


