/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****   Lesson X   *****  SUBQUERY, TEMP TABLE, CTE  ************************
*****************************************************************************
****************************************************************************/

USE GrandSlamDB
GO

--НЕЗАВИСИМЫЕ ПОДЗАПРОСЫ
SELECT p.LName, t.Name, ISNULL(tb.Wins, 0) Wins FROM Players p
		CROSS JOIN Tournaments t
		LEFT JOIN 
		(SELECT ps.PlayerId, COUNT(ps.Win) Wins, m.TournamentId FROM PlayerStats ps 
				JOIN Matches m 
				ON ps.MatchId = m.Id AND ps.Win = 1 
				GROUP BY ps.PlayerId, m.TournamentId) tb -- производная таблица
		ON tb.PlayerId = p.Id AND tb.TournamentId = t.Id
		ORDER BY p.LName

-- Вывести информацию по играм, которые проходили на турнире 'Wimbledon'
SELECT * FROM Matches
WHERE TournamentId = (SELECT Id FROM Tournaments WHERE Name = 'Wimbledon')

-- Ошибка - вложенный запрос возвращает несколько значений Id
--SELECT * FROM Matches
--WHERE TournamentId = (SELECT Id FROM Tournaments)

--Вывести информацию об самом возрастном игроке
SELECT * FROM PlayerInfos
WHERE BirthDate = (SELECT MIN(BirthDate) FROM PlayerInfos)

--Вывести инормацию о высоких игроках
SELECT * FROM PlayerInfos
WHERE Height >= (SELECT AVG(Height) FROM PlayerInfos)

--Вывести инормацию об игроках с ростом 198 см.
SELECT * FROM Players
WHERE Id IN (SELECT Id FROM PlayerInfos WHERE Height = 198)

SELECT * FROM Players p
	JOIN PlayerInfos pi ON p.Id = pi.PlayerId
	WHERE pi.Height = 198

--Вывести информацию о самых высоких игроках 
SELECT * FROM Players
WHERE Id IN (SELECT Id FROM PlayerInfos 
			WHERE Height = (SELECT MAX(Height) FROM PlayerInfos))


--ALL, ANY (SOME), EXIST
--Вывести инормацию об игроках, которые не играли в финалах
SELECT * FROM Players
WHERE Id != ALL (SELECT ps.PlayerId FROM Matches m
					JOIN PlayerStats ps ON m.Id = ps.MatchId
					WHERE m.Round = 'FINALS')

--Вывести информацию о кортах, на которых не проходили игры
SELECT * FROM Courts
WHERE Id != ALL (SELECT CourtId FROM Matches)

--http://www.sqlservercentral.com/blogs/sqlinthewild/2011/01/18/distincting-an-in-subquery/

SELECT * FROM Courts
WHERE Id NOT IN (SELECT CourtId FROM Matches)

SELECT * FROM Courts c1
WHERE NOT EXISTS (SELECT * FROM Matches m
								JOIN Courts c2 ON m.CourtId = c2.Id AND c1.Id = c2.Id)

--Вывести информацию о кортах, на которых проходили игры
SELECT * FROM Courts
WHERE Id = ANY (SELECT CourtId FROM Matches)

SELECT * FROM Courts
WHERE Id IN (SELECT CourtId FROM Matches)

SELECT DISTINCT c.Id, c.Name FROM Courts c 
			JOIN Matches m ON m.CourtId = c.Id


--СВЯЗАННЫЕ ПОДЗАПРОСЫ
--1. Выбрать строку из таблицы, указанной во внешнем запросе. Это будет текущая строка-кандидат.
--2. Сохранить значения из этой строки-кандидата во временном буфере.
--3. Выполнить подзапрос. Для отбора записей использовать строку-кандидат.
--4. Вычислить условие во внешнем запросе, на основе результатов внутреннего подзапроса, выполняемого в п.3. 
--   Определить отбирается ли строка-кандидат для вывода.
--5. Повторить процедуру для всех строк.

--Вывести игры, в которых игрок сделал наибольшее количество "подач навылет"
SELECT * FROM PlayerStats ps1
WHERE Aces = (SELECT MAX(Aces) FROM PlayerStats ps2 WHERE ps1.PlayerId = ps2.PlayerId)

--Вывести дату игры, фамилию игрока и сколько игрок сделал эйсов в этой игре
SELECT Id, 
(SELECT Date FROM Matches m WHERE m.Id = ps.MatchId) Date,
(SELECT LName FROM Players p WHERE p.Id = ps.PlayerId) Player,
Aces
FROM PlayerStats ps 

SELECT ps.Id, m.Date, p.LName, ps.Aces FROM PlayerStats ps 
			JOIN Matches m ON m.Id = ps.MatchId
			JOIN Players p ON p.Id = ps.PlayerId

-- Вывести по каждому игроку его максимальное количество сделанных эйсов за игру
SELECT LName,
(SELECT MAX(Aces) FROM PlayerStats ps WHERE ps.PlayerId = p.Id) MAX_Aces
FROM Players p

--Вывести игроков, которые не играли
SELECT * FROM Players p
WHERE NOT EXISTS (SELECT * FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 

SELECT * FROM Players p
WHERE p.Id NOT IN (SELECT PlayerId FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 

SELECT * FROM Players p
WHERE p.Id != ALL (SELECT PlayerId FROM PlayerStats ps WHERE ps.PlayerId = p.Id) 


--APPLY (CROSS APPLY, OUTER APPLY)

SELECT LName,
(SELECT MIN(Aces) FROM PlayerStats ps WHERE ps.PlayerId = p.Id) MIN_Aces,
(SELECT MAX(Aces) FROM PlayerStats ps WHERE ps.PlayerId = p.Id) MAX_Aces
FROM Players p

SELECT LName,
psa.MIN_Aces,
psa.MAX_Aces
FROM Players p
CROSS APPLY
(SELECT MAX(Aces) MAX_Aces, MIN(Aces) MIN_Aces FROM PlayerStats ps WHERE ps.PlayerId = p.Id) psa


