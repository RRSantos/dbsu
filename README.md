#dbsu - database schema updater
dbsu is a .NET (C#) application that lets you version your (MSSQL for a while) databases.

##Getting started - The easy way
####1. InitDB.sql
  - Run `InitDB.sql` on the database you want version to prepare it for dbsu.

####2. Folder hierarchy and sql scripts
  - Create a folder hierarchy for your sql scripts following the **connection name rule**.
  - Create your sql scripts.

#### 3. dbsu.console.exe.config
  - Insert the rootDbPath configuration.
  - Insert the connection string configurations according to **connection name rule** defined on step 2.

####4. dbsu.console.exe
  - Run the dbsu.console.exe



## Configuration reference
- ConnectionName structure
- rootDbPath
- schemaScriptFolderName
- connectionStrings


##Connection name rule
TODO!

##Ordered execution
TODO!


##Configuration
###rootDbPath
Insert the `rootDbPath` settings to tells dbsu where is the root of all sql scripts.
```XML
<appSettings>
     <add name="rootDbPath" value="path_to_script_hierarchy"/>
</appSettings>
```
###schemaScriptFolderName
TODO!


###ConnectionString
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