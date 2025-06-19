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
            
            Logger logger1 = Logger.GetInstance();
            logger1.Log("This is the first log message.");

            
            Logger logger2 = Logger.GetInstance();
            logger2.Log("This is the second log message.");

            
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
