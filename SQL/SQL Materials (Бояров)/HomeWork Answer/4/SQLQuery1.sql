--********************************************************************************
--                            Дополнительное задание.
--********************************************************************************
/*Спроектировать базу данных для вымышленной системы 
отдела кадров, провести нормализацию всех таблиц*/

CREATE DATABASE HomeWork1
ON							  -- Задаем параметры Базы Данных.
(
	NAME = 'HomeWork1',				-- Указываем логическое имя БД (используется при обращении к БД).
	FILENAME = 'D:\HomeWork1.mdf',	-- Указываем Физическое полное имя файла БД.
	SIZE = 5MB,                    -- Задаем начальный размер файла БД.
	MAXSIZE = 30MB,				-- Задаем максимальный размер файла БД.
	FILEGROWTH = 5MB				-- Задаем значение, на которое будет увеличиваться размер файла БД.
)
LOG ON						  -- Задаем параметры журнала Базы Данных.
( 
	NAME = 'LogHomeWork1',		       -- Указываем логическое имя журнала БД (используется при обращении к журналу БД).
	FILENAME = 'X:\HomeWork1.ldf',      -- Указываем Физическое полное имя файла журнала БД.
	SIZE = 5MB,                        -- Задаем начальный размер файла журнала БД.
	MAXSIZE = 30MB,                    -- Задаем максимальный размер файла журнала БД.
	FILEGROWTH = 5MB                   -- Задаем значение, на которое будет увеличиваться размер файла журнала БД.
)               
COLLATE Cyrillic_General_CI_AS -- Задаем кодировку для базы данных по умолчанию

USE HomeWork1
GO


CREATE TABLE Info
(
    EmployeesID int IDENTITY NOT NULL 
    PRIMARY KEY,
	Name varchar(60) NOT NULL,
	Post varchar(70) NOT NULL,
	Info varchar(60) NOT NULL,
	History varchar(60) NOT NULL
)
GO

INSERT INTO Info
VALUES
('Главный директор $1000','Андреев А. В. (093)9831282 andreev44@mail.ru', 'Не женат Киев 08/15/1975', 'Менеджер 2 г. Google'),
('Главный директор $1000','Андреев А. В. (093)9831282 andreev44@mail.ru', 'Не женат Киев 08/15/1975', 'Менеджер 5 г. Microsoft'),
('Менеджер $500 ','Бойко M. К. (067)9831311 boyko_M_K@gmail.ru', 'Женат Львов 01/01/1990', 'Нет'),
('Рабочий $200 ', 'Гусев О. А. (098)9831411 gus@mail.ru', 'Не женат Киев 03/11/1985', 'Менеджер 3 г. ASUS'),
('Менеджер $400 ', 'Кравец Н. Н. (097)9811182 krava@ukr.net','Не женат Херсон 05/10/1977', '5 м. HP'),
('Рабочий $250  ','Тарасенко В. О. (063)1491352 tarasenko_v@ukr.net','Женат Полтава 02/04/1991', 'Нет');


SELECT * FROM Info
--Нормализация

/*Первая нормальная форма(1NF)–отсутствие повторяющихся данных,
любое поле любой записи хранит только одно значение.*/

/*Вторая нормальная форма(2NF)–требует предварительного приведения 
исходной таблицы к первой НФ, а также каждый не ключевой столбец таблицы 
находящейся в 1НФ,должен зависеть от всего ключа.*/

/*Третья нормальная форма(3NF)–требует предварительного приведения исходной 
таблицы ко второй НФ,а так же ни в одном не ключевом столбце не может быть
зависимости от другого не ключевого столбца.Так же не допускается наличие 
в таблице производных данных.*/


/*
1)Разделить записи в столбце Name Post, Info и History
2)Вынести столбцы Name, Post, Info и History в одельные таблицы 	
3)Создать каталог должностей
4)Связать все таблицы 
*/

 --Создание таблицы должности.
 CREATE TABLE Post
(                                      
	PostID int IDENTITY NOT NULL 
    PRIMARY KEY,
	Post varchar(25) NOT NULL,				  
)
GO	

 --Создание таблицы сотрудники.
 CREATE TABLE Employees
(                                      
	EmployeesID int IDENTITY NOT NULL 
    PRIMARY KEY,
	Name varchar(25) NOT NULL,				  
	Phone char(12) Not NULL,
	Contact varchar(30) NOT NULL,
	Salary money NOT NULL,
	PostID int NOT NULL 					                        
    FOREIGN KEY REFERENCES Post(PostID)
)
GO	
 --Создание таблицы информация.  

CREATE TABLE InfoEmployees
(                                      
	InfoEmployeesID int IDENTITY NOT NULL 
    PRIMARY KEY
    FOREIGN KEY REFERENCES Employees(EmployeesID),				  
	MaritalStatus varchar(25) NOT NULL,
	BirthDate date NOT NULL, 
	Locations Varchar (30) NOT NULL
)
GO	

-- Создание таблицы трудовая история.
CREATE TABLE WorkHistory
(                                      
	WorkHistoryID int IDENTITY NOT NULL ,				  
	PostID int NOT NULL						                        
    FOREIGN KEY REFERENCES Post(PostID),
	Experience varchar(25) NOT NULL, 
	Company Varchar (30) NOT NULL,
	EmployeesID int NOT NULL						                        
    FOREIGN KEY REFERENCES Employees(EmployeesID),
	PRIMARY KEY (WorkHistoryID, EmployeesID)
)
GO	

--Вставка данных в таблицы

INSERT INTO Post																			   
VALUES
('Главный директор'),
('Менеджер'),
('Рабочий');
GO

INSERT INTO Employees																			   
(Name, Phone, Contact, Salary, PostID)
VALUES
('Андреев А. В.','(093)9831282','andreev44@mail.ru','$1000',1 ),
('Бойко M. К.','(067)9831311','boyko_M_K@gmail.ru','$500',2),
('Гусев О. А.','(098)9831411','gus@mail.ru','$200',3),
('Кравец Н. Н.','(097)9811182','krava@ukr.net','$400',2),
('Тарасенко В. О.', '(063)1491352','tarasenko_v@ukr.net','$250',3);
GO


INSERT INTO InfoEmployees																			   
(MaritalStatus, Locations, BirthDate)
VALUES
('Не женат','Киев', '08/15/1975'),
('Женат','Львов',   '01/01/1990'),
('Не женат','Киев', '03/11/1985'),
('Не женат','Херсон','05/10/1977'),
('Женат','Полтава', '02/04/1991');
GO

INSERT INTO WorkHistory																			   
(PostID, Experience, Company, EmployeesID)
VALUES
(2,'2 г.', 'Google', 1),
(2,'5 г.', 'Microsoft', 1),
(2,'3 г.', 'ASUS', 3),
(3,'5 м.','HP', 4);

GO

SELECT * FROM Info 
Select * From Post
Select * From Employees
Select * From InfoEmployees
Select * From WorkHistory

SELECT P.Post, Salary, Name, Phone, Contact, MaritalStatus, Locations, BirthDate, W.PostID, Experience, Company
FROM Post P INNER JOIN Employees E ON P.PostID = E.PostID
INNER JOIN InfoEmployees I ON E.EmployeesID = I.InfoEmployeesID
INNER JOIN WorkHistory W ON E.EmployeesID = W.EmployeesID


Select * From Info
--********************************************************************************
--                            Создание Базы Данных (Задание №2).
--********************************************************************************

/*Создайте базу данных максимальной размерностью 100 МБ, 
предполагается что будет использоваться около 30 МБ. 
Введите все необходимые настройки. Журнал транзакций 
должен быть расположен на другом физическом диске (если такой имеется).*/


CREATE DATABASE HomeWork4 
ON							  -- Задаем параметры Базы Данных.
(
	NAME = 'HomeWork4 ',				-- Указываем логическое имя БД (используется при обращении к БД).
	FILENAME = 'D:\HomeWork4 .mdf',	-- Указываем Физическое полное имя файла БД.
	SIZE = 30MB,                    -- Задаем начальный размер файла БД.
	MAXSIZE = 100MB,				-- Задаем максимальный размер файла БД.
	FILEGROWTH = 10MB				-- Задаем значение, на которое будет увеличиваться размер файла БД.
)
LOG ON						  -- Задаем параметры журнала Базы Данных.
( 
	NAME = 'LogHomeWork4 ',		       -- Указываем логическое имя журнала БД (используется при обращении к журналу БД).
	FILENAME = 'X:\HomeWork4 .ldf',      -- Указываем Физическое полное имя файла журнала БД.
	SIZE = 5MB,                        -- Задаем начальный размер файла журнала БД.
	MAXSIZE = 50MB,                    -- Задаем максимальный размер файла журнала БД.
	FILEGROWTH = 5MB                   -- Задаем значение, на которое будет увеличиваться размер файла журнала БД.
)               
COLLATE Cyrillic_General_CI_AS -- Задаем кодировку для базы данных по умолчанию



--********************************************************************************
--                  Создание Таблицы в Базе Данных MyDB.
--********************************************************************************

USE HomeWork4               
GO   

----------------------------------------------------------------------------------
/*Нормализируйте данную таблицу:  */

CREATE TABLE Info
(                                      
	InfoID int IDENTITY NOT NULL 
    PRIMARY KEY,				  
	Name varchar(35) NOT NULL, --фамилия
	Platoon varchar(25) NOT NULL, --взвод
	Weapons varchar(15) NOT NULL, --оружие
	GiveRank  varchar(35) NOT NULL, --оружие выдал
)
GO		

--Вставка данных

INSERT INTO Info																			   
VALUES
('Петров В.А.,оф.205', '222', 'АК-47', 'Буров О. С., майор'),
('Петров В.А.,оф.205', '222', 'Глок20', 'Рыбаков Н.Г., майор'),
('Лодарев П.С.,оф.221', '232', 'АК-74', 'Деребанов В.Я., подполковник'),
('Лодарев П.С.,оф.221', '232', 'Глок20', 'Рыбаков Н.Г.,майор'),
('Леонтьев К.В.,оф.201', '212', 'АК-47', 'Буров О. С., майор'),
('Леонтьев К.В.,оф.201', '212', 'Глок20', 'Рыбаков Н. Г., майор'),
('Духов Р.М.', '200', 'АК-47', 'Буров О. С., майор');


SELECT * FROM Info

/*Первая нормальная форма(1NF)–отсутствие повторяющихся данных,
любое поле любой записи хранит только одно значение.*/

/*Вторая нормальная форма(2NF)–требует предварительного приведения 
исходной таблицы к первойНФ, а также каждый не ключевой столбец таблицы 
находящейся в 1НФ,должен зависеть от всегоключа.*/

/*Третья нормальная форма(3NF)–требует предварительног оприведения исходной 
таблицы ко второй НФ,а так же ни в одном не ключевом столбце не может быть
зависимости от другого не ключевого столбца.Так же не допускается наличие 
в таблице производных данных.*/

/*
1)Разделить записи в столбце Name и столбце GiveRank
2)Вынести столбцы GiveRank и Weapons в одельную таблицу 	
3)Создать каталог оружия 
4)Связать все таблицы 
*/

--Нормализация
--Создание талицы "Получатель оружия"
CREATE TABLE ArmoryCustomer
(
	ArmoryCustomerID int IDENTITY NOT NULL
	PRIMARY KEY,
	Name varchar(20) NOT NULL,
	[Off] varchar(10) NULL,
	Platoon int NOT NULL
)
GO

--Создание таблицы "Выдает оружие"
CREATE TABLE ArmoryProvider
(
	ArmoryProviderID int IDENTITY NOT NULL 
	PRIMARY KEY,
	Name Varchar(20) NOT NULL,
	[Rank] Varchar(20) NOT NULL
)
GO

--Создание таблицы "Оружие"
 CREATE TABLE Weapons
 (
	WeaponsId smallint IDENTITY NOT NULL 
	PRIMARY KEY,
	Name Varchar(20) NOT NULL,
 )
 GO

 --Создание таблицы "Получает"
 CREATE TABLE Give
(
	GiveId int IDENTITY NOT NULL
	PRIMARY KEY,
	ArmoryCustomerID int NOT NULL FOREIGN KEY 
	REFERENCES ArmoryCustomer(ArmoryCustomerID),
	ArmoryProviderID int NOT NULL FOREIGN KEY 
	REFERENCES ArmoryProvider(ArmoryProviderID),
	WeaponsId smallint NOT NULL FOREIGN KEY 
	REFERENCES Weapons(WeaponsId)
)
GO 


INSERT INTO ArmoryCustomer  
VALUES
('Петров В.А.', 205, 222), 
('Лодарев П.С.' , 221, 232),
('Леонтьев К.В.', 201, 212),
('Духов Р.М', NULL, 200)
GO



INSERT INTO ArmoryProvider  
VALUES
('Буров О.С.', 'майор'), 
('Рыбаков Н.Г.' , 'майор'),
('Деребанов В.Я.', 'подполковник')
GO

INSERT INTO Weapons  
VALUES
('АК-47'), 
('Глок20'),
('АК-74')

INSERT INTO Give 
VALUES
(1,  1, 1), 
(1,  2, 2),
(2,  3, 3),
(2,  2, 2),
(3,  1, 1),
(3,  2, 2),
(4,  1, 1)
GO
SELECT * FROM Info
SELECT * FROM ArmoryCustomer
SELECT * FROM ArmoryProvider
SELECT * FROM Weapons
SELECT * FROM Give 

SELECT AC.Name, AC.[Off], AC.Platoon,
W.Name, AP.Name, AP.[Rank]
FROM 
ArmoryCustomer AC INNER JOIN Give G ON AC.ArmoryCustomerID = G.ArmoryCustomerID
INNER JOIN ArmoryProvider AP ON G.ArmoryProviderID = AP.ArmoryProviderID
INNER JOIN Weapons W ON G.WeaponsID = W.WeaponsID

SELECT * FROM Info