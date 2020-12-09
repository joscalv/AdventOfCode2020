using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day10Test
    {
        private static readonly Day10 _day10 = new Day10();
        
        [Fact]
        public void TestPart1()
        {
            int part1Solution = 0;
            Assert.Equal(part1Solution, _day10.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 0;
            Assert.Equal(part2Solution, actual: _day10.ExecutePart2());
        }
    }
}