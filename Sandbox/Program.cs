using System;
using System.Collections.Generic;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var yes = new Counter("Yes", 4);
            var no = new Counter("No", 4);
            var maybe = new Counter("Maybe", 4);
            var hopefully = new Counter("Hopefully", 4);

            var manager = new CounterManager(yes, no, maybe, hopefully);

            manager.AnounceWinner();
        }
    }
}
