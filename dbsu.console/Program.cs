using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbsu.core;
using dbsu.core.consoleApp.Logging;

namespace dbsu.core.consoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var updater = new DbUpdater();
            var logger = new ConsoleLogger();
            updater.SetLogger(logger);
            updater.UpdateDb();
        }
    }
}
