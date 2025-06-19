using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExamples
{
    public class Logger
    {
        
        private static Logger instance;

        
        private Logger()
        {
            Console.WriteLine("Logger initialized.");
        }

        
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        
        public void Log(string message)
        {
            Console.WriteLine("[LOG]: " + message);
        }
    }
}
