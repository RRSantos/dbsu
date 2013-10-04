if object_id('dbo.MyOtherTestProcedure') is not null
begin
	drop procedure dbo.MyOtherTestProcedure
	print '<< procedure dbo.MyOtherTestProcedure dropped >>'
end
go

create procedure dbo.MyOtherTestProcedure
as
begin
	select Field1 = 'OK-2'
	union all
		select Field1 = 'Error-2'
	union all
		select Field1 = 'Alert-2'
end
go
if object_id('dbo.MyOtherTestProcedure') is not null
begin
	print '<< procedure dbo.MyOtherTestProcedure created >>'
end
go