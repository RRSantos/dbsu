/*
script-2.sql
Script for test 3
*/
begin transaction;

begin try
	exec dbo.UpdateDatabaseVersionControl @ScriptOrder = 3, @ScriptName = 'script-3.sql'
	
	alter table dbo.MyFirstTable add DeleteDate datetime not null	
	
	commit transaction;
end try
begin catch
	rollback transaction;
	THROW 
end catch