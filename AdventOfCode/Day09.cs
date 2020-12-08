using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using AdventOfCode.Computer;
using AdventOfCode.Computer.Instructions;

namespace AdventOfCode
{

    public class Day09 : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _input;

        public Day09()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input09.txt"))
                  .Split("\n")
                  .ToArray();
        }

        public long ExecutePart1()
        {
            return 0;
        }

        public long ExecutePart2()
        {
            return 0;
        }

    }
}
