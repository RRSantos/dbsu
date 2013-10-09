if object_id('dbo.MyTestFunction') is not null
begin
	drop function dbo.MyTestFunction
	print '<< function dbo.MyTestFunction dropped >>'
end
go

create function dbo.MyTestFunction()
	returns int
as
begin
	return 1
end
go

if object_id('dbo.MyTestFunction') is not null
begin
	print '<< function dbo.MyTestFunction created >>'
end
go