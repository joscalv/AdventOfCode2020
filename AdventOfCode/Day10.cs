﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using AdventOfCode.Computer;
using AdventOfCode.Computer.Instructions;

namespace AdventOfCode
{

    public class Day10 : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _input;

        public Day10()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input10.txt"))
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
