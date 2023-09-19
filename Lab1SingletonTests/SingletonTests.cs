using NUnit.Framework;
using SingletonDemo;

namespace SingletonTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNonSingleInstance()
        {
            //Create two non-Singleton loggers
            Logger s1 = new Logger(true);
            Logger s2 = new Logger(true);

            //Confirm that they are in fact different instances
            Console.WriteLine("s1: {0} s2: {1}", s1.GetHashCode(), s2.GetHashCode());
            Assert.That(s1.GetHashCode(), Is.Not.EqualTo(s2.GetHashCode()));
        }

        [Test]
        public void TestSingleInstance()
        {
            //Get first instance (Constructor is called)
            SingletonLogger s1 = SingletonLogger.GetInstance(true);

            //Get second instance (Constructor is not called)
            SingletonLogger s2 = SingletonLogger.GetInstance(true);

            //Bith instances are the same object
            Console.WriteLine("s1: {0} s2: {1}", s1.GetHashCode(), s2.GetHashCode());
            Assert.That(s1.GetHashCode(), Is.EqualTo(s2.GetHashCode()));
        }

        [Test]
        public void TestScopedInstance()
        {
            //Get first instance
            int m1HashCode = ScopedSingleton(1);
            //Get second instance (Constructor is not be called again)
            int m2HashCode = ScopedSingleton(2);
            //Two hashcodes should match
            Assert.That(m1HashCode, Is.EqualTo(m2HashCode));

            //First two instances are out of scope, run Garbage Collection
            GC.Collect();

            //Get third instance (Constructor should be called again)
            MortalLogger m3 = MortalLogger.GetInstance(true);

            //First and third instances should no longer match
            Console.WriteLine("m1 {0}, m3 {1}", m1HashCode, m3.GetHashCode());
            Assert.That(m1HashCode, Is.Not.EqualTo(m3.GetHashCode()));
        }

        static int ScopedSingleton(int number)
        {
            MortalLogger m = MortalLogger.GetInstance(true);
            Console.WriteLine("m{0}: {1}", number, m.GetHashCode());
            return m.GetHashCode();
        }
    }
}