/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
************************ P R A C T I C A L   W O R K ************************
*****************************************************************************
*****  Lesson II  ******           TRIGGER           ************************
****************************************************************************/

USE InternetShopDB
GO

--1. ТРИГГЕРЫ
--1) Создайте триггер, который уменьшит остатки товара на складе при добавлении товара в заказ. 
CREATE TRIGGER trMatchingStocksOnInsert
ON OrderDetails
FOR INSERT
AS
    -- Триггер срабатывает при объявлении операции вставки данных в таблицу, при этом кол-во
	-- вставляемых строк может оказаться равным нулю. Например:
	-- INSERT INTO OrderDetails 
	-- SELECT * FROM SomeEmptyTable;
	IF @@ROWCOUNT = 0
		RETURN
    
	-- Отключает вывод сообщений о кол-ве обработанных записей, что положительно влияет на производительность
	SET NOCOUNT ON

	UPDATE Stocks 
    SET Qty = s.Qty - i.Qty
	FROM Stocks s JOIN 
		-- inserted i - такая запись не верна.
		-- Необходимо суммировать кол-во по продуктам, иначе при добавлении одинаковых продуктов
		-- в заказы (т.е. при наличии нескольких записей одного и того же продукта в таблице
		-- inserted) отнимется количество только по первой найденной записи.
		(SELECT ProductID, SUM(Qty) Qty FROM inserted GROUP BY ProductID) i -- так правильно
		ON s.ProductID = i.ProductID;
GO

--2) Создайте триггер, который увеличит остатки товара на складе при удалении товара из заказа.
CREATE TRIGGER trMatchingStocksOnDelete
ON OrderDetails
FOR DELETE
AS
	IF @@ROWCOUNT = 0
		RETURN

	SET NOCOUNT ON

	UPDATE Stocks 
    SET Qty = s.Qty + d.Qty
	FROM Stocks s JOIN 
		(SELECT ProductID, SUM(Qty) Qty FROM deleted GROUP BY ProductID) d
		ON s.ProductID = d.ProductID;
GO
	
--3) Создайте триггер, который изменит остатки товара на складе при изменении количества товара в заказе.
CREATE TRIGGER trMatchingStocksOnUpdate
ON OrderDetails
FOR UPDATE
AS
	IF @@ROWCOUNT = 0
		RETURN

	IF NOT UPDATE(Qty)
		RETURN

	SET NOCOUNT ON

	UPDATE Stocks 
    SET Qty = s.Qty - (i.Qty - d.Qty)
	FROM Stocks s JOIN 
		(SELECT ProductID, SUM(Qty) Qty FROM deleted GROUP BY ProductID) d
		ON s.ProductID = d.ProductID
		JOIN 
		(SELECT ProductID, SUM(Qty) Qty FROM inserted GROUP BY ProductID) i
		ON s.ProductID = i.ProductID;
GO			

--4) Продемонстрируйте работу триггеров.
--   Добавьте два заказа, содержащие по три разных продукта (три продукта в одном заказе, такие же три - в другом).
--   Измените кол-во одного из продуктов в обоих заказах.
--   Удалите созданные ранее два заказа.

-- Остатки до вставки/изменения/удаления (будем менять продукты 8, 9, 10)
SELECT * FROM Stocks WHERE ProductID IN (8, 9, 10)

INSERT Orders
VALUES
(2, null, GETDATE()),
(3, null, GETDATE())
GO

INSERT OrderDetails
VALUES
(25, 1, 8, 4, 301),
(25, 2, 9, 1, 250),
(25, 3, 10, 1, 250),
(26, 1, 8, 10, 250),
(26, 2, 9, 2, 250),
(26, 3, 10, 1, 250)
GO
-- Остатки после добавления продуктов в заказ
SELECT * FROM Stocks WHERE ProductID IN (8, 9, 10)

UPDATE OrderDetails
SET Qty = 5
WHERE OrderID IN (25, 26) AND ProductID = 8
GO
-- Остатки после изменения количества в заказах
SELECT * FROM Stocks WHERE ProductID IN (8, 9, 10)

-- Выйдем из триггера по условию, т.к. обновляем не по полю Qty
UPDATE OrderDetails
SET Price = 100
WHERE OrderID IN (25, 26) AND ProductID = 8
GO

DELETE Orders
WHERE ID IN (25, 26)
GO
-- Остатки после удаления заказов
SELECT * FROM Stocks WHERE ProductID IN (8, 9, 10)

-- Домашнее задание. 
-- Удалите созданные ранее триггеры и создайте один общий триггер, объединяющий функционал удаленных.
CREATE TRIGGER trMatchingStocks
ON OrderDetails
FOR INSERT, DELETE, UPDATE
AS
	IF @@ROWCOUNT = 0
		RETURN

	SET NOCOUNT ON
	-- Используйте SELECT 1 вместо SELECT * для увеличения производительность, т.к. возвращаемые данные
	-- не используются; важен сам факт возврата (true или false).
	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
		BEGIN
			IF NOT UPDATE(Qty)
				RETURN

			UPDATE Stocks 
			SET Qty = s.Qty - (i.Qty - d.Qty)
			FROM Stocks s JOIN 
				(SELECT ProductID, SUM(Qty) Qty FROM deleted GROUP BY ProductID) d
				ON s.ProductID = d.ProductID
				JOIN 
				(SELECT ProductID, SUM(Qty) Qty FROM inserted GROUP BY ProductID) i
				ON s.ProductID = i.ProductID
		END
	ELSE IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
		BEGIN
			UPDATE Stocks 
			SET Qty = s.Qty - i.Qty
			FROM Stocks s JOIN 
				(SELECT ProductID, SUM(Qty) Qty FROM inserted GROUP BY ProductID) i
				ON s.ProductID = i.ProductID
		END
	ELSE IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
		BEGIN
			UPDATE Stocks 
			SET Qty = s.Qty + d.Qty
			FROM Stocks s JOIN 
				(SELECT ProductID, SUM(Qty) Qty FROM deleted GROUP BY ProductID) d
				ON s.ProductID = d.ProductID
		END
GO

-- 5) Создайте триггер, который позволит удалять продукт из таблицы продуктов, только при условии, 
--    что его нет в заказах и остаток на складе нулевой.
CREATE TRIGGER trAllowDeleteProduct
ON Products
INSTEAD OF DELETE
AS
	IF @@ROWCOUNT = 0
		RETURN

	SET NOCOUNT ON

	IF EXISTS (SELECT 1 FROM OrderDetails od
						JOIN deleted d 
						ON od.ProductID = d.ID)
		RAISERROR('Товар не может быть удален т.к. стоит в заказах', 10, 1)

	ELSE IF EXISTS (SELECT 1 FROM Stocks s
						JOIN deleted d
						ON s.ProductID = d.ID
						WHERE s.Qty <> 0)
		RAISERROR('Товар не может быть удален т.к. есть остаток на складе', 10, 2)

	ELSE
		DELETE Products WHERE ID IN (SELECT ID FROM deleted)
GO

-- 6) 
INSERT Products
VALUES
('Планшет Apple iPad A1566'),
('Планшет Microsoft Surface RT')
GO

INSERT Stocks
VALUES
(11, 2),
(12, 0)
GO

DELETE FROM Products
WHERE ID = 1

DELETE FROM Products
WHERE ID = 11

DELETE FROM Products
WHERE ID = 12

SELECT * FROM Products

--1. ПРОСТЫЕ ЗАПРОСЫ.
--1) Вывести все заказы, которые были сделаны за последние два месяца.
-- Вариант 1
SELECT * FROM Orders
WHERE  OrderDate >= DATEADD(MONTH, -2, GETDATE()) 
-- Вариант 2
SELECT * FROM Orders 
WHERE  OrderDate BETWEEN DATEADD(MONTH, -2, GETDATE()) AND GETDATE()
-- Вариант 3
SELECT * FROM Orders
WHERE  DATEDIFF(DAY, OrderDate, GETDATE()) <= 60

--2) Вывести все товары, которые есть в InternetShopDB под маркой "Dell".
SELECT * FROM Products
WHERE Name LIKE '%Dell%'

--3) Вывести список всех ноутбуков и нетбуков.
SELECT * FROM Products 
WHERE Name LIKE 'Ноутбук%' OR Name LIKE 'Нетбук%'

--4) Вывести всех сотрудников, у которых премия больше чем 10% от з/п.
SELECT * FROM Employees
WHERE Salary/10 < PriorSalary

--5) Вывести список клиентов которые проживают в городе Киеве или Львове.
SELECT FName +' '+ MName +' '+ LName  AS Customer, City FROM Customers
WHERE City IN ('Киев','Львов')

--6) Вывести перечень имеющихся в магазине должностей.
SELECT DISTINCT Post FROM Employees