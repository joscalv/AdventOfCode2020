using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day15Test
    {
        private static readonly Day15 _day = new Day15();
        
        [Fact]
        public void TestPart1()
        {
            int part1Solution = 273;
            Assert.Equal(part1Solution, _day.ExecutePart1());
        }
        
        [Fact]
        public void TestPart1Sample1()
        {
            int expectedResult = 436;
            int[] input = { 0, 3, 6 };
            Day15Extensions.ExecuteGame(input).Should().Be(expectedResult);
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 47205;
            Assert.Equal(part2Solution, actual: _day.ExecutePart2());
        }
    }
}