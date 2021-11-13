/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
************************ P R A C T I C A L   W O R K ************************
*****************************************************************************
*****  Lesson V  *******       VIEW. PROCEDURE       ************************
****************************************************************************/

USE InternetShopDB
GO

--1. VIEW
--1) Создайте представление, которое показывает ID, название, цвет, описание товара.
CREATE VIEW ProductsDescription
AS
SELECT p.ID, Name, Color, [Description] 
FROM Products p
LEFT JOIN ProductDetails pd
ON p.ID = pd.ID
GO

SELECT * FROM ProductsDescription
GO

--2) Создайте представление, которое показывает ID, название, остаток товара на складе, 
--   количество проданного товара.
CREATE VIEW ProductStatistics
AS
SELECT p.ID, p.Name, s.Qty BalanceQty, 
(SELECT SUM(od.Qty) FROM OrderDetails od 
WHERE od.ProductID = p.ID) SoldQty
FROM Products p
LEFT JOIN Stocks s
ON p.ID = s.ProductID
GO

SELECT * FROM ProductStatistics
GO

--3) Создайте представление, которое показывает ID, ФИО, должность, зарплату, премию,
--   телефон, адресс, дату рождения, семейное положение сотрдуников.
CREATE VIEW EmployessData
AS
SELECT e.ID, e.FName + ' ' + e.MName + ' ' + e.LName Name, 
e.Post, e.Salary, e.PriorSalary, 
ei.Phone, ei.[Address], ei.BirthDate, 
ei.MaritalStatus
FROM Employees e
LEFT JOIN EmployeesInfo ei
ON e.ID = ei.ID
GO

SELECT * FROM EmployessData
GO

--4) Создайте представление, которое показывает ID, ФИО, должность, общую сумму продажи
--   по сотруднику.
CREATE VIEW EmployessStatistics
AS
SELECT e.ID, e.FName + ' ' + e.MName + ' ' + e.LName Name,
e.Post,
(SELECT SUM(TotalPrice) FROM OrderDetails od
JOIN Orders o ON od.OrderID = o.ID 
WHERE o.EmployeeID = e.ID) TotalSold
FROM Employees e
GO

SELECT * FROM EmployessStatistics
GO

--5) Создайте представление, которое показывает продажи по товарам бренда Apple: 
--   название товара, проданное количество, дату продажи, город, из которого купили товар.
CREATE VIEW AppleSales
AS
SELECT p.Name, od.Qty, o.OrderDate, c.City
FROM Products p 
JOIN OrderDetails od
ON od.ProductID = p.ID
JOIN Orders o
ON o.ID = od.OrderID
JOIN Customers c
ON c.ID = o.CustomerID
WHERE p.Name LIKE '%Apple%'
GO

SELECT * FROM AppleSales
GO

--6) В тех случаях, когда нет необходимости сохранять в базе SQL представление, для его
--   замены можно использовать Обобщенное Табличное Выражение.

--   Вывести общую, среднюю сумму заказа, кол-во заказов и общее количество проданного 
--   товара по каждому сотруднику за последний год.

WITH EmpStat AS
(
	SELECT o.ID, FName +' '+ MName +' '+ LName AS Name, 
	OrderDate, 
	SUM(TotalPrice) InvoiceAmount, 
	SUM(Qty) InvoiceQty
	FROM Employees e
	LEFT JOIN Orders o
		ON e.ID = o.EmployeeID
	LEFT JOIN OrderDetails od 
		ON o.ID = od.OrderID
	GROUP BY o.ID, FName, MName, LName, OrderDate

)
SELECT Name, SUM(InvoiceAmount) as TotalSales, 
AVG(InvoiceAmount) as AVGSales, 
COUNT(OrderDate) QtyOrders, 
SUM(InvoiceQty) as TotalQty
FROM EmpStat
WHERE OrderDate BETWEEN  
DATEADD(YEAR, -1, GETDATE()) AND GETDATE() 
OR OrderDate IS NULL
GROUP BY Name

--2. PROCEDURE 
--1) Создайте процедуру, которая позволит найти покупателя по фамилии и/или городу.
--   При этом, если мы не передадим параметров, выведутся все покупатели. Также,
--   мы можем найти всех покупателей, фамилии которых начинаются, например, на Кр
--   (аналигочино и с названием города).
CREATE PROC spSearchCustomers
	@LName nvarchar(20) = '%',
	@City nvarchar(20) = '%'
AS
SET NOCOUNT ON

SELECT c.FName + ' ' + c.MName + ' ' + c.LName Customer, 
o.OrderDate,
p.Name, od.Qty, od.Price
FROM Customers c 
JOIN Orders o
ON c.ID = o.CustomerID AND c.City LIKE @City
JOIN OrderDetails od 
ON o.ID = od.OrderID
JOIN Products p
ON od.ProductID = p.ID
WHERE c.LName LIKE @LName 
GO

EXEC spSearchCustomers 
EXEC spSearchCustomers 'Кр%'
EXEC spSearchCustomers @City = 'Л%'
EXEC spSearchCustomers 'Кр%', 'Л%'
GO

--2) Создайте процедуру, которая позволит найти сотрудника по фамилии и/или должности, 
--   и/или адресу. Функционал поиска должен быть таким же, как и в предыдущей процедуре.
CREATE PROC spSearchEmployees
	@LName nvarchar(20) = '%',
	@Post nvarchar(25) = '%',
	@Address nvarchar(50) = '%'
AS
SET NOCOUNT ON

SELECT e.FName + ' ' + e.MName + ' ' + e.LName Employee, 
e.Post, ei.Phone, ei.[Address], ei.BirthDate
FROM Employees e
JOIN EmployeesInfo ei
ON e.ID = ei.ID AND e.Post LIKE @Post 
AND ei.[Address] LIKE @Address
WHERE e.LName LIKE @LName
GO

EXEC spSearchEmployees
EXEC spSearchEmployees @LName = 'Р%'
EXEC spSearchEmployees 'Р%'
EXEC spSearchEmployees @Post = 'М%'
EXEC spSearchEmployees @Address = '%16%'
EXEC spSearchEmployees @Post = 'М%', @Address = '%16%'
GO;

--3) Создайте процедуру на добаление нового продукта в БД. Процедура должна принимать
--   название товара. Цвет, описание и количество принимаются опционально.
--   Добавьте с помощью процедуры три товара:
--   1 товар - Название: Product1;
--   2 товар - Название: Product2; цвет: Синий; описание: Какое-то описание; кол-во: 5;
--   3 товар - Название: Product3; кол-во: 10.
--   Для демонстрации корректного добавления сделайте выборку по товарам (название, цвет,
--   описание, остаток на складе).
CREATE PROC spAddProduct
	@Name nvarchar(50),
	@Color nchar(20) = NULL,
	@Description nvarchar(max) = NULL,
	@Qty int = 0
AS
SET NOCOUNT ON

DECLARE @Id int

INSERT Products
VALUES
(@Name)

SET @Id = @@IDENTITY

INSERT ProductDetails
VALUES
(@Id, @Color, @Description)

INSERT Stocks
VALUES
(@Id, @Qty)
GO

-- Добавление
EXEC spAddProduct 'Product1'
EXEC spAddProduct 'Product2', 'Синий', 'Какое-то описание', 5 
EXEC spAddProduct 'Product3', @Qty = 10
GO

-- Запрос на выборку
SELECT pd.Name, pd.Color, pd.[Description], 
s.Qty FROM ProductsDescription pd
LEFT JOIN Stocks s ON pd.ID = s.ProductID
GO



