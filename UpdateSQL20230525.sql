USE [Evitel2]
GO
/****** Object:  StoredProcedure [dbo].[RotateClientCurrentStatus]    Script Date: 25.05.2023 20:00:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- https://stackoverflow.com/questions/15745042/efficiently-convert-rows-to-columns-in-sql-server



/*

-- 25.5.2023 - ZPT 


	EXEC [RotateClientCurrentStatus] '##tmpCSS' 
	SELECt * FROM ##tmpCSS
*/

CREATE Procedure [dbo].[RotateClientCurrentStatus] @TABLENAME nvarchar(255) 
AS BEGIN

DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX)

DROP TABLE IF EXISTS  #tmpSCCS
SELECT @query = 'DROP TABLE If Exists ' + QUOTENAME(@TABLENAME) + '';
exec sp_executesql @query;

SELECT SCCS.SubClientCurrentStatusId AS SCCSID, SCCS.Text AS SCCSTEXT  INTO #tmpSCCS 
  FROM [dbo].[eClientCurrentStatus] CCS
  LEFT JOIN [dbo].[eSubClientCurrentStatus] SCCS ON  SCCS.ClientCurrentStatusId = CCS.ClientCurrentStatusId 


select @cols = STUFF((SELECT ',' + QUOTENAME('Status-'+SCCSTEXT) 
                    from #tmpSCCS
                    group by SCCSTEXT, SCCSID
                    order by SCCSID
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')  
select @cols = '[LPKId],' + @cols


set @query = N'SELECT SCCS.SubClientCurrentStatusId AS SCCSID, SCCS.Text AS SCCSTEXT  INTO #tmpSCCS
  FROM [eClientCurrentStatus] CCS
  LEFT JOIN [eSubClientCurrentStatus] SCCS ON  SCCS.ClientCurrentStatusId = CCS.ClientCurrentStatusId; '


set @query =  @query + N' SELECT ' + @cols + N' INTO '+@TABLENAME+' from 
             (
                select SCCSID, SCCSTEXT
                from [#tmpSCCS]
            ) x
            pivot 
            (
                max(SCCSID)
                for SCCSTEXT in (' + @cols + N')
            ) p '


exec sp_executesql @query;

END


/****** Object:  StoredProcedure [dbo].[RotateContactTopic]    Script Date: 25.05.2023 20:00:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- https://stackoverflow.com/questions/15745042/efficiently-convert-rows-to-columns-in-sql-server



/*

-- 25.5.2023 - ZPT 


	EXEC [RotateContactTopic] '##tmpCT' 
	SELECt * FROM ##tmpCT


*/

-- ContactTopic
Create Procedure [dbo].[RotateContactTopic] @TABLENAME nvarchar(255) 
AS BEGIN



DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX)

DROP TABLE IF EXISTS  #tmpSCT
SELECT @query = 'DROP TABLE If Exists ' + QUOTENAME(@TABLENAME) + '';
exec sp_executesql @query;

SELECT SCT.SubContactTopicId AS SCTID, SCT.Text AS SCTTEXT INTO #tmpSCT
  FROM [dbo].[eContactTopic] CT
  LEFT JOIN [dbo].[eSubContactTopic] SCT ON  SCT.ContactTopicId = CT.ContactTopicId 


select @cols = STUFF((SELECT ',' + QUOTENAME('Topic-'+SCTTEXT) 
                    from #tmpSCT
                    group by SCTTEXT, SCTID
                    order by SCTID
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')  
select @cols = '[LPKId],' + @cols


set @query = N'SELECT SCT.SubContactTopicId AS SCTID, SCT.Text AS SCTTEXT  INTO #tmpSCCS
  FROM [eContactTopic] CT
  LEFT JOIN [eSubContactTopic] SCT ON  SCT.ContactTopicId = CT.ContactTopicId; '


set @query =  @query + N' SELECT ' + @cols + N' INTO '+@TABLENAME+' from 
             (
                select SCTID, SCTTEXT
                from [#tmpSCCS]
            ) x
            pivot 
            (
                max(SCTID)
                for SCTTEXT in (' + @cols + N')
            ) p '


exec sp_executesql @query;

END



/****** Object:  StoredProcedure [dbo].[RotateEndOfSpeech]    Script Date: 25.05.2023 20:01:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*

-- 25.5.2023 - ZPT 


	EXEC RotateEndOfSpeech '##tmpEOS' 
	SELECt * FROM ##tmpEOS


*/

-- EndOfSpeech
CREATE Procedure [dbo].[RotateEndOfSpeech] @TABLENAME nvarchar(255) 
AS BEGIN



DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX)

DROP TABLE IF EXISTS  #tmpEOS
SELECT @query = 'DROP TABLE If Exists ' + QUOTENAME(@TABLENAME) + '';
exec sp_executesql @query;

SELECT SEOS.SubEndOfSpeechId AS SEOSID, SEOS.Text AS SEOSTEXT INTO #tmpEOS
  FROM [dbo].[eEndOfSpeech] EOS
  LEFT JOIN [dbo].[eSubEndOfSpeech] SEOS ON  SEOS.EndOfSpeechId = EOS.EndOfSpeechId 


select @cols = STUFF((SELECT ',' + QUOTENAME('End-'+SEOSTEXT) 
                    from #tmpEOS
                    group by SEOSTEXT, SEOSID
                    order by SEOSID
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')  
select @cols = '[LPKId],' + @cols
print @cols

set @query = N'SELECT SEOS.EndOfSpeechId AS SEOSID, SEOS.Text AS SEOSTEXT  INTO #tmpEOS
  FROM [eEndOfSpeech] EOS
  LEFT JOIN [eEndOfSpeech] SEOS ON  SEOS.EndOfSpeechId = EOS.EndOfSpeechId; '


set @query =  @query + N' SELECT ' + @cols + N' INTO '+@TABLENAME+' from 
             (
                select SEOSID, SEOSTEXT
                from [#tmpEOS]
            ) x
            pivot 
            (
                max(SEOSID)
                for SEOSTEXT in (' + @cols + N')
            ) p '


exec sp_executesql @query;

END

/****** Object:  StoredProcedure [dbo].[wLPKFull]    Script Date: 25.05.2023 20:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
-- 25.5.2023 - ZPT 
 EXEC [dbo].[wLPKFull]
*/

CREATE PROCEDURE [dbo].[wLPKFull]
AS
BEGIN
SET NOCOUNT ON;
DECLARE @Id int
DECLARE @lastLPKId int=0
DECLARE @LPKId int
DECLARE @LPKSubClientCurrentStatusEID int
DECLARE @Text nvarchar(255)
DECLARE @query NVARCHAR(MAX)

	EXEC [RotateClientCurrentStatus] '##tmpCSS' 
	EXEC [RotateContactTopic]'##tmpCT' 
	EXEC [RotateEndOfSpeech] '##tmpEOS' 


DROP TABLE IF EXISTS ##tmpCSS 
DROP TABLE IF EXISTS ##tmpCT 
DROP TABLE IF EXISTS ##tmpEOS 

-- tmpCSS - ClientCurrentStatus
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
		set @query =  'INSERT INTO ##tmpCSS (LPKId,[Status-'+@Text+']) VALUES ('+CAST(@LPKId AS nVarchar(10)) +',1)'
	END ELSE BEGIN
		set @query =  'UPDATE  ##tmpCSS SET [Status-'+@Text+']=1 WHERE LPKId = '+CAST(@LPKId AS nVarchar(10))
	END
	SET @lastLPKId = @LPKId
	exec sp_executesql @query;
	SET @lastLPKId = @LPKId
	FETCH NEXT FROM db_cursor INTO @Id,@LPKId,@Text
END 
CLOSE db_cursor  
DEALLOCATE db_cursor 
------------------
-- tmpCT - ContactTopic
DECLARE db_cursor CURSOR FOR 
SELECT [LPKSubContactTopicEID],LPKId,Text
FROM [dbo].[LPKSubContactTopic]
LEFT JOIN [dbo].[eSubContactTopic] ON [dbo].[LPKSubContactTopic].LPKSubContactTopicEID = [dbo].[eSubContactTopic].SubContactTopicId 
ORDER BY LPKId
OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @Id,@LPKId,@Text
WHILE @@FETCH_STATUS = 0  
BEGIN
	if (@lastLPKId != @LPKId) BEGIN
		set @query =  'INSERT INTO ##tmpCT (LPKId,[Topic-'+@Text+']) VALUES ('+CAST(@LPKId AS nVarchar(10)) +',1)'
	END ELSE BEGIN
		set @query =  'UPDATE  ##tmpCT SET [Topic-'+@Text+']=1 WHERE LPKId = '+CAST(@LPKId AS nVarchar(10))
	END
	SET @lastLPKId = @LPKId
	exec sp_executesql @query;
	SET @lastLPKId = @LPKId
	FETCH NEXT FROM db_cursor INTO @Id,@LPKId,@Text
END 
CLOSE db_cursor  
DEALLOCATE db_cursor 


-- tmpCSS - ClientCurrentStatus
DECLARE db_cursor CURSOR FOR 
SELECT [LPKSubEndOfSpeechEID],LPKId,Text
FROM [dbo].[LPKSubEndOfSpeech]
LEFT JOIN [dbo].[eSubEndOfSpeech] ON [LPKSubEndOfSpeech].LPKSubEndOfSpeechEID = [eSubEndOfSpeech].SubEndOfSpeechId 
ORDER BY LPKId
OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @Id,@LPKId,@Text
WHILE @@FETCH_STATUS = 0  
BEGIN
	if (@lastLPKId != @LPKId) BEGIN
		set @query =  'INSERT INTO ##tmpEOS (LPKId,[End-'+@Text+']) VALUES ('+CAST(@LPKId AS nVarchar(10)) +',1)'
	END ELSE BEGIN
		set @query =  'UPDATE  ##tmpEOS SET [End-'+@Text+']=1 WHERE LPKId = '+CAST(@LPKId AS nVarchar(10))
	END
	SET @lastLPKId = @LPKId
	exec sp_executesql @query;
	SET @lastLPKId = @LPKId
	FETCH NEXT FROM db_cursor INTO @Id,@LPKId,@Text
END 
CLOSE db_cursor  
DEALLOCATE db_cursor 




SELECT * FROM [dbo].[wLPK] W
LEFT JOIN ##tmpCSS CSS ON W.LPKId = CSS.LPKId
LEFT JOIN ##tmpCT CT ON W.LPKId = CT.LPKId
LEFT JOIN ##tmpEOS EOS ON W.LPKId = EOS.LPKId

DROP TABLE ##tmpCSS 
DROP TABLE ##tmpCT 
DROP TABLE ##tmpEOS 
END







