using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Computer;
using AdventOfCode.Computer.Instructions;

namespace AdventOfCode
{

    public class Day10 : IAdventOfCodeDay<long, long>
    {
        private readonly int[] _input;

        public Day10()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input10.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .Select(int.Parse)
                  .ToArray();
        }

        public long ExecutePart1()
        {
            return ExecutePart1(_input);
        }

        public long ExecutePart1(int[] input)
        {
            int previousValue = 0;

            var ordered = input
                .OrderBy(x => x)
                .Where(current =>
                {
                    int diff = current - previousValue;
                    previousValue = current;
                    return diff <= 3;
                })
                .ToArray();

            int count1 = 0;
            int count3 = 1;
            int previous = 0;
            for (int i = 0; i < ordered.Length; i++)
            {
                int difference = ordered[i] - previous;
                previous = ordered[i];
                if (difference == 1)
                {
                    count1++;
                }
                else if (difference == 3)
                {
                    count3++;
                }
            }
            return count1 * count3;
        }


        public long ExecutePart2()
        {
            return ExecutePart2Solution3(_input);
        }

        public long ExecutePart2(int[] input)
        {
            var ordered = input
                .OrderBy(x => x)
                .ToArray();

            long counter = 0;
            Queue<(int[] combination, int[] rest)> posibilities = new Queue<(int[] combination, int[] rest)>();
            posibilities.Enqueue((new int[] { 0 }, ordered));

            long combinations = 0;
            while (posibilities.Any())
            {
                if (counter++ % 1000000 == 0)
                {
                    Console.WriteLine("Tested" + counter + " Pending" + posibilities.Count);
                }

                var current = posibilities.Dequeue();
                if (!current.rest.Any())
                {
                    combinations++;
                }
                else
                {
                    for (int i = 0; i < Math.Min(3, current.rest.Length); i++)
                    {
                        if (current.rest[i] - current.combination.Last() <= 3)
                        {
                            posibilities.Enqueue((
                                AppendToArray(current.combination, current.rest[i]),
                                SubArray(current.rest, i + 1)));
                        }
                    }
                }
            }
            return combinations;
        }

        public long ccc((int[] combination, int[] rest) current)
        {
            if (!current.rest.Any())
            {
                return 1;
            }
            else
            {
                long result = 0;
                for (int i = 0; i < Math.Min(3, current.rest.Length); i++)
                {

                    if (current.rest[i] - current.combination.Last() <= 3)
                    {
                        result = result + ccc((
                            AppendToArray(current.combination, current.rest[i]),
                            SubArray(current.rest, i + 1)));
                    }
                }
                return result;
            }
        }

        public long ExecutePart2Solution3(int[] input)
        {
            var ordered = input.ToList().Append(0).Append(input.Max() + 3).OrderBy(x => x).ToArray();
            var ways = new long[ordered.Length];

            for (int i=0; i< ordered.Length; i++)
            {
                if (i==0)
                {
                    ways[i] = 1;
                }
                else
                {
                    ways[i] = 0;
                    for (int j=i-1;j> j-3 && j >= 0; j--)
                    {
                        if (ordered[i]-ordered[j]<=3)
                        {
                            ways[i] += ways[j];
                        }
                    }
                }
            }
            return ways[ordered.Length - 1];
        }

        public long ExecutePart2B(int[] input)
        {
            var ordered = input
                .OrderBy(x => x)
                .ToArray();

            return ccc((new int[] { 0 }, ordered));
        }

        public string GetHash(int[] input)
        {
            StringBuilder s = new StringBuilder();
            foreach (var i in input)
            {
                s.Append($"{i}-");
            }
            return s.ToString();
        }

        public long GetNumberOfSolutions(int[] input, HashSet<string> existing)
        {
            long result = 0;
            if (IsSolution(input) && !existing.Contains(GetHash(input)))
            {
                existing.Add(GetHash(input));
                result = 1;
                for (int i = 0; i < input.Length; i++)
                {
                    result = result + GetNumberOfSolutions(RemoveIndex(input, i), existing);
                }
            }

            return result;
        }

        public bool IsSolution(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i + 1] - input[i] > 3) return false;
            }
            return true;
        }

        public static int[] AppendToArray(int[] input, int value)
        {
            int length = input.Length;
            var result = new int[length + 1];
            for (int i = 0; i < length; i++)
            {
                result[i] = input[i];
            }
            result[length] = value;
            return result;
        }

        public static int[] SubArray(int[] input, int position)
        {
            int length = input.Length - position;
            var result = new int[length];
            for (int i = position; i < input.Length; i++)
            {
                result[i - position] = input[i];
            }
            return result;
        }

        public static int[] RemoveIndex(int[] input, int position)
        {
            int length = input.Length - 1;
            var result = new int[length];
            int offset = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i != position)
                {
                    result[i - offset] = input[i];
                }
                else
                {
                    offset = 1;
                }
            }
            return result;
        }
    }

}
