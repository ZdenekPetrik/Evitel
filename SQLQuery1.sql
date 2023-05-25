/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ClientCurrentStatusId]
      ,[Text]
      ,[dtDeleted]
  FROM [Evitelx2].[dbo].[eClientCurrentStatus]

select [ClientCurrentStatusId], [Text],
  indicatorname,
  indicatorvalue
from [Evitelx2].[dbo].[eClientCurrentStatus]
unpivot
(
  indicatorvalue
  for indicatorname in (Indicator1, Indicator2, Indicator3)
) unpiv;



SELECT id
        ,entityId
        ,indicatorname
        ,indicatorvalue
  FROM (VALUES
        (1, 1, 'Value of Indicator 1 for entity 1', 'Value of Indicator 2 for entity 1', 'Value of Indicator 3 for entity 1'),
        (2, 1, 'Value of Indicator 1 for entity 2', 'Value of Indicator 2 for entity 2', 'Value of Indicator 3 for entity 2'),
        (3, 1, 'Value of Indicator 1 for entity 3', 'Value of Indicator 2 for entity 3', 'Value of Indicator 3 for entity 3'),
        (4, 2, 'Value of Indicator 1 for entity 4', 'Value of Indicator 2 for entity 4', 'Value of Indicator 3 for entity 4')
       ) AS Category(ID, EntityId, Indicator1, Indicator2, Indicator3)
UNPIVOT
(
    indicatorvalue
    FOR indicatorname IN (Indicator1, Indicator2, Indicator3)
) UNPIV;


SELECT STRING_AGG ([value],',') FROM STRING_SPLIT('Akio,Hiraku,Kazuo', ',')


Declare @YourTable Table ([ID] varchar(50),[Col1] varchar(50),[Col2] varchar(50))
Insert Into @YourTable Values 
 (1,'A','B')
,(2,'R','C')
,(3,'X','D')

Select A.[ID]
      ,Item  = B.[Key]
      ,Value = B.[Value]
 From  @YourTable A
 Cross Apply ( Select * 
                From  OpenJson((Select A.* For JSON Path,Without_Array_Wrapper )) 
                Where [Key] not in ('ID','Other','Columns','ToExclude')
             ) B

---------
DECLARE @Candidate TABLE(
Id INT IDENTITY(1,1), 
Country NVARCHAR(250), 
Score Float)

INSERT INTO @Candidate(Country, Score) VALUES('America', 7)
INSERT INTO @Candidate(Country, Score) VALUES('Canada', NULL)
INSERT INTO @Candidate(Country, Score) VALUES('Vietnam', 9)
INSERT INTO @Candidate(Country, Score) VALUES('Thailand', 9)
INSERT INTO @Candidate(Country, Score) VALUES('Vietnam', 6)
INSERT INTO @Candidate(Country, Score) VALUES('America', 8)


SELECT * FROm @Candidate


SELECT [America], [Canada], [Vietnam], [Thailand]
FROM (
	SELECT  Country  FROM @Candidate
) AS src
PIVOT (COUNT(Country) FOR Country IN ([America], [Canada], [Vietnam], [Thailand])) AS pvt

----- 

Select * FROM [Evitelx2].[dbo].[eClientCurrentStatus]




create table #Temp
(
    FormId int,
    FieldName Varchar(50), 
    Value Varchar(50)
)

Insert Into #Temp VALUES (1,'FirstName','Joe')
Insert Into #Temp VALUES (1,'MiddleName','S')
Insert Into #Temp VALUES (1,'LastName','Smith')
Insert Into #Temp VALUES (1,'Email','abc@abc.com')
Insert Into #Temp VALUES (2,'FirstName','Sam')
Insert Into #Temp VALUES (2,'MiddleName','S')
Insert Into #Temp VALUES (2,'LastName','Freddrick')
Insert Into #Temp VALUES (2,'Email','abc1@abc.com')
Insert Into #Temp VALUES (3,'FirstName','Jaime')
Insert Into #Temp VALUES (3,'MiddleName','S')
Insert Into #Temp VALUES (3,'LastName','Carol')
Insert Into #Temp VALUES (3,'Email','abc2@abc.com')


Select * FROM #Temp


select FormId, max(FirstName) as FirstName, max(MiddleName) as MiddleName, max(LastName) as LastName, max(Email) as Email 
from (
    select FormId
         , case when FieldName = 'FirstName' then Value end as FirstName
         , case when FieldName = 'MiddleName' then Value end as MiddleName 
         , case when FieldName = 'LastName' then Value end as LastName 
         , case when FieldName = 'Email' then Value end as Email 
    from #Temp
) as t 
group by FormId;


SELECT SCCS.SubClientCurrentStatusId, SCCS.Text INTO #tmpSCCS
  FROM [Evitelx2].[dbo].[eClientCurrentStatus] CCS
  LEFT JOIN [Evitelx2].[dbo].[eSubClientCurrentStatus] SCCS ON  SCCS.ClientCurrentStatusId = CCS.ClientCurrentStatusId 

SELECT Sum(ClientCurrentStatusId),[Text]
  FROM [Evitelx2].[dbo].[eClientCurrentStatus]
  GROUP BY [Text]


** https://stackoverflow.com/questions/15745042/efficiently-convert-rows-to-columns-in-sql-server

DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX)

DROP TABLE IF EXISTS  #tmpSCCS
DROP TABLE IF EXISTS  ##tmp

SELECT SCCS.SubClientCurrentStatusId AS SCCSID, SCCS.Text AS SCCSTEXT INTO #tmpSCCS
  FROM [Evitelx2].[dbo].[eClientCurrentStatus] CCS
  LEFT JOIN [Evitelx2].[dbo].[eSubClientCurrentStatus] SCCS ON  SCCS.ClientCurrentStatusId = CCS.ClientCurrentStatusId 


select @cols = STUFF((SELECT ',' + QUOTENAME('ccs-'+SCCSTEXT) 
                    from #tmpSCCS
                    group by SCCSTEXT, SCCSID
                    order by SCCSID
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')  

SELECT @cols

set @query = N'SELECT SCCS.SubClientCurrentStatusId AS SCCSID, SCCS.Text AS SCCSTEXT  INTO #tmpSCCS
  FROM [Evitelx2].[dbo].[eClientCurrentStatus] CCS
  LEFT JOIN [Evitelx2].[dbo].[eSubClientCurrentStatus] SCCS ON  SCCS.ClientCurrentStatusId = CCS.ClientCurrentStatusId; '


set @query =  @query + N' SELECT ' + @cols + N' INTO ##tmp from 
             (
                select SCCSID, SCCSTEXT
                from [#tmpSCCS]
            ) x
            pivot 
            (
                max(SCCSID)
                for SCCSTEXT in (' + @cols + N')
            ) p '

print @query;
exec sp_executesql @query;


SELECt * FROM ##tmp


SELECT * FROM ##tmp

SELECT * FROm LPK,case when LpkId > 0 Then 
LEFT JOIN ##tmp ON LPK.LpkID != ##tmp.[Pl·Ë]

------------


DECLARE @Id int
DECLARE @lastLPKId int=0
DECLARE @LPKId int
DECLARE @LPKSubClientCurrentStatusEID int
DECLARE @Text nvarchar(255)
DECLARE @query NVARCHAR(MAX)


DECLARE db_cursor CURSOR FOR 
SELECT [LPKSubClientCurrentStatusEID],LPKId,Text
FROM [dbo].[LPKClientCurrentStatus]
LEFT JOIN [dbo].[eSubClientCurrentStatus] ON [dbo].[LPKClientCurrentStatus].LPKSubClientCurrentStatusEID = [dbo].[eSubClientCurrentStatus].SubClientCurrentStatusId 
ORDER BY LPKId
OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @Id,@LPKId,@Text
WHILE @@FETCH_STATUS = 0  
BEGIN
	if (@lastLPKId != @LPKId) BEGIN
		set @query =  'INSERT INTO ##tmp (LPKId,[ccs-'+@Text+']) VALUES ('+CAST(@LPKId AS nVarchar(10)) +',1)'
	END ELSE BEGIN
		set @query =  'UPDATE  ##tmp SET [ccs-'+@Text+']=1 WHERE LPKId = '+CAST(@LPKId AS nVarchar(10))
	END
	SET @lastLPKId = @LPKId
	print @query
	exec sp_executesql @query;
	SET @lastLPKId = @LPKId
	FETCH NEXT FROM db_cursor INTO @Id,@LPKId,@Text
END 
CLOSE db_cursor  
DEALLOCATE db_cursor 
SELECT * FROM ##tmp
------------------

SELECT * FROM [dbo].[LPKClientCurrentStatus]
ORDER BY LPKId
DELETE FROM ##tmp
