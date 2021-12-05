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
            PocketDimension dimension = new PocketDimension(_input, CubeDimensions.Four);

            return dimension.RunCyclesAndReturnNumberOfActive(6);
        }

        public enum CubeStatus
        {
            Active = '#',
            Inactive = '.',
            Undefined
        }

        public enum CubeDimensions
        {
            Three,
            Four
        }

        public class PocketDimension
        {
            private readonly CubeDimensions _dimensions;
            private readonly HashSet<(int x, int y, int z, int w)> _values;
            private readonly int _sizeDimension;

            public PocketDimension(CubeStatus[][] values, CubeDimensions dimensions = CubeDimensions.Three)
            {
                _dimensions = dimensions;
                HashSet<(int, int, int, int)> map = new HashSet<(int, int, int, int)>();
                _sizeDimension = values.Length;

                for (var y = 0; y < values.Length; y++)
                {
                    for (var x = 0; x < values[y].Length; x++)
                    {
                        var value = values[y][x];
                        if (value == CubeStatus.Active)
                        {
                            map.Add((x, y, 0, 0));
                        }
                    }
                }

                _values = map;
            }


            private CubeStatus Get(HashSet<(int, int, int, int)> values, int x, int y, int z, int w)
            {
                return values.Contains((x, y, z, w)) ? CubeStatus.Active : CubeStatus.Inactive;
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

            public HashSet<(int, int, int, int)> RunCycle(int cycle, HashSet<(int, int, int, int)> values)
            {

                var result = new HashSet<(int, int, int, int)>();
                var wStart = 0;
                var wEnd = 1;
                if (_dimensions == CubeDimensions.Four)
                {
                    wStart = 0 - cycle;
                    wEnd = cycle;
                }
                for (var w = wStart; w <= wEnd; w++)
                {
                    for (var z = 0 - cycle; z <= cycle; z++)
                    {
                        for (var y = 0 - cycle; y < _sizeDimension + cycle; y++)
                        {
                            for (var x = 0 - cycle; x < _sizeDimension + cycle; x++)
                            {

                                var value = ApplyRules(values, x, y, z, w);
                                if (value == CubeStatus.Active)
                                {
                                    result.Add((x, y, z, w));
                                }

                            }
                        }
                    }
                }

                return result;
            }

            public CubeStatus ApplyRules(HashSet<(int, int, int, int)> values, int x, int y, int z, int w)
            {
                var current = Get(values, x, y, z, w);

                var active = 0;
                var wInc = _dimensions == CubeDimensions.Four ? new[] { 0, -1, 1 } : new int[] { 0 };
                ;
                foreach (var incW in wInc)
                {
                    foreach (var incZ in new[] { 0, -1, 1 })
                    {
                        foreach (var incY in new[] { 0, -1, 1 })
                        {
                            foreach (var incX in new[] { 0, -1, 1 })
                            {
                                if (incY != 0 || incX != 0 || incZ != 0 || incW != 0)
                                {
                                    var value = Get(values, x + incX, y + incY, z + incZ, w + incW);
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
                }

                if (current == CubeStatus.Active && active < 2 || current == CubeStatus.Inactive && active != 3)
                {
                    return CubeStatus.Inactive;
                }

                return CubeStatus.Active;
            }
        }
    }
}
