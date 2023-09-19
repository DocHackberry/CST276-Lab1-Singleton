using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class Logger
    {
        public Logger(bool log = false)
        {
            if(log)
                Console.WriteLine("Logger constructor");
        }

        public void Logging()
        {
            Console.WriteLine("Logger Logging");
        }
    }
}
