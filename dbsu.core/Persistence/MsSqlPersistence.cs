using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace dbsu.core.Persistence
{
    public class MsSqlPersistence:IPersistence
    {
        private readonly SqlConnection connection;
        private readonly string[] scriptSeparator = new string[] { "GO", "Go", "gO", "go" };

        private void openConnection()
        {
            if (this.connection.State != System.Data.ConnectionState.Open)
                this.connection.Open();
        }


        public MsSqlPersistence(string connectionStringName)
        {
            var defaultConnectionsString = Configuration.GetConnectionString(connectionStringName);
            this.connection = new SqlConnection(defaultConnectionsString);

        }

        public void ExecuteScript(string scriptContent)
        {
            
            var splittedContent = scriptContent.Split(scriptSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var script in splittedContent)
            {
                using (var sqlCommand = new SqlCommand(script, this.connection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    openConnection();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            
        }

        public int GetLastExecutedSchemaScriptOrder()
        {
            var lastExecutedScriptQuery = "select Isnull(max(ScriptOrder),0) from dbo.DatabaseVersionControl";
            using (var sqlCommand = new SqlCommand(lastExecutedScriptQuery, this.connection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;
                openConnection();
                var result = (int)sqlCommand.ExecuteScalar();
                return result;
            }
            
        }

        public void Dispose()
        {
            this.connection.Dispose();
        }

        
    }
}
