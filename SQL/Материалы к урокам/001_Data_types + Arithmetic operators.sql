/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson I  *******      INTRO. DATA TYPES      ************************
****************************************************************************/

--		  ������������ �����������.

/*
	...   ������������ �����������.
*/

--Data Types

---- !!!��� �������� ���� ���� ����� �������� NULL!!!

/****************************************************************************
*					������ �������� ���� (Exact Numeric Types)				*  
****************************************************************************/

---- BIT
------ ������ ����������� ��������, (bool)
------ �������� 1 ����
------ ������������ ������ ���� �������� 1
------ ���� ������ ���������� ����������� ������� �������� � ���� ���� ��� 
------ �������� ������

DECLARE @someBit bit = 0 --���������� � ������������ ���������� ���� bit 
PRINT @someBit

SET @someBit = 123
PRINT @someBit


---- TINYINT
------ ������ ����� �� 0 �� 255
------ ������������ ���� Arithmetic overflow error
------ �������� 1 ����

DECLARE @someTinyInt tinyInt  = 255
PRINT @someTinyInt


---- SMALLINT
------ ������ ����� �� �32 768 �� 32 767
------ ������������ ���� Arithmetic overflow error
------ �������� 2 ����

DECLARE @someSmallInt smallInt = 32767
PRINT @someSmallInt


---- INT (INTEGER)
----- ������ ����� �� �2 147 483 648 �� 2 147 483 647
----- ������������ ���� Arithmetic overflow error
----- �������� 4 ����

DECLARE @someInt int = 123 --���������� � ������������ ���������� ���� bit 
PRINT @someInt

SET @someInt = 2147483647 + 1
PRINT @someInt


---- BIGINT
----- ������ ����� �� -9 223 372 036 854 775 808 �� 9 223 372 036 854 775 807
----- ������������ ���� Arithmetic overflow error
----- �������� 8 ����

DECLARE @someBigInt bigint = 9223372036854775807
PRINT @someBigInt

---- DECIMAL (NUMERIC - ������� DECIMAL)
------ ������ ����� � ������������ ��������
------ ���������: DECIMAL(��������, �������)
-------- ��������: ���������� ���� � ����� [1, 38]
-------- �������: ���������� ���� ����� ������� [0, ��������]
------ ����������� ������� �� ��������:
-------- (1 - 9):	5 ����
-------- (10 - 19): 9 ����
-------- (20 - 28): 13 ����
-------- (29 - 38): 17 ����
------ ������������:
-------- �� ������� ���� Arithmetic overflow error
-------- ����� ������� ��������� ���������� ��������

DECLARE @someDecimal1 decimal = 123.56 --�������� �� ��������� (18, 0) 
PRINT @someDecimal

DECLARE @someDecimal2 decimal(8,5) = 123.56
PRINT @someDecimal2

SET @someDecimal2 = 123.123456 -- ����������
PRINT @someDecimal2

SET @someDecimal2 = 1234.56 -- ������
PRINT @someDecimal2

DECLARE @someNumeric1 numeric(3,2) = 3.14
PRINT @someNumeric1

DECLARE @someNumeric2 numeric = 25000
PRINT @someNumeric2


---- SMALLMONEY
------ �������� ������������� ����� �� -214748.3648 �� 214748.3647
------ ������ ���� DECIMAL(10,4), �� ����� ������ ��� �����������
------ ������������ ���� Arithmetic overflow error
------ �������� 4 ����

DECLARE @someSmallMoney smallmoney = 25.50
PRINT @someSmallMoney


---- MONEY
------ �������� ������������� ����� �� �922337203685477.5808 �� 92233720 685477.5807
------ ������ ���� DECIMAL(19,4), �� ����� ������ ��� �����������
------ ������������ ���� Arithmetic overflow error
------ �������� 8 ����

DECLARE @someMoney money = 1000000.52
PRINT @someMoney


/****************************************************************************
*			��������������� �������� ���� (Approximate Numeric Types)		*  
****************************************************************************/

---- FLOAT
------ ������ ����� � ��������� �������
------ ���������: FLOAT(��������)
-------- ��������: ���������� ���, ��� �������� ����� [1, 53]
------ ����������� ������� � ���������� ���� �� ��������:
-------- (1 - 24):  7 ����	4 �����
-------- (25 - 53):	15 ���� 8 ����
-------- SQL Server ��������� ������� ��� ���� ��� 24 ��� 53
------ ������������ ������� �����: 308
------ ������������:
-------- ������� ������� �� ������������ ���� Arithmetic overflow error

DECLARE @someFloat1 float(24) = 145.4
PRINT @someFloat1

-- �� ��������� Float(53)
DECLARE @someFloat2 float = 5e300
PRINT @someFloat2


---- REAL
------ ������ ����� � ��������� �������
------ ������ FLOAT(24)
------ �������� 4 ����
------ ������������ ������� �����: 38
------ ������������:
-------- ������� ������� �� ������������ ���� Arithmetic overflow error

DECLARE @someReal real = 1e5
PRINT @someReal


/****************************************************************************
*				���� ������ ���� � ������� (Date and Time Types)			*  
****************************************************************************/

---- DATE
------ ������ ���� �� 1 ������ 1 ���� �� 31 ������� 9999 ����
------ �������� 3 �����
------ ������ ������ ��� ����������� � DATE: '����-��-��'
-------- ����: �� 0001 �� 9999
-------- ��: �� 01 �� 12
-------- ��: �� 01 �� 31 (�������� �� ������)
------ ������������:
-------- ������ ���� ������ �������������� ������ � Date

DECLARE @someDate date = '01-17-2017'
PRINT @someDate

SET @someDate = '20170117'
PRINT @someDate

SET @someDate = '17-01-2017'
PRINT @someDate


---- TIME
------ ������ ����� �� 00:00:00 �� 23:59:59
------ �������� 5 �����
------ ���������: TIME(��������)
-------- ��������: ���������� ���� ����� ������ [0, 7]
------ ������ ������ ��� ����������� � Time: '��:��[:��[.��]]'
-------- ��: �� 0 �� 23
-------- ��: �� 0 �� 59
-------- ��: �� 0 �� 59
-------- ��: �� 0000000 �� 9999999
------ ������������:
-------- � ����� ������� ������������
-------- ������ ���� ������ �������������� ������ � Time

DECLARE @someTime1 time = '03:36:49:1'
PRINT @someTime1

SET @someTime1 = '03:36:49.1234567'
PRINT @someTime1

-- �� ��������� TIME(7)
DECLARE @someTime2 time = '23:59:59.1234567'
PRINT @someTime2


---- SMALLDATETIME
------ ������ ���� � ����� �� 1 ������ 1900 ���� � 6 ���� 2079 ����
------ �������� 4 �����
------ ������ ������ ��� ����������� � DATETIME: '����-��-�� ��:��[:��]'
-------- ����: �� 1900 �� 9999
-------- ��: �� 01 �� 12
-------- ��: �� 01 �� 31 (�������� �� ������)
-------- ��: �� 00 �� 23
-------- ��: �� 00 �� 59
-------- ��: �� 00 �� 59 (������� ������ ������������ � �������)
------ ������������:
-------- ������ ���� ������ �������������� ������ � SmallDateTime

DECLARE @smallDateTime SmallDateTime = '2018-01-01 12:35:40'
PRINT @smallDateTime


---- DATETIME
------ ������ ���� � ����� �� 1 ������ 1753 ���� �� 31 ������� 9999 ����
------ �������� 8 �����
------ ������ ������ ��� ����������� � DATETIME: '����-��-�� ��:��[:��[.��]]'
-------- ����: �� 1753 �� 9999
-------- ��: �� 01 �� 12
-------- ��: �� 01 �� 31 (�������� �� ������)
-------- ��: �� 00 �� 23
-------- ��: �� 00 �� 59
-------- ��: �� 00 �� 59
-------- ��: �� 001 �� 999
------ ������������:
-------- ������ ���� ������ �������������� ������ � DATETIME

DECLARE @someDateTime datetime = '01-17-2017 03:36:49'
PRINT @someDateTime

SET @someDateTime = '20170117 03:36:49:123'
PRINT @someDateTime


---- DATETIME2
------ ������ ���� � ����� �� 1 ������ 0001 ���� �� 31 ������� 9999 ����
------ ���������: DATETIME2(��������)
-------- ��������: ���������� ���� ����� ������ [0, 7]
------ ����������� ������� �� ��������:
-------- (1-2): 6 ����
-------- (3-4): 7 ����
-------- (4-7): 8 ����
------ ������ ������ ��� ����������� � DATETIME: '����-��-�� ��:��[:��[.��]]'
-------- ����: �� 0001 �� 9999
-------- ��: �� 01 �� 12
-------- ��: �� 01 �� 31 (�������� �� ������)
-------- ��: �� 00 �� 23
-------- ��: �� 00 �� 59
-------- ��: �� 00 �� 59
-------- ��: �� 0000001 �� 9999999
------ ������������:
-------- � ����� ������� ������������
-------- ������ ���� ������ �������������� ������ � DATETIME2

DECLARE @someDateTime2_1 datetime2(3) = '2018-01-01 12:42:13.1234567'
PRINT @someDateTime2_1

-- �� ��������� DateTime2(7)
DECLARE @someDateTime2_2 datetime2 = '2018-01-01 12:42:13.1234567'
PRINT @someDateTime2_2


---- DATETIMEOFFSET
------ ������ ���� � ����� �� 1 ������ 0001 ���� �� 31 ������� 9999 ����
------ ������� 10 �����
------ ���������: DATETIMEOFFSET(��������)
-------- ��������: ���������� ���� ����� ������ [0, 7]
------ ������ ������ ��� ����������� � DATETIME: '����-��-�� ��:��[:��[.��][{+|-}��:��]]'
-------- ����: �� 0001 �� 9999
-------- ��: �� 01 �� 12
-------- ��: �� 01 �� 31 (�������� �� ������)
-------- ��: �� 00 �� 23
-------- ��: �� 00 �� 59
-------- ��: �� 00 �� 59
-------- ��: �� 0000001 �� 9999999
-------- ��: �� -14 �� +14
-------- ��: �� 00 �� 59
------ ������������:
-------- � ����� ������� ������������
-------- ������ ���� ������ �������������� ������ � DATETIMEOFFSET

DECLARE @someDateTimeOffset datetimeoffset(2) = '2018-01-01 12:00:00 +10:00'
PRINT @someDateTimeOffset


/****************************************************************************
*					���������� ������ (Character Strings)					*  
****************************************************************************/

---- CHAR
------ ������ ��������� ������ ������������� ����� �� � �������
------ �������� 1 ���� ������ ������
------ ���������: CHAR(�����)
-------- �����: ���������� �������� � ������ [1, 8000]
------ ������������:
-------- �������� ����������� �� �������� �����
-------- �������� ������ �����������, ������ ������������ �� �������� ����� 
-------- �� ���� ��������

DECLARE @someStr1 char(20) = 'hello world'
PRINT @someStr1

-- �� ��������� Char(1)
DECLARE @someStr2 char = 'a'
PRINT @someStr2


---- VARCHAR
------ ������ ��������� ������ ���������� ����� �� � �������
------ �������� 1 ���� ������ ������
------ ���������: VARCHAR(�����)
-------- �����: ���������� �������� � ������ [1, 8000]
---------- ����� ������ ��������� max, ����� ����� ������: 2147483647 (2 ��)
------ ������������:
-------- �������� ����������� �� ������������ �����

DECLARE @varStr varchar(12) = 'hello world'
PRINT @varStr

DECLARE @varMaxStr varchar(max) = 'Goodbay'
PRINT @varMaxStr

-- �� ��������� VARCHAR(1)
DECLARE @someVarStr varchar = 'a'
PRINT @someVarStr


------ TEXT
------ ������ ��������� ������ ���������� ����� �� � �������
------ ������ VARCHAR(max)
------ ����������, ����� ��������!!!
------ �������� 1 ���� ������ ������
------ ������������ �����: 2147483647 (2 ��)

--DECLARE @someText text


---- NCHAR
------ ������ ��������� ������ ������������� ����� � �������
------ �������� 2 ���� ������ ������
------ ���������: NCHAR(�����)
-------- �����: ���������� �������� � ������ [1, 4000]
------ ������������:
-------- �������� ����������� �� �������� �����
-------- �������� ������ �����������, ������ ������������ 
-------- �� �������� ����� �� ���� ��������

DECLARE @someNChar1 nchar(15) = N'�����-�� �����'
PRINT @someNChar1

DECLARE @someNChar2 nchar(20) = '������ ���'
PRINT @someNChar2

DECLARE @someNChar3 nchar(max) = '������ ���, � ���!!!'
PRINT @someNChar3

-- �� ��������� NCHAR(1)
DECLARE @someNChar4 nchar = '�'
PRINT @someNChar4


---- NVARCHAR
------ ������ ��������� ������ ���������� ����� �� � �������
------ �������� 2 ���� ������ ������
------ ���������: NVARCHAR(�����)
-------- �����: ���������� �������� � ������ [1, 4000]
---------- ����� ������ ��������� max, ����� ����� ������: 1073741823 (2 ��)
------ ������������:
-------- �������� ����������� �� ������������ �����

DECLARE @nvarStr nvarchar(12) = '������ ���!'
PRINT @nvarStr

DECLARE @nvarMaxStr nvarchar(max) = '����!'
PRINT @nvarMaxStr

-- �� ��������� NVarChar(1)
DECLARE @nvarMinStr nvarchar = 'a'
PRINT @nvarMinStr


---- NTEXT
------ ������ ��������� ������ ���������� ����� �� � �������
------ ������ NVARCHAR(max)
------ ����������, ����� ��������!!!
------ �������� 2 ���� ������ ������
------ ������������ �����: 1073741823 (2 ��)

--DECLARE @someNText ntext

/****************************************************************************
*					�������� ������ (Binary Strings)						*  
****************************************************************************/                                 

---- BINARY
------ ������ �������� ������ ������������� �����
------ ���������: BINARY(�����)
---------- �����: ���������� ������ [1, 8000]
------ ������������:
-------- �������� ����������� �� �������� �����
-------- �������� ������ �����, ������ ������������ �� �������� ����� �� ���� �����

DECLARE @someBinary binary(4) = 0x800000FF
PRINT @someBinary

-- �� ��������� BINARY(1)
DECLARE @oneByte binary = 0xAF
PRINT @oneByte


---- VARBINARY
------ ������ �������� ������ ���������� �����
------ ���������: VARBINARY(�����)
---------- �����: ���������� ������ [1, 8000]
------------ ����� ������ ��������� max, ����� ������ ����: 2147483647 (2 ��)
------ ������������:
-------- �������� ����������� �� ������������ �����

DECLARE @someVarBinary varbinary(5) = 0xFF
PRINT @someVarBinary

DECLARE @varBigData varbinary(max) = 0xAEF0FF93FC
PRINT @varBigData

-- �� ��������� VARBINARY(1)
DECLARE @varOneByte varbinary = 0xFF;
PRINT @varOneByte


---- Image
------ ������ �������� ������ ���������� �����
------ ������ VARBINARY(max)
------ ����������, ����� ��������
------ ������������ �����: 2147483647 (2 ��)

--DECLARE @someImage image


/****************************************************************************
*****************************************************************************
*						INTRO. Arithmetic operators							*
*****************************************************************************
****************************************************************************/

--Arithmetic operators
--��������� ����� ������ https://msdn.microsoft.com/library/ms190309(SQL.130).aspx

---- �������� + (��������)

DECLARE @x int = 123, @y int = 456
SELECT @x + @y

DECLARE @date datetime = '20170117 12:00'
SELECT @date + 1.25

SELECT 'Hello, ' + 'world!' --������������

 ---- �������� - (���������)
 ---- �������� * (���������)
 ---- �������� / (�������)

SELECT  10/3,
		17/10,
		10./3,
		10/3.

SELECT 1/0 -- Divide by zero error encountered. 

 ---- �������� % (������� �� �������)

SELECT  7/5,
		7%5
