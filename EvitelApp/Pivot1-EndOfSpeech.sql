
/*
DROP TABLE Grades

CREATE TABLE Grades(
  [Student] VARCHAR(50),
  [Subject] VARCHAR(50),
  [Marks]   INT
)
GO
 
INSERT INTO Grades VALUES 
('Jacob','Mathematics',100),
('Jacob','Science',95),
('Jacob','Geography',90),
('Amilee','Mathematics',90),
('Amilee','Science',90),
('Amilee','Geography',100)
GO
*/
SELECt * FROM Grades

SELECT * FROM (
  SELECT
    [Student],
    [Subject],
    [Marks]
  FROM Grades
) StudentResults
PIVOT (
  SUM([Marks])
  FOR [Subject]
  IN (
    [Mathematics],
    [Science],
    [Geography]
  )
) AS PivotTable


SELECt * FROM LPK

SELECT LPK.LPKId,Calls.dtStartCall, EOS.LPKSubEndOfSpeechEID,EOS2.Text ,EOS1.Text AS SubText INTO #tmp
FROM LPK 
LEFT JOIN [dbo].[Calls] ON LPK.CallId = Calls.CallId
LEFT JOIN [dbo].[LPKSubEndOfSpeech] EOS ON EOS.LPKId = LPK.LPKId
LEFT JOIN [dbo].[eSubEndOfSpeech] EOS1 ON EOS.LPKSubEndOfSpeechEID = EOS1.SubEndOfSpeechId
LEFT JOIN [dbo].[eEndOfSpeech] EOS2 ON EOS1.EndOfSpeechId = EOS2.EndOfSpeechId


SELECT YEAR(dtStartCall) Rok, MONTH(dtStartCall) Mesic, Text, SubText, COUNT(Text)   FROM #tmp
GROUP BY YEAR(dtStartCall),MONTH(dtStartCall), Text,SubText
SELECT * FROM #tmp2


SELECT YEAR(dtStartCall) Rok, MONTH(dtStartCall) Mesic, text, COUNT(Text)   FROM #tmp
GROUP BY YEAR(dtStartCall),MONTH(dtStartCall), Text

SELECT YEAR(dtStartCall) Rok, MONTH(dtStartCall) Mesic, Text, subtext, COUNT(SubText)   FROM #tmp
GROUP BY YEAR(dtStartCall),MONTH(dtStartCall), Text,subText
HAVING (COUNT(SubText)>0)
ORDER BY Rok,Mesic,Text,SubText

SELECT * FROM #tmp2
