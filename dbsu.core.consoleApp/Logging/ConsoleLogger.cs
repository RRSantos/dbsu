using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbsu.core.Logging;

namespace dbsu.core.consoleApp.Logging
{
    class ConsoleLogger:ILogger
    {
        private string formatExceptionMessage(Exception e)
        {
            var result = e.InnerException != null ? e.InnerException.Message : e.Message;
            return result;
        }
        

        public void LogInfo(string message)
        {
            Console.WriteLine("[INFO]\t{0}\t{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
        }

        public void LogWarning(string message)
        {
            Console.WriteLine("[WARN]\t{0}\t{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
        }

        public void LogError(string message, Exception exception)
        {
            Console.WriteLine("[ERROR]\t{0}\t{1}\tException:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message, formatExceptionMessage(exception));
            
        }

        
    }
}
