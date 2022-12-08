-- Script na práci s Excelem v prostøedí SQLServer (i Express)
-- 1 . Je tøeba nainstalovat Microsoft.ACE.OLEDB.12.0
-- 2. Nakonfigurovat SQl Server
-- 3. SQL server musí bìžet pod právy Local System (bìží pod NT Service\SQLServer). Tak jsem ho pøehodil ale nevím jak nazpìt
-- 4. Pak lze použít OPENROWSET nebo LINKEDSERVER


USE Evitel2
sp_configure 'show advanced options', 1;
RECONFIGURE;
GO
sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;
GOEXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1
GO
EXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParameters', 1
GO

USE [Evitel2]
GO

SELECT * 
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0; Database=h:\Drive\ZDENEK\Word\Nabidky\2022\Simona\Jednani20221202\a.xlsx', [List1$]);
GO


EXEC sp_addlinkedserver
    @server = 'ExcelServer2',
    @srvproduct = 'Excel',
    @provider = 'Microsoft.ACE.OLEDB.12.0',
    @datasrc = 'h:\Drive\ZDENEK\Word\Nabidky\2022\Simona\Jednani20221202\a.xlsx',
    @provstr = 'Excel 12.0;IMEX=1;HDR=YES;'

EXEC sp_addlinkedserver
    @server = 'ExcelServer1',
    @srvproduct = 'Excel',
    @provider = 'Microsoft.Jet.OLEDB.4.0',
    @datasrc = 'C:\Test\excel-sql-server.xls',
    @provstr = 'Excel 8.0;IMEX=1;HDR=YES;'

EXEC sp_dropserver
    @server = N'ExcelServer2',
    @droplogins='droplogins'


INSERT INTO [dbo].[Intervents]
           ([Rank]
           ,[Title]
           ,[Name]
           ,[SurName]
           ,[Phone]
           ,[MobilPhone]
           ,[PrivatePhone]
           ,[Email]
           ,[dtDeleted]
           ,[Note]
           ,[RegionId])
     SELECT F2,F3,F5,F4,F6,F7,F8,F9,NULL,'',8 FROM  ExcelServer2...List1$ WHERE F2 != 'hodnost'
GO

SELECT * FROM [dbo].[Intervents]
SELECT * FROM [dbo].[Regions]

DBCC checkident ('Intervents',reseed,1)
DBCC checkident ('Intervents')


SELECT * from ExcelServer2...List1$  WHERE F2 != 'hodnost'


SELECt DISTINCT regionId  FROm Intervents
