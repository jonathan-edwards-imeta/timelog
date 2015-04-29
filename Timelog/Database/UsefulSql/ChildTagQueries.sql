----------------------------------------------------------------
-- Example queries using the child tags function
----------------------------------------------------------------

--Find me all td/imp tasks.
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(5) ct on ct.id = bc.TagTreeId

--Find all TD tasks
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(1) ct on ct.id = bc.TagTreeId

--Find all BMO tasks
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(8) ct on ct.id = bc.TagTreeId

--Get time for all MQ tasks.
select * from TimeEntry te
join BookingCode bc on bc.Id = te.BookingCodeId
join cfGetChildTags(null) ct on ct.id = bc.TagTreeId
where ct.tag_id = 5

select * from Tag
