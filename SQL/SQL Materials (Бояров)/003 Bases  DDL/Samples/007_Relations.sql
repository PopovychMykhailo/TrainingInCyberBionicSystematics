-------------------------------------------------------------------------
--                 Связь Один к Одному
-------------------------------------------------------------------------

USE ShopDB 
GO

DROP TABLE Orders;
GO

DROP TABLE Customers;
GO

CREATE TABLE Customers					
(                                      
	CustomerNO int IDENTITY NOT NULL 
		PRIMARY KEY,				  
	CustomerName varchar(25) NOT NULL,
	Address1 varchar(25) NOT NULL,
	City     varchar(15) NOT NULL,
	Contact  varchar(25) NOT NULL,
	Phone char(12)
)
GO

CREATE TABLE Orders
( 
	OrderID int IDENTITY NOT NULL
		PRIMARY KEY,
	CustomerNo int NOT NULL	UNIQUE 
    	FOREIGN KEY REFERENCES Customers(CustomerNo), -- Связь Один к Одному.
	OrderDate date NOT NULL,
	Goods varchar(30) NOT NULL 
)
GO

INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
('Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244');	

INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(1, GETDATE(), 'KeyBoard'),
(2, GETDATE(), 'Mouse');


SELECT CustomerNO, CustomerName, Address1, City FROM Customers;
SELECT * FROM Orders;

INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(2, GETDATE(), 'WebCam'),
(1, GETDATE(), 'Mouse');  -- Ошибка

-------------------------------------------------------------------------
--                 Связь Один ко Многим
-------------------------------------------------------------------------


DROP TABLE Orders;
GO
DROP TABLE Customers;
GO

CREATE TABLE Customers					
(                                      
	CustomerNO int IDENTITY NOT NULL 
		PRIMARY KEY,				  
	CustomerName varchar(25) NOT NULL,
	Address1 varchar(25) NOT NULL,
	City     varchar(15) NOT NULL,
	Contact  varchar(25) NOT NULL,
	Phone char(12)
)
GO

CREATE TABLE Orders
( 
	OrderID int IDENTITY NOT NULL
		PRIMARY KEY,
	CustomerNo int NOT NULL						                        
    	FOREIGN KEY REFERENCES Customers(CustomerNo), -- Связь Один ко Многим.
	OrderDate date NOT NULL,
	Goods varchar(30) NOT NULL 
)
GO

INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
('Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244');	

INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(1, GETDATE(), 'KeyBoard'),
(2, GETDATE(), 'Mouse'),
(2, GETDATE(), 'WebCam'),
(1, GETDATE(), 'Mouse');

SELECT CustomerNO, CustomerName, Address1, City FROM Customers;
SELECT * FROM Orders;

-------------------------------------------------------------------------
--                 Связь Многие ко Многим
-------------------------------------------------------------------------

DROP TABLE Students;
DROP TABLE StudentsCourses;
DROP TABLE Courses;

CREATE TABLE Students				
(                                      
	StudentId int IDENTITY NOT NULL 
		PRIMARY KEY,				  
	FName varchar(50) NOT NULL,
	LName varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Phone varchar(50) NOT NULL
)

CREATE TABLE Courses
( 
	CourseId int IDENTITY NOT NULL
		PRIMARY KEY,
	CourseName varchar(50) NOT NULL,
	Price money Not Null
)


CREATE TABLE StudentsCourses
(
	 StudentId int NOT NULL
		FOREIGN KEY REFERENCES Students(StudentId),
	 CourseId int NOT NULL
		FOREIGN KEY REFERENCES Courses(CourseId),
	 PRIMARY KEY(StudentId, CourseId)
)

INSERT INTO Students																			   
(FName, LName, Email, Phone)
VALUES
('Петр', 'Петренко', 'PetrPetrenko@mail.com', '(093)1231212'),
('Иван', 'Иваненко', 'IvanenkoIvan@mail.com', '(095)2313244'),
('Максим', 'Максимов', 'MaximovMax@mail.com', '(095)7658786');	

INSERT INTO Courses
(CourseName, Price)
VALUES
('SQL Essential', 100.00),
('C# Professional', 200.00),
('ASP.NET MVC', 300.00),
('Patterns GoF', 400.00);

INSERT INTO StudentsCourses
(StudentId, CourseId)
VALUES
(1,1),
(2,1),
(3,3),
(3,1),
(2,2);


SELECT * FROM Students
SELECT * FROM StudentsCourses
SELECT * FROM Courses