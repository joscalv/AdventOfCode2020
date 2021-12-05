using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{

    public record Status(int X, int Y, int Angle);
    public record Movement(char M, int value);
    public class Day12 : IAdventOfCodeDay<long, long>
    {
        private readonly Movement[] _input;

        public Day12()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input12.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .Select(Parse)
                  .ToArray();
        }



        public static Movement Parse(string str)
        {
            return new Movement(str[0], int.Parse(str.Substring(1)));
        }

        public static Status Move(Status status, Movement movement) => movement.M switch
        {
            'N' => status with { Y = status.Y + movement.value },
            'S' => status with { Y = status.Y - movement.value },
            'E' => status with { X = status.X + movement.value },
            'W' => status with { X = status.X - movement.value },
            'L' => status with { Angle = (status.Angle - movement.value + 360) % 360 },
            'R' => status with { Angle = (status.Angle + movement.value + 360) % 360 },
            'F' => status.Angle switch
            {

                0 => Move(status, movement with { M = 'N' }),
                90 => Move(status, movement with { M = 'E' }),
                180 => Move(status, movement with { M = 'S' }),
                270 => Move(status, movement with { M = 'W' }),
                _ => status,
            },
            _ => status,
        };

        public static (Status waypoint, Status ship) Move2(Status status, Status ship, Movement movement) => movement.M switch
        {
            'N' => (status with { Y = status.Y + movement.value }, ship),
            'S' => (status with { Y = status.Y - movement.value }, ship),
            'E' => (status with { X = status.X + movement.value }, ship),
            'W' => (status with { X = status.X - movement.value }, ship),
            'L' => (Rotate(status, -1 * movement.value), ship),
            'R' => (Rotate(status, movement.value), ship),
            'F' => (status, ship with { X = ship.X + (status.X * movement.value), Y = ship.Y + (status.Y * movement.value) }),
            _ => (status, ship),
        };

        public static Status Rotate(Status status, int angle)
        {
            var s = Math.Round(Math.Sin(angle * Math.PI / 180), 2);
            var c = Math.Round(Math.Cos(angle * Math.PI / 180), 2);
            var xnew = (int)(status.X * c + status.Y * s);
            var ynew = (int)(-1 * status.X * s + status.Y * c);

            return status with { X = xnew, Y = ynew };
        }

        public long ExecutePart1()
        {
            var status = new Status(0, 0, 90);
            foreach (var s in _input)
            {
                status = Move(status, s);
            }
            return Math.Abs(status.X) + Math.Abs(status.Y);
        }

        public long ExecutePart2()
        {
            var shipStatus = new Status(0, 0, 0);
            var wayPointStatus = new Status(10, 1, 0);

            foreach (var s in _input)
            {
                var status = Move2(wayPointStatus, shipStatus, s);
                shipStatus = status.ship;
                wayPointStatus = status.waypoint;
            }
            return Math.Abs(shipStatus.X) + Math.Abs(shipStatus.Y);
        }
    }
}
