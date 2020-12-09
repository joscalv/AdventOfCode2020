using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class DayNTest
    {
        private static readonly DayN _day = new DayN();
        
        [Fact]
        public void TestPart1()
        {
            int part1Solution = 0;
            Assert.Equal(part1Solution, _day.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 0;
            Assert.Equal(part2Solution, actual: _day.ExecutePart2());
        }
    }
}