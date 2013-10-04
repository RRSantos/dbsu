if object_id('dbo.MyTestProcedure') is not null
begin
	drop procedure dbo.MyTestProcedure
	print '<< procedure dbo.MyTestProcedure dropped >>'
end
go

create procedure dbo.MyTestProcedure
as
begin
	select Field1 = 'OK'
	union all
		select Field1 = 'Error'
	union all
		select Field1 = 'Alert'
end
go
if object_id('dbo.MyTestProcedure') is not null
begin
	print '<< procedure dbo.MyTestProcedure created >>'
end
go