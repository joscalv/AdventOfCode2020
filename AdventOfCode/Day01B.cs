using System.IO;
using System.Linq;

namespace AdventOfCode
{
    
    public class Day01B : IAdventOfCodeDay<long, long>
    {

        private int[] _values;
        public Day01B()
        {
            _values = File
                .ReadAllLines(Path.Combine("Inputs", "input01.txt"))
                .Select(int.Parse)
                .ToArray();
        }


        public long ExecutePart1()
        {

            var result = Day1CalculatorPart1(_values);

            return result;
        }

        public long ExecutePart2()
        {
            var result = Day1CalculatorPart2(_values);

            return result;
        }

        public static long Day1CalculatorPart1(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    if (values[i] + values[j] == 2020)
                    {
                        return values[i] * values[j];
                    }
                }
            }

            return -1;
        }

        public static long Day1CalculatorPart2(int[] values)
        {
            for (int i = 0; i < values.Count(); i++)
            {
                for (int j = i+1; j < values.Length; j++)
                {
                    for (int k = j+1; k < values.Length; k++)
                    {
                        if (values[i] + values[j] + values[k] == 2020)
                        {
                            return values[i] * values[j] * values[k];
                        }
                    }
                }
            }

            return 0;
        }
    }
}
