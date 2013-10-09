/*
script-1.sql
Script for test
*/
begin transaction;

begin try
	exec dbo.UpdateDatabaseVersionControl @ScriptOrder = 1, @ScriptName = 'script-1.sql'
	
	create table dbo.MyFirstTable (Id int Identity, Name varchar(100))
	
	commit transaction;
end try
begin catch
	rollback transaction;
	THROW 
end catch