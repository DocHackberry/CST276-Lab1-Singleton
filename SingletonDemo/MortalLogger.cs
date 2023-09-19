using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class MortalLogger
    {
        // private static MortalLogger _instance = null;
        private static WeakReference _instance = new WeakReference(null);
        private static object _lock = new object();

        private MortalLogger()
        {
            Console.WriteLine("In MortalLogger constructor");
        }

        public static MortalLogger GetInstance(bool log = false)
        {
            if (log)
                Console.WriteLine("Getting MortalLogger Instance");

            MortalLogger strongReference = (MortalLogger)_instance.Target;

            if (strongReference == null)
            {
                lock (_lock)
                {
                    if (strongReference == null)
                    {
                        strongReference = new MortalLogger();
                        _instance = new WeakReference(strongReference);
                    }
                }
            }

            return strongReference;
        }

        public void Logging()
        {
            Console.WriteLine("MortalLogger Logging");
        }

        int count = 0;
        public void Increment()
        {
            ++count;
        }
    }
}
