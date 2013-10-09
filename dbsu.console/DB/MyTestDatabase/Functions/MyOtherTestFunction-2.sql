if object_id('dbo.MyOtherTestFunction') is not null
begin
	drop function dbo.MyOtherTestFunction
	print '<< function dbo.MyOtherTestFunction dropped >>'
end
go

create function dbo.MyOtherTestFunction()
	returns int
as
begin
	return 3
end
go

if object_id('dbo.MyOtherTestFunction') is not null
begin
	print '<< function dbo.MyOtherTestFunction created >>'
end
go