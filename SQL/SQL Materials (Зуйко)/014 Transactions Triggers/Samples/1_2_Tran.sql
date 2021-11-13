/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIV *******        TRANSACTIONS         ************************
************************          TRIGGERS           ************************
****************************************************************************/

--LOST UPDATE
--1.
BEGIN TRAN --SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

UPDATE TestTable 
SET Value = Value + 9
WHERE Id = 1;



SELECT Value 
FROM TestTable
WHERE Id = 1;

COMMIT TRAN;

--2.
BEGIN TRAN --SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
		   --SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

DECLARE @Value INT;

SELECT @Value = Value
FROM TestTable
WHERE Id = 1;



UPDATE TestTable 
SET Value = @Value + 9
WHERE Id = 1;

COMMIT TRAN;

SELECT Value 
FROM TestTable
WHERE Id = 1;

--DIRTY READS
BEGIN TRAN --SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;









SELECT Value 
FROM TestTable
WHERE Id = 1;

COMMIT TRAN;


--NON-REPEATABLE READS
BEGIN TRAN;




UPDATE TestTable 
SET Value = 17
WHERE Id = 1;




COMMIT TRAN;

--PHANTOM READS
BEGIN TRAN;



INSERT INTO TestTable (Value) VALUES(22)



COMMIT TRAN;