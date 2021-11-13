/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson IV  ******      Scalar Functions       ************************
****************************************************************************/

--6. Logical Functions
----CHOOSE - возвращает элемент по указанному индексу из списка значений
SELECT Id, LName, BirthDate,
CHOOSE(MONTH(BirthDate), 'Winter','Winter', 'Spring','Spring','Spring','Summer','Summer',   
'Summer','Autumn','Autumn','Autumn','Winter') 
FROM Employees

--7. Metadata Functions
----OBJECT_ID и OBJECT_NAME
IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Cars'))
BEGIN
    CREATE TABLE Cars
	(
		Id int IDENTITY,
		Name varchar(20)
	)
END
GO

SELECT OBJECT_ID('Cars'),
       OBJECT_NAME(OBJECT_ID('Cars'))

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Cars'))
BEGIN
    DROP TABLE Cars
END
GO