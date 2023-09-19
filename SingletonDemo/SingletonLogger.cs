using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class SingletonLogger
    {
        private static SingletonLogger _instance = null;

        private SingletonLogger()
        {
            Console.WriteLine("SingletonLogger constructor");
        }

        public static SingletonLogger GetInstance(bool log = false)
        {
            if(log)
                Console.WriteLine("Getting SingletonLogger Instance");

            if (_instance == null)
                _instance = new SingletonLogger();

            return _instance;
        }

        public void Logging()
        {
            Console.WriteLine("SingletonLogger Logging");
        }

        int count = 0;
        public int Increment()
        {
            return ++count;
        }
    }
}
