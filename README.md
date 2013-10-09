#dbsu - database schema updater


#Overview
dbsu is a .NET (C#) application that lets you version your (MSSQL for a while) databases.

#Getting started 
  - [The easy way](#the-easy-way)
  - [Configuration reference](#configuration-reference)


##The easy way  
####1. InitDB.sql
- Run `dbsu.core\sql\InitDB-mssql.sql` on the database you want version to prepare it for dbsu.

####2. Folder hierarchy and sql scripts
  - Create a folder hierarchy for your sql scripts following the [connectionName structure](#connectionname-structure) (or follow the [default folder structure](#default-folder-structure)).
  - Create your sql scripts.

#### 3. dbsu.console.exe.config
  - Add the [rootDbPath](#rootdbpath) configuration.
  - Add the [connectionStrings](#connectionstrings) nodes according to [connectionName structure](#connectionname-structure) defined on step 2.

####4. dbsu.console.exe
  - Run the dbsu.console.exe


## Configuration reference
- [ConnectionName structure](#connectionname-structure)
- [Default folder structure](#default-folder-structure)
- [rootDbPath](#rootdbpath)
- [schemaScriptFolderName](#schemascriptfoldername)
- [connectionStrings](#connectionstrings)
- [Ordered execution](#ordered-execution)
- [Numeric suffix](#numeric-suffix)


###ConnectionName structure
dbsu allows you to version multiple databases. For this, you need to:

Inside the [rootDbPath](#rootdbpath) create folders for each database you want to version. 

The folder's names will be used later on [connectionStrings](#connectionstrings) configuration.

*Tip*: Can't you think on a good folder structure ? Use the [default folder structure](#default-folder-structure) !

###Default folder structure
Here's the default folder structure
```
- rootDbPath
  - MyConnection
    - Scripts-1
      + MyScript.sql
	- Function-2
	  + MyFunction.sql
	- Procedures-3
	  + MyProcedure.sql
```

###rootDbPath
Insert the `rootDbPath` settings to tell dbsu where is the root of all sql scripts.
```XML
<appSettings>
     <add name="rootDbPath" value="path_to_script_hierarchy"/>
</appSettings>
```
###schemaScriptFolderName
TODO!


###connectionStrings
For each folder in [rootDbPath](#rootdbpath) add a connectionString with name equals to the folder name.

*Example:* 

Suppose [rootDbPath](#rootdbpath) is equal to `C:\MyScripts` and we have  the following directory structure:
```
- MyScripts
  - MyConnection1
    - Scripts
      + myFirstScript.sql
   - MyConnection2
     - Procedures
       + myFirstProcedure.sql
```
We need to insert two connection strings: `MyConnection1` and `MyConnection2`. 

Thus, the `connectionString` section should looks like:

```XML
<connectionStrings>
  <add name="MyConnection1" connectionString="connection.string.to.my.connection1"/>
  <add name="MyConnection2" connectionString="connection.string.to.my.connection2"/>
</connectionStrings>
```

###Ordered execution
After reading all subfolders and files in [rootDbPath](#rootdbpath), dbsu will order it following this rules:

- First, order by [numeric suffix](#numeric-suffix)
- Then, order by alphabetical order.


*OBS:If the item doesn't have [numeric suffix](#numeric-suffix), only the alphabetical order will by applied.*

###Numeric suffix
Numeric suffix is indicated by `-n` on folder or file name, where `n` indicates the relative item order in folder.

*Examples:*

- MyScript-2.sql  `=> file with numeric suffix 2`
- MyProcedure-121.sql `=> file with numeric suffix 121`
- MyConnection-5  ->  `=> folder with numeric suffix 5`

*Tip*: You can use **numeric suffix** on folders too !
