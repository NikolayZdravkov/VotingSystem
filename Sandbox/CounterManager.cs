using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

namespace Sandbox
{
    public class CounterManager
    {

        public CounterManager(params Counter[] counters)
        {
            Counters = new List<Counter>(counters);
        }

        public List<Counter> Counters { get; set; }

        public int Total() => Counters.Sum(x => x.Count);
        public double TotalPercentage() => Counters.Sum(x => x.CalculatePercent(Total()));

        public void AnounceWinner()
        {
            var excess = Math.Round(100 - TotalPercentage(), 2);

            Console.WriteLine($"Excess: {excess}");

            var biggestAmountOfVotes = Counters.Max(x => x.Count);

            var winners = Counters.Where(x => x.Count == biggestAmountOfVotes).ToList();

            if (winners.Count == 1)
            {
                var winner = winners.First();
                winner.AddExcess(excess);
                Console.WriteLine($"{winner.Name} Won!");
            }
            else
            {
                if (winners.Count != Counters.Count)
                {
                    var lowestAmountOfVotes = Counters.Min(x => x.Count);

                    var looser = Counters.First(x => x.Count == lowestAmountOfVotes);
                    looser.AddExcess(excess);
                }
                Console.WriteLine(string.Join(" -Draw- ", winners.Select(x => x.Name)));
                
            }

            foreach(var c in Counters)
            {
                Console.WriteLine($"{c.Name} Counts: {c.Count}, Percentage: {c.CalculatePercent(Total())}%");
            }

            Console.WriteLine($"Total Percentage: {Math.Round(TotalPercentage(), 2)}%");
        }
    }
}
