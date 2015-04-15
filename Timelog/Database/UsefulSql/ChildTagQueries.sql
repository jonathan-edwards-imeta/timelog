----------------------------------------------------------------
-- Example queries using the child tags function
----------------------------------------------------------------

--Find me all td/imp tasks.
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(5) ct on ct.id = bc.TagTree_Id

--Find all TD tasks
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(1) ct on ct.id = bc.TagTree_Id

--Find all BMO tasks
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(8) ct on ct.id = bc.TagTree_Id

--Get time for all MQ tasks.
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(null) ct on ct.id = bc.TagTree_Id
where ct.tag_id = 5

select * from Tag
