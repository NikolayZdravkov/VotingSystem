using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox
{
    public class Counter
    {

        private double? _percentage;
        public Counter(string name, int count) 
        {
            Name = name;
            Count = count;
        }

        public double CalculatePercent(int total)
        {
            return _percentage ?? (_percentage = Math.Round(Count * 100.0 / total, 2)).Value;
        }

        public void AddExcess(double excess) => _percentage += excess;



        public string Name { get; }
        public int Count { get; private set; }
    }
}
