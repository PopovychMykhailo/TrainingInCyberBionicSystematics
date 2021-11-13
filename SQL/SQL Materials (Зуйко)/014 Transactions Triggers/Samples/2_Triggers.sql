/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
***** Lesson XIV *******        TRANSACTIONS         ************************
************************          TRIGGERS           ************************
****************************************************************************/

--2.TRIGGERS
--1) FOR
CREATE TRIGGER trSomeTrigger
ON Courts
FOR INSERT, UPDATE, DELETE
AS
	IF @@ROWCOUNT = 0
		RETURN

	SET NOCOUNT ON

	SELECT * FROM inserted;
	SELECT * FROM deleted;
		
	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
		BEGIN
			IF NOT UPDATE(City)
				RETURN	
			PRINT 'UPDATE'		
		END
	ELSE IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
		BEGIN
			PRINT 'INSERT'
		END
	ELSE IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
		BEGIN
			PRINT 'DELETE'
		END
GO

INSERT Courts VALUES
('No. 3 Court', 'NY', 1000, 'Grass'),
('No. 4 Court', 'NY', 900, 'Grass')

UPDATE Courts
SET Capasity = 'London'
WHERE Id IN (11, 12)

UPDATE Courts
SET Capasity = 500
WHERE Id IN (11, 12)

DELETE Courts
WHERE Id IN (11, 12)


--2) INSTEAD OF
CREATE TRIGGER trAllowDeleteCourts
ON Courts
INSTEAD OF DELETE
AS
	IF @@ROWCOUNT = 0
		RETURN

	SET NOCOUNT ON

	IF EXISTS (SELECT 1 FROM deleted 
							WHERE Capasity >= 1000)
		THROW 51000, 'Нельзя удалить корт с вместимостью больше 1000', 11

	ELSE
		DELETE Courts WHERE Id IN (SELECT Id FROM deleted)
GO

DELETE Courts
WHERE Id IN (13, 14)