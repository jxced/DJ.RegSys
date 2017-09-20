using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    public class Anm<t> : IAnm<t>
    {
        public void Add()
        {
            Console.Write("ADD");
        }

        public void Del()
        {
            Console.Write("DEL");
        }
    }
}
