using System;
using System.ComponentModel;
using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day18Test
    {
        //private static readonly Day18 _day = new Day18();

        [Fact]
        public void TestPart1()
        {
            var part1Solution = 75592527415659L;
            var day = new Day18();
            day.ExecutePart1().Should().Be(part1Solution);
        }

        [Fact]
        public void TestPart2()
        {
            long part2Solution = 0360029542265462L;
            var day = new Day18();
            day.ExecutePart2().Should().Be(part2Solution);
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 26)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void OperationTest(string input, int expected)
        {
            Day18.Calc(input).Should().Be(expected);
        }
        
        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        [InlineData("1", 1)]
        [InlineData("2 + 2", 4)]
        [InlineData("(2 + 2)", 4)]
        [InlineData("((4 * 4) + (3 * 3))", 25)]
        [InlineData("2 + 2 + 2", 6)]
        [InlineData("2 * 4 + 6 + 8", 36)]
        [InlineData("3 * 3", 9)]
        public void OperationPrecedenceTest(string input, int expected)
        {
            Day18.CalcPrecedence(input).Should().Be(expected);
        }
    }
}