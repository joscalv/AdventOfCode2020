using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day06Test
    {

        [Theory]
        [InlineData("abcx\nabcy\nabcz",6)]
        [InlineData("abc", 3)]
        [InlineData("a\nb\nc", 3)]
        [InlineData("ab\nac", 3)]
        [InlineData("a\na\na\na", 1)]
        [InlineData("b", 1)]
        public void CountAnswers(string answers, int expectedCount)
        {
            Group g= new Group(answers);
            g.GetNumerOfAnswers().Should().Be(expectedCount);
        }       
        
        [Theory]
        [InlineData("abc", 3)]
        [InlineData("a\nb\nc", 0)]
        [InlineData("ab\nac", 1)]
        [InlineData("a\na\na\na", 1)]
        [InlineData("b", 1)]
        public void CommonAnswers(string answers, int expectedCount)
        {
            Group g= new Group(answers);
            g.GetCommonAnswers().Should().Be(expectedCount);
        }




        [Fact]
        public void TestPart1()
        {
            int part1Solution = 6911;
            var day6 = new Day06();
            Assert.Equal(part1Solution, day6.ExecutePart1());
        } 
        
        [Fact]
        public void TestPart1Linq()
        {
            int part1Solution = 6911;
            var day6 = new Day06();
            Assert.Equal(part1Solution, day6.ExecutePart1Linq());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 3473;
            var day6 = new Day06();
            Assert.Equal(part2Solution, actual: day6.ExecutePart2());
        } 
        [Fact]
        public void TestPart2Linq()
        {
            int part2Solution = 3473;
            var day6 = new Day06();
            Assert.Equal(part2Solution, actual: day6.ExecutePart2Linq());
        }
    }
}