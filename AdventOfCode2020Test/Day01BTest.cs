using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day01BTest
    {
        [Fact]
        public void Day1TestTest1()
        {
            var values = new int[] { 1721, 979, 366, 299, 675, 1456 };
            var expected = 514579;
            var result = Day01B.Day1CalculatorPart1(values);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Day1TestTest2()
        {
            var values = new int[] { 1721, 979, 366, 299, 675, 1456 };
            var expected = 241861950;
            var result = Day01B.Day1CalculatorPart2(values);
            Assert.Equal(expected, result);
        }
    }
}