using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{

    public class Day15 : IAdventOfCodeDay<long, long>
    {
        private readonly int[] _input = new int[] { 1, 12, 0, 20, 8, 16 };

        public Day15()
        {
        }

        public long ExecutePart1()
        {
            return Day15Extensions.ExecuteGame(_input);
        }

        public long ExecutePart2()
        {
            return Day15Extensions.ExecuteGame(_input, 30000000);
        }
    }

    public static class Day15Extensions
    {

        public static long ExecuteGame(int[] input, int executions = 2020)
        {
            Dictionary<int, int> lastTurnNumber = new Dictionary<int, int>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                lastTurnNumber.Add(input[i], i + 1);
            }
            var previousNumber = 0;
            var lastNumber = input.Last();
            for (int currentTurn = input.Length; currentTurn <= executions; currentTurn++)
            {
                var turnOfLastNumber = GetTurnOfNumber(lastTurnNumber, lastNumber);
                previousNumber = lastNumber;
                if (turnOfLastNumber >= 0)
                {
                    MemorizeNumberTurn(lastTurnNumber, lastNumber, currentTurn);
                    lastNumber = currentTurn - turnOfLastNumber;
                }
                else
                {
                    MemorizeNumberTurn(lastTurnNumber, lastNumber, currentTurn);
                    lastNumber = 0;
                }
            }


            return previousNumber;
        }

        public static int GetTurnOfNumber(Dictionary<int, int> d, int number)
        {
            if (d.TryGetValue(number, out var turn))
            {
                return turn;
            }
            else
            {
                return -1;
            }
        }

        public static void MemorizeNumberTurn(Dictionary<int, int> d, int number, int currentTurn)
        {
            if (d.ContainsKey(number))
            {
                d[number] = currentTurn;
            }
            else
            {
                d.Add(number, currentTurn);
            }
        }
    }
}
