using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExamples
{
    public class Logger
    {
        // Step 1: Private static variable to hold the single instance
        private static Logger instance;

        // Step 2: Private constructor so no one else can create it
        private Logger()
        {
            Console.WriteLine("Logger initialized.");
        }

        // Step 3: Public method to get the single instance (lazy initialization)
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        // A simple method to simulate logging
        public void Log(string message)
        {
            Console.WriteLine("[LOG]: " + message);
        }
    }
}
