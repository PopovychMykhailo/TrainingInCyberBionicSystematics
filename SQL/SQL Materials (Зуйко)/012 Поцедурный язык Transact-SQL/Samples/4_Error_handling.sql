/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson XII  *****      Procedural T-SQL       ************************
*****************************************************************************
****************************************************************************/

--3. ��������� ������
--1) TRY..CATCH
BEGIN TRY
    SELECT 1/0;
    --DROP TABLE NonexistentTable;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber
        ,ERROR_SEVERITY() AS ErrorSeverity
        ,ERROR_STATE() AS ErrorState
        ,ERROR_PROCEDURE() AS ErrorProcedure
        ,ERROR_LINE() AS ErrorLine
        ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

--2) RAISERROR
BEGIN TRY
    SELECT 1/0;
END TRY
BEGIN CATCH
   RAISERROR('������� �� ����', 11, 2);  --message, severity, state 
END CATCH;
GO

BEGIN TRY
    SELECT 1/0;
END TRY
BEGIN CATCH
   RAISERROR('������ %s %d', 11, 2, N'�����', 10);  --message, severity, state 
END CATCH;
GO

--3) SEVERITY
BEGIN TRY
    RAISERROR('������� �� ����', 11, 3);
	PRINT 'TRY'
END TRY
BEGIN CATCH
   PRINT 'CATCH'
END CATCH;
GO

BEGIN TRY	     
    RAISERROR('������� �� ����', 10, 3);
	PRINT 'TRY'
END TRY
BEGIN CATCH
   PRINT 'CATCH'
END CATCH;
GO

--4) THROW
BEGIN TRY
    SELECT 1/0;
END TRY
BEGIN CATCH
   THROW 51000, '������� �� ����', 2;  --error number, message, state 
END CATCH;
GO

BEGIN TRY
    THROW 51000, '������� �� ����', 2;
END TRY
BEGIN CATCH
   SELECT
        ERROR_NUMBER() AS ErrorNumber
        ,ERROR_SEVERITY() AS ErrorSeverity
        ,ERROR_STATE() AS ErrorState
        ,ERROR_PROCEDURE() AS ErrorProcedure
        ,ERROR_LINE() AS ErrorLine
        ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO