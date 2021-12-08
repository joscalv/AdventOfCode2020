using System.Linq;
using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day21Test
    {

        private readonly string[] _sample1;

        public Day21Test()
        {
            _sample1 = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)".Split('\n').Select(line => line.Replace("\r", "")).ToArray();
        }

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 2072;
            var day21 = new Day21();
            day21.ExecutePart1().Should().Be(part1Solution);
        }
        
        [Fact]
        public void TestPart1Sample()
        {
            var input = Day21Extensions.Parse(_sample1);

            Day21.ExecutePart1(input).Should().Be(5);
        }
        
        [Fact]
        public void TestPart2Sample()
        {
            var input = Day21Extensions.Parse(_sample1);

            Day21.ExecutePart2(input).Should().Be("mxmxvkd,sqjhc,fvjkl");
        }

        [Fact]
        public void TestPart2()
        {
            string part2Solution = "fdsfpg,jmvxx,lkv,cbzcgvc,kfgln,pqqks,pqrvc,lclnj";
            var day21 = new Day21();
            day21.ExecutePart2().Should().Be(part2Solution);
        }

        [Fact]
        public void TestParseInput()
        {
            
            
            
            Day21Extensions.Parse(_sample1).Should().HaveCount(4);
        }
    }
}