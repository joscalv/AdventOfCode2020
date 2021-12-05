using AdventOfCode;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day17Test
    {

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 319;
            Day17 day = new Day17();
            day.ExecutePart1().Should().Be(part1Solution);
        }

        [Fact]
        public void TestPart1Sample()
        {

            var input =
                @".#.
..#
###".Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.ToCharArray().Where(c => c == '#' || c == '.').Select(c => (Day17.CubeStatus)c).ToArray())
                .ToArray();

            Day17.PocketDimension dimension = new Day17.PocketDimension(input);
            dimension.RunCyclesAndReturnNumberOfActive(1).Should().Be(11);
            dimension.RunCyclesAndReturnNumberOfActive(2).Should().Be(21);
            dimension.RunCyclesAndReturnNumberOfActive(3).Should().Be(38);
        }

        [Fact]
        public void TestPart2Sample()
        {

            var input =
                @".#.
..#
###".Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.ToCharArray().Where(c => c == '#' || c == '.').Select(c => (Day17.CubeStatus)c).ToArray())
                .ToArray();

            Day17.PocketDimension dimension = new Day17.PocketDimension(input, Day17.CubeDimensions.Four);
            dimension.RunCyclesAndReturnNumberOfActive(1).Should().Be(29);
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 2324;
            Day17 day = new Day17();
            day.ExecutePart2().Should().Be(part2Solution);
        }
    }
}