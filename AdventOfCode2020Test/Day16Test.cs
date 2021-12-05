using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day16Test
    {


        [Fact]
        public void TestPart1()
        {
            var day = new Day16();
            int part1Solution = 28882;
            day.ExecutePart1().Should().Be(part1Solution);
        }

        [Fact]
        public void TestPart1Sample()
        {
            int expectedResult = 71;
            var lines = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50
your ticket:
7,1,14
nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12".Split('\n');
            var input = Day16Extensions.ParseInput(lines);
            Day16.ExecutePart1(input.rules, input.ticket, input.nearTickes).Should().Be(expectedResult);
        }
        
        [Fact]
        public void TestPart2Sample()
        {
            int expectedResult = 0;
            var lines = @"class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19
your ticket:
11,12,13
nearby tickets:
3,9,18
15,1,5
5,14,9".Split('\n');
            var input = Day16Extensions.ParseInput(lines);
            Day16.ExecutePart2(input.rules, input.ticket, input.nearTickes).Should().Be(expectedResult);
        }

        [Fact]
        public void TestPart2()
        {
            var part2Solution = 1429779530273L;
            var day = new Day16();
            day.ExecutePart2().Should().Be(part2Solution);
        }

        [Fact]
        public void ParseRuleTest()
        {

            "class: 1-3 or 5-7".ParseRule().Should()
                .BeEquivalentTo(new Rule("class", new[] { (1, 3), (5, 7) }));
            "seat: 13-40 or 45-50".ParseRule().Should()
                .BeEquivalentTo(new Rule("seat", new[] { (13, 40), (45, 50) }));
        }
        
        [Fact]
        public void IsValidTest()
        {

            "class: 1-3 or 5-7".ParseRule().IsValid(7).Should().BeTrue();
        }
    }
}