using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbsu.core.Logging
{
    class NullLogger:ILogger
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
