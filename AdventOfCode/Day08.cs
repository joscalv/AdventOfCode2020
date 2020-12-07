using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace AdventOfCode
{

    public class Day08 : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _lines;

        public Day08()
        {
            _lines = File
                  .ReadAllText(Path.Combine("Inputs", "input08.txt"))
                  .Split("\n");
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
