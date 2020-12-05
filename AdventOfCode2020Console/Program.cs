using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode;

namespace AdventOfCode2020Console
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("*** AdventOfCode2020 ***");
            Console.WriteLine($"{Environment.NewLine}--- Day 1: Report Repair ---");
            var day1 = new Day01();
            ExecuteSolution("1.1", day1.ExecutePart1);
            ExecuteSolution("1.2", day1.ExecutePart2);

            var day2 = new Day02();
            ExecuteSolution("2.1", day2.ExecutePart1);
            ExecuteSolution("2.2", day2.ExecutePart2);

            var day3 = new Day03();
            ExecuteSolution("3.1", day3.ExecutePart1);
            ExecuteSolution("3.2", day3.ExecutePart2);

            var day4 = new Day04();
            ExecuteSolution("4.1", day4.ExecutePart1);
            ExecuteSolution("4.2", day4.ExecutePart2);

            var day5 = new Day05();
            ExecuteSolution("5.1", day5.ExecutePart1);
            ExecuteSolution("5.2", day5.ExecutePart2);

            var day6 = new Day06();
            ExecuteSolution("6.1", day6.ExecutePart1);
            ExecuteSolution("6.2", day6.ExecutePart2);
        }

        private static void ExecuteSolution(string title, Func<long> solution)
        {
            ExecuteSolution(title, () => solution.Invoke().ToString());
        }

        private static void ExecuteSolution(string title, Func<int> solution)
        {
            ExecuteSolution(title, () => solution.Invoke().ToString());
        }

        private static void ExecuteSolution(string title, Func<string> solution)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            var result = solution.Invoke().ToString();
            clock.Stop();
            string separator = (result.Length > 40) ? Environment.NewLine : $"\t";

            Console.WriteLine($"{title}{separator}{result}{separator}{CalculateMilliseconds(clock)} ms.");
        }

        private static double CalculateMilliseconds(Stopwatch stopwatch)
        {
            return 1000 * stopwatch.ElapsedTicks / (double)Stopwatch.Frequency;
        }
    }
}
