/* Name Password */
DECLARE @LoginMode int = 22;




SET IDENTITY_INSERT [dbo].[LoginAccesses] ON
INSERT INTO [dbo].[LoginAccesses] ([LoginAccessId], [AccessName]) VALUES (1,'Administrator');
INSERT INTO [dbo].[LoginAccesses] ([LoginAccessId], [AccessName]) VALUES (2,'User');
INSERT INTO [dbo].[LoginAccesses] ([LoginAccessId], [AccessName]) VALUES (3,'PowerUser');
INSERT INTO [dbo].[LoginAccesses] ([LoginAccessId], [AccessName]) VALUES (4,'Archive');
SET IDENTITY_INSERT [dbo].[LoginAccesses] OFF

SET IDENTITY_INSERT [dbo].[LoginUsers] ON
if (@LoginMode = 1) BEGIN
    INSERT INTO [dbo].[LoginUsers] ([LoginUserId],[FirstName],[LastName],[LoginName],[LoginPassword],[Created]) VALUES (1,'User','User','user','user',GetDate());
END ELSE IF (@LoginMode = 21 OR @LoginMode = 22) BEGIN
    INSERT INTO [dbo].[LoginUsers] ([LoginUserId],[FirstName],[LastName],[LoginName],[LoginPassword],[Created]) VALUES (1,'Zdeněk','Petřík','ZPT','12345678',GetDate());
    INSERT INTO [dbo].[LoginUsers] ([LoginUserId],[FirstName],[LastName],[LoginName],[LoginPassword],[Created]) VALUES (2,'Simona','Hoskovsova','Hos','12345678',GetDate());
END
INSERT INTO [dbo].[LoginUsers] ([LoginUserId],[FirstName],[LastName],[LoginName],[LoginPassword],[Created]) VALUES (-99,'Unknown','Unknown','','',GetDate());
INSERT INTO [dbo].[LoginUsers] ([LoginUserId],[FirstName],[LastName],[LoginName],[LoginPassword],[Created]) VALUES (-5,'System','System','','',GetDate());

SET IDENTITY_INSERT [dbo].[LoginUsers] OFF




INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,1);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,2);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,3);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,4);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (2,1);

INSERT INTO [dbo].[MainSettings] ([Name],[sValue],[iValue],[dValue]) VALUES ('LoginPasswordMask','^([a-zA-Z0-9@*#!]{8,15})$',NULL,NULL);
INSERT INTO [dbo].[MainSettings] ([Name],[sValue],[iValue],[dValue]) VALUES ('LoginPassworderErrMessage','Heslo musí splňovat následující kritéria<br/>Délka 8-15 znaků<br/>Pouze alfanumerické znaky (A-Z,a-z,0-9)a speciální znaky @*#!',NULL,NULL);
INSERT INTO [dbo].[MainSettings] ([Name],[sValue],[iValue],[dValue]) VALUES ('LoginMode',NULL,@LoginMode,NULL);
