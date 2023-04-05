USE [Evitel2]
GO
/****** Object:  View [dbo].[wIntervent]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 

   v1.0 01.01.2023 ZPT
   v1.1 25.02.2023 ZPT cmbName nejprve pøijmení

-- SELECT * FROM [dbo].[wIntervent]
*/




ALTER VIEW [dbo].[wIntervent]
AS
SELECT        dbo.Intervents.InterventId, dbo.Intervents.Rank, dbo.Intervents.Title, dbo.Intervents.Name, dbo.Intervents.SurName, dbo.Regions.Name AS RegionName, dbo.Regions.RegionOrder, 
                         dbo.Regions.ShortName AS RegionShortName, dbo.Intervents.SurName + N' ' +  dbo.Intervents.Name + N' (' + dbo.Regions.ShortName + N')'  AS cmbName, Phone, MobilPhone, PrivatePhone, Email, dbo.Intervents.dtCreate,  CAST(IIF(dbo.Intervents.dtDeleted IS NULL,0,1) AS BIT) isDeleted, dbo.Intervents.RegionId,
						  dbo.Intervents.SurName + CASE WHEN dbo.Intervents.[Name] is NULL OR LEN(dbo.Intervents.[Name]) =0 THEN '' ELSE ' '+ LEFT(dbo.Intervents.Name,1)+'.' END AS InterventShortName
FROM            dbo.Intervents INNER JOIN
                         dbo.Regions ON dbo.Intervents.RegionId = dbo.Regions.RegionId
GO
/****** Object:  View [dbo].[wLIKOIntervence]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/* 
   wLIKOAll spojuje tabulky LIKOParticipant  s LIKOIntervence a èíselníky wintervents eTypeParty eDruhIntervence eSex
   v1.0 01.01.2023 ZPT
   v1.1 05.02.2023 ZPT plnì pøepracováno 
   v1.3 01.04.2023 - ZPT doplneni YEAR/MONTH

 SELECT * FROM [dbo].[wLIKOIntervence]
 */
ALTER VIEW [dbo].[wLIKOIntervence]
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
/****** Object:  View [dbo].[wLIKOAll]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/* 
   wLIKOAll spojuje tabulky LIKOParticipant  s LIKOIntervence a èíselníky wintervents eTypeParty eDruhIntervence eSex
   v1.0 01.01.2023 ZPT
   v1.1 05.02.2023 ZPT plnì pøepracováno 
   v1.1 18.03.2023 ZPT Rok a mesic incidentu, zruseni Nasledek smrti,Dokonaná, pokus/pøíprava,
   v1.3 1.4.2023 - ZPT doplneni YEAR/MONTH
 SELECT * FROM [dbo].[wLIKOAll]
 */
ALTER VIEW [dbo].[wLIKOAll]
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
/****** Object:  View [dbo].[wLIKOCalls]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- SELECT * from [dbo].[wLIKOCalls]
-- 1.4.2023 - ZPT doplneni YEAR/MONTH

ALTER VIEW [dbo].[wLIKOCalls]
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
/****** Object:  View [dbo].[wLIKOParticipant]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/* 
   wLIKOParticipant spojuje tabulky wLIKOParticipant  s wLIKOIntervence a èíselníky wintervents eTypeParty eDruhIntervence eSex
   v1.0 01.01.2023 ZPT
   V1.1 14.01.2023 ZPT Pridano Poradi, InterventId2, isAgreementBKB
   V1.2 04.02.2023 ZPT Poradi + InterventName2
   V1.3 26.02.2023 ZPT Uprava pro zmenu v wLIKOIntervence
   v1.3 01.04.2023 - ZPT doplneni YEAR/MONTH

*/

-- SELECT * FROM [dbo].[wLIKOParticipant]
ALTER VIEW [dbo].[wLIKOParticipant]
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
/****** Object:  View [dbo].[wLIKOIncident]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* 
   v1.0 01.01.2023 ZPT
   v1.1 05.02.2023 ZPT plnì pøepracováno 
   v1.3 01.04.2023 - ZPT doplneni YEAR/MONTH
 SELECT * FROM [dbo].[wLIKOIncident]
 */
ALTER VIEW [dbo].[wLIKOIncident]
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
/****** Object:  View [dbo].[wCalls]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* SELECT * from [dbo].[wCalls]*/
-- 1.4.2023 - ZPT doplneni YEAR/MONTH
ALTER VIEW [dbo].[wCalls]
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
/****** Object:  View [dbo].[wLPK]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*    SELECT * FROM [dbo].[wLPK]*/
ALTER VIEW [dbo].[wLPK]
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
/****** Object:  View [dbo].[wMainEventLogs]    Script Date: 05.04.2023 6:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
