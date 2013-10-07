using System.Collections.Generic;
using System.IO;
using System.Linq;
using dbsu.core.DTO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("dbsu.core.tests")]
namespace dbsu.core
{
    internal class DbFileManager
    {
        private readonly string rootPath;

        private List<DbConnection> getConnections()
        {
            var result = new List<DbConnection>();

            var directories = Directory.GetDirectories(this.rootPath);
            foreach (var dir in directories)
	        {
                var connection = new DbConnection
                {
                    Name = Path.GetFileNameWithoutExtension(dir)
                };

                result.Add(connection);
	        }
            
            result = result.OrderBy(x => x.Order).ToList();
            return result;
        }

        private List<DbObjectType> getObjectTypes(string connectionName)
        {
            var result = new List<DbObjectType>();
            var searchPath = Path.Combine(this.rootPath, connectionName);
            var directories = Directory.GetDirectories(searchPath);
            
            foreach (var dir in directories)
            {
                var objectType = new DbObjectType
                {
                    Name = Path.GetFileNameWithoutExtension(dir)
                };

                result.Add(objectType);
            }
            
            result = result.OrderBy(x => x.Order).ToList();
            return result;
        }

        private List<DbScript> getScripts(string connectionName, string objectTypeName)
        {
            var result = new List<DbScript>();

            var searchPath = Path.Combine(this.rootPath, connectionName, objectTypeName);

            var files = Directory.GetFiles(searchPath, "*.sql", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var script = new DbScript
                {
                    Path = Path.GetFullPath(file),
                    Content = File.ReadAllText(file),
                    Name = Path.GetFileNameWithoutExtension(file)
                };

                result.Add(script);
            }
            
            result = result.OrderBy(x => x.Order).ToList();
            return result;
        }

        public DbFileManager(string rootPath)
        {
            this.rootPath = rootPath;
        }

        public DbScriptContainer GetScripts()
        {
            var result = new DbScriptContainer();

            result.Connections = getConnections();
            foreach (var connection in result.Connections)
            {
                connection.ObjectTypes = getObjectTypes(connection.Name);

                foreach (var objectType in connection.ObjectTypes)
                {
                    objectType.Scripts = getScripts(connection.Name, objectType.Name);
                }
            }

            return result;
        }
    }
}
