using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{


    public class Day05
    {
        private readonly string[] _lines;

        public Day05()
        {
            _lines = File
                  .ReadAllLines(Path.Combine("Inputs", "input05.txt"))
                  .ToArray();
        }

        public long ExecutePart1()
        {
            return _lines
                .Select(l => new BoardingPass(l).GetSeatId())
                .Max();
        }

        public long ExecutePart2()
        {
            var ids= _lines
                .Select(l => new BoardingPass(l).GetSeatId())
                .OrderBy(id=>id).ToArray();

            for (int i = 0; i < ids.Length-1; i++)
            {
                if (ids[i+1] - ids[i]==2)
                    return ids[i]+1;
            }

            return -1;
        }
    }

    public class BoardingPass
    {
        private const int Rows = 127;
        private const int Columns = 7;

        private const char Front = 'F';
        private const char Back = 'B';
        private const char Right = 'R';
        private const char Left = 'L';


        private readonly string _binaryPosition;

        public BoardingPass(string binaryPosition)
        {
            _binaryPosition = binaryPosition;
        }

        public static (int, int) BinaryMovement((int lower, int upper) range, bool isUpper)
        {
            var middle = (range.upper - range.lower) / 2.0;
            if (middle <= 1)
            {
                return isUpper ? (range.upper, range.upper) : (range.lower, range.lower);
            }
            else
            {
                return isUpper
                    ? (range.lower + (int)Math.Round(middle + 0.001, 0), range.upper)
                    : (range.lower, range.lower + (int)middle);
            }
        }

        public (int row, int column) GetSeatPosition()
        {
            var rowRange = (min: 0, max: Rows);
            var columnRange = (min: 0, max: Columns);

            foreach (var movement in _binaryPosition)
            {
                switch (movement)
                {
                    case Front:
                        rowRange = BinaryMovement(rowRange, false);
                        break;
                    case Back:
                        rowRange = BinaryMovement(rowRange, true);
                        break;
                    case Right:
                        columnRange = BinaryMovement(columnRange, true);
                        break;
                    case Left:
                        columnRange = BinaryMovement(columnRange, false);
                        break;
                }
            }

            return (rowRange.min, columnRange.min);
        }

        public int GetSeatId()
        {
            var seatPos = GetSeatPosition();
            return seatPos.column + 8 * seatPos.row;
        }
    }
}
