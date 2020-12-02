using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day02Test
    {
        [Theory]
        [InlineData(1, 3, 'a', "abcde", true)]
        [InlineData(1, 3, 'b', "cdefg", false)]
        [InlineData(2, 9, 'c', "ccccccccc", true)]
        public void IsValidPassword(int minRep, int maxRep, char letter, string password, bool expectedValid)
        {
            var pattern = new Pattern(minRep, maxRep, letter);
            Assert.Equal(expectedValid, pattern.IsValid(password));
        }
        
        [Theory]
        [InlineData(1, 3, 'a', "abcde", true)]
        [InlineData(1, 3, 'b', "cdefg", false)]
        [InlineData(2, 9, 'c', "ccccccccc", false)]
        public void IsValidPasswordPart2(int minRep, int maxRep, char letter, string password, bool expectedValid)
        {
            var pattern = new Pattern(minRep, maxRep, letter);
            Assert.Equal(expectedValid, pattern.IsValidPolicy2(password));
        }

        [Theory]
        [InlineData("1-3 a: abcde", 1, 3, 'a', "abcde")]
        [InlineData("1-3 b: cdefg", 1, 3, 'b', "cdefg")]
        [InlineData("2-9 c: ccccccccc", 2, 9, 'c', "ccccccccc")]
        public void ParsePattern(string line, int expMinRep, int expMaxRep, char expLetter, string expPassword)
        {
            Day02.ParsePatternAndPassword(line, out Pattern pattern, out string password);

            Assert.Equal(pattern.MinRep, expMinRep);
            Assert.Equal(pattern.MaxRep, expMaxRep);
            Assert.Equal(pattern.Character, expLetter);
            Assert.Equal(password, expPassword);


        }

        [Fact]
        public void Part1()
        {
            var expectedSolution = 569;
            var day2 = new Day02();

            Assert.Equal(expectedSolution, day2.ExecutePart1());
        }
        
        [Fact]
        public void Part2()
        {
            var expectedSolution =346;
            var day2 = new Day02();

            Assert.Equal(expectedSolution, day2.ExecutePart2());
        }


    }
}