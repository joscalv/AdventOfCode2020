using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day13Test
    {
        private static readonly Day13 _day = new Day13();

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 4207;
            Assert.Equal(part1Solution, _day.ExecutePart1());
        }

        [Fact]

        public void TestPart2()
        {
            long part2Solution = 725850285300475;
            Assert.Equal(part2Solution, actual: _day.ExecutePart2());
        }

        [Fact]
        public void TestSamplePart2()
        {
            var busIds = new int[] { 7, 13, 1, 1, 59, 1, 31, 19 };
            int part2Solution = 1068781;
            Assert.Equal(part2Solution, actual: _day.ExecutePart2(busIds));
        }
    }
}