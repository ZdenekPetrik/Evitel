-- https://stackoverflow.com/questions/15745042/efficiently-convert-rows-to-columns-in-sql-server

/*
	DROP TABLE  ##tmp;
	DROP TABLE IF EXISTS  ##tmp
	RotateCCS '##tmp'
	SELECt * FROM ##tmp
*/

ALTER Procedure RotateCCS @tmpTableName nvarchar(255) 
AS BEGIN

DECLARE @tmpTableName AS NVARCHAR(MAX) = '##tmp'
DECLARE @cols AS NVARCHAR(MAX), @query  AS NVARCHAR(MAX)
DROP TABLE IF EXISTS  #tmpSCCS
DROP TABLE IF EXISTS  ##tmp


SELECT SCCS.SubClientCurrentStatusId AS SCCSID, SCCS.Text AS SCCSTEXT INTO #tmpSCCS
  FROM [dbo].[eClientCurrentStatus] CCS
  LEFT JOIN [dbo].[eSubClientCurrentStatus] SCCS ON  SCCS.ClientCurrentStatusId = CCS.ClientCurrentStatusId 


select @cols = STUFF((SELECT ',' + QUOTENAME('ccs-'+SCCSTEXT) 
                    from #tmpSCCS
                    group by SCCSTEXT, SCCSID
                    order by SCCSID
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')  
select @cols = '[LPKId],' + @cols


set @query = N'SELECT SCCS.SubClientCurrentStatusId AS SCCSID, SCCS.Text AS SCCSTEXT  INTO '+@tmpTableName+' 
  FROM [Evitelx2].[dbo].[eClientCurrentStatus] CCS
  LEFT JOIN [Evitelx2].[dbo].[eSubClientCurrentStatus] SCCS ON  SCCS.ClientCurrentStatusId = CCS.ClientCurrentStatusId; '


set @query =  @query + N' SELECT ' + @cols + N' INTO '+@tmpTableName+'  from 
             (
                select SCCSID, SCCSTEXT
                from [#tmpSCCS]
            ) x
            pivot 
            (
                max(SCCSID)
                for SCCSTEXT in (' + @cols + N')
            ) p '

-- print @query;
exec sp_executesql @query;
SELECT * FROM ##tmp
END
