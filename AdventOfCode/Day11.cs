using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day11Utils
    {

        public static SeatMap ParseSeatMap(this string mapString)
        {
            var chars = mapString
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .Select(line => line.ToCharArray())
                  .ToArray();

            return new SeatMap(chars);
        }
    }
    public class Day11 : IAdventOfCodeDay<long, long>
    {
        private SeatMap _input;

        public Day11()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input11.txt"))
                  .ParseSeatMap();
        }



        public long ExecutePart1()
        {
            return ExecutePart1(_input);
        }

        public long ExecutePart1(SeatMap seatMap)
        {
            char[][] previousMap = null;
            var moves = 0;
            do
            {
                previousMap = seatMap.Map;
                seatMap.ApplyRules();
                moves++;
            }
            while (!SeatMap.AreEqual(previousMap, seatMap.Map));

            return seatMap.Map.Select(file => file.Count(c => c == '#')).Sum();
        }

        public long ExecutePart2()
        {
            var input = File
                  .ReadAllText(Path.Combine("Inputs", "input11.txt"))
                  .ParseSeatMap();
            return ExecutePart2(input);
        }

        public long ExecutePart2(SeatMap seatMap)
        {

            char[][] previousMap = null;
            var moves = 0;
            do
            {
                previousMap = seatMap.Map;
                seatMap.ApplyRules2();
                moves++;
            }
            while (!SeatMap.AreEqual(previousMap, seatMap.Map));

            return seatMap.Map.Select(file => file.Count(c => c == '#')).Sum();
        }
    }

    public class SeatMap
    {
        public const char Occupied = '#';
        public const char Empty = 'L';
        public const char Floor = '.';


        private char[][] _map;


        public SeatMap(char[][] map)
        {
            _map = map;
        }

        public char[][] Map => _map;

        public void ApplyRules()
        {
            var result = _map.Select(array => array.Select(c => '.').ToArray()).ToArray();

            for (int y = 0; y < _map.Length; y++)
            {
                for (int x = 0; x < _map[y].Length; x++)
                {
                    char current = _map[y][x];
                    if (current == Empty)
                    {
                        char resultEmptyRule = EmptyRule(_map, x, y);
                        result[y][x] = resultEmptyRule;
                    }
                    else if (current == Occupied)
                    {
                        char resultOccupiedRule = OccupiedRule(_map, x, y);
                        result[y][x] = resultOccupiedRule;
                    }
                    else
                    {
                        result[y][x] = current;
                    }
                }
            }
            _map = result;
        }

        public void ApplyRules2()
        {
            var result = _map.Select(array => array.Select(c => '.').ToArray()).ToArray();

            for (int y = 0; y < _map.Length; y++)
            {
                for (int x = 0; x < _map[y].Length; x++)
                {
                    char current = _map[y][x];
                    if (current == Empty)
                    {
                        char resultEmptyRule = EmptyRule2(_map, x, y);
                        result[y][x] = resultEmptyRule;
                    }
                    else if (current == Occupied)
                    {
                        char resultOccupiedRule = OccupiedRule2(_map, x, y);
                        result[y][x] = resultOccupiedRule;
                    }
                    else
                    {
                        result[y][x] = current;
                    }
                }
            }
            _map = result;
        }

        public static char EmptyRule(char[][] map, int x, int y)
        {

            var c = map[y][x];
            if (c == SeatMap.Empty)
            {
                bool allEmpty = true;

                ForEachAdjacent(map, x, y, (char c) =>
                {
                    allEmpty = allEmpty && c != SeatMap.Occupied;
                });

                if (allEmpty)
                {
                    c = SeatMap.Occupied;
                }
            }
            return c;
        }

        public static char EmptyRule2(char[][] map, int x, int y)
        {

            var c = map[y][x];
            if (c == SeatMap.Empty)
            {
                bool anyOccupied = false;

                ForEachAdjacent2(map, x, y, (char c, int x, int y) =>
                {
                    anyOccupied = anyOccupied || c == SeatMap.Occupied;
                    return c != SeatMap.Floor;
                });

                if (!anyOccupied)
                {
                    c = SeatMap.Occupied;
                }
            }
            return c;
        }

        public static char OccupiedRule(char[][] map, int x, int y)
        {
            var c = map[y][x];
            if (c == SeatMap.Occupied)
            {
                int occupied = 0;
                ForEachAdjacent(map, x, y, (char c) =>
                {
                    occupied = occupied + (c == SeatMap.Occupied ? 1 : 0);
                });

                if (occupied >= 4)
                {
                    c = SeatMap.Empty;
                }
            }
            return c;
        }

        public static char OccupiedRule2(char[][] map, int x, int y)
        {
            var c = map[y][x];
            if (c == SeatMap.Occupied)
            {
                var numberOfOccupies = 0;

                ForEachAdjacent2(map, x, y, (char c, int x, int y) =>
                {
                    numberOfOccupies = numberOfOccupies + (c == SeatMap.Occupied ? 1 : 0);
                    return c != SeatMap.Floor;
                });

                if (numberOfOccupies >= 5)
                {
                    c = SeatMap.Empty;
                }
            }
            return c;
        }

        public static bool InBounds(char[][] map, int x, int y)
        {
            return y >= 0
                && y <= map.Length - 1
                && x >= 0
                && x <= map[y].Length - 1;
        }

        public static void ForEachAdjacent(char[][] map, int x, int y, Action<char> func)
        {
            foreach (int xInc in Enumerable.Range(-1, 3))
            {
                foreach (int yInc in Enumerable.Range(-1, 3))
                {
                    if ((xInc != 0 || yInc != 0) && InBounds(map, x + xInc, y + yInc))
                    {
                        func.Invoke(map[y + yInc][x + xInc]);
                    }
                }
            }
        }

        public static void ForEachAdjacent2(char[][] map, int x, int y, Func<char, int, int, bool> func)
        {
            var diagonal = new List<(int X, int Y)>()
            {
                (0,1),
                (1,0),
                (0,-1),
                (-1,0),
                (1,1),
                (1,-1),
                (-1,1),
                (-1,-1),

            };
            var processed = new HashSet<(int X, int Y)>();
            int inc = 1;
            do
            {
                foreach (var d in diagonal.Where(dd => !processed.Contains(dd)))
                {
                    var newX = x + d.X * inc;
                    var newY = y + d.Y * inc;

                    if (!InBounds(map, newX, newY) || func(map[newY][newX], newX, newY))
                    {
                        processed.Add(d);

                    }
                }
                inc++;
            }
            while (diagonal.Where(dd => !processed.Contains(dd)).Any());
        }

        public static bool AreEqual(char[][] map1, char[][] map2)
        {
            if (map1 == null || map2 == null || map1.Length != map2.Length)
            {
                return false;
            }

            for (int i = 0; i < map1.Length; i++)
            {
                if (!Enumerable.SequenceEqual(map1[i], map2[i]))
                {
                    return false;
                }
            }
            return true;

        }
    }
}
