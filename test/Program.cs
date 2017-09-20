using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnm<Pig> pig = new Pig();
            pig.Add();
            Console.ReadKey();
            Pig pigs = new Pig();
            pigs.Add();
           
        }
    }
}
