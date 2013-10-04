#dbsu


*dbsu* stands for **d**ata**b**ase **s**chema **u**pdater.
It's an easy and customizable way to version your MSSQL database.

##Getting started

1. Clone this repository 
2. Compile the solution
3. Add the dbsu.core.dll to references in your project
4. Insert (or alter) a configuration file of your project (App.config or Web.config)
  
##Configuration file
___
###appSettings section
dbsu uses the configurations key/value pair shown below:
- **rootDbPath**: Indicates de root path where the scripts will be loaded. It could be relative ou full path.
- **schemaScriptFolderName**: _[Optional]_ Indicates the name of the folder that contains the alter schema scripts (alter table, drop table, create index, etc.). **_Default_**: Scripts
 
###connectionStrings
dbsu uses the connection strings according to the directory hierarchy on the **rootDbPath** path. 
- rootDbPath
 - **MyDatabase1**
   - Scripts
     - script1.sql
