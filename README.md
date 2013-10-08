#dbsu - database schema updater
dbsu is a .NET (C#) application that lets you version your (MSSQL for a while) databases.

##Getting started 
  - [The easy way](#the-easy-way)
  - [Configuration reference](#configuration-reference)


##The easy way  
####1. InitDB.sql
  - Run `InitDB.sql` on the database you want version to prepare it for dbsu.

####2. Folder hierarchy and sql scripts
  - Create a folder hierarchy for your sql scripts following the [connectionName structure](#connectionname-structure).
  - Create your sql scripts.

#### 3. dbsu.console.exe.config
  - Add the [rootDbPath](#rootdbpath) configuration.
  - Add the [connectionStrings](#connectionstrings) nodes according to [connectionName structure](#connectionname-structure) defined on step 2.

####4. dbsu.console.exe
  - Run the dbsu.console.exe



## Configuration reference
- [ConnectionName structure](#connectionname-structure)
- [rootDbPath](#rootdbpath)
- [schemaScriptFolderName](#schemascriptfoldername)
- [connectionStrings](#connectionstrings)
- [Ordered execution](#ordered-execution)


##ConnectionName structure
TODO!

###rootDbPath
Insert the `rootDbPath` settings to tells dbsu where is the root of all sql scripts.
```XML
<appSettings>
     <add name="rootDbPath" value="path_to_script_hierarchy"/>
</appSettings>
```
###schemaScriptFolderName
TODO!


###connectionStrings
For each folder in `rootDbPath` add a connectionString with name equals to the folder name.

*Example:* Suppose `rootDbPath` is equal to `C:\MyScripts` and we have  the following directory structure:

- MyScripts
   - **MyConnection1**
      -  Scripts
              - myFirstScript.sql
   - **MyConnection2**
      -  Procedures
              - myFirstProcedure.sql 

So, we need to insert two connection strings: `MyConnection1` and `MyConnection2`. Thus, the `connectionString` section should looks like:

```XML
<connectionStrings>
  <add name="MyConnection1" connectionString="connection.string.to.my.connection1"/>
  <add name="MyConnection2" connectionString="connection.string.to.my.connection2"/>
</connectionStrings>
```

##Ordered execution
By default, dbsu executes all the scripts (in all subfolders) following an alphabetical order. If you need to change this order (including connection subfolders) just suffix the subfolders/scripts with a dash and a number to indicate the desired order. 

*Example:* 
Suppose we have this directory structure:


- AConnection-2
  -  AProcedures-2
    - AProc-2.sql
    - BProc-1.sql
  - BScripts-1
    - AScript.sql
    - BScript-1.sql
    - XScript.sql
- BConnection-1
  -  AProcedures
    - A.sql    
  - BScripts-1
    - A.sql
    
So, dbsu will read and execute the scripts in the following order:

- BConnection-1 
  - BScripts-1 
    - A.sql 
  -  AProcedures 
    - A.sql
- AConnection-2 
  - BScripts-1     
    - BScript-1.sql 
    - AScript.sql  *(for non-suffixed names, dbsu considers the alphabetical order)*
    - XScript.sql
  -  AProcedures-2
    - BProc-1.sql
    - AProc-2.sql
    
  
  
    