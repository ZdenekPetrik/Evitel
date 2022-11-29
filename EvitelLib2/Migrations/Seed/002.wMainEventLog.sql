CREATE View [dbo].[wMainEventLogs] AS
SELECT   l.*, u.FirstName as UserFirstName, u.LastName as UserLastName, s1.DescriptionValue CodeText, s2.DescriptionValue SubCodeText    
FROM    dbo.MainEventLogs l LEFT JOIN 
dbo.States s1 ON s1.StateType = 99 and s1.StateValue = l.eventCode LEFT JOIN
dbo.States s2 ON s2.StateType = 98 and s2.StateValue = l.eventSubCode LEFT JOIN
dbo.LoginUsers u ON u.LoginUserId = l.LoginUserId;

