
/*********************
 * After insert tridder on old TimeEntry table 
 */

 IF OBJECT_ID('TRG_InsertSyncTimEntries') IS NOT NULL
 DROP TRIGGER TRG_InsertSyncTimEntries
 GO

 CREATE TRIGGER TRG_InsertSyncTimEntries
 ON [TimeTracker].[dbo].[aspnet_starterkits_TimeEntry]
 AFTER INSERT AS
 BEGIN
INSERT INTO [TimeLog].[dbo].[TimeEntry]
           ([TimeEntryCreated]
           ,[TimeEntryDuration]
           ,[TimeEntryDescription]
           ,[TimeEntryDate]
           ,[BookingCodeId]
           ,[TimeEntryCreatorId]
           ,[TimeEntryUserId])
     Select 
      ,[TimeEntryCreated]
      ,[TimeEntryDuration]
      ,[TimeEntryDescription]     
      ,[TimeEntryDate]
	  ,[CategoryId]
      ,[TimeEntryCreatorId]
      ,[TimeEntryUserId] from INSERTED
 END
 GO
