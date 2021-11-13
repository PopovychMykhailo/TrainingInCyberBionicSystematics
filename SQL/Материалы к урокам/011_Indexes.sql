/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****   Lesson XI  *****           INDEXES           ************************
*****************************************************************************
****************************************************************************/

-- ƒополнительно: https://habr.com/ru/post/247373/

-- »ндексы Ц это специальные таблицы, которые могут быть использованы поисковым 
-- двигателем базы данных (далее Ц Ѕƒ), дл€ ускорени€ получени€ данных. Ќеобходимо 
-- просто добавить указатель индекса в таблицу. »ндекс в Ѕƒ крайне схож с индексом 
-- в конце книги.
 
-- ƒопустим, мы хотим иметь ссылку на все страницы книги, которые касаютс€ определЄнной
-- темы (например, Ќаследование в книге по программированию на €зыке Java). ƒл€ этого,
-- мы в первую очередь ссылаемс€ на индекс, который указан в конце книге и переходим 
-- на любую из страниц, котора€ относитс€ к необходимой теме.
 
-- »ндекс помогает ускорить запросы на получение данных (SELECT [WHERE]) , но 
-- замедл€ет процесс добавлени€ и изменени€ записей (INSERT, UPDATE). »ндексы могут
-- быть добавлены или удалены без вли€ни€ на сами данные.

CREATE DATABASE Les11_Indexes
GO

USE Les11_Indexes
GO

CREATE TABLE [Persons] (
    [Id] INTEGER NOT NULL IDENTITY(1, 1),
    [ZipCode] VARCHAR(255) NULL,
    [Date] Date,
    [Name] VARCHAR(255) NOT NULL
);
GO

INSERT INTO Persons
	([ZipCode],[Date],[Name]) 
VALUES
('12178','20170707','Church'),('07670','20170807','Ward'),('21908','20180410','Hampton'),('22636','20170728','Navarro'),
('02781','20170823','Hunter'),('46232','20180525','Walsh'),('58558','20180219','Hall'),('55412','20180212','Deleon'),
('64394','20171117','Mullen'),('79709','20170818','Chase'),('45904','20161221','Cooley'),('87582','20161005','Justice'),
('26407','20170910','Pierce'),('70052','20171112','Schwartz'),('05957','20161016','Zamora'),('39214','20180610','Brock'),
('02018','20161006','Myers'),('39519','20171231','Medina'),('70213','20161030','Page'),('82807','20170202','Gomez'),
('59242','20160620','Jenkins'),('31116','20180520','Cline'),('48341','20180310','Acevedo'),('54376','20171007','Bond'),
('36595','20170520','Wagner'),('69030','20170705','Hendrix'),('52512','20160616','Price'),('78756','20161004','Byrd'),
('88809','20160823','Warren'),('12779','20170108','Alston'),('59417','20161226','Lawson'),('41805','20170209','Emerson'),
('31080','20170126','Wilson'),('69389','20170131','Duran'),('57736','20160619','Stevens'),('20911','20170707','Rush'),
('83244','20180305','Estes'),('20541','20160828','Cox'),('06462','20171128','Wyatt'),('95329','20170516','Tate'),
('43728','20161225','Small'),('19481','20161223','Silva'),('78677','20160714','Morgan'),('60937','20171215','Mason'),
('08887','20160711','Parrish'),('37424','20170209','Mcknight'),('56651','20180314','Yang'),('29859','20171205','Estrada'),
('95634','20161115','Woods'),('55431','20160925','Sampson'),('05890','20161008','Velez'),('97120','20180118','Cole'),
('52852','20161122','Chan'),('79090','20171112','Trevino'),('72797','20170925','Graham'),('37104','20160713','Mcconnell'),
('61346','20180527','Green'),('43332','20170404','Trujillo'),('91953','20170424','Duffy'),('72573','20171025','Bartlett'),
('76043','20171022','Lang'),('86888','20170528','Tate'),('20185','20171202','Love'),('11323','20170624','Hoover'),
('54490','20170724','Whitaker'),('42488','20160710','Clayton'),('42637','20180601','Ferguson'),('15513','20170519','Mckay'),
('00149','20170622','Ray'),('10656','20170307','Myers'),('06868','20180305','Yang'),('59662','20171228','Henson'),
('03949','20161220','Combs'),('88043','20180614','Yang'),('75226','20161202','Perry'),('16345','20170206','Scott'),
('07576','20171024','Oconnor'),('04299','20171223','Kane'),('58464','20170817','Pena'),('54117','20160720','Forbes'),
('90642','20170206','Mayer'),('98529','20160623','George'),('36289','20170204','Griffin'),('57003','20160908','Kennedy'),
('84049','20170703','Ratliff'),('19067','20171229','Chan'),('63521','20170125','Kelly'),('47949','20180207','Payne'),
('69779','20180603','Ware'),('05436','20171204','Adams'),('36465','20170117','Guy'),('47285','20180406','Dyer'),
('47518','20161020','Stewart'),('35266','20170628','Mendoza'),('88166','20180408','Merritt'),('93134','20180508','Wade'),
('72041','20170807','Robinson'),('79153','20170508','Barton'),('29999','20161010','Buck'),('88813','20160805','Holman')
GO

SELECT * FROM Persons
WHERE Name = 'Jenkins'

-- ѕолна€ форма создани€ и настройки индекса:

-- CREATE [UNIQUE] [CLUSTERED | NONCLUSTERED] INDEX index_name
--     ON table_name (column1 [ASC | DESC] ,...)
--         [ INCLUDE ( column_name [ ,... ] ) ]     
-- [WITH
--     [FILLFACTOR=n]
--     [[, ] PAD_INDEX = {ON | OFF}]
--     [[, ] DROP_EXISTING = {ON | OFF}]
--     [[, ] SORT_IN_TEMPDB = {ON | OFF}]
--     [[, ] IGNORE_DUP_KEY = {ON | OFF}]
--     [[, ] ALLOW_ROW_LOCKS = {ON | OFF}]
--     [[, ] ALLOW_PAGE_LOCKS = {ON | OFF}]
--     [[, ] STATISTICS_NORECOMPUTE = {ON | OFF}]
--     [[, ] ONLINE = {ON | OFF}]]
--     [ON file_group | "default"]

-- про настройки можно прочитать здесь: http://professorweb.ru/my/sql-server/2012/level3/3_5.php

CREATE CLUSTERED INDEX IX_CL_Persons_Name
	ON Persons([Name])
GO

DROP INDEX IX_CL_Persons_Name
	ON Persons
GO

CREATE INDEX IX_CL_Persons_Name
	ON Persons([Name])
GO

CREATE UNIQUE CLUSTERED INDEX IX_CL_Persons_Id
	ON Persons(Id)
GO

SET STATISTICS TIME ON			-- включает замеры по времени
GO

-- созадание test_table с 300 000 запис€ми
/*
CREATE TABLE test_table (
  id INT,
  rand_integer INT,
  rand_datetime DATETIME,
  rand_string VARCHAR(20)
);
GO

DECLARE @row INT;
DECLARE @string VARCHAR(20), @length INT, @code INT;
SET @row = 0;
WHILE @row < 300000 BEGIN
   SET @row = @row + 1;

   SET @length = ROUND(20*RAND(),0);
   SET @string = '';
   WHILE @length > 0 BEGIN
      SET @length = @length - 1;
      SET @code = ROUND(32*RAND(),0) - 6;
      IF @code BETWEEN 1 AND 26 
         SET @string = @string + CHAR(ASCII('a')+@code-1);
      ELSE
         SET @string = @string + ' ';
   END 

   SET NOCOUNT ON;
   INSERT INTO test_table VALUES (
      @row,
      ROUND(2000000*RAND()-1000000,0),
      CONVERT(DATETIME, ROUND(60000*RAND()-30000,9)),
      @string
   )
END
PRINT 'Rows inserted: '+CONVERT(VARCHAR(20),@row);
GO
*/

SELECT Count(*) FROM test_table

SELECT * FROM test_table
WHERE /*rand_integer = -533469 AND*/ rand_string = 'k  ttf levbbjtl  sv'


CREATE CLUSTERED INDEX IX_CL_rand_integer
ON test_table(rand_integer)
GO

DROP INDEX IX_CL_rand_integer
ON test_table
GO

CREATE INDEX IX_CL_rand_string
ON test_table(rand_string)
GO

DROP INDEX IX_CL_rand_string
ON test_table
GO

CREATE UNIQUE INDEX IX_CL_id
ON test_table(id)
GO

CREATE UNIQUE CLUSTERED INDEX IX_CL_id
ON test_table(id)
GO

DROP INDEX IX_CL_id
ON test_table
GO

