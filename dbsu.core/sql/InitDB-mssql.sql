select Isnull(max(ScriptOrder),0) from dbo.DatabaseVersionControl

/* dbo.DatabaseVersionControl table */
if object_id('dbo.DatabaseVersionControl') is not null
begin
	drop table dbo.DatabaseVersionControl
	print '<< table dbo.DatabaseVersionControl dropped >>'
end
go

create table dbo.DatabaseVersionControl
	(
		 Id 			int identity(1,1)
		,ScriptOrder	int
		,ScriptName		varchar(255)
		,InsertDate		datetime
	)
go	

if object_id('dbo.DatabaseVersionControl') is not null
begin
	print '<< table dbo.DatabaseVersionControl created >>'
end
go


/* dbo.VerifyScriptOrder procedure */
if object_id('dbo.VerifyScriptOrder') is not null
begin
	drop procedure dbo.VerifyScriptOrder
	print '<< procedure dbo.VerifyScriptOrder dropped>>'
end
go

create procedure dbo.VerifyScriptOrder
	 @ScriptOrder	int
	,@ScriptName	varchar(255)
as
begin
	declare
		 @ExpectedOrder	int
		,@errorMessage varchar(100)

	set @ExpectedOrder = 0

	select @ExpectedOrder = isnull(max(a.ScriptOrder), 0) + 1
	from dbo.DatabaseVersionControl a

	if @ScriptOrder != @ExpectedOrder
	begin
		set @errorMessage = 'Script [' + left(@ScriptName,30) + ']: Wrong script order. Expected [' + convert(varchar(5), @ExpectedOrder) + ']. Actual: [' + convert(varchar(5), @ScriptOrder) + '].' 
		raiserror( @errorMessage, 18, 18)
		return -1		
	end

	return 0
end
go
if object_id('dbo.VerifyScriptOrder') is not null
begin	
	print '<< procedure dbo.VerifyScriptOrder created>>'
end
go



/* dbo.UpdateDatabaseVersionControl procedure */

if object_id('dbo.UpdateDatabaseVersionControl') is not null
begin
	drop procedure dbo.UpdateDatabaseVersionControl
	print '<< procedure dbo.UpdateDatabaseVersionControl dropped>>'
end
go

create procedure dbo.UpdateDatabaseVersionControl
	 @ScriptOrder	int
	,@ScriptName	varchar(255)
as
begin
	declare @isIncorrectOrder int
	exec @isIncorrectOrder = dbo.VerifyScriptOrder @ScriptOrder, @ScriptName

	if @isIncorrectOrder = 0
	begin
		insert into DatabaseVersionControl(ScriptOrder, ScriptName, InsertDate) values (@ScriptOrder, @ScriptName, getdate())
	end
end
go
if object_id('dbo.UpdateDatabaseVersionControl') is not null
begin	
	print '<< procedure dbo.UpdateDatabaseVersionControl created>>'
end
go