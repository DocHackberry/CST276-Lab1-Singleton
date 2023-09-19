using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class ThreadsafeLogger
    {
        private static ThreadsafeLogger _instance = null;
        private static object _lock = new object();

        private ThreadsafeLogger()
        {
            Console.WriteLine("ThreadsafeLogger constructor");
        }

        public static ThreadsafeLogger GetInstance(bool log = false)
        {
            if(log)
                Console.WriteLine("Getting ThreadsafeLogger Instance");

            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadsafeLogger();
                    }
                }
            }

            return _instance;
        }

        public void Logging()
        {
            Console.WriteLine("ThreadsafeLogger Logging");
        }

        int count = 0;
        public void Increment()
        {
            ++count;
        }
    }
}
