
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
