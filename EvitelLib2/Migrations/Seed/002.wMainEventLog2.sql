INSERT INTO [dbo].[MainEventLogs]([dtCreate],[LoginUserId],[eventCode],[eventSubCode],[Program],[Text],[Value])
VALUES ( GetDate(),-5,101,1,'testPrg','AnyText','AnyValue');
