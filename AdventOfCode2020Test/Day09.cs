using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day09Test
    {
        private readonly Day09 _day09 = new Day09();

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 0;
            Assert.Equal(part1Solution, _day09.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 0;
            Assert.Equal(part2Solution, actual: _day09.ExecutePart2());
        }
    }


}