using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get the first logger instance
            Logger logger1 = Logger.GetInstance();
            logger1.Log("This is the first log message.");

            // Try to get another logger instance
            Logger logger2 = Logger.GetInstance();
            logger2.Log("This is the second log message.");

            // Check if both logger1 and logger2 are the same instance
            if (logger1 == logger2)
            {
                Console.WriteLine("Same Logger instance");
            }
            else
            {
                Console.WriteLine("Multiple instances exist!");
            }
        }
    }
}
