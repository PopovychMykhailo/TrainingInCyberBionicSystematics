/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
************************ P R A C T I C A L   W O R K ************************
*****************************************************************************
*****  Lesson I  *******      DATABASE CREATION      ************************
****************************************************************************/

--1. Создать базу данных интернет магазина InternetShopDB.

CREATE DATABASE InternetShopDB               
COLLATE Cyrillic_General_CI_AS
GO

USE InternetShopDB
GO

--2. Создать в базе данных таблицы согласно рис.2.

/*1) Customers (ID,FName,MName,LName,[Address],City,Phone,DateInSystem)
  2) Employees (ID,FName,MName,LName,Post,Salary,PriorSalary)
  3) EmployeesInfo (ID,MaritalStatus,BirthDate,[Address],Phone) 
  4) Products (ID,Name) 
  5) ProductDetails (ID,Color,[Description])
  6) Stocks (ProductID, Qty)
  7) Orders (ID,CustomerID,EmployeeID,OrderDate)
  8) OrderDetails (OrderID,LineItem,ProductID,Qty,Price,TotalPrice) */

CREATE TABLE Customers
(
	ID int NOT NULL IDENTITY,
	FName nvarchar(20) NULL,
	MName nvarchar(20) NULL,
	LName nvarchar(20) NULL,
	[Address] nvarchar(50) NULL,
	City nvarchar(20) NULL,
	Phone char(12) NULL,
	DateInSystem date DEFAULT GETDATE()
)  
GO

CREATE TABLE Employees
(
	ID int NOT NULL IDENTITY,
	FName nvarchar(20) NOT NULL,
	MName nvarchar(20) NULL,
	LName nvarchar(20) NOT NULL,
	Post  nvarchar(25) NOT NULL,
	Salary money NOT NULL,
	PriorSalary money NULL
)  
GO

CREATE TABLE EmployeesInfo
(                                      
	ID int NOT NULL,  
	MaritalStatus varchar(10) NOT NULL,
	BirthDate date NOT NULL, 
	[Address] nvarchar(50) NOT NULL,
	Phone char(12) NOT NULL
)
GO	

CREATE TABLE Products
(
	ID int NOT NULL IDENTITY,
	Name nvarchar(50) NOT NULL,          
)
GO

CREATE TABLE ProductDetails
(
	ID int NOT NULL,
	Color nchar(20) NULL,
    [Description] nvarchar(max) NULL,     
)
GO

CREATE TABLE Stocks
(
	ProductID int NOT NULL,
	Qty int DEFAULT 0
)
GO

CREATE TABLE Orders
(
	ID int NOT NULL IDENTITY,
	CustomerID int NULL,  
	EmployeeID int NULL,
	OrderDate date DEFAULT GETDATE()
)  
GO

CREATE TABLE OrderDetails
(
	OrderID int NOT NULL,
	LineItem int NOT NULL,
	ProductID int NULL,
	Qty int NOT NULL,
	Price money NOT NULL,
	TotalPrice AS CONVERT(money, Qty*Price) 
)  
GO


--3. Установить связи между таблицами согласно рис.1, необходимо предусмотреть условия ссылочной целостности.

/*1) Customers: ID(PK)
  2) Employees: ID(PK)
  3) EmployeesInfo: ID(UQ,FK)
  4) Products: ID(PK) 
  5) ProductDetails: ID(UQ,FK)
  6) Stocks: ProductID(UQ,FK)
  7) Orders: ID(PK), CustomerID(FK), EmployeeID(FK)
  8) OrderDetails: OrderID,LineItem(PK), OrderID(FK), ProductID(FK) */

--таблица Customers
ALTER TABLE Customers ADD 
	CONSTRAINT PK_Customers PRIMARY KEY(ID) 
GO

--таблица Employees
ALTER TABLE Employees ADD 
	CONSTRAINT PK_Employees PRIMARY KEY(ID) 
GO

--таблица InfoEmployees
ALTER TABLE EmployeesInfo ADD 
	CONSTRAINT UQ_EmployeesInfo UNIQUE(ID)
GO

ALTER TABLE EmployeesInfo ADD 
	CONSTRAINT FK_EmployeesInfo_Employees FOREIGN KEY (ID)
	REFERENCES Employees(ID) 
	ON DELETE CASCADE
GO

--таблица Products
ALTER TABLE Products ADD 
	CONSTRAINT PK_Products PRIMARY KEY (ID) 
GO

--таблица ProductDetails
ALTER TABLE ProductDetails ADD 
	CONSTRAINT UQ_ProductDetails UNIQUE(ID)
GO

ALTER TABLE ProductDetails ADD 
	CONSTRAINT FK_ProductDetails_Products FOREIGN KEY (ID)
	REFERENCES Products(ID) 
	ON DELETE CASCADE
GO

--таблица Stocks
ALTER TABLE Stocks ADD 
	CONSTRAINT UQ_Stocks UNIQUE(ProductID)
GO

ALTER TABLE Stocks ADD 
	CONSTRAINT FK_Stocks_Products FOREIGN KEY (ProductID) 
	REFERENCES Products(ID) 
	ON DELETE CASCADE
GO

--таблица Orders
ALTER TABLE Orders ADD 
	CONSTRAINT PK_Orders PRIMARY KEY (ID) 
GO

ALTER TABLE Orders ADD CONSTRAINT
	FK_Orders_Customers FOREIGN KEY(CustomerID) 
	REFERENCES Customers(ID) 
	ON DELETE SET NULL  
GO

ALTER TABLE Orders ADD CONSTRAINT
	FK_Orders_Employees FOREIGN KEY(EmployeeID) 
	REFERENCES Employees(ID)
	ON DELETE SET NULL  
GO

--таблица OrderDetails
ALTER TABLE OrderDetails ADD CONSTRAINT
	PK_OrderDetails PRIMARY KEY
	(OrderID,LineItem) 
GO

ALTER TABLE OrderDetails ADD CONSTRAINT
	FK_OrderDetails_Orders FOREIGN KEY(OrderID) 
	REFERENCES Orders(ID) 
	ON DELETE CASCADE
GO

ALTER TABLE OrderDetails ADD CONSTRAINT
	FK_OrderDetails_Products FOREIGN KEY(ProductID) 
	REFERENCES Products(ID) 
		ON DELETE SET NULL 
GO

--4. Создать пользовательские ограничений

/*1) Создать ограничение на корректность ввода номера телефона.
  2) Создать ограничение, согласно которому в InternetShopDB могут устраиваться кандидаты в возрасте от 18 до 50 лет.
  3) Создать ограничение, согласно которому заказы могу фиксироватся с дня открытия магазина и до сегодня (день открытия - 90 дней назад).
  4) Создать ограничение на ввод данных в столбец "Семейное положение" (ввод: Женат, Не женат, Замужем, Не замежем).
  5) Создать ограничение, согласно которому клиент может быть зарегистрированным в системе с дня открытия и до сегодня.
  6) Создать ограничение, согласно которому премия не может равняться и быть больше чем зарплата. 
  7) Создать ограничение, согласно которому остаток товара на складе не может быть отрицательным. */

--1)
ALTER TABLE Customers
ADD CONSTRAINT CN_Customers_Phone
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')	 
GO

ALTER TABLE EmployeesInfo
ADD CONSTRAINT CN_EmployeesInfo_Phone
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')	 
GO

--2)
ALTER TABLE EmployeesInfo
ADD CONSTRAINT CN_EmployeesInfo_BirthDate 
CHECK (BirthDate BETWEEN  DATEADD(YEAR, -50, GETDATE()) AND DATEADD(YEAR, -18, GETDATE()))
	
--3)
ALTER TABLE Orders
ADD CONSTRAINT CN_Orders_OrderDate
				 -- DATEADD(DAY, -90, GETDATE()) - вставить данный код вместо константной даты для создания учебной базы
				 --								   (магазин открылся три месяца назад).
CHECK (OrderDate >= DATEADD(DAY, -90, GETDATE()) AND OrderDate <= GETDATE())	 
GO

--4)
ALTER TABLE EmployeesInfo
ADD CONSTRAINT CN_EmployeesInfo_MaritalStatus
CHECK (MaritalStatus IN ('Женат','Не женат', 'Замужем','Не замужем'))	 
GO

--5)
ALTER TABLE Customers
ADD CONSTRAINT CN_Customers_DateInSystem
				    -- DATEADD(DAY, -90, GETDATE()) - вставить данный код вместо константной даты для создания учебной базы
				    --								  (магазин открылся три месяца назад).
CHECK (DateInSystem >= DATEADD(DAY, -90, GETDATE()) AND DateInSystem <= GETDATE())	 
GO

--6)
ALTER TABLE Employees
ADD CONSTRAINT CN_Employees_PriorSalary
CHECK (PriorSalary < Salary)	 
GO

--7)
ALTER TABLE Stocks
ADD CONSTRAINT CN_Stocks_Qty
CHECK (Qty >= 0)	 
GO

-- 5. Наполнить таблицы данными. 
INSERT Customers 
(FName, MName, LName, [Address], City, Phone, DateInSystem)
VALUES
('Виктор','Викторович','Прокопенко','Руденко 21а, 137','Тернополь','(063)4569385',DATEADD(DAY, -85, GETDATE())),
('Антон','Олегович','Крук','Бажова 77','Киев','(093)1416433',DATEADD(DAY, -85, GETDATE())),
('Оксана','Владимировна','Десятова','Бажана 6, 22','Киев','(068)0989367',DATEADD(DAY, -85, GETDATE())),
('Антонина','Дмитриевна','Шевченко','Мышуги 25','Львов','(098)4569111',DATEADD(DAY, -65, GETDATE())),
('Анатолий','Петрович','Дмитров','Дружнова 15','Львов','(068)2229325',DATEADD(DAY, -45, GETDATE())),
('Иван','Иванович','Кобзар','Ковпака 24, 17','Киев','(063)1119311',DATEADD(DAY, -45, GETDATE())),
('Виктор','Олегович','Грачь','Лесная 21','Тернополь','(068)4569344',DATEADD(DAY, -35, GETDATE())),
('Ольга','Алексеевна','Буткова','Дорожная 77, 99','Николаев','(050)4569255',DATEADD(DAY, -25, GETDATE())),
('Алина','Михайловна','Мелова','Контрактна 20','Николаев','(050)4539333',DATEADD(DAY, -15, GETDATE())),
('Михаил','Андреевич','Савицкий','Медовая 1','Киев','(063)9999380',DATEADD(DAY, -5, GETDATE())),
('Артем','Иванович','Крава','Артема 23','Львов','(067)9995558',DATEADD(DAY, -15, GETDATE()));
GO

INSERT Employees
(FName, MName, LName, Post, Salary, PriorSalary)
VALUES
('Анатолий', 'Владимирович', 'Десятов', 'Главный директор', 2000, 300),
('Андрей', 'Антонович', 'Зарицкий', 'Менеджер', 700, 150),
('Олег', 'Артемович', 'Сурков', 'Менеджер по продажам', 500, 50),
('Максим', 'Иванович', 'Рудаков', 'Менеджер по продажам', 500, 50),
('Ирина', 'Михайловна', 'Макар', 'Менеджер', 700, 150),
('Юлия', 'Борисовна', 'Таран', 'Менеджер по продажам', 700, 150);
GO

INSERT EmployeesInfo
(ID, MaritalStatus, BirthDate, [Address], Phone)
VALUES
(1, 'Не женат', '08/15/1970', 'Викторкая 16/7','(067)4564489'),
(2, 'Женат', '09/09/1985', 'Малинская 15','(050)0564585'),
(3, 'Не женат', '12/11/1990', 'Победы 16, 145','(068)4560409'),
(4, 'Не женат', '01/11/1988', 'Антонова 11','(066)4664466'),
(5, 'Замужем', '08/08/1990', 'Руденко 10, 7','(093)4334493'),
(6, 'Замужем', '01/10/1994', 'Просвещения 7','(063)4114141');
GO

INSERT Products
(Name)
VALUES
('Ноутбук Asus D345'),
('Ноутбук HP Pavilion 15-p032er'),
('Ноутбук Dell Inspiron 5555'),
('Нетбук Acer Aspire ES1'),
('Нетбук Lenovo Flex 10'),
('Нетбук Dell Inspiron 3147'),
('Смартфон Samsung Galaxy S6 SS 32GB'),
('Смартфон Apple iPhone 6'),
('Фотоаппарат Canon PowerShot SX400'),
('Телевизор LG 55LB631V');
GO

INSERT ProductDetails
(ID, Color, [Description])
VALUES
(1, 'Черный', 'Экран 14" (1366x768) HD LED, глянцевый / Intel Celeron N2840 (2.16 ГГц) / RAM 2 ГБ / HDD 500 ГБ / Intel HD Graphics / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 2.09 кг'),
(2, 'Серый', 'Экран 15.6" (1366x768) HD LED, глянцевый / AMD Quad-Core A6-6310 (1.8 - 2.4 ГГц) / RAM 4 ГБ / HDD 500 ГБ / AMD Radeon R4 + AMD Radeon R7 M260, 2 ГБ / DVD Super Multi / LAN / Wi-Fi / Bluetooth 4.0 / веб-камера / DOS / 2.44 кг'),
(3, 'Черный', 'Экран 15.6" (1366x768) HD WLED, глянцевый / AMD Quad-Core A6-7310 (2.0 ГГц) / RAM 4 ГБ / HDD 500 ГБ / AMD Radeon R5 M335, 2 ГБ / DVD±RW / LAN / Wi-Fi / Bluetooth / веб-камера / Linux / 2.3 кг'),
(4, 'Черный', 'Экран 11.6'' (1366x768) HD LED, матовый / Intel Celeron N2840 (2.16 ГГц) / RAM 2 ГБ / HDD 500 ГБ / Intel HD Graphics / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / Linpus / 1.29 кг'),
(5, 'Черный', 'Экран 10.1" (1366x768) HD LED, сенсорный, глянцевый / Intel Celeron N2830 (2.16 ГГц) / RAM 2 ГБ / HDD 320 ГБ / Intel HD Graphics / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 8.1 Pro 64bit (Ukrainian language) / Microsoft Office Pro Academic 2013 (Ukrainian language) / 1.2 кг'),
(6, 'Черный', 'Экран 11.6" IPS (1366x768) HD LED, сенсорный, глянцевый / Intel Pentium N3530 (2.16 - 2.58 ГГц) / RAM 4 ГБ / HDD 500 ГБ / Intel HD Graphics / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 8.1 / 1.41 кг'),
(7, 'Белый', 'Экран 5.1" Super AMOLED (2560х1440, сенсорный, емкостный, Multi-Touch) / моноблок / Exynos 7420 (Quad 2.1 ГГц + Quad 1.5 ГГц) / камера 16 Мп + фронтальная 5 Мп / Bluetooth 4.1 / Wi-Fi a/b/g/n/ac / 3 ГБ оперативной памяти / 32 ГБ встроенной памяти / разъем 3.5 мм / LTE / GPS / ГЛОНАСС / OC Android 5.0 / 143.4 x 70.5 x 6.8 мм, 138 г'),
(8, 'Черный', 'Экран: 4.7" IPS LCD (1334x750 точек) с LED-подсветкой / 16 млн. цветов / сенсорный, емкостной / стойкое к царапинам стекло Ion-X Glass с олеофобным покрытиемВстроенная память: 16 ГБ'),
(9, 'Черный', 'Матрица 1/2.3", 16 Мп / Зум: 30х (оптический), 4х (цифровой) / поддержка карт памяти SD, SDHC, SDXC / LCD-дисплей 3" / HD-видео / питание от литий-ионнного аккумулятора / 104.4 x 69.1 x 80.1 мм, 313 г'),
(10, 'Черный', 'Диагональ экрана: 55" Поддержка Smart TV: Есть Разрешение: 1920x1080 Wi-Fi: Да Диапазоны цифрового тюнера: DVB-S2, DVB-C, DVB-T2 Частота развертки панели: 100 Гц Частота обновления: 500 Гц (MCI)');
GO

INSERT Stocks
(ProductID, Qty)
VALUES
(1, 20),
(2, 10),
(3, 7),
(4, 8),
(5, 9),
(6, 5),
(7, 12),
(8, 54),
(9, 8),
(10, 7);
GO

INSERT Orders
(CustomerID, EmployeeID, OrderDate)
VALUES
(1,3, DATEADD(DAY, -85, GETDATE())),
(2,6, DATEADD(DAY, -85, GETDATE())),
(3,4, DATEADD(DAY, -85, GETDATE())),
(3,NULL, DATEADD(DAY, -75, GETDATE())),
(2,3, DATEADD(DAY, -65, GETDATE())),
(4,6, DATEADD(DAY, -65, GETDATE())),
(1,3, DATEADD(DAY, -55, GETDATE())),
(5,3, DATEADD(DAY, -45, GETDATE())),
(6,3, DATEADD(DAY, -45, GETDATE())),
(1,4, DATEADD(DAY, -45, GETDATE())),
(2,NULL, DATEADD(DAY, -45, GETDATE())),
(7,3, DATEADD(DAY, -35, GETDATE())),
(6,4,	 DATEADD(DAY, -35, GETDATE())),
(3,NULL, DATEADD(DAY, -35, GETDATE())),
(5,6, DATEADD(DAY, -35, GETDATE())),
(8,3, DATEADD(DAY, -25, GETDATE())),
(5,4, DATEADD(DAY, -25, GETDATE())),
(7,4, DATEADD(DAY, -25, GETDATE())),
(7,3, DATEADD(DAY, -15, GETDATE())),
(9,3, DATEADD(DAY, -15, GETDATE())),
(8,4, DATEADD(DAY, -15, GETDATE())),
(10,NULL, DATEADD(DAY, -15, GETDATE())),
(11,3, DATEADD(DAY, -5, GETDATE())),
(10,4, DATEADD(DAY, -5, GETDATE()));
GO

INSERT OrderDetails
(OrderID, LineItem, ProductID, Qty, Price)
VALUES
(1,1,1,1,295),
(2,1,2,1,445),
(2,2,6,1,450),
(3,1,4,1,422),
(3,2,9,4,218),
(4,1,7,1,450),
(5,1,9,1,220),
(6,1,8,1,550),
(7,1,8,2,550),
(7,2,9,1,222),
(7,3,5,1,289),
(8,1,3,1,518),
(8,2,9,1,222),
(9,1,6,1,451),
(10,1,10,1,600),
(11,1,7,3,452),
(12,1,7,2,452),
(13,1,9,1,222),
(13,2,8,1,550),
(13,3,7,1,455),
(14,1,9,2,222),
(15,1,3,1,520),
(16,1,4,2,420),
(17,1,10,2,600),
(18,1,10,1,600),
(19,1,7,3,453),
(19,2,8,2,550),
(20,1,5,2,300),
(21,1,4,1,422),
(21,2,5,1,305),
(22,1,1,1,305),
(22,2,2,1,450),
(23,1,1,3,300),
(23,2,2,1,450),
(23,3,3,1,525),
(23,4,4,2,420),
(24,1,6,4,450);
GO

SELECT * FROM Customers
SELECT * FROM Employees
SELECT * FROM Stocks
SELECT * FROM EmployeesInfo
SELECT * FROM Orders
SELECT * FROM Products
SELECT * FROM ProductDetails
SELECT * FROM OrderDetails