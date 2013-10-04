using System;

namespace dbsu.core.Persistence
{
    public interface IPersistence:IDisposable
    {
        
        void ExecuteScript(string scriptContent);
        int GetLastExecutedSchemaScriptOrder();
    }
}
