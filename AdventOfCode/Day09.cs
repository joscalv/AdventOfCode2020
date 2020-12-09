using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using AdventOfCode.Computer;
using AdventOfCode.Computer.Instructions;

namespace AdventOfCode
{

    public class Day09 : IAdventOfCodeDay<long, long>
    {
        private readonly long[] _input;

        public Day09()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input09.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .Select(long.Parse)
                  .ToArray();
        }

        public long ExecutePart1()
        {
            return XmasUtils.GetFirstNotValid(_input, 25);
        }

        public long ExecutePart2()
        {
            var seed= XmasUtils.GetFirstNotValid(_input, 25);
            var vector = XmasUtils.GetRangeThatSums(_input, seed);

            return vector.Min() + vector.Max();
        }



    }

    public static class XmasUtils
    {
        public static bool ExistSum(long[] input, int preambleSize, int position)
        {
            int limit = position - preambleSize;
            for (int i = limit; i < position; i++)
            {
                for (int j = i + 1; j < position; j++)
                {
                    if (input[i] + input[j] == input[position])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static long GetFirstNotValid(long[] input, int preambleSize)
        {
            for (int i = preambleSize; i < input.Length; i++)
            {
                if (!ExistSum(input, preambleSize, i))
                {
                    return input[i];
                }
            }
            return -1;
        }

        public static long[] GetRangeThatSums(long[] input, long objetive)
        {
            //long objetive = input[sumPosition];
            for (int i = 0; i < input.Length; i++)
            {
                List<long> tmpList = new List<long>();
                long sum = 0;
                int j = i;
                while (sum < objetive)
                {
                    j++;
                    sum = sum + input[j];
                    tmpList.Add(input[j]);
                }
                if (sum == objetive)
                {
                    return tmpList.ToArray();
                }
            }

            return null;
        }
    }
}
