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
            _day.ExecutePart1().Should().Be(part1Solution);
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 0;
            _day.ExecutePart2().Should().Be(part2Solution);
        }
    }
}