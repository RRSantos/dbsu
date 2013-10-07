using System;

namespace dbsu.core.Logging
{
    internal class NullLogger:ILogger
    {
        
        public void LogInfo(string message)
        {
            //Intentionally left blank ;)
        }

        public void LogWarning(string message)
        {
            //Intentionally left blank ;)
        }

        public void LogError(string message, Exception exception)
        {
            //Intentionally left blank ;)
        }
        
    }
}
