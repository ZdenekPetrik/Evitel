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
INSERT INTO [dbo].[LoginUsers] ([LoginUserId],[FirstName],[LastName],[LoginName],[LoginPassword],[Created]) VALUES (-99,'Unknown','Unknown','<Unkwown>','<NoPassword>',GetDate());
INSERT INTO [dbo].[LoginUsers] ([LoginUserId],[FirstName],[LastName],[LoginName],[LoginPassword],[Created]) VALUES (-5,'System','System','<System>','<NoPassword>',GetDate());

SET IDENTITY_INSERT [dbo].[LoginUsers] OFF




INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,1);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,2);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,3);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (1,4);
INSERT INTO [dbo].[LoginAccessUsers] ([LoginUserId],[LoginAccessId]) VALUES (2,1);

INSERT INTO [dbo].[MainSettings] ([Name],[sValue],[iValue],[dValue]) VALUES ('LoginPasswordMask','^([a-zA-Z0-9@*#!]{8,15})$',NULL,NULL);
INSERT INTO [dbo].[MainSettings] ([Name],[sValue],[iValue],[dValue]) VALUES ('LoginPassworderErrMessage','Heslo musí splňovat následující kritéria<br/>Délka 8-15 znaků<br/>Pouze alfanumerické znaky (A-Z,a-z,0-9)a speciální znaky @*#!',NULL,NULL);
INSERT INTO [dbo].[MainSettings] ([Name],[sValue],[iValue],[dValue]) VALUES ('LoginMode',NULL,@LoginMode,NULL);



INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (99,101,'Event','Program','Událost programu (Start,Stop,Fáze )');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (99,102,'Event','Login','Přihlašování');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (99,103,'Event','Message','Zpráva typu Error,Warning ,Info');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (98,1,'SubType','Start','Začátek (programu, procesu, přihlášení)');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (98,2,'SubType','Stop','Konec (programu, procesu, přihlášení)');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (98,3,'SubType','BadLogin','Neúspěšný pokus o přihlášení');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (98,11,'SubType','Error','Chyba');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (98,12,'SubType','Warning','Upozornění');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (98,13,'SubType','Info','Informace');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (98,14,'SubType','Debug','Debug');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (97,21,'SubType','New','Nový zápis');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (97,22,'SubType','Update','Úprava');
INSERT INTO [dbo].[States] (StateType,StateValue,DescriptionType,DescriptionValue,Description) VALUES (97,23,'SubType','Delete','Smazání');
