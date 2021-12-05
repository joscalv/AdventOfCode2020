using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{

    public class Day17 : IAdventOfCodeDay<long, long>
    {
        private readonly CubeStatus[][] _input;



        public Day17()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input17.txt"))
                  .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                  .Select(l => l.ToCharArray().Select(c => (CubeStatus)c).ToArray())
                  .ToArray();
        }

        public long ExecutePart1()
        {
            PocketDimension dimension = new PocketDimension(_input);

            return dimension.RunCyclesAndReturnNumberOfActive(6);
        }

        public long ExecutePart2()
        {
            return 0;
        }

        public enum CubeStatus
        {
            Active = '#',
            Inactive = '.',
            Undefined
        }

        public class PocketDimension
        {
            private readonly HashSet<(int x, int y, int z)> _values;
            private readonly int _sizeDimension;

            public PocketDimension(CubeStatus[][] values)
            {
                HashSet<(int, int, int)> map = new HashSet<(int, int, int)>();
                _sizeDimension = values.Length;

                for (int y = 0; y < values.Length; y++)
                {
                    for (int x = 0; x < values[y].Length; x++)
                    {
                        var value = values[y][x];
                        if (value == CubeStatus.Active)
                        {
                            map.Add((x, y, 0));
                        }
                    }
                }

                _values = map;
            }


            private CubeStatus Get(HashSet<(int, int, int)> values, int x, int y, int z)
            {
                return values.Contains((x, y, z)) ? CubeStatus.Active : CubeStatus.Inactive;
            }

            public int RunCyclesAndReturnNumberOfActive(int numberOfCycles)
            {
                var current = _values;
                for (int i = 1; i <= numberOfCycles; i++)
                {
                    current = RunCycle(i, current);
                }

                return current.Count();
            }

            public HashSet<(int, int, int)> RunCycle(int cycle, HashSet<(int, int, int)> values)
            {

                var result = new HashSet<(int, int, int)>();
                for (var z = 0 - cycle; z <= cycle; z++)
                {
                    Console.WriteLine($"Z:{z}");
                    for (var y = (0 - cycle); y < _sizeDimension + cycle; y++)
                    {
                        for (var x = (0 - cycle); x < _sizeDimension + cycle; x++)
                        {

                            var value = ApplyRules(values, x, y, z);
                            if (value == CubeStatus.Active)
                            {
                                result.Add((x, y, z));
                                Console.Write("#");
                            }
                            else { Console.Write("."); }
                        }
                        Console.WriteLine();
                    }
                }

                return result;
            }

            public CubeStatus ApplyRules(HashSet<(int, int, int)> values, int x, int y, int z)
            {
                var current = Get(values, x, y, z);

                var active = 0;
                foreach (var incZ in new[] { 0, -1, 1 })
                {
                    foreach (var incY in new[] { 0, -1, 1 })
                    {
                        foreach (var incX in new[] { 0, -1, 1 })
                        {
                            if (incY != 0 || incX != 0 || incZ != 0)
                            {
                                var value = Get(values, x + incX, y + incY, z + incZ);
                                if (value == CubeStatus.Active)
                                {
                                    active++;
                                }

                                if (active > 3)
                                {
                                    return CubeStatus.Inactive;
                                }
                            }
                        }
                    }
                }

                if ((current == CubeStatus.Active && active < 2) || (current == CubeStatus.Inactive && active != 3))
                {
                    return CubeStatus.Inactive;
                }

                return CubeStatus.Active;
            }
        }
    }
}
