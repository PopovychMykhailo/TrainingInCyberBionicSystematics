USE Les11_Indexes
GO

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