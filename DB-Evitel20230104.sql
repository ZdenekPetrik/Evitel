USE [master]
GO
/****** Object:  Database [Evitel2]    Script Date: 04.01.2023 11:24:41 ******/
CREATE DATABASE [Evitel2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Evitel2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Evitel2.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Evitel2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Evitel2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Evitel2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Evitel2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Evitel2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Evitel2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Evitel2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Evitel2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Evitel2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Evitel2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Evitel2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Evitel2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Evitel2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Evitel2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Evitel2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Evitel2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Evitel2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Evitel2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Evitel2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Evitel2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Evitel2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Evitel2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Evitel2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Evitel2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Evitel2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Evitel2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Evitel2] SET RECOVERY FULL 
GO
ALTER DATABASE [Evitel2] SET  MULTI_USER 
GO
ALTER DATABASE [Evitel2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Evitel2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Evitel2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Evitel2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Evitel2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Evitel2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Evitel2', N'ON'
GO
ALTER DATABASE [Evitel2] SET QUERY_STORE = OFF
GO
USE [Evitel2]
GO
/****** Object:  Table [dbo].[eDruhIntervence]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[eTypeParty]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[LoginUsers]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[Intervents]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[Regions]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  View [dbo].[wIntervent]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[wIntervent]
AS
SELECT        dbo.Intervents.InterventId, dbo.Intervents.Rank, dbo.Intervents.Title, dbo.Intervents.Name, dbo.Intervents.SurName, dbo.Regions.Name AS RegionName, dbo.Regions.RegionOrder, 
                         dbo.Regions.ShortName AS RegionShortName, dbo.Regions.ShortName + N' - ' + dbo.Intervents.Name + N' ' + dbo.Intervents.SurName AS cmbName, Phone, MobilPhone, PrivatePhone, Email, dbo.Intervents.dtCreate,  CAST(IIF(dbo.Intervents.dtDeleted IS NULL,0,1) AS BIT) isDeleted, dbo.Intervents.RegionId
FROM            dbo.Intervents INNER JOIN
                         dbo.Regions ON dbo.Intervents.RegionId = dbo.Regions.RegionId
GO
/****** Object:  Table [dbo].[Calls]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calls](
	[CallId] [int] IDENTITY(1,1) NOT NULL,
	[dtStartCall] [datetime2](7) NULL,
	[dtEndCall] [datetime2](7) NULL,
	[LoginUserId] [int] NULL,
 CONSTRAINT [PK_Calls] PRIMARY KEY CLUSTERED 
(
	[CallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIKOIntervence]    Script Date: 04.01.2023 11:24:41 ******/
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
 CONSTRAINT [PK_LIKOIntervence] PRIMARY KEY CLUSTERED 
(
	[LIKOIntervenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[wLIKOCalls]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- SELECT * from [dbo].[wLIKOCalls]
CREATE VIEW [dbo].[wLIKOCalls]
AS
SELECT        Cll.CallId,dbo.LIKOIntervence.LIKOIntervenceId,Cll.dtStartCall,
			  CAST(Cll.dtStartCall as Date) as dtCall,
			  CAST(Cll.dtEndCall as Date) as dtEndCall,
			  CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Cll.dtStartCall as Date), Cll.dtStartCall),0),114) as tmStartCall,
			  CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(Cll.dtEndCall as Date),Cll.dtEndCall ),0),114) as tmEndCall,
			  CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, Cll.dtStartCall, Cll.dtEndCall),0),114) as CallDuration, 
			  Cll.LoginUserId, usr.FirstName AS usrFirstName, 
                         usr.LastName AS usrLastName, dbo.wIntervent.InterventId, dbo.wIntervent.cmbName
FROM            dbo.Calls AS Cll INNER JOIN
                         dbo.LIKOIntervence ON Cll.CallId = dbo.LIKOIntervence.CallId LEFT OUTER JOIN
                         dbo.wIntervent ON dbo.LIKOIntervence.InterventId = dbo.wIntervent.InterventId LEFT OUTER JOIN
                         dbo.LoginUsers AS usr ON usr.LoginUserId = Cll.LoginUserId
GO
/****** Object:  View [dbo].[wLIKOIntervence]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/* 
   wIntervence spojuje tabulky LIKOIntervence s Intervents a LIKOCalls
   navic zobrazuje speciální 2 sloupce s rozděleným datumem a časem. 
   v1.0 01.01.2023 ZPT
*/

-- SELECT * from wIntervence

CREATE VIEW [dbo].[wLIKOIntervence]
AS
SELECT        dbo.LIKOIntervence.LIKOIntervenceId, dbo.LIKOIntervence.CallId, dbo.LIKOIntervence.LIKOIncidentId, dbo.LIKOIntervence.dtStartIntervence, dbo.LIKOIntervence.dtEndIntervence, dbo.LIKOIntervence.Note, 
              dbo.LIKOIntervence.ObetemPoskozenym, dbo.LIKOIntervence.PozustalymBlizkym, dbo.LIKOIntervence.Ostatnim, dbo.LIKOIntervence.LIKOIntervenceIDMaster, dbo.wLIKOCalls.dtStartCall, dbo.wLIKOCalls.dtEndCall, 
             dbo.wLIKOCalls.LoginUserId, dbo.wLIKOCalls.usrFirstName, dbo.wLIKOCalls.usrLastName, dbo.wIntervent.InterventId,dbo.wIntervent.cmbName AS InterventName,
			 CAST(dbo.LIKOIntervence.dtStartIntervence as Date) as dateStartIntervence,
			 CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(dbo.LIKOIntervence.dtStartIntervence as Date), dbo.LIKOIntervence.dtStartIntervence),0),114) as timeStartIntervence,
			 CAST(IIF(dbo.LIKOIntervence.LikoIntervenceIdmaster IS NULL,0,1) AS BIT) FirstIntervence
FROM            dbo.LIKOIntervence LEFT OUTER JOIN
                         dbo.wLIKOCalls ON dbo.LIKOIntervence.CallId = dbo.wLIKOCalls.CallId LEFT JOIN
						 dbo.wIntervent ON dbo.wIntervent.InterventId = dbo.LIKOIntervence.InterventId
GO
/****** Object:  Table [dbo].[eSex]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[LIKOParticipant]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIKOParticipant](
	[LIKOParticipantId] [int] IDENTITY(1,1) NOT NULL,
	[LIKOIntervenceId] [int] NULL,
	[TypePartyEID] [int] NULL,
	[SexEID] [int] NULL,
	[Age] [int] NULL,
	[IsDead] [bit] NULL,
	[IsInjury] [bit] NULL,
	[IsIntervence] [bit] NULL,
	[IsFirstIntervence] [bit] NULL,
	[DruhIntervenceEID] [int] NULL,
	[InterventId] [int] NULL,
	[IsAgreement] [bit] NULL,
	[IsContact] [bit] NULL,
	[IsPolicement] [bit] NULL,
	[IsPolicementClosePerson] [bit] NULL,
	[IsSenior] [bit] NULL,
	[IsChildJuvenile] [bit] NULL,
	[IsHandyCappedMedical] [bit] NULL,
	[IsHandyCappedMentally] [bit] NULL,
	[IsMemberMinorityGroup] [bit] NULL,
	[Organization] [nvarchar](255) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_LIKOParticipant] PRIMARY KEY CLUSTERED 
(
	[LIKOParticipantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[wLIKOParticipant]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
   wLIKOParticipant spojuje tabulky wLIKOParticipant  s wLIKOIntervence a číselníky wintervents eTypeParty eDruhIntervence eSex
   v1.0 01.01.2023 ZPT
*/

-- SELECT * FROM [dbo].[wLIKOParticipant]
CREATE VIEW [dbo].[wLIKOParticipant]
AS
SELECT        P.LIKOParticipantId, P.LIKOIntervenceId, P.TypePartyEID, P.SexEID, P.Age, P.IsDead, P.IsInjury, P.IsIntervence, P.IsFirstIntervence, P.DruhIntervenceEID, P.InterventId, P.IsAgreement, P.IsContact, P.IsPolicement, 
                         P.IsPolicementClosePerson, P.IsSenior, P.IsChildJuvenile, P.IsHandyCappedMedical, P.IsHandyCappedMentally, P.IsMemberMinorityGroup, P.Organization, P.Note, Interv.dtStartIntervence, Interv.dtEndIntervence, 
                         Interv.Note AS intervenceNote, Interv.ObetemPoskozenym, Interv.PozustalymBlizkym, Interv.Ostatnim, Interv.LIKOIntervenceIDMaster, Interv.dtStartCall, Interv.dtEndCall, Interv.usrFirstName, Interv.usrLastName, 
                         Sex.Text AS SexText, DruhInt.Text AS DruhIntervenceText, TypeParty.Text AS TypePartyText, Interv.InterventId AS MainInterventId, Interv.InterventName,
						 i.cmbName
FROM            dbo.LIKOParticipant AS P INNER JOIN
                         dbo.wLIKOIntervence AS Interv ON Interv.LIKOIntervenceId = P.LIKOIntervenceId LEFT OUTER JOIN
                         dbo.eSex AS Sex ON P.SexEID = Sex.SexId LEFT OUTER JOIN
                         dbo.eDruhIntervence AS DruhInt ON P.DruhIntervenceEID = DruhInt.DruhIntervenceId LEFT OUTER JOIN
                         dbo.eTypeParty AS TypeParty ON P.TypePartyEID = TypeParty.TypePartyId LEFT OUTER JOIN
                         dbo.wintervent AS i ON P.InterventId = i.InterventId
GO
/****** Object:  Table [dbo].[eTypeIncident]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[LIKOIncidents]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[eSubTypeIncident]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  View [dbo].[wLIKOIncident]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 
CREATE VIEW [dbo].[wLIKOIncident]
AS
SELECT        dbo.LIKOIncidents.LIKOIncidentId, Title, Note, SubTypeIncidentEID, dbo.LIKOIncidents.RegionId, dtIncident, NasledekSmrti, Dokonane, Pokus_Priprava, Place, PocetPoskozenych,
			  B.IntervenceCount, R.[Name] as RegionName,
			  sti.Text as IncidentName, ti.Text as IncidentCategory,
			  CAST(dtIncident as Date) as dtIncidentDate,
			  CONVERT(varchar(8),DATEADD(second, DATEDIFF(second, CAST(dtIncident as Date), dtIncident),0),114) as tmIncident,
			  C.LikoIntervenceId AS FirstLikoIntervenceId
FROM            dbo.LIKOIncidents LEFT JOIN 
(SELECT LikoIncidentId, COUNT(LikoIncidentId) as IntervenceCount FROM dbo.LikoIntervence GROUP BY LikoIncidentId ) AS B  ON B.LikoIncidentId = dbo.LIKOIncidents.LikoIncidentId
 LEFT JOIN dbo.Regions R ON dbo.LIKOIncidents.RegionId = R.RegionId
 LEFT JOIN dbo.eSubTypeIncident sti ON dbo.LIKOIncidents.SubTypeIncidentEID = sti.SubTypeIncidentId
 LEFT JOIN dbo.eTypeIncident ti ON ti.TypeIncidentId = sti.TypeIncidentId
 LEFT JOIN (SELECT LikoIntervenceId,LIKOIncidentId FROM dbo.LikoIntervence WHERE LIKOIntervenceIDMaster is NULL) AS C ON C.LikoIncidentId = dbo.LIKOIncidents.LikoIncidentId
GO
/****** Object:  Table [dbo].[MainEventLogs]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[States]    Script Date: 04.01.2023 11:24:41 ******/
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
	[ewfewfwef] [nchar](10) NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[wMainEventLogs]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[LoginAccesses]    Script Date: 04.01.2023 11:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginAccesses](
	[LoginAccessId] [int] IDENTITY(1,1) NOT NULL,
	[AccessName] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoginAccesses] PRIMARY KEY CLUSTERED 
(
	[LoginAccessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginAccessUsers]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[MainSettings]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[UserColumns]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Table [dbo].[UserSetting]    Script Date: 04.01.2023 11:24:41 ******/
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
/****** Object:  Index [IX_LoginAccessUsers_LoginUserId]    Script Date: 04.01.2023 11:24:41 ******/
CREATE NONCLUSTERED INDEX [IX_LoginAccessUsers_LoginUserId] ON [dbo].[LoginAccessUsers]
(
	[LoginUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Intervents] ADD  CONSTRAINT [DF_Intervents_dtCreate]  DEFAULT (getdate()) FOR [dtCreate]
GO
ALTER TABLE [dbo].[Calls]  WITH NOCHECK ADD  CONSTRAINT [FK_Calls_Intervents] FOREIGN KEY([CallId])
REFERENCES [dbo].[Intervents] ([InterventId])
GO
ALTER TABLE [dbo].[Calls] CHECK CONSTRAINT [FK_Calls_Intervents]
GO
ALTER TABLE [dbo].[Calls]  WITH CHECK ADD  CONSTRAINT [FK_Calls_LoginUsers] FOREIGN KEY([LoginUserId])
REFERENCES [dbo].[LoginUsers] ([LoginUserId])
GO
ALTER TABLE [dbo].[Calls] CHECK CONSTRAINT [FK_Calls_LoginUsers]
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
ALTER TABLE [dbo].[LIKOIntervence]  WITH CHECK ADD  CONSTRAINT [FK_LIKOIntervence_LIKOIncidents] FOREIGN KEY([LIKOIntervenceId])
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
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Intervents"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "Regions"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4485
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wIntervent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wIntervent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "usr"
            Begin Extent = 
               Top = 3
               Left = 357
               Bottom = 133
               Right = 527
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LIKOIntervence"
            Begin Extent = 
               Top = 173
               Left = 252
               Bottom = 303
               Right = 468
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Cll"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "wIntervent"
            Begin Extent = 
               Top = 6
               Left = 565
               Bottom = 136
               Right = 751
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOCalls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOCalls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOCalls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[21] 4[40] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LIKOIncidents"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2100
         Width = 1500
         Width = 2610
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOIncident'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOIncident'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LIKOIntervence"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "wLIKOCalls"
            Begin Extent = 
               Top = 4
               Left = 322
               Bottom = 134
               Right = 492
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOIntervence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOIntervence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[15] 2[22] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "P"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 260
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interv"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sex"
            Begin Extent = 
               Top = 138
               Left = 292
               Bottom = 251
               Right = 462
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DruhInt"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 383
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TypeParty"
            Begin Extent = 
               Top = 252
               Left = 292
               Bottom = 365
               Right = 462
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOParticipant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOParticipant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wLIKOParticipant'
GO
USE [master]
GO
ALTER DATABASE [Evitel2] SET  READ_WRITE 
GO
