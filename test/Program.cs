using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnm<Pig> pig = new Pig() as IAnm<Pig>;
            pig.Add();
           
            Pig p= pig as Pig;
            
            Console.ReadKey();
            Pig pigs = new Pig();
            pigs.Add();
           
        }
    }
}
