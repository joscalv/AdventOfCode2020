using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode;

namespace AdventOfCode2020Console
{
    class Program
    {
        static void Main(string[] args)
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
            ExecuteSolution("6.1 Loop", day6.ExecutePart1);
            ExecuteSolution("6.1 Linq", day6.ExecutePart1Linq);
            ExecuteSolution("6.2 Loop", day6.ExecutePart2);
            ExecuteSolution("6.2 Linq", day6.ExecutePart2Linq);

            var day7 = new Day07();
            ExecuteSolution("7.1", day7.ExecutePart1);
            ExecuteSolution("7.2", day7.ExecutePart2);

            var day8 = new Day08();
            ExecuteSolution("8.1", day8.ExecutePart1);
            ExecuteSolution("8.2", day8.ExecutePart2);

            var day8Simpler = new Day08Simpler();
            ExecuteSolution("8.1", day8Simpler.ExecutePart1);
            ExecuteSolution("8.2", day8Simpler.ExecutePart2);

            var day9 = new Day09();
            ExecuteSolution("9.1", day9.ExecutePart1);
            ExecuteSolution("9.2", day9.ExecutePart2);

            var day10 = new Day10();
            ExecuteSolution("10.1", day10.ExecutePart1);
            ExecuteSolution("10.2", day10.ExecutePart2);

            var day11 = new Day11();
            ExecuteSolution("11.1", day11.ExecutePart1);
            ExecuteSolution("11.2", day11.ExecutePart2);

            var day12 = new Day12();
            ExecuteSolution("12.1", day12.ExecutePart1);
            ExecuteSolution("12.2", day12.ExecutePart2);
            var day13 = new Day13();
            ExecuteSolution("13.1", day13.ExecutePart1);
            ExecuteSolution("13.2", day13.ExecutePart2);
            var day14 = new Day14();
            ExecuteSolution("14.1", day14.ExecutePart1);
            ExecuteSolution("14.2", day14.ExecutePart2);
            var day15 = new Day15();
            ExecuteSolution("15.1", day15.ExecutePart1);
            ExecuteSolution("15.2", day15.ExecutePart2);
            var day16 = new Day16();
            ExecuteSolution("16.1", day16.ExecutePart1);
            ExecuteSolution("16.2", day16.ExecutePart2);
            var day17 = new Day17();
            ExecuteSolution("17.1", day17.ExecutePart1);
            ExecuteSolution("17.2", day17.ExecutePart2);
            var day18 = new Day18();
            ExecuteSolution("18.1", day18.ExecutePart1);
            ExecuteSolution("18.2", day18.ExecutePart2);
            var day19 = new Day19();
            ExecuteSolution("19.1", day19.ExecutePart1);
            ExecuteSolution("19.2", day19.ExecutePart2);
            
        }

        private static void ExecuteDay<T1, T2>(IAdventOfCodeDay<T1, T2> day, string title)
        {
            ExecuteSolution(title + ".1", day.ExecutePart1);
            ExecuteSolution(title + ".2", day.ExecutePart2);
        }

        private static void ExecuteSolution<T>(string title, Func<T> solution)
        {
            ExecuteSolution(title, () => solution.Invoke().ToString());
        }

        private static void ExecuteSolution(string title, Func<string> solution)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            var result = solution.Invoke().ToString();
            clock.Stop();
            string separator = "|";

            Console.WriteLine($"{separator}{title.PadRight(20)}{separator}{result.PadLeft(15)}{separator}{CalculateMilliseconds(clock).PadLeft(10)}{separator}");
        }

        private static string CalculateMilliseconds(Stopwatch stopwatch)
        {
            return ($"{(1000 * stopwatch.ElapsedTicks / (double)Stopwatch.Frequency):F2}ms");
        }
    }
}
