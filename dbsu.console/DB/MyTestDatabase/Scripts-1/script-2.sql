/*
script-2.sql
Script for test 2
*/
begin transaction;

begin try
	exec dbo.UpdateDatabaseVersionControl @ScriptOrder = 2, @ScriptName = 'script-2.sql'
	
	alter table dbo.MyFirstTable add InsertDate datetime not null	
	
	commit transaction;
end try
begin catch
	rollback transaction;
	THROW 
end catch