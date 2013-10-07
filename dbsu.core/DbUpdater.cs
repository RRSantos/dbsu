using System;
using System.Collections.Generic;
using dbsu.core.DTO;
using dbsu.core.Logging;
using dbsu.core.Persistence;

namespace dbsu.core
{
    public class DbUpdater
    {
        private readonly DbFileManager dbFileManager;
        private readonly string dbRootPath;
        private readonly string schemaScriptPathName;
        private ILogger logger = new NullLogger(); 
        
        public DbUpdater()
        {
            this.dbRootPath = Configuration.GetRootDbPath();
            this.schemaScriptPathName = Configuration.GetSchemaScriptFolderName();
            this.dbFileManager = new DbFileManager(this.dbRootPath);
        }

        public void SetLogger(ILogger logger)
        {
            this.logger = logger;
        }
        
        public void UpdateDb()
        {
            var scriptContainer = dbFileManager.GetScripts();
            
            foreach (var connection in scriptContainer.Connections)
            {
                logger.LogInfo(string.Format("Found connection '{0}'", connection.Name));
                using (var persistence = PersistenceFactory.GetPersistence(connection.Name))
                {
                    try
                    {
                        var lastSchemaScriptExecutedOrder = persistence.GetLastExecutedSchemaScriptOrder();
                        logger.LogInfo(string.Format("Found lastSchemaScriptExecutedOrder '{0}'", lastSchemaScriptExecutedOrder));
                        foreach (var objectType in connection.ObjectTypes)
                        {
                            logger.LogInfo(string.Format("Found objectType '{0}'", objectType.Name));
                            var dontVerifyLastScriptExecutionOrder = !objectType.Name.Contains(schemaScriptPathName);
                            foreach (var script in objectType.Scripts)
                            {
                                logger.LogInfo(string.Format("Found script '{0}'", script.Name));
                                if (dontVerifyLastScriptExecutionOrder || (script.Order > lastSchemaScriptExecutedOrder))
                                    persistence.ExecuteScript(script.Content);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        logger.LogError("An error ocurred while trying to update database", e);
                    }
                }
            }
            
        }

        
    }
}
