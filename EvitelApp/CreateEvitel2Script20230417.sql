USE [Evitel2]
GO
/****** Object:  Table [dbo].[eSex]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eSex](
	[SexId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eSex] PRIMARY KEY CLUSTERED 
(
	[SexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LPK]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LPK](
	[LPKId] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[ContactTypeEID] [int] NOT NULL,
	[TypeServiceEID] [int] NOT NULL,
	[ClientFromEID] [int] NOT NULL,
	[SexEID] [int] NOT NULL,
	[AgeEID] [int] NOT NULL,
	[Nick] [nvarchar](50) NULL,
	[CallId] [int] NOT NULL,
	[ContactTopicEID] [int] NULL,
 CONSTRAINT [PK_LPKId] PRIMARY KEY CLUSTERED 
(
	[LPKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginUsers]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUsers](
	[LoginUserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[LoginName] [nvarchar](50) NULL,
	[LoginPassword] [nvarchar](50) NULL,
	[Created] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_LoginUsers] PRIMARY KEY CLUSTERED 
(
	[LoginUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ShortName] [nvarchar](10) NULL,
	[Name2] [nvarchar](50) NULL,
	[RegionOrder] [int] NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Intervents]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intervents](
	[InterventId] [int] IDENTITY(1,1) NOT NULL,
	[Rank] [nvarchar](50) NULL,
	[Title] [nvarchar](20) NULL,
	[Name] [nvarchar](50) NULL,
	[SurName] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[MobilPhone] [nvarchar](20) NULL,
	[PrivatePhone] [nvarchar](20) NULL,
	[Email] [nvarchar](255) NULL,
	[dtDeleted] [datetime2](7) NULL,
	[Note] [nvarchar](max) NULL,
	[RegionId] [int] NULL,
	[dtCreate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Intervents] PRIMARY KEY CLUSTERED 
(
	[InterventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[wIntervent]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 

   v1.0 01.01.2023 ZPT
   v1.1 25.02.2023 ZPT cmbName nejprve přijmení

-- SELECT * FROM [dbo].[wIntervent]
*/




CREATE VIEW [dbo].[wIntervent]
AS
SELECT        dbo.Intervents.InterventId, dbo.Intervents.Rank, dbo.Intervents.Title, dbo.Intervents.Name, dbo.Intervents.SurName, dbo.Regions.Name AS RegionName, dbo.Regions.RegionOrder, 
                         dbo.Regions.ShortName AS RegionShortName, dbo.Intervents.SurName + N' ' +  dbo.Intervents.Name + N' (' + dbo.Regions.ShortName + N')'  AS cmbName, Phone, MobilPhone, PrivatePhone, Email, dbo.Intervents.dtCreate,  CAST(IIF(dbo.Intervents.dtDeleted IS NULL,0,1) AS BIT) isDeleted, dbo.Intervents.RegionId,
						  dbo.Intervents.SurName + CASE WHEN dbo.Intervents.[Name] is NULL OR LEN(dbo.Intervents.[Name]) =0 THEN '' ELSE ' '+ LEFT(dbo.Intervents.Name,1)+'.' END AS InterventShortName
FROM            dbo.Intervents INNER JOIN
                         dbo.Regions ON dbo.Intervents.RegionId = dbo.Regions.RegionId
GO
/****** Object:  Table [dbo].[Calls]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calls](
	[CallId] [int] IDENTITY(1,1) NOT NULL,
	[dtStartCall] [datetime2](7) NULL,
	[dtEndCall] [datetime2](7) NULL,
	[LoginUserId] [int] NULL,
	[callType] [int] NULL,
 CONSTRAINT [PK_Calls] PRIMARY KEY CLUSTERED 
(
	[CallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIKOIntervence]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIKOIntervence](
	[LIKOIntervenceId] [int] IDENTITY(1,1) NOT NULL,
	[CallId] [int] NULL,
	[LIKOIncidentId] [int] NULL,
	[dtStartIntervence] [datetime2](7) NULL,
	[dtEndIntervence] [datetime2](7) NULL,
	[Note] [nvarchar](max) NULL,
	[ObetemPoskozenym] [int] NULL,
	[PozustalymBlizkym] [int] NULL,
	[Ostatnim] [int] NULL,
	[LIKOIntervenceIDMaster] [int] NULL,
	[InterventId] [int] NULL,
	[Poradi] [int] NULL,
 CONSTRAINT [PK_LIKOIntervence] PRIMARY KEY CLUSTERED 
(
	[LIKOIntervenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eCallType]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eCallType](
	[callTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eCallType] PRIMARY KEY CLUSTERED 
(
	[callTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eContactType]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eContactType](
	[ContactTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eContactType] PRIMARY KEY CLUSTERED 
(
	[ContactTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[wCalls]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* SELECT * from [dbo].[wCalls]*/
-- 1.4.2023 - ZPT doplneni YEAR/MONTH
CREATE VIEW [dbo].[wCalls]
AS
SELECT        Cll.CallId, dbo.LIKOIntervence.LIKOIntervenceId, dbo.LPK.LPKId, Cll.dtStartCall, CAST(Cll.dtStartCall AS Date) AS dtCall, CONVERT(varchar(8), DATEADD(second, DATEDIFF(second, CAST(Cll.dtStartCall AS Date), Cll.dtStartCall), 0), 114) AS tmStartCall
			, CONVERT(varchar(8), DATEADD(second, DATEDIFF(second, CAST(Cll.dtEndCall AS Date), Cll.dtEndCall), 0), 114) AS tmEndCall, CONVERT(varchar(8), DATEADD(second, DATEDIFF(second, Cll.dtStartCall, Cll.dtEndCall), 0), 114) AS tmDuration
			, Cll.LoginUserId, usr.FirstName AS usrFirstName, usr.LastName AS usrLastName, dbo.wIntervent.InterventId, dbo.wIntervent.InterventShortName, dbo.wIntervent.RegionName, dbo.LPK.Nick
			,  dbo.eCallType.Text AS CallType, dbo.eContactType.Text AS ContactType, Cll.dtEndCall, dbo.eCallType.callTypeId,YEAR(Cll.dtStartCall) as [Year], MONTH(Cll.dtStartCall) as [Month]
FROM            dbo.Calls AS Cll LEFT OUTER JOIN
                         dbo.LIKOIntervence ON Cll.CallId = dbo.LIKOIntervence.CallId LEFT OUTER JOIN
                         dbo.wIntervent ON dbo.LIKOIntervence.InterventId = dbo.wIntervent.InterventId LEFT OUTER JOIN
                         dbo.LoginUsers AS usr ON usr.LoginUserId = Cll.LoginUserId LEFT OUTER JOIN
                         dbo.LPK ON Cll.CallId = dbo.LPK.CallId LEFT OUTER JOIN
                         dbo.eCallType ON Cll.callType = dbo.eCallType.callTypeId LEFT OUTER JOIN
                         dbo.eContactType ON dbo.LPK.ContactTypeEID = dbo.eContactType.ContactTypeId
GO
/****** Object:  Table [dbo].[eSubEndOfSpeech]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eSubEndOfSpeech](
	[SubEndOfSpeechId] [int] IDENTITY(1,1) NOT NULL,
	[EndOfSpeechId] [int] NULL,
	[Text] [nvarchar](255) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eSubEndOfSpeech] PRIMARY KEY CLUSTERED 
(
	[SubEndOfSpeechId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eSubClientCurrentStatus]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eSubClientCurrentStatus](
	[SubClientCurrentStatusId] [int] IDENTITY(1,1) NOT NULL,
	[ClientCurrentStatusId] [int] NULL,
	[Text] [nvarchar](255) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eSubClientCurrentStatus] PRIMARY KEY CLUSTERED 
(
	[SubClientCurrentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eSubContactTopic]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eSubContactTopic](
	[SubContactTopicId] [int] IDENTITY(1,1) NOT NULL,
	[ContactTopicId] [int] NULL,
	[Text] [nvarchar](255) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eSubContactTopic] PRIMARY KEY CLUSTERED 
(
	[SubContactTopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eAge]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eAge](
	[AgeId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eAge] PRIMARY KEY CLUSTERED 
(
	[AgeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eTypeService]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eTypeService](
	[TypeServiceId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eTypeService] PRIMARY KEY CLUSTERED 
(
	[TypeServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eClientFrom]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eClientFrom](
	[ClientFromId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eClientFrom] PRIMARY KEY CLUSTERED 
(
	[ClientFromId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LPKClientCurrentStatus]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LPKClientCurrentStatus](
	[LPKSubClientCurentStatus] [int] IDENTITY(1,1) NOT NULL,
	[LPKSubClientCurrentStatusEID] [int] NULL,
	[LPKId] [int] NULL,
 CONSTRAINT [PK_LPKClientCurrentStatus] PRIMARY KEY CLUSTERED 
(
	[LPKSubClientCurentStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LPKSubContactTopic]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LPKSubContactTopic](
	[LPKSubContactTopicID] [int] IDENTITY(1,1) NOT NULL,
	[LPKSubContactTopicEID] [int] NULL,
	[LPKId] [int] NULL,
 CONSTRAINT [PK_LPKSubContactTopic] PRIMARY KEY CLUSTERED 
(
	[LPKSubContactTopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LPKSubEndOfSpeech]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LPKSubEndOfSpeech](
	[LPKSubEndOfSpeechID] [int] IDENTITY(1,1) NOT NULL,
	[LPKSubEndOfSpeechEID] [int] NULL,
	[LPKId] [int] NULL,
 CONSTRAINT [PK_LPKSubEndOfSpeech] PRIMARY KEY CLUSTERED 
(
	[LPKSubEndOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[wLPK]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*    SELECT * FROM [dbo].[wLPK]*/
CREATE VIEW [dbo].[wLPK]
AS
SELECT        TOP (1000) dbo.LPK.LPKId, dbo.LPK.Note, dbo.LPK.ContactTypeEID, dbo.LPK.TypeServiceEID, dbo.LPK.ClientFromEID, dbo.LPK.SexEID, dbo.LPK.AgeEID, dbo.LPK.CallId, dbo.eAge.Text AS Age, 
                         dbo.eTypeService.Text AS TypeService, dbo.eClientFrom.Text AS ClientFrom, dbo.eSex.Text AS Sex, dbo.wCalls.dtStartCall, dbo.wCalls.dtCall, dbo.wCalls.tmStartCall, dbo.wCalls.tmEndCall, dbo.wCalls.tmDuration, 
                         dbo.wCalls.LoginUserId, dbo.wCalls.usrFirstName, dbo.wCalls.usrLastName, dbo.wCalls.Nick, dbo.wCalls.CallType, dbo.wCalls.ContactType, dbo.wCalls.dtEndCall, eos.ClientCurrentStatus, ct.ContactTopic, ccs.EndOfSpeech, 
                         MONTH(dbo.wCalls.dtStartCall) AS call_Month, YEAR(dbo.wCalls.dtStartCall) AS call_Year
FROM            dbo.LPK LEFT OUTER JOIN
                         dbo.eAge ON dbo.LPK.AgeEID = dbo.eAge.AgeId LEFT OUTER JOIN
                         dbo.eTypeService ON dbo.LPK.TypeServiceEID = dbo.eTypeService.TypeServiceId LEFT OUTER JOIN
                         dbo.eClientFrom ON dbo.LPK.ClientFromEID = dbo.eClientFrom.ClientFromId LEFT OUTER JOIN
                         dbo.eSex ON dbo.LPK.SexEID = dbo.eSex.SexId LEFT OUTER JOIN
                         dbo.wCalls ON dbo.LPK.LPKId = dbo.wCalls.LPKId LEFT OUTER JOIN
                             (SELECT        dbo.LPKClientCurrentStatus.LPKId, STRING_AGG(dbo.eSubClientCurrentStatus.Text, ', ') AS ClientCurrentStatus
                               FROM            dbo.eSubClientCurrentStatus RIGHT OUTER JOIN
                                                         dbo.LPKClientCurrentStatus ON dbo.LPKClientCurrentStatus.LPKSubClientCurrentStatusEID = dbo.eSubClientCurrentStatus.SubClientCurrentStatusId
                               GROUP BY dbo.LPKClientCurrentStatus.LPKId) AS eos ON eos.LPKId = dbo.LPK.LPKId LEFT OUTER JOIN
                             (SELECT        dbo.LPKSubContactTopic.LPKId, STRING_AGG(dbo.eSubContactTopic.Text, ', ') AS ContactTopic
                               FROM            dbo.eSubContactTopic RIGHT OUTER JOIN
                                                         dbo.LPKSubContactTopic ON dbo.LPKSubContactTopic.LPKSubContactTopicEID = dbo.eSubContactTopic.SubContactTopicId
                               GROUP BY dbo.LPKSubContactTopic.LPKId) AS ct ON ct.LPKId = dbo.LPK.LPKId LEFT OUTER JOIN
                             (SELECT        dbo.LPKSubEndOfSpeech.LPKId, STRING_AGG(dbo.eSubEndOfSpeech.Text, ', ') AS EndOfSpeech
                               FROM            dbo.eSubEndOfSpeech RIGHT OUTER JOIN
                                                         dbo.LPKSubEndOfSpeech ON dbo.LPKSubEndOfSpeech.LPKSubEndOfSpeechEID = dbo.eSubEndOfSpeech.SubEndOfSpeechId
                               GROUP BY dbo.LPKSubEndOfSpeech.LPKId) AS ccs ON ccs.LPKId = dbo.LPK.LPKId
GO
/****** Object:  Table [dbo].[LIKOIncidents]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIKOIncidents](
	[LIKOIncidentId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Note] [nvarchar](max) NULL,
	[SubTypeIncidentEID] [int] NULL,
	[RegionId] [int] NULL,
	[dtIncident] [datetime] NULL,
	[NasledekSmrti] [bit] NULL,
	[Dokonane] [bit] NULL,
	[Pokus_Priprava] [bit] NULL,
	[Place] [nvarchar](50) NULL,
	[PocetPoskozenych] [int] NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_LIKOIncidents] PRIMARY KEY CLUSTERED 
(
	[LIKOIncidentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eSubTypeIncident]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eSubTypeIncident](
	[SubTypeIncidentId] [int] IDENTITY(1,1) NOT NULL,
	[TypeIncidentId] [int] NULL,
	[Text] [nvarchar](255) NULL,
	[Kategorie] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eSubTypeIncident] PRIMARY KEY CLUSTERED 
(
	[SubTypeIncidentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[wLIKOIntervence]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/* 
   wLIKOAll spojuje tabulky LIKOParticipant  s LIKOIntervence a číselníky wintervents eTypeParty eDruhIntervence eSex
   v1.0 01.01.2023 ZPT
   v1.1 05.02.2023 ZPT plně přepracováno 
   v1.3 01.04.2023 - ZPT doplneni YEAR/MONTH

 SELECT * FROM [dbo].[wLIKOIntervence]
 */
CREATE VIEW [dbo].[wLIKOIntervence]
AS
SELECT       
Interv.dtEndIntervence,
CAST(Interv.dtEndIntervence   AS DATE) AS dtIntervEnd,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Interv.dtEndIntervence as Date) ,  Interv.dtEndIntervence),0),114) as   tmIntervEnd,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second,  Interv.dtStartIntervence, Interv.dtEndIntervence),0),114) AS tmIntervDuration,
Interv.Note AS Intrv_Note,
Interv.ObetemPoskozenym,
Interv.PozustalymBlizkym,
Interv.Ostatnim,
Interv.Poradi Interv_Poradi,
Interv.InterventId AS Intrv_Id,
Interv.LIKOIntervenceId AS LIKOIntervenceId,
calls.dtStartCall,
CAST(calls.dtStartCall AS DATE) AS dtCall,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(calls.dtStartCall as Date), calls.dtStartCall),0),114) as tmCall,
interinter.InterventShortName AS Volajici,
interinter.RegionName AS Volajici_Kraj,
calls.CallId,
Inc.dtIncident,
CAST(Inc.dtIncident AS DATE) AS dtUdalost,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Inc.dtIncident as Date), Inc.dtIncident),0),114) as tmUdalost,
reg.Name Udalost_Region,
Inc.Place AS Udalost_Misto,
Inc.Note AS Udalost_Note,
sti.Text AS Druh_Udalosti,
sti.Kategorie AS Kategorie_Udalosti,
Inc.NasledekSmrti,
Inc.Dokonane,
Inc.Pokus_Priprava,
Inc.PocetPoskozenych,
Inc.LIKOIncidentId,   
Interv.dtStartIntervence,
CAST(Interv.dtStartIntervence AS DATE) AS dtIntervStart,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Interv.dtStartIntervence as Date),Interv.dtStartIntervence),0),114) as tmIntervStart,
usr.LastName as UserLastName, usr.FirstName AS UserFirstName, usr.LoginUserId
,YEAR(calls.dtStartCall) as [Year], MONTH(calls.dtStartCall) as [Month]
FROM         
dbo.LIKOIntervence AS Interv LEFT OUTER JOIN
dbo.Calls AS calls ON Interv.CallId = calls.CallId LEFT OUTER JOIN
             dbo.LIKOIncidents AS Inc ON Inc.LIKOIncidentId = Interv.LIKOIncidentId LEFT OUTER JOIN
             dbo.wIntervent AS interinter ON Interv.InterventId = interinter.InterventId LEFT OUTER JOIN
             dbo.loginUsers AS usr ON calls.LoginUserId = usr.LoginUserId LEFT OUTER JOIN
             dbo.Regions AS reg ON Inc.RegionId = reg.RegionId LEFT OUTER JOIN
             dbo.eSubTypeIncident AS sti ON Inc.SubTypeIncidentEID = sti.SubTypeIncidentId
GO
/****** Object:  Table [dbo].[eDruhIntervence]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eDruhIntervence](
	[DruhIntervenceId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eDruhIntervence] PRIMARY KEY CLUSTERED 
(
	[DruhIntervenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eTypeParty]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eTypeParty](
	[TypePartyId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eTypeParty] PRIMARY KEY CLUSTERED 
(
	[TypePartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIKOParticipant]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIKOParticipant](
	[LIKOParticipantId] [int] IDENTITY(1,1) NOT NULL,
	[LIKOIntervenceId] [int] NOT NULL,
	[TypePartyEID] [int] NOT NULL,
	[SexEID] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[IsDead] [bit] NOT NULL,
	[IsInjury] [bit] NOT NULL,
	[IsIntervence] [bit] NOT NULL,
	[IsFirstIntervence] [bit] NOT NULL,
	[DruhIntervenceEID] [int] NULL,
	[InterventId] [int] NULL,
	[InterventId2] [int] NULL,
	[IsAgreement] [bit] NOT NULL,
	[IsAgreementBKB] [bit] NOT NULL,
	[IsContact] [bit] NOT NULL,
	[IsPolicement] [bit] NOT NULL,
	[IsPolicementClosePerson] [bit] NOT NULL,
	[IsSenior] [bit] NOT NULL,
	[IsChildJuvenile] [bit] NOT NULL,
	[IsHandyCappedMedical] [bit] NOT NULL,
	[IsHandyCappedMentally] [bit] NOT NULL,
	[IsMemberMinorityGroup] [bit] NOT NULL,
	[Organization] [nvarchar](255) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_LIKOParticipant] PRIMARY KEY CLUSTERED 
(
	[LIKOParticipantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[wLIKOAll]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/* 
   wLIKOAll spojuje tabulky LIKOParticipant  s LIKOIntervence a číselníky wintervents eTypeParty eDruhIntervence eSex
   v1.0 01.01.2023 ZPT
   v1.1 05.02.2023 ZPT plně přepracováno 
   v1.1 18.03.2023 ZPT Rok a mesic incidentu, zruseni Nasledek smrti,Dokonaná, pokus/příprava,
   v1.3 1.4.2023 - ZPT doplneni YEAR/MONTH
 SELECT * FROM [dbo].[wLIKOAll]
 */
CREATE VIEW [dbo].[wLIKOAll]
AS
SELECT       
calls.dtStartCall,
CAST(calls.dtStartCall AS DATE) AS dtCall,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(calls.dtStartCall as Date), calls.dtStartCall),0),114) as tmCall,
interinter.InterventShortName AS Volajici,
interinter.RegionName AS Volajici_Kraj,
calls.CallId,
Inc.dtIncident,
MONTH(Inc.dtIncident) AS Udalost_Month,
YEAR(Inc.dtIncident) AS Udalost_Year,
CAST(Inc.dtIncident AS DATE) AS dtUdalost,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Inc.dtIncident as Date), Inc.dtIncident),0),114) as tmUdalost,
reg.Name Udalost_Region,
Inc.Place AS Udalost_Misto,
Inc.Note AS Udalost_Note,
sti.Text AS Druh_Udalosti,
sti.Kategorie AS Kategorie_Udalosti,
Inc.PocetPoskozenych,
Inc.LIKOIncidentId AS Udalost_Id,  
Interv.LIKOIntervenceId AS Intervence_Id,
Interv.dtStartIntervence,
CAST(Interv.dtStartIntervence AS DATE) AS dtIntervStart,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Interv.dtStartIntervence as Date),Interv.dtStartIntervence),0),114) as tmIntervStart,
Interv.dtEndIntervence,
CAST(Interv.dtEndIntervence   AS DATE) AS dtIntervEnd,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Interv.dtEndIntervence as Date) ,  Interv.dtEndIntervence),0),114) as   tmIntervEnd,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second,  Interv.dtStartIntervence, Interv.dtEndIntervence),0),114) AS tmIntervDuration,
Interv.Note AS Intrv_Note,
Interv.ObetemPoskozenym,
Interv.PozustalymBlizkym,
Interv.Ostatnim,
Interv.Poradi Interv_Poradi,
Interv.InterventId AS Intrv_Id,
Interv.LIKOIntervenceId AS LIKOIntervenceId,
TypeParty.Text AS TypePartyText,
Sex.Text AS SexText,
P.Age,P.IsDead, P.IsInjury, P.IsIntervence, P.IsFirstIntervence, 
DruhInt.Text AS DruhIntervence,
pintervent.InterventShortName AS InterventName,
pintervent.RegionName,
P.InterventId2,
pintervent2.InterventShortName AS Intervent2Name, 
P.IsAgreement,
P.IsAgreementBKB,
P.IsContact,  P.IsPolicement, P.IsPolicementClosePerson, P.IsSenior, P.IsChildJuvenile, P.IsHandyCappedMedical, P.IsHandyCappedMentally, P.IsMemberMinorityGroup, P.Organization, 
P.Note, P.LIKOParticipantId AS ParticipantId,
usr.LastName as UserLastName, usr.FirstName AS UserFirstName, usr.LoginUserId
,YEAR(calls.dtStartCall) as [Year], MONTH(calls.dtStartCall) as [Month]
FROM         dbo.LIKOParticipant AS P INNER JOIN
             dbo.LIKOIntervence AS Interv ON Interv.LIKOIntervenceId = P.LIKOIntervenceId LEFT OUTER JOIN
             dbo.Calls AS calls ON Interv.CallId = calls.CallId LEFT OUTER JOIN
             dbo.LIKOIncidents AS Inc ON Inc.LIKOIncidentId = Interv.LIKOIncidentId LEFT OUTER JOIN
             dbo.eTypeParty AS TypeParty ON P.TypePartyEID = TypeParty.TypePartyId LEFT OUTER JOIN
             dbo.eSex AS Sex ON P.SexEID = Sex.SexId LEFT OUTER JOIN
             dbo.eDruhIntervence AS DruhInt ON P.DruhIntervenceEID = DruhInt.DruhIntervenceId LEFT OUTER JOIN
             dbo.wIntervent AS pintervent ON P.InterventId = pintervent.InterventId LEFT OUTER JOIN
             dbo.wIntervent AS pintervent2 ON P.InterventId2 = pintervent2.InterventId LEFT OUTER JOIN
             dbo.wIntervent AS interinter ON Interv.InterventId = interinter.InterventId LEFT OUTER JOIN
             dbo.loginUsers AS usr ON calls.LoginUserId = usr.LoginUserId LEFT OUTER JOIN
             dbo.Regions AS reg ON Inc.RegionId = reg.RegionId LEFT OUTER JOIN
             dbo.eSubTypeIncident AS sti ON Inc.SubTypeIncidentEID = sti.SubTypeIncidentId
GO
/****** Object:  View [dbo].[wLIKOCalls]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- SELECT * from [dbo].[wLIKOCalls]
-- 1.4.2023 - ZPT doplneni YEAR/MONTH

CREATE VIEW [dbo].[wLIKOCalls]
AS
SELECT        Cll.CallId,dbo.LIKOIntervence.LIKOIntervenceId,Cll.dtStartCall,YEAR(Cll.dtStartCall) as [Year], MONTH(Cll.dtStartCall) as [Month],
			  CAST(Cll.dtStartCall as Date) as dtCall,
			  CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Cll.dtStartCall as Date), Cll.dtStartCall),0),114) as tmStartCall,
			  Cll.LoginUserId, usr.FirstName AS usrFirstName, 
              usr.LastName AS usrLastName, dbo.wIntervent.InterventId,  dbo.wIntervent.InterventShortName , dbo.wIntervent.RegionName, ct.Text as CallType
						
FROM            dbo.Calls AS Cll INNER JOIN
				dbo.eCallType AS ct ON ct.callTypeId = Cll.callType INNER JOIN 
                         dbo.LIKOIntervence ON Cll.CallId = dbo.LIKOIntervence.CallId LEFT OUTER JOIN
                         dbo.wIntervent ON dbo.LIKOIntervence.InterventId = dbo.wIntervent.InterventId LEFT OUTER JOIN
                         dbo.LoginUsers AS usr ON usr.LoginUserId = Cll.LoginUserId 
GO
/****** Object:  View [dbo].[wLIKOIntervenceOld]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/* 
   wIntervence spojuje tabulky LIKOIntervence s Intervents a LIKOCalls
   navic zobrazuje speciální 2 sloupce s rozděleným datumem a časem. 
   v1.0 01.01.2023 ZPT
*/

-- SELECT * from wLIKOIntervence

CREATE VIEW [dbo].[wLIKOIntervenceOld]
AS
SELECT        dbo.LIKOIntervence.LIKOIntervenceId, dbo.LIKOIntervence.CallId, dbo.LIKOIntervence.LIKOIncidentId, dbo.LIKOIntervence.dtStartIntervence, dbo.LIKOIntervence.dtEndIntervence, dbo.LIKOIntervence.Note, 
              dbo.LIKOIntervence.ObetemPoskozenym, dbo.LIKOIntervence.PozustalymBlizkym, dbo.LIKOIntervence.Ostatnim, dbo.LIKOIntervence.LIKOIntervenceIDMaster, dbo.wLIKOCalls.dtStartCall,  
             dbo.wLIKOCalls.LoginUserId, dbo.wLIKOCalls.usrFirstName, dbo.wLIKOCalls.usrLastName, dbo.wIntervent.InterventId,dbo.wIntervent.InterventShortName , dbo.wIntervent.RegionName,
			 CAST(dbo.LIKOIntervence.dtStartIntervence as Date) as dateStartIntervence,
			 CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(dbo.LIKOIntervence.dtStartIntervence as Date), dbo.LIKOIntervence.dtStartIntervence),0),114) as timeStartIntervence,
			 dbo.LIKOIntervence.Poradi
FROM            dbo.LIKOIntervence LEFT OUTER JOIN
                         dbo.wLIKOCalls ON dbo.LIKOIntervence.CallId = dbo.wLIKOCalls.CallId LEFT JOIN
						 dbo.wIntervent ON dbo.wIntervent.InterventId = dbo.LIKOIntervence.InterventId
GO
/****** Object:  View [dbo].[wLIKOParticipant]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/* 
   wLIKOParticipant spojuje tabulky wLIKOParticipant  s wLIKOIntervence a číselníky wintervents eTypeParty eDruhIntervence eSex
   v1.0 01.01.2023 ZPT
   V1.1 14.01.2023 ZPT Pridano Poradi, InterventId2, isAgreementBKB
   V1.2 04.02.2023 ZPT Poradi + InterventName2
   V1.3 26.02.2023 ZPT Uprava pro zmenu v wLIKOIntervence
   v1.3 01.04.2023 - ZPT doplneni YEAR/MONTH

*/

-- SELECT * FROM [dbo].[wLIKOParticipant]
CREATE VIEW [dbo].[wLIKOParticipant]
AS
SELECT        P.LIKOParticipantId, P.LIKOIntervenceId, P.TypePartyEID, P.SexEID, P.Age, P.IsDead, P.IsInjury, P.IsIntervence, P.IsFirstIntervence, P.DruhIntervenceEID, P.InterventId, P.IsAgreement, P.IsContact, P.IsPolicement, 
                         P.IsPolicementClosePerson, P.IsSenior, P.IsChildJuvenile, P.IsHandyCappedMedical, P.IsHandyCappedMentally, P.IsMemberMinorityGroup, P.Organization, P.Note, P.InterventId2, P.IsAgreementBKB , Interv.dtStartIntervence, Interv.dtEndIntervence, 
                         Interv.Intrv_Note AS intervenceNote, Interv.ObetemPoskozenym, Interv.PozustalymBlizkym, Interv.Ostatnim, Interv.Interv_Poradi, Interv.dtStartCall, Interv.UserFirstName, Interv.UserLastName, 
                         Sex.Text AS SexText, DruhInt.Text AS DruhIntervenceText, TypeParty.Text AS TypePartyText, Interv.LIKOIntervenceId  AS MainInterventId, Interv.Udalost_Region,
						 i.InterventShortName as InterventName, i2.InterventShortName as InterventName2, Interv_Poradi AS Poradi, dtIntervStart, tmIntervStart
						 ,YEAR(Interv.dtStartCall) as [Year], MONTH(Interv.dtStartCall) as [Month]
FROM            dbo.LIKOParticipant AS P INNER JOIN
                         dbo.wLIKOIntervence AS Interv ON Interv.LIKOIntervenceId = P.LIKOIntervenceId LEFT OUTER JOIN
                         dbo.eSex AS Sex ON P.SexEID = Sex.SexId LEFT OUTER JOIN
                         dbo.eDruhIntervence AS DruhInt ON P.DruhIntervenceEID = DruhInt.DruhIntervenceId LEFT OUTER JOIN
                         dbo.eTypeParty AS TypeParty ON P.TypePartyEID = TypeParty.TypePartyId LEFT OUTER JOIN
                         dbo.wintervent AS i ON P.InterventId = i.InterventId LEFT OUTER JOIN
                         dbo.wintervent AS i2 ON P.InterventId2 = i2.InterventId
GO
/****** Object:  View [dbo].[wLIKOIncident]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* 
   v1.0 01.01.2023 ZPT
   v1.1 05.02.2023 ZPT plně přepracováno 
   v1.3 01.04.2023 - ZPT doplneni YEAR/MONTH
 SELECT * FROM [dbo].[wLIKOIncident]
 */
CREATE VIEW [dbo].[wLIKOIncident]
AS
SELECT       
Inc.dtIncident,
CAST(Inc.dtIncident AS DATE) AS dtUdalost,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Inc.dtIncident as Date), Inc.dtIncident),0),114) as tmUdalost,
reg.Name Udalost_Region,
Inc.Place AS Udalost_Misto,
Inc.Note AS Udalost_Note,
sti.Text AS Druh_Udalosti,
sti.Kategorie AS Kategorie_Udalosti,
Inc.NasledekSmrti,
Inc.Dokonane,
Inc.Pokus_Priprava,
Inc.PocetPoskozenych,
Inc.LIKOIncidentId,  
calls.dtStartCall,
CAST(calls.dtStartCall AS DATE) AS dtCall,
CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(calls.dtStartCall as Date), calls.dtStartCall),0),114) as tmCall,
interinter.InterventShortName AS Volajici,
interinter.RegionName AS Volajici_Kraj,
calls.CallId,
usr.LastName as UserLastName, usr.FirstName AS UserFirstName, usr.LoginUserId
,YEAR(calls.dtStartCall) as [Year], MONTH(calls.dtStartCall) as [Month]
FROM  
dbo.LIKOIncidents AS Inc  LEFT OUTER JOIN
dbo.LIKOIntervence AS Interv on Inc.LIKOIncidentId = Interv.LIKOIncidentId AND Interv.Poradi = 1 LEFT JOIN 
dbo.Calls AS calls on Interv.CallId = calls.CallId LEFT JOIN 
dbo.wIntervent AS interinter ON Interv.InterventId = interinter.InterventId LEFT OUTER JOIN
dbo.loginUsers AS usr ON calls.LoginUserId = usr.LoginUserId LEFT OUTER JOIN
dbo.Regions AS reg ON Inc.RegionId = reg.RegionId LEFT OUTER JOIN
dbo.eSubTypeIncident AS sti ON Inc.SubTypeIncidentEID = sti.SubTypeIncidentId

GO
/****** Object:  Table [dbo].[MainEventLogs]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainEventLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[dtCreate] [datetime2](7) NOT NULL,
	[LoginUserId] [int] NOT NULL,
	[eventCode] [int] NOT NULL,
	[eventSubCode] [int] NOT NULL,
	[Program] [nvarchar](50) NULL,
	[Text] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_MainEventLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateType] [int] NOT NULL,
	[StateValue] [int] NOT NULL,
	[DescriptionType] [nvarchar](50) NULL,
	[DescriptionValue] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[wMainEventLogs]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[wMainEventLogs] AS
SELECT   l.*, u.FirstName as UserFirstName, u.LastName as UserLastName, s1.DescriptionValue CodeText, s2.DescriptionValue SubCodeText    
FROM    dbo.MainEventLogs l LEFT JOIN 
dbo.States s1 ON s1.StateType = 99 and s1.StateValue = l.eventCode LEFT JOIN
dbo.States s2 ON s2.StateType = 98 and s2.StateValue = l.eventSubCode LEFT JOIN
dbo.LoginUsers u ON u.LoginUserId = l.LoginUserId;


GO
/****** Object:  Table [dbo].[dimDateTime]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dimDateTime](
	[date] [date] NOT NULL,
	[day]  AS (datepart(day,[date])),
	[month]  AS (datepart(month,[date])),
	[FirstOfMonth]  AS (CONVERT([date],dateadd(month,datediff(month,(0),[date]),(0)),(0))),
	[MonthName]  AS (datename(month,[date])),
	[week]  AS (datepart(week,[date])),
	[ISOweek]  AS (datepart(iso_week,[date])),
	[DayOfWeek]  AS (datepart(weekday,[date])),
	[quarter]  AS (datepart(quarter,[date])),
	[year]  AS (datepart(year,[date])),
	[FirstOfYear]  AS (CONVERT([date],dateadd(year,datediff(year,(0),[date]),(0)),(0))),
	[Style112]  AS (CONVERT([char](8),[date],(112))),
	[Style101]  AS (CONVERT([char](10),[date],(101))),
	[halfOfYear]  AS (case when datepart(weekday,[date])>(2) then (2) else (1) end),
PRIMARY KEY CLUSTERED 
(
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eClientCurrentStatus]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eClientCurrentStatus](
	[ClientCurrentStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eClientCurrentStatus] PRIMARY KEY CLUSTERED 
(
	[ClientCurrentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eContactTopic]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eContactTopic](
	[ContactTopicId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eContactTopis] PRIMARY KEY CLUSTERED 
(
	[ContactTopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eEndOfSpeech]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eEndOfSpeech](
	[EndOfSpeechId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eEndOfSpeech] PRIMARY KEY CLUSTERED 
(
	[EndOfSpeechId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eGrouping]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eGrouping](
	[groupingId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eGrouping] PRIMARY KEY CLUSTERED 
(
	[groupingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eNick]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eNick](
	[NickId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eNick] PRIMARY KEY CLUSTERED 
(
	[NickId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eTypeIncident]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eTypeIncident](
	[TypeIncidentId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[ShortText] [nvarchar](5) NULL,
	[dtDeleted] [datetime] NULL,
 CONSTRAINT [PK_eEvent] PRIMARY KEY CLUSTERED 
(
	[TypeIncidentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginAccesses]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginAccesses](
	[LoginAccessId] [int] IDENTITY(1,1) NOT NULL,
	[AccessName] [nvarchar](50) NULL,
	[AccessShortName] [nvarchar](3) NULL,
 CONSTRAINT [PK_LoginAccesses] PRIMARY KEY CLUSTERED 
(
	[LoginAccessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginAccessUsers]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginAccessUsers](
	[LoginAccessUserId] [int] IDENTITY(1,1) NOT NULL,
	[LoginUserId] [int] NOT NULL,
	[LoginAccessId] [int] NOT NULL,
 CONSTRAINT [PK_LoginAccessUsers] PRIMARY KEY CLUSTERED 
(
	[LoginAccessUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MainSettings]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainSettings](
	[MainSettingId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[sValue] [nvarchar](max) NULL,
	[iValue] [int] NULL,
	[dValue] [datetime2](7) NULL,
 CONSTRAINT [PK_MainSettings] PRIMARY KEY CLUSTERED 
(
	[MainSettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserColumns]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserColumns](
	[UserColumnId] [int] IDENTITY(1,1) NOT NULL,
	[ColumnIndex] [int] NULL,
	[DisplayIndex] [int] NULL,
	[Width] [int] NULL,
	[LoginUserId] [int] NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_UserColumns] PRIMARY KEY CLUSTERED 
(
	[UserColumnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSetting]    Script Date: 17.04.2023 0:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSetting](
	[UserSettingId] [int] IDENTITY(1,1) NOT NULL,
	[LoginUserId] [int] NULL,
	[Name] [nvarchar](255) NULL,
	[sValue] [nvarchar](max) NULL,
	[iValue] [int] NULL,
	[dValue] [datetime2](7) NULL,
 CONSTRAINT [PK_UserSetting] PRIMARY KEY CLUSTERED 
(
	[UserSettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2022-12-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-01-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-02-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-03-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-04-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-05-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-06-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-07-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-08-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-09-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-10-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-11-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2023-12-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-01-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-02-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-03-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-04-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-05-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-06-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-07-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-08-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-09-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-10-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-11-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-01-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-02-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-03-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-04-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-05-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-06-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-07-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-08-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-09-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-10-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-11-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2025-12-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-01-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-02-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-03-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-04-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-05-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-06-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-07-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-08-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-09-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-10-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-11-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2026-12-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-01-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-02-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-03-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-04-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-05-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-06-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-07-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-08-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-09-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-10-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-11-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2027-12-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-01-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-02-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-03-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-04-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-05-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-06-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-07-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-08-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-09-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-10-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-11-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2028-12-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-01-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-02-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-03-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-04-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-05-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-06-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-07-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-08-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-09-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-10-31' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-11-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-01' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-02' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-03' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-04' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-05' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-06' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-07' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-08' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-09' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-10' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-11' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-12' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-13' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-14' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-15' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-16' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-17' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-18' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-19' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-20' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-21' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-22' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-23' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-24' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-25' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-26' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-27' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-28' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-29' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-30' AS Date))
GO
INSERT [dbo].[dimDateTime] ([date]) VALUES (CAST(N'2029-12-31' AS Date))
GO
SET IDENTITY_INSERT [dbo].[eAge] ON 
GO
INSERT [dbo].[eAge] ([AgeId], [Text], [dtDeleted]) VALUES (1, N'Dítě', NULL)
GO
INSERT [dbo].[eAge] ([AgeId], [Text], [dtDeleted]) VALUES (2, N'Mladý dospělý (18-40)', NULL)
GO
INSERT [dbo].[eAge] ([AgeId], [Text], [dtDeleted]) VALUES (3, N'Zralý dospělý (30-65)', NULL)
GO
INSERT [dbo].[eAge] ([AgeId], [Text], [dtDeleted]) VALUES (4, N'Senior (65 a výše)', NULL)
GO
INSERT [dbo].[eAge] ([AgeId], [Text], [dtDeleted]) VALUES (5, N'nezjištěno', NULL)
GO
SET IDENTITY_INSERT [dbo].[eAge] OFF
GO
SET IDENTITY_INSERT [dbo].[eCallType] ON 
GO
INSERT [dbo].[eCallType] ([callTypeId], [Text], [dtDeleted]) VALUES (1, N'LPvK', NULL)
GO
INSERT [dbo].[eCallType] ([callTypeId], [Text], [dtDeleted]) VALUES (2, N'SKI', NULL)
GO
SET IDENTITY_INSERT [dbo].[eCallType] OFF
GO
SET IDENTITY_INSERT [dbo].[eClientCurrentStatus] ON 
GO
INSERT [dbo].[eClientCurrentStatus] ([ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (1, N'Emoční stav', NULL)
GO
INSERT [dbo].[eClientCurrentStatus] ([ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (2, N'Nápadnost', NULL)
GO
SET IDENTITY_INSERT [dbo].[eClientCurrentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[eClientFrom] ON 
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (1, N'Neurčeno', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (2, N'Přepojeno ze 112', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (3, N'Veřejnost', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (4, N'Policie ČR (i rodinný příslušník)', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (5, N'HZS (i rod. přísl.)', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (6, N'Armáda ČR (i rod. přísl.)', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (7, N'Celní správa (i rod. přísl.)', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (8, N'Vězeňská služba (i rod. přísl.)', CAST(N'2023-02-06T11:16:12.640' AS DateTime))
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (9, N'GIBS (i rod. přísl.)', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (10, N'Kartotéka - klient volá opakovaně', NULL)
GO
INSERT [dbo].[eClientFrom] ([ClientFromId], [Text], [dtDeleted]) VALUES (12, N'Vězeňská služba (i rod. přísl.)', NULL)
GO
SET IDENTITY_INSERT [dbo].[eClientFrom] OFF
GO
SET IDENTITY_INSERT [dbo].[eContactTopic] ON 
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (1, N'Problematika vztahová', NULL)
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (2, N'Problematika osobní a existenciální', NULL)
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (3, N'Problematika sociální a právní', NULL)
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (4, N'Problematika zdravotní', NULL)
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (5, N'Problematika závislostí a sociální patologie', NULL)
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (6, N'Problematika menšin', NULL)
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (7, N'Náhlá nečekaná stresující událost', NULL)
GO
INSERT [dbo].[eContactTopic] ([ContactTopicId], [Text], [dtDeleted]) VALUES (8, N'Duševní zdraví', NULL)
GO
SET IDENTITY_INSERT [dbo].[eContactTopic] OFF
GO
SET IDENTITY_INSERT [dbo].[eContactType] ON 
GO
INSERT [dbo].[eContactType] ([ContactTypeId], [Text], [dtDeleted]) VALUES (1, N'Telefon', NULL)
GO
INSERT [dbo].[eContactType] ([ContactTypeId], [Text], [dtDeleted]) VALUES (2, N'E-mail', NULL)
GO
SET IDENTITY_INSERT [dbo].[eContactType] OFF
GO
SET IDENTITY_INSERT [dbo].[eDruhIntervence] ON 
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (1, N'KI', NULL)
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (2, N'oznámení události (úmrtí)', NULL)
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (3, N'asistence při výslechu', NULL)
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (4, N'asistence jiná', NULL)
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (5, N'doprovod', NULL)
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (6, N'konzultace, poradenství', NULL)
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (7, N'Jiné, různé (uveďte příp. v poznámce)', NULL)
GO
INSERT [dbo].[eDruhIntervence] ([DruhIntervenceId], [Text], [dtDeleted]) VALUES (9, N'bez intervence', NULL)
GO
SET IDENTITY_INSERT [dbo].[eDruhIntervence] OFF
GO
SET IDENTITY_INSERT [dbo].[eEndOfSpeech] ON 
GO
INSERT [dbo].[eEndOfSpeech] ([EndOfSpeechId], [Text], [dtDeleted]) VALUES (1, N'závažnost při ukončení hovoru', NULL)
GO
INSERT [dbo].[eEndOfSpeech] ([EndOfSpeechId], [Text], [dtDeleted]) VALUES (2, N'poskytnutá podpora', NULL)
GO
INSERT [dbo].[eEndOfSpeech] ([EndOfSpeechId], [Text], [dtDeleted]) VALUES (3, N'odkaz na další pomoc', NULL)
GO
SET IDENTITY_INSERT [dbo].[eEndOfSpeech] OFF
GO
SET IDENTITY_INSERT [dbo].[eGrouping] ON 
GO
INSERT [dbo].[eGrouping] ([groupingId], [Text], [Value], [dtDeleted]) VALUES (1, N'Den', N'D.Date', NULL)
GO
INSERT [dbo].[eGrouping] ([groupingId], [Text], [Value], [dtDeleted]) VALUES (2, N'Týden', N'D.Week', NULL)
GO
INSERT [dbo].[eGrouping] ([groupingId], [Text], [Value], [dtDeleted]) VALUES (3, N'Dny v týdnu', N'D.DayOfWeek', NULL)
GO
INSERT [dbo].[eGrouping] ([groupingId], [Text], [Value], [dtDeleted]) VALUES (4, N'Měsíc', N'D.Year, D.Month', NULL)
GO
INSERT [dbo].[eGrouping] ([groupingId], [Text], [Value], [dtDeleted]) VALUES (5, N'Čtvrtletí', N'D.Year, D.quarter', NULL)
GO
INSERT [dbo].[eGrouping] ([groupingId], [Text], [Value], [dtDeleted]) VALUES (6, N'Pololetí', N'D.Year, D.halfOfYear', NULL)
GO
INSERT [dbo].[eGrouping] ([groupingId], [Text], [Value], [dtDeleted]) VALUES (7, N'Rok', N'D.Year', NULL)
GO
SET IDENTITY_INSERT [dbo].[eGrouping] OFF
GO
SET IDENTITY_INSERT [dbo].[eNick] ON 
GO
INSERT [dbo].[eNick] ([NickId], [Text], [dtDeleted]) VALUES (1, N'Alík', NULL)
GO
INSERT [dbo].[eNick] ([NickId], [Text], [dtDeleted]) VALUES (2, N'Honza', NULL)
GO
INSERT [dbo].[eNick] ([NickId], [Text], [dtDeleted]) VALUES (4, N'Alojz', NULL)
GO
INSERT [dbo].[eNick] ([NickId], [Text], [dtDeleted]) VALUES (8, N'mojmir chacaturjan', NULL)
GO
INSERT [dbo].[eNick] ([NickId], [Text], [dtDeleted]) VALUES (9, N'Doktorka', NULL)
GO
INSERT [dbo].[eNick] ([NickId], [Text], [dtDeleted]) VALUES (10, N'Josef Královec', NULL)
GO
SET IDENTITY_INSERT [dbo].[eNick] OFF
GO
SET IDENTITY_INSERT [dbo].[eSex] ON 
GO
INSERT [dbo].[eSex] ([SexId], [Text], [dtDeleted]) VALUES (1, N'Muž', NULL)
GO
INSERT [dbo].[eSex] ([SexId], [Text], [dtDeleted]) VALUES (2, N'Žena', NULL)
GO
INSERT [dbo].[eSex] ([SexId], [Text], [dtDeleted]) VALUES (6, N'Jiné/Nejasné', NULL)
GO
INSERT [dbo].[eSex] ([SexId], [Text], [dtDeleted]) VALUES (8, N'nezjištěno', NULL)
GO
SET IDENTITY_INSERT [dbo].[eSex] OFF
GO
SET IDENTITY_INSERT [dbo].[eSubClientCurrentStatus] ON 
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (1, 1, N'Pláč', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (2, 1, N'Smutek', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (3, 1, N'Úzkost', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (4, 1, N'Strach', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (5, 1, N'Vztek a zlost', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (6, 1, N'Klid', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (7, 1, N'Dobrá nálada (smích)', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (8, 1, N'Uvolnění v průběhu hovoru', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (9, 1, N'Jiné emoce', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (10, 2, N'Bez nápadnosti', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (11, 2, N'Setřelá mluva, pravděpodobně opilý', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (12, 2, N'Působí, jako když onanuje', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (13, 2, N'Zrychlená překotná mluva (nekoherentní vyjadřování)', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (14, 2, N'Používání hrubých slov a urážek', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (15, 2, N'Jiná nápadnost', NULL)
GO
INSERT [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId], [ClientCurrentStatusId], [Text], [dtDeleted]) VALUES (16, 1, N'Zhnusení (opovržení)', NULL)
GO
SET IDENTITY_INSERT [dbo].[eSubClientCurrentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[eSubContactTopic] ON 
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (1, 1, N'Partnerská/manželská', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (2, 1, N'Rodinná', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (3, 1, N'Sousedská', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (4, 1, N'Vrstevnická', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (5, 1, N'Vztahy na pracovišti', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (6, 2, N'Existenciální otázky (duchovní, filosofické, univerzální, klimatické)', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (7, 2, N'Problémy se sebou samým', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (8, 2, N'Obavy o vlastní duševní zdraví', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (9, 2, N'Sebevražedné úvahy', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (10, 2, N'Osamělost', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (11, 2, N'Ztráta smyslu života', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (12, 2, N'Truchlení po ztrátě blízké osoby', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (13, 2, N'Problémy výkonu (v práci, ve škole)', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (14, 2, N'Jiná osobní a existenciální problematika', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (15, 3, N'Oběť trestné činnosti', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (16, 3, N'Internetové podvody', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (17, 3, N'Dotazy směřující k podání oznámení o trestné činnosti', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (18, 3, N'Dotazy týkající se práce policie (subjektivní nespokojenost s prací policie, apod.)', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (19, 3, N'Předmanželská, manželská, rozvodová', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (20, 3, N'Právní vztahy mezi rodiči a dětmi, péče o seniory', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (21, 3, N'Nezaměstnanost', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (22, 3, N'Finanční tíseň', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (23, 3, N'Bezdomovectví', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (24, 3, N'Jiná sociální a právní problematika', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (25, 4, N'Aktuální tělesná nemoc', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (26, 4, N'Zdravotní postižení', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (27, 4, N'Pohlavně přenosné nemoci', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (28, 4, N'Sexuálně-zdravotní problematika', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (29, 4, N'Jiná zdravotní problematika', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (30, 5, N'Alkohol', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (31, 5, N'Drogy', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (32, 5, N'Gambling', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (33, 5, N'Sekty', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (34, 5, N'Poruchy příjmu potravy', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (35, 2, N'Pracovní vyhoření', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (36, 5, N'Domácí násilí', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (37, 5, N'Znásilnění', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (38, 5, N'Šikana, mobbing, bossing', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (39, 5, N'Jiné závislosti a sociální patologie', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (40, 6, N'Rasismus', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (41, 6, N'Problematika migrace', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (42, 6, N'Problematika sexuálních menšin (LGBTQIA+)', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (43, 6, N'Náboženská menšina', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (44, 6, N'Jiná problematika menšin', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (45, 7, N'Autonehoda', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (46, 7, N'Úmrtí - náhlé, tragické', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (47, 7, N'Oběť trestného činu (znásilnění, přepadení, okradení, podvod)', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (48, 7, N'Živelná katastrofa', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (49, 7, N'Ztráta zaměstnání', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (50, 7, N'Jiná nečekaná stresující událost', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (51, 8, N'Organické duševní poruchy', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (52, 8, N'Duševní poruchy způsobené užíváním psychoaktivních látek', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (53, 8, N'Schizofrenie (bludy)', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (54, 8, N'Poruchy nálad', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (55, 8, N'Neurotické a somatoformní poruchy', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (56, 8, N'Poruchy osobnosti', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (57, 8, N'Mentální retardace', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (58, 8, N'Jiné duševní poruchy', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (59, 5, N'CAN', NULL)
GO
INSERT [dbo].[eSubContactTopic] ([SubContactTopicId], [ContactTopicId], [Text], [dtDeleted]) VALUES (60, 5, N'Kyberšikana', NULL)
GO
SET IDENTITY_INSERT [dbo].[eSubContactTopic] OFF
GO
SET IDENTITY_INSERT [dbo].[eSubEndOfSpeech] ON 
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (1, 1, N'zvládá', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (2, 1, N'nezvládá', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (3, 1, N'naznačené suicidální tendence', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (4, 1, N'výrazné suicidální tendence', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (5, 1, N'suicidální pokus započat', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (6, 1, N'nejasné', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (7, 1, N'jiná', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (8, 2, N'ventilace emocí', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (9, 2, N'podání informací', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (10, 2, N'mapování problému', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (11, 2, N'zrcadlení emocí', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (12, 2, N'legitimizace pocitů', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (13, 2, N'stabilizace volajícího', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (14, 2, N'hledání a nalezení zdrojů zvládání zátěže', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (15, 2, N'formulace zakázky', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (16, 2, N'poradenské vedení', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (17, 2, N'sociálně právní informace', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (18, 2, N'relaxace, imaginace', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (19, 2, N'jiná podpůrná technika ', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (20, 3, N'linka důvěry', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (21, 3, N'krizové centrum', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (22, 3, N'pohotovost', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (23, 3, N'rychlá záchranná služba', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (24, 3, N'policie', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (25, 3, N'psychoterapeut, psycholog', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (26, 3, N'psychoterapeutické centrum', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (27, 3, N'centrum pro léčbu závislostí', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (28, 3, N'pedagogicko-psychologická poradna/rodinná poradna', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (29, 3, N'psychiatr', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (30, 3, N'lékař', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (31, 3, N'právník', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (32, 3, N'blízká osoba', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (33, 3, N'jinam', NULL)
GO
INSERT [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId], [EndOfSpeechId], [Text], [dtDeleted]) VALUES (34, 3, N'Nikam', NULL)
GO
SET IDENTITY_INSERT [dbo].[eSubEndOfSpeech] OFF
GO
SET IDENTITY_INSERT [dbo].[eSubTypeIncident] ON 
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (1, 1, N'TČ  -loupež', N'násilné TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (2, 1, N'TČ - násilí a vyhrožování sk. obyvatel', N'násilné TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (3, 1, N'TČ - obchodování s lidmi', N'mravnostní TČ1', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (4, 1, N'TČ - omezování n. zbavení osobní svobody', N'ostatní TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (5, 1, N'TČ - pohlavní zneužívání', N'mravnostní TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (10, 1, N'TČ - ublížení na zdraví, napadení', N'násilné TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (11, 1, N'TČ - únos dítěte či osoby duš. nemocné', N'ostatní TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (12, 1, N'TČ - vražda, zabití, usmrcení', N'násilné TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (13, 1, N'TČ - vyhrožování, pronásledování', N'násilné TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (14, 1, N'TČ - znásilnění', N'mravnostní TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (15, 1, N'TČ - krádež vloupáním', N'majektková TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (16, 1, N'TČ - JINÉ (upřesněte v poznámce)', N'ostatní TČ', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (17, 2, N'POHŘEŠOVÁNÍ - dítěte, mladistvého', N'pohřešování', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (18, 2, N'POHŘEŠOVÁNÍ - dospělého', N'pohřešování', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (19, 3, N'NEHODA - dopravní', N'nehody', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (20, 3, N'NEHODA - pracovní úraz', N'nehody', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (21, 3, N'NEHODA - utonutí', N'nehody', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (22, 3, N'NEHODA - jiné', N'nehody', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (23, 4, N'SEBEVRAŽDA', N'jiné', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (24, 5, N'ÚMRTÍ - jiné', N'jiné', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (25, 6, N'KU - povodeň', N'krizové a mim. události', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (26, 6, N'KU - požár', N'krizové a mim. události', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (27, 6, N'KU - sesuv půdy', N'krizové a mim. události', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (28, 6, N'KU - jiné', N'krizové a mim. události', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (29, 7, N'OSTATNÍ - oznámení', N'jiné', NULL)
GO
INSERT [dbo].[eSubTypeIncident] ([SubTypeIncidentId], [TypeIncidentId], [Text], [Kategorie], [dtDeleted]) VALUES (30, 7, N'OSTATNÍ - požadavek', N'jiné', NULL)
GO
SET IDENTITY_INSERT [dbo].[eSubTypeIncident] OFF
GO
SET IDENTITY_INSERT [dbo].[eTypeIncident] ON 
GO
INSERT [dbo].[eTypeIncident] ([TypeIncidentId], [Text], [ShortText], [dtDeleted]) VALUES (1, N'Trestná činnost', N'TČ', NULL)
GO
INSERT [dbo].[eTypeIncident] ([TypeIncidentId], [Text], [ShortText], [dtDeleted]) VALUES (2, N'Pohřešování', N'POHŘ', NULL)
GO
INSERT [dbo].[eTypeIncident] ([TypeIncidentId], [Text], [ShortText], [dtDeleted]) VALUES (3, N'Nehoda', N'NHD', NULL)
GO
INSERT [dbo].[eTypeIncident] ([TypeIncidentId], [Text], [ShortText], [dtDeleted]) VALUES (4, N'Sebevražda', N'SBVR', NULL)
GO
INSERT [dbo].[eTypeIncident] ([TypeIncidentId], [Text], [ShortText], [dtDeleted]) VALUES (5, N'Úmrtí', N'ÚMRTÍ', NULL)
GO
INSERT [dbo].[eTypeIncident] ([TypeIncidentId], [Text], [ShortText], [dtDeleted]) VALUES (6, N'Krizová událost', N'KU', NULL)
GO
INSERT [dbo].[eTypeIncident] ([TypeIncidentId], [Text], [ShortText], [dtDeleted]) VALUES (7, N'Ostatní', N'JINÉ', NULL)
GO
SET IDENTITY_INSERT [dbo].[eTypeIncident] OFF
GO
SET IDENTITY_INSERT [dbo].[eTypeParty] ON 
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (1, N'oběť/poškozený', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (2, N'manžel(ka), druh/družka oběti', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (3, N'rodič oběti', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (4, N'dítě oběti', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (5, N'sourozenec oběti', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (6, N'jiná osoba blízká oběti', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (7, N'spolupracovník oběti', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (8, N'svědek události (jinde neuvedený)', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (9, N'osoba zasahující u události', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (10, N'pachatel', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (11, N'osoba blízká pachateli', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (12, N'jiná osoba', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (13, N'neuvedeno (pozůstalý)', NULL)
GO
INSERT [dbo].[eTypeParty] ([TypePartyId], [Text], [dtDeleted]) VALUES (17, N'kdekdo', CAST(N'2023-02-20T09:37:01.137' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[eTypeParty] OFF
GO
SET IDENTITY_INSERT [dbo].[eTypeService] ON 
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (1, N'Hovor', NULL)
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (2, N'Profesní kontakt', NULL)
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (3, N'Podaná informace', NULL)
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (4, N'Mlčení', NULL)
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (5, N'Zazvonění a zavěšení', NULL)
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (6, N'Omyl', NULL)
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (7, N'Rozhovor za účelem sexuálního uspokojení', NULL)
GO
INSERT [dbo].[eTypeService] ([TypeServiceId], [Text], [dtDeleted]) VALUES (8, N'Odchozí e-mail', NULL)
GO
SET IDENTITY_INSERT [dbo].[eTypeService] OFF
GO
GO
SET IDENTITY_INSERT [dbo].[LoginAccesses] ON 
GO
INSERT [dbo].[LoginAccesses] ([LoginAccessId], [AccessName], [AccessShortName]) VALUES (1, N'Administrator', N'Adm')
GO
INSERT [dbo].[LoginAccesses] ([LoginAccessId], [AccessName], [AccessShortName]) VALUES (2, N'User', N'Usr')
GO
INSERT [dbo].[LoginAccesses] ([LoginAccessId], [AccessName], [AccessShortName]) VALUES (3, N'PowerUser', N'Pwr')
GO
INSERT [dbo].[LoginAccesses] ([LoginAccessId], [AccessName], [AccessShortName]) VALUES (4, N'Archive', N'Arc')
GO
SET IDENTITY_INSERT [dbo].[LoginAccesses] OFF
GO
SET IDENTITY_INSERT [dbo].[LoginAccessUsers] ON 
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (4, 1, 4)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (13, 2, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (21, 2, 1)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (22, 5, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (23, 5, 3)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (24, 5, 4)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (25, 4, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (26, 2, 3)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (27, 2, 4)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (28, 3, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (29, 7, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (30, 7, 3)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (31, 7, 4)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (32, 8, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (33, 9, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (34, 6, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (35, 6, 3)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (36, 10, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (37, 11, 2)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (39, 4, 3)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (40, 1, 1)
GO
INSERT [dbo].[LoginAccessUsers] ([LoginAccessUserId], [LoginUserId], [LoginAccessId]) VALUES (41, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[LoginAccessUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[LoginUsers] ON 
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (-99, N'Unknown', N'Unknown', N'<Unknown>', N'<NoPassword>', CAST(N'2022-11-28T12:11:05.4466667' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (-5, N'System', N'System', N'<System>', N'<NoPassword>', CAST(N'2022-11-28T12:11:05.4466667' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (1, N'Zdeněk', N'Petřík', N'ZPT', N'12345678', CAST(N'2022-11-28T12:11:05.4466667' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (2, N'Simona', N'Hoskovcová', N'Simona', N'12345678', CAST(N'2022-11-28T12:11:05.4466667' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (3, N'Eva', N'Nguyen', N'Eva', N'12345678', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (4, N'Kateřina', N'Ciglerová', N'Kateřina', N'12345678', CAST(N'2023-01-05T22:18:15.4190592' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (5, N'Pavel', N'Šebesta', N'Pavel', N'12345678', CAST(N'2023-02-08T09:23:33.8608411' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (6, N'Darina', N'Majková', N'Darina', N'12345678', CAST(N'2023-02-08T14:22:24.7709835' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (7, N'Karolína', N'Faberová', N'Karolína', N'12345678', CAST(N'2023-02-08T14:23:09.0825567' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (8, N'Jana', N'Mazurová', N'Jana', N'12345678', CAST(N'2023-02-08T14:23:36.3075797' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (9, N'Hedvika ', N'Boukalová', N'Hedvika', N'12345678', CAST(N'2023-02-08T14:24:34.3624786' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (10, N'Markéta', N'Niederlová', N'Markéta', N'12345678', CAST(N'2023-03-08T09:56:52.0065960' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (11, N'Tereza ', N'Opolzerová', N'Tereza', N'12345678', CAST(N'2023-03-08T09:57:47.2785817' AS DateTime2))
GO
INSERT [dbo].[LoginUsers] ([LoginUserId], [FirstName], [LastName], [LoginName], [LoginPassword], [Created]) VALUES (12, N'Lenka', N'Šrámková', N'Lenka', N'12345678', CAST(N'2023-03-08T09:58:12.9574817' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[LoginUsers] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[MainSettings] ON 
GO
INSERT [dbo].[MainSettings] ([MainSettingId], [Name], [sValue], [iValue], [dValue]) VALUES (1, N'LoginPasswordMask', N'^([a-zA-Z0-9@*#!]{8,15})$', NULL, NULL)
GO
INSERT [dbo].[MainSettings] ([MainSettingId], [Name], [sValue], [iValue], [dValue]) VALUES (2, N'LoginPassworderErrMessage', N'Heslo musí splňovat následující kritéria<br/>Délka 8-15 znaků<br/>Pouze alfanumerické znaky (A-Z,a-z,0-9)a speciální znaky @*#!', NULL, NULL)
GO
INSERT [dbo].[MainSettings] ([MainSettingId], [Name], [sValue], [iValue], [dValue]) VALUES (3, N'LoginMode', NULL, 22, NULL)
GO
INSERT [dbo].[MainSettings] ([MainSettingId], [Name], [sValue], [iValue], [dValue]) VALUES (4, N'CisloJednaci', N'č.j.: PPR-528 <ID>/ČJ-2023-990562', 1, NULL)
GO
INSERT [dbo].[MainSettings] ([MainSettingId], [Name], [sValue], [iValue], [dValue]) VALUES (5, N'CisloJednaciIncrement', N'', 10, NULL)
GO
SET IDENTITY_INSERT [dbo].[MainSettings] OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (1, N'Hlavní město Praha', N'PHA', N'KŘP hl. m. Prahy', 10)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (2, N'Jihočeský kraj', N'JHC', N'KŘP Jihočeského kraje', 70)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (3, N'Jihomoravský kraj', N'JHM', N'KŘP Jihomoravského kraje', 130)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (4, N'Karlovarský kraj', N'KVK', N'KŘP Karlovarského kraje', 90)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (5, N'Kraj Vysočina', N'VYS', N'KŘP kraje Vysočina', 100)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (6, N'Královéhradecký kraj', N'HKK', N'KŘP Královehradeckého kraje', 50)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (7, N'Liberecký kraj', N'LBK', N'KŘP Libereckého kraje', 40)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (8, N'Moravskoslezský kraj', N'MSK', N'KŘP Moravskoslezského kraje', 110)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (9, N'Olomoucký kraj', N'OLK', N'KŘP Olomouckého kraje', 120)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (10, N'Pardubický kraj', N'PAK', N'KŘP Pardubického kraje', 60)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (11, N'Plzeňský kraj', N'PLK', N'KŘP Plzeňského kraje', 80)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (12, N'Středočeský kraj', N'STC', N'KŘP Středočeského kraje', 20)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (13, N'Ústecký kraj', N'ULK', N'KŘP Ústeckého kraje', 30)
GO
INSERT [dbo].[Regions] ([RegionId], [Name], [ShortName], [Name2], [RegionOrder]) VALUES (14, N'Zlínský kraj', N'ZLK', N'KŘP Zlínského kraje', 140)
GO
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (1, 99, 101, N'Event', N'Program', N'Událost programu (Start,Stop,Fáze )')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (2, 99, 102, N'Event', N'Login', N'Přihlašování')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (3, 99, 103, N'Event', N'Message', N'Zpráva typu Error,Warning ,Info')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (4, 98, 1, N'SubType', N'Start', N'Začátek (programu, procesu, přihlášení)')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (5, 98, 2, N'SubType', N'Stop', N'Konec (programu, procesu, přihlášení)')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (6, 98, 3, N'SubType', N'BadLogin', N'Neúspěšný pokus o přihlášení')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (7, 98, 11, N'SubType', N'Error', N'Chyba')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (8, 98, 12, N'SubType', N'Warning', N'Upozornění')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (9, 98, 13, N'SubType', N'Info', N'Informace')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (10, 98, 14, N'SubType', N'Debug', N'Debug')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (11, 98, 21, N'SubType', N'New', N'Nový zápis')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (12, 98, 22, N'SubType', N'Update', N'Úprava')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (13, 98, 23, N'SubType', N'Delete', N'Smazání')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (14, 99, 104, N'Event', N'Table', N'Změny v tabulkách')
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (15, 98, 51, N'SubType', N'Call', NULL)
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (16, 98, 52, N'SubType', N'Intervence', NULL)
GO
INSERT [dbo].[States] ([StateId], [StateType], [StateValue], [DescriptionType], [DescriptionValue], [Description]) VALUES (17, 98, 53, N'SubType', N'Incident', NULL)
GO
SET IDENTITY_INSERT [dbo].[States] OFF
GO
ALTER TABLE [dbo].[Intervents] ADD  CONSTRAINT [DF_Intervents_dtCreate]  DEFAULT (getdate()) FOR [dtCreate]
GO
ALTER TABLE [dbo].[Calls]  WITH CHECK ADD  CONSTRAINT [FK_Calls_LoginUsers] FOREIGN KEY([LoginUserId])
REFERENCES [dbo].[LoginUsers] ([LoginUserId])
GO
ALTER TABLE [dbo].[Calls] CHECK CONSTRAINT [FK_Calls_LoginUsers]
GO
ALTER TABLE [dbo].[eSubClientCurrentStatus]  WITH CHECK ADD  CONSTRAINT [FK_eSubClientCurrentStatus_eClientCurrentStatus] FOREIGN KEY([ClientCurrentStatusId])
REFERENCES [dbo].[eEndOfSpeech] ([EndOfSpeechId])
GO
ALTER TABLE [dbo].[eSubClientCurrentStatus] CHECK CONSTRAINT [FK_eSubClientCurrentStatus_eClientCurrentStatus]
GO
ALTER TABLE [dbo].[eSubContactTopic]  WITH CHECK ADD  CONSTRAINT [FK_eSubContactTopic_eContactTopic] FOREIGN KEY([ContactTopicId])
REFERENCES [dbo].[eContactTopic] ([ContactTopicId])
GO
ALTER TABLE [dbo].[eSubContactTopic] CHECK CONSTRAINT [FK_eSubContactTopic_eContactTopic]
GO
ALTER TABLE [dbo].[eSubEndOfSpeech]  WITH CHECK ADD  CONSTRAINT [FK_eSubEndOfSpeech_eEndOfSpeech] FOREIGN KEY([EndOfSpeechId])
REFERENCES [dbo].[eEndOfSpeech] ([EndOfSpeechId])
GO
ALTER TABLE [dbo].[eSubEndOfSpeech] CHECK CONSTRAINT [FK_eSubEndOfSpeech_eEndOfSpeech]
GO
ALTER TABLE [dbo].[eSubTypeIncident]  WITH CHECK ADD  CONSTRAINT [FK_eSubTypeIncident_eTypeIncident] FOREIGN KEY([TypeIncidentId])
REFERENCES [dbo].[eTypeIncident] ([TypeIncidentId])
GO
ALTER TABLE [dbo].[eSubTypeIncident] CHECK CONSTRAINT [FK_eSubTypeIncident_eTypeIncident]
GO
ALTER TABLE [dbo].[Intervents]  WITH CHECK ADD  CONSTRAINT [FK_Intervents_Regions] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([RegionId])
GO
ALTER TABLE [dbo].[Intervents] CHECK CONSTRAINT [FK_Intervents_Regions]
GO
ALTER TABLE [dbo].[LIKOIncidents]  WITH CHECK ADD  CONSTRAINT [FK_LIKOIncidents_eSubTypeIncident] FOREIGN KEY([SubTypeIncidentEID])
REFERENCES [dbo].[eSubTypeIncident] ([SubTypeIncidentId])
GO
ALTER TABLE [dbo].[LIKOIncidents] CHECK CONSTRAINT [FK_LIKOIncidents_eSubTypeIncident]
GO
ALTER TABLE [dbo].[LIKOIncidents]  WITH CHECK ADD  CONSTRAINT [FK_LIKOIncidents_LIKOIncidents] FOREIGN KEY([LIKOIncidentId])
REFERENCES [dbo].[LIKOIncidents] ([LIKOIncidentId])
GO
ALTER TABLE [dbo].[LIKOIncidents] CHECK CONSTRAINT [FK_LIKOIncidents_LIKOIncidents]
GO
ALTER TABLE [dbo].[LIKOIntervence]  WITH CHECK ADD  CONSTRAINT [FK_LIKOIntervence_Calls] FOREIGN KEY([CallId])
REFERENCES [dbo].[Calls] ([CallId])
GO
ALTER TABLE [dbo].[LIKOIntervence] CHECK CONSTRAINT [FK_LIKOIntervence_Calls]
GO
ALTER TABLE [dbo].[LIKOIntervence]  WITH CHECK ADD  CONSTRAINT [FK_LIKOIntervence_Intervents] FOREIGN KEY([InterventId])
REFERENCES [dbo].[Intervents] ([InterventId])
GO
ALTER TABLE [dbo].[LIKOIntervence] CHECK CONSTRAINT [FK_LIKOIntervence_Intervents]
GO
ALTER TABLE [dbo].[LIKOIntervence]  WITH CHECK ADD  CONSTRAINT [FK_LIKOIntervence_LIKOIncidents] FOREIGN KEY([LIKOIncidentId])
REFERENCES [dbo].[LIKOIncidents] ([LIKOIncidentId])
GO
ALTER TABLE [dbo].[LIKOIntervence] CHECK CONSTRAINT [FK_LIKOIntervence_LIKOIncidents]
GO
ALTER TABLE [dbo].[LIKOParticipant]  WITH CHECK ADD  CONSTRAINT [FK_LIKOParticipant_eDruhIntervence] FOREIGN KEY([DruhIntervenceEID])
REFERENCES [dbo].[eDruhIntervence] ([DruhIntervenceId])
GO
ALTER TABLE [dbo].[LIKOParticipant] CHECK CONSTRAINT [FK_LIKOParticipant_eDruhIntervence]
GO
ALTER TABLE [dbo].[LIKOParticipant]  WITH CHECK ADD  CONSTRAINT [FK_LIKOParticipant_eSex] FOREIGN KEY([SexEID])
REFERENCES [dbo].[eSex] ([SexId])
GO
ALTER TABLE [dbo].[LIKOParticipant] CHECK CONSTRAINT [FK_LIKOParticipant_eSex]
GO
ALTER TABLE [dbo].[LIKOParticipant]  WITH CHECK ADD  CONSTRAINT [FK_LIKOParticipant_eTypeParty] FOREIGN KEY([TypePartyEID])
REFERENCES [dbo].[eTypeParty] ([TypePartyId])
GO
ALTER TABLE [dbo].[LIKOParticipant] CHECK CONSTRAINT [FK_LIKOParticipant_eTypeParty]
GO
ALTER TABLE [dbo].[LIKOParticipant]  WITH CHECK ADD  CONSTRAINT [FK_LIKOParticipant_Intervents] FOREIGN KEY([InterventId])
REFERENCES [dbo].[Intervents] ([InterventId])
GO
ALTER TABLE [dbo].[LIKOParticipant] CHECK CONSTRAINT [FK_LIKOParticipant_Intervents]
GO
ALTER TABLE [dbo].[LIKOParticipant]  WITH CHECK ADD  CONSTRAINT [FK_LIKOParticipant_Intervents2] FOREIGN KEY([InterventId2])
REFERENCES [dbo].[Intervents] ([InterventId])
GO
ALTER TABLE [dbo].[LIKOParticipant] CHECK CONSTRAINT [FK_LIKOParticipant_Intervents2]
GO
ALTER TABLE [dbo].[LIKOParticipant]  WITH CHECK ADD  CONSTRAINT [FK_LIKOParticipant_LIKOIntervence] FOREIGN KEY([LIKOIntervenceId])
REFERENCES [dbo].[LIKOIntervence] ([LIKOIntervenceId])
GO
ALTER TABLE [dbo].[LIKOParticipant] CHECK CONSTRAINT [FK_LIKOParticipant_LIKOIntervence]
GO
ALTER TABLE [dbo].[LoginAccessUsers]  WITH CHECK ADD  CONSTRAINT [FK_LoginAccessUsers_LoginUsers_LoginUserId] FOREIGN KEY([LoginUserId])
REFERENCES [dbo].[LoginUsers] ([LoginUserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoginAccessUsers] CHECK CONSTRAINT [FK_LoginAccessUsers_LoginUsers_LoginUserId]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_Calls] FOREIGN KEY([CallId])
REFERENCES [dbo].[Calls] ([CallId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_Calls]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_eAge] FOREIGN KEY([AgeEID])
REFERENCES [dbo].[eAge] ([AgeId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_eAge]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_eClientFrom] FOREIGN KEY([ClientFromEID])
REFERENCES [dbo].[eClientFrom] ([ClientFromId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_eClientFrom]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_eContactType] FOREIGN KEY([ContactTypeEID])
REFERENCES [dbo].[eContactType] ([ContactTypeId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_eContactType]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_eSex] FOREIGN KEY([SexEID])
REFERENCES [dbo].[eSex] ([SexId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_eSex]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_eTypeService] FOREIGN KEY([TypeServiceEID])
REFERENCES [dbo].[eTypeService] ([TypeServiceId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_eTypeService]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_LPK] FOREIGN KEY([LPKId])
REFERENCES [dbo].[LPK] ([LPKId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_LPK]
GO
ALTER TABLE [dbo].[LPK]  WITH CHECK ADD  CONSTRAINT [FK_LPK_LPK1] FOREIGN KEY([LPKId])
REFERENCES [dbo].[LPK] ([LPKId])
GO
ALTER TABLE [dbo].[LPK] CHECK CONSTRAINT [FK_LPK_LPK1]
GO
ALTER TABLE [dbo].[LPKClientCurrentStatus]  WITH CHECK ADD  CONSTRAINT [FK_LPKClientCurrentStatus_eSubClientCurrentStatus] FOREIGN KEY([LPKSubClientCurrentStatusEID])
REFERENCES [dbo].[eSubClientCurrentStatus] ([SubClientCurrentStatusId])
GO
ALTER TABLE [dbo].[LPKClientCurrentStatus] CHECK CONSTRAINT [FK_LPKClientCurrentStatus_eSubClientCurrentStatus]
GO
ALTER TABLE [dbo].[LPKClientCurrentStatus]  WITH CHECK ADD  CONSTRAINT [FK_LPKClientCurrentStatus_LPK] FOREIGN KEY([LPKId])
REFERENCES [dbo].[LPK] ([LPKId])
GO
ALTER TABLE [dbo].[LPKClientCurrentStatus] CHECK CONSTRAINT [FK_LPKClientCurrentStatus_LPK]
GO
ALTER TABLE [dbo].[LPKSubContactTopic]  WITH CHECK ADD  CONSTRAINT [FK_LPKSubContactTopic_eSubContactTopic] FOREIGN KEY([LPKSubContactTopicEID])
REFERENCES [dbo].[eSubContactTopic] ([SubContactTopicId])
GO
ALTER TABLE [dbo].[LPKSubContactTopic] CHECK CONSTRAINT [FK_LPKSubContactTopic_eSubContactTopic]
GO
ALTER TABLE [dbo].[LPKSubContactTopic]  WITH CHECK ADD  CONSTRAINT [FK_LPKSubContactTopic_LPK] FOREIGN KEY([LPKId])
REFERENCES [dbo].[LPK] ([LPKId])
GO
ALTER TABLE [dbo].[LPKSubContactTopic] CHECK CONSTRAINT [FK_LPKSubContactTopic_LPK]
GO
ALTER TABLE [dbo].[LPKSubEndOfSpeech]  WITH CHECK ADD  CONSTRAINT [FK_LPKSubEndOfSpeech_eSubEndOfSpeech] FOREIGN KEY([LPKSubEndOfSpeechEID])
REFERENCES [dbo].[eSubEndOfSpeech] ([SubEndOfSpeechId])
GO
ALTER TABLE [dbo].[LPKSubEndOfSpeech] CHECK CONSTRAINT [FK_LPKSubEndOfSpeech_eSubEndOfSpeech]
GO
ALTER TABLE [dbo].[LPKSubEndOfSpeech]  WITH CHECK ADD  CONSTRAINT [FK_LPKSubEndOfSpeech_LPK] FOREIGN KEY([LPKId])
REFERENCES [dbo].[LPK] ([LPKId])
GO
ALTER TABLE [dbo].[LPKSubEndOfSpeech] CHECK CONSTRAINT [FK_LPKSubEndOfSpeech_LPK]
GO
