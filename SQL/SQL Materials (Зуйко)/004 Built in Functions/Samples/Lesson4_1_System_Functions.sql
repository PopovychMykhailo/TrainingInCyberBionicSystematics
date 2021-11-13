/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson IV  ******      Scalar Functions       ************************
****************************************************************************/

--GO - информирует об окончании пакета инструкций Transact-SQL.
--GO - это не инструкция Transact-SQL; эта команда распознается редактором SQL Server Management Studio.
--Пакет (batch) - это последовательность инструкций Transact-SQL и процедурных расширений, 
--которые направляются системе базы данных для совместного их выполнения. Преимущество пакета 
--над группой отдельных инструкций состоит в том, что одновременное исполнение всех инструкций 
--позволяет получить значительное улучшение производительности. 

--1. System Functions
--@@ERROR
DECLARE @myint int;  
SET @myint = 'ABC';  
GO

SELECT @@ERROR; 
GO

BEGIN TRY
	DECLARE @myint int;  
	SET @myint = 1/0
END TRY
BEGIN CATCH
	SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage
END CATCH

--@@IDENTITY - возвращает значение последнего вставленного идентификатора
--SCOPE_IDENTITY, IDENT_CURRENT - похожие функции

INSERT Students
VALUES 
('Alex', 'Li', NULL, NULL);  
GO  
SELECT @@IDENTITY;  
GO  

--@@ROWCOUNT - возвращает число строк, затронутых при выполнении последней инструкции.
UPDATE Students
SET LName = 'Po'
WHERE Id = 6
GO 
SELECT @@ROWCOUNT;  
GO

DELETE Students
GO  
SELECT @@ROWCOUNT;  
GO

-- NEWID - cоздает уникальное значение типа uniqueidentifier. 
DECLARE @myId uniqueidentifier  
SET @myId = NEWID()  
PRINT @myId

-- ISNUMERIC - определяет, имеет ли переданное выражение допустимый числовой тип (int, decimal и др.),
-- возвращает 1, если при оценке входного выражения получается допустимый числовой тип данных, иначе - 0.
SELECT 
	ISNUMERIC('33')
	,ISNUMERIC(17)
	,ISNUMERIC('3abc')
	,ISNUMERIC(@myId)
	,ISNUMERIC('+')
	,ISNUMERIC('$')
	
-- ISNULL - заменяет значение NULL указанным замещающим значением.

SELECT Id, LName, ISNULL(Salary, 0.0) AS Salary
FROM Employees

DECLARE @myInt int;
SELECT 3 + @myInt, 3 + ISNULL(@myInt, 0)

-- COALESCE - возвращает первое не NULL значение из списка значений.
-- (переписывается оптимизатором запросов в выражение case)