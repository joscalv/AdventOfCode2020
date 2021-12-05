using System.Linq;
using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day12Test
    {
        private static readonly Day12 _day = new Day12();

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 582;
            Assert.Equal(part1Solution, _day.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 52069;
            Assert.Equal(part2Solution, actual: _day.ExecutePart2());
        }

        [Fact]
        public void TestMovements()
        {
            var movements = new string[]
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11",
            }.Select(Day12.Parse).ToArray();

            var status = new Status(0, 0, 90);
            status = Day12.Move(status, movements[0]);
            status.Should().BeEquivalentTo(new Status(10, 0, 90));
            status = Day12.Move(status, movements[1]);
            status.Should().BeEquivalentTo(new Status(10, 3, 90));
            status = Day12.Move(status, movements[2]);
            status.Should().BeEquivalentTo(new Status(17, 3, 90));
            status = Day12.Move(status, movements[3]);
            status.Should().BeEquivalentTo(new Status(17, 3, 180));
            status = Day12.Move(status, movements[4]);
            status.Should().BeEquivalentTo(new Status(17, -8, 180));
        }

        [Fact]
        public void TestMovementsPart2()
        {
            var movements = new string[]
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11",
            }.Select(Day12.Parse).ToArray();

            var statusShip = new Status(0, 0, 0);
            var statusWayPoint = new Status(10, 1, 0);
            var status = Day12.Move2(statusWayPoint, statusShip, movements[0]);
            status.ship.Should().BeEquivalentTo(new Status(100, 10, 0));
            status.waypoint.Should().BeEquivalentTo(new Status(10, 1, 0));

            status = Day12.Move2(status.waypoint, status.ship, movements[1]);
            status.ship.Should().BeEquivalentTo(new Status(100, 10, 0));
            status.waypoint.Should().BeEquivalentTo(new Status(10, 4, 0));

            status = Day12.Move2(status.waypoint, status.ship, movements[2]);
            status.ship.Should().BeEquivalentTo(new Status(170, 38, 0));
            status.waypoint.Should().BeEquivalentTo(new Status(10, 4, 0));

            status = Day12.Move2(status.waypoint, status.ship, movements[3]);
            status.ship.Should().BeEquivalentTo(new Status(170, 38, 0));
            status.waypoint.Should().BeEquivalentTo(new Status(4, -10, 0));

            status = Day12.Move2(status.waypoint, status.ship, movements[4]);
            status.ship.Should().BeEquivalentTo(new Status(214, -72, 0));
            status.waypoint.Should().BeEquivalentTo(new Status(4, -10, 0));

        }

        [Fact]
        public void TestRotate()
        {
            Day12.Rotate(new Status(10, 4, 0), 90).Should().Be(new Status(4, -10, 0));
            Day12.Rotate(new Status(10, 4, 0), -90).Should().Be(new Status(-4, 10, 0));
        }


    }
}