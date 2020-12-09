using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using AdventOfCode.Computer;
using AdventOfCode.Computer.Instructions;

namespace AdventOfCode
{

    public class DayN : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _input;

        public DayN()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "inputN.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
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
