﻿using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    public class Pig:Anm<Pig>,IPig
    {
       public void say()
        {
            Console.Write("pig");
        }
    }
}
