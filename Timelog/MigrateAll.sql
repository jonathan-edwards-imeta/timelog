

DELETE FROM [dbo].[User]
DELETE FROM [dbo].[TimeEntry]
DELETE FROM [dbo].[BookingCode]
DELETE FROM [TimeLog].[dbo].[TagTree]
DELETE FROM [TimeLog].[dbo].[Tag]
 
--Fix collation of user names to match old db
ALTER TABLE [TimeLog].[dbo].[User]
  ALTER COLUMN [Name]
    NVARCHAR(max) COLLATE SQL_Latin1_General_CP1_CI_AS;

ALTER TABLE [TimeLog].[dbo].[Tag]
  ALTER COLUMN [Text]
    NVARCHAR(max) COLLATE SQL_Latin1_General_CP1_CI_AS;

--insert in all old usernames
INSERT INTO [TimeLog].[dbo].[User] ([Name]) SELECT [UserName] FROM [TimeTracker].[dbo].[aspnet_Users];

--create task tags from categories
--create project tags from categories
INSERT INTO [TimeLog].[dbo].[Tag] ([Text],[TagTypeId])
(SELECT distinct [CategoryName], 4 FROM [TimeTracker].[dbo].[aspnet_starterkits_ProjectCategories]
UNION
SELECT distinct [ProjectName], 1 FROM [TimeTracker].[dbo].[aspnet_starterkits_Projects])

--create tag trees from projects
INSERT INTO [dbo].[TagTree] ([RelatedTagTreeId],[TagId]) 
     select null, [Id] from [TimeLog].[dbo].[Tag] where [TagTypeId] = 1;

--@todo FIX THIS
--create tag trees from project categories
INSERT INTO [dbo].[TagTree] ([RelatedTagTreeId],[TagId]) 
     select  tt.Id, pct.[Id] 
		from [TimeTracker].[dbo].[aspnet_starterkits_ProjectCategories] pc
		join [TimeTracker].[dbo].[aspnet_starterkits_Projects] p on pc.ProjectId = p.ProjectId
		join [TimeLog].[dbo].[Tag] pct on pct.[Text] = pc.[CategoryName] and pct.[TagTypeId] = 4
		join [TimeLog].[dbo].[Tag] pt on pt.[Text] = p.[ProjectName] and pt.[TagTypeId] = 1
		join [TimeLog].[dbo].[TagTree] tt on tt.TagId = pt.Id

--create booking codes from category ids
SET IDENTITY_INSERT [TimeLog].[dbo].[BookingCode] ON
DELETE FROM [TimeLog].[dbo].[BookingCode] where [Id] < 1000;

INSERT INTO [TimeLog].[dbo].[BookingCode] ([Id], [TagTreeId])
	select distinct pc.CategoryId, tt.Id
		from [TimeTracker].[dbo].[aspnet_starterkits_ProjectCategories] pc
			join [TimeTracker].[dbo].[aspnet_starterkits_Projects] p on pc.ProjectId = p.ProjectId
			join [TimeLog].[dbo].[Tag] pct on pct.[Text] = pc.[CategoryName] and pct.[TagTypeId] = 4
			join [TimeLog].[dbo].[Tag] pt on pt.[Text] = p.[ProjectName] and pt.[TagTypeId] = 1
			join [TimeLog].[dbo].[TagTree] rtt on rtt.TagId = pt.Id
			join [TimeLog].[dbo].[TagTree] tt on tt.TagId = pct.Id and tt.RelatedTagTreeId = rtt.Id

DBCC checkident ("[TimeLog].[dbo].[BookingCode]", reseed, 1000);

SET IDENTITY_INSERT [TimeLog].[dbo].[BookingCode] OFF

--create time entries
INSERT INTO [TimeLog].[dbo].[TimeEntry]
           ([TimeEntryCreated]
           ,[TimeEntryDuration]
           ,[TimeEntryDescription]
           ,[TimeEntryDate]
           ,[BookingCodeId]
           ,[TimeEntryCreatorId]
           ,[TimeEntryUserId])
     Select [TimeEntryCreated]
      ,[TimeEntryDuration]
      ,[TimeEntryDescription]     
      ,[TimeEntryDate]
	  ,[CategoryId]
      ,(select [Id] from [TimeLog].[dbo].[User] where [TimeLog].[dbo].[User].[Name] = (SELECT [UserName] FROM [TimeTracker].[dbo].[aspnet_Users] where [UserId] = [TimeEntryCreatorId]))
      ,(select [Id] from [TimeLog].[dbo].[User] where [TimeLog].[dbo].[User].[Name] = (SELECT [UserName] FROM [TimeTracker].[dbo].[aspnet_Users] where [UserId] = [TimeEntryUserId]))
  FROM [TimeTracker].[dbo].[aspnet_starterkits_TimeEntry];
