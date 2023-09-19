using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SingletonDemo
{
    class GlobalLogger
    {
        public static Logger logger = new Logger();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In Main");

            //Performance test between Singleton types
            ThreadSafeOverhead(200000000);

            //Simple Singleton Example
            Singleton();

            //Scoped Singleton that allows garbage collection
            ScopedSingleton();

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        static void ThreadSafeOverhead(int iter)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < iter; i++)
            {
                SingletonLogger.GetInstance().Increment();
            }
            Console.WriteLine("SingletonLogger {0}", timer.Elapsed);

            timer.Restart();
            for (int i = 0; i < iter; i++)
            {
                ThreadsafeLogger.GetInstance().Increment();
            }
            Console.WriteLine("ThreadsafeLogger {0}", timer.Elapsed);

            timer.Restart();
            for (int i = 0; i < iter; i++)
            {
                MortalLogger.GetInstance().Increment();
            }
            Console.WriteLine("MortalLogger {0}", timer.Elapsed);
        }

        static void Singleton()
        {
            SingletonLogger s1 = SingletonLogger.GetInstance(true);
            Console.WriteLine("s1: {0}", s1.GetHashCode());

            SingletonLogger s2 = SingletonLogger.GetInstance(true);
            Console.WriteLine("s2 {0}", s2.GetHashCode());
        }

        static void ScopedSingleton()
        {
            MortalLogger m1 = MortalLogger.GetInstance(true);
            Console.WriteLine("m1: {0}", m1.GetHashCode());
            m1 = null;
            GC.Collect();
            MortalLogger m2 = MortalLogger.GetInstance(true);
            Console.WriteLine("m2 {0}", m2.GetHashCode());
        }
    }
}
