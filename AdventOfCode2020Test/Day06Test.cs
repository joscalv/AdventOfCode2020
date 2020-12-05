using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day06Test
    {
        [Fact]
        public void TestPart1()
        {
            int part1Solution = int.MinValue;
            var day6 = new Day06();
            Assert.Equal(part1Solution, day6.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = int.MinValue;
            var day6 = new Day06();
            Assert.Equal(part2Solution, actual: day6.ExecutePart2());
        }
    }
}