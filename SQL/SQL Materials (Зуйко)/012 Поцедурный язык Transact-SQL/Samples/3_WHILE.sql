/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson XII  *****      Procedural T-SQL       ************************
*****************************************************************************
****************************************************************************/

--2. Инструкции управления потоком (control-of-flow statements)
--2) Циклические конструкции

DECLARE @counter int = 0

WHILE @counter < 10
BEGIN	
	SET @counter = @counter + 1
	PRINT 'counter: ' + CAST(@counter as varchar)
END

--CONTINUE
PRINT '--continue--'

SET @counter = 0
WHILE @counter < 10
BEGIN	
	SET @counter = @counter + 1
	
	IF @counter % 2 = 0
		CONTINUE

	PRINT 'counter: ' + CAST(@counter as varchar)
END

--BREAK
PRINT '--break--'

SET @counter = 0
WHILE @counter < 10
BEGIN	
	SET @counter = @counter + 1
	
	IF @counter = 6
		BREAK

	PRINT 'counter: ' + CAST(@counter as varchar)
END