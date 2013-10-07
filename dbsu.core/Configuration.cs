using System.Configuration;

namespace dbsu.core
{
    internal static class Configuration
    {
        private static string NoRootDbPath = "Configuração [rootDbPath] não encontrada";
        private static string ConnectionStringNotFound = "Connection string [{0}] não encontrada";

        private static string defaultSchemaScriptPathName = "Scripts";
        
        public static string GetRootDbPath()
        {
            var dbRootPath = ConfigurationManager.AppSettings["rootDbPath"];
            
            if (!string.IsNullOrEmpty(dbRootPath))
                return dbRootPath;
            
            throw new ConfigurationErrorsException(NoRootDbPath);
        }

        public static string GetConnectionString(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name];

            if (connectionString != null)
                return connectionString.ConnectionString;

            throw new ConfigurationErrorsException(string.Format(ConnectionStringNotFound, name));
        }

        public static string GetSchemaScriptFolderName()
        {
            var schemaScriptPathName = ConfigurationManager.ConnectionStrings["schemaScriptFolderName"];

            if (schemaScriptPathName != null)
                return schemaScriptPathName.ConnectionString;

            return defaultSchemaScriptPathName;
            
        }
    }
}
