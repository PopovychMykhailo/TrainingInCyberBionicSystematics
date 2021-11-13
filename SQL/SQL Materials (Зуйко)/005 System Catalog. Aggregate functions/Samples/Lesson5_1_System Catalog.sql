/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson V  *******      System Catalog.        ************************
************************    Aggregate functions      ************************
****************************************************************************/

USE InternetShopDB

-- 1. Object Catalog Views

SELECT * FROM sys.objects

SELECT * FROM sys.objects
WHERE type = 'U'

SELECT * FROM sys.objects
WHERE schema_id = SCHEMA_ID('dbo')


SELECT * FROM sys.tables

SELECT * FROM sys.views

SELECT * FROM sys.triggers

SELECT * FROM sys.procedures

SELECT * FROM sys.objects
WHERE type IN ('FN', 'IF', 'TF', 'FS', 'FT') ;

/*
From https://msdn.microsoft.com/en-us/library/ms190324.aspx:
 FN SQL_SCALAR_FUNCTION
 FS Assembly (CLR) scalar-function
 FT Assembly (CLR) table-valued function
 IF SQL_INLINE_TABLE_VALUED_FUNCTION
 TF SQL_TABLE_VALUED_FUNCTION
*/


-- 2. System Stored Procedures

EXEC sp_help -- ALT + F1

EXEC sp_help 'Employees'

EXEC sp_help 'PK_Customers'

EXEC sp_databases -- No parameters

EXEC sp_tables

EXEC sp_tables @table_owner='dbo'

EXEC sp_columns 'Employees'

EXEC sp_pkeys 'Employees'

EXEC sp_depends 'Employees'

EXEC sp_depends 'Orders'

