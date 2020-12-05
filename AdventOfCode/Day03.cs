using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public enum PositionType
    {
        Empty,
        Tree
    }

    public class Day03
    {
        private Map _map;

        public Day03()
        {
            var values = File
                  .ReadAllLines(Path.Combine("Inputs", "input03.txt"))
                  .ToArray();
            _map = new Map(values);
        }

        public long ExecutePart1()
        {
            return _map.TraverseMap(3, 1);
        }

        public long ExecutePart2()
        {

            return (_map.TraverseMap(1, 1)
                * _map.TraverseMap(3, 1)
                * _map.TraverseMap(5, 1)
                * _map.TraverseMap(7, 1)
                * _map.TraverseMap(1, 2));
        }
    }

    public static class MapUtils
    {
        public static long TraverseMap(this Map map, int incX, int incY)
        {
            var currentX = 0;
            var currentY = 0;

            var numberOfTrees = 0;

            while (currentY < map.Height - 1)
            {
                currentY += incY;
                currentX += incX;
                numberOfTrees = numberOfTrees + (map.GetPosition(currentX, currentY) == PositionType.Tree ? 1 : 0);
            }
            return numberOfTrees;
        }
    }

    public class Map
    {
        private PositionType[,] _map;
        public int Length { get; private set; }
        public int Height { get; private set; }

        public Map(string[] mapText)
        {
            _map = CreateFromText(mapText);
        }

        public PositionType GetPosition(int x, int y)
        {
            return _map[y, x % Length];
        }

        public PositionType[,] CreateFromText(string[] mapText)
        {
            Length = mapText.First().Length;
            Height = mapText.Length;

            var map = new PositionType[Height, Length];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Length; x++)
                {
                    map[y, x] = mapText[y][x] == '#' ? PositionType.Tree : PositionType.Empty;
                }
            }
            return map;
        }
    }
}
