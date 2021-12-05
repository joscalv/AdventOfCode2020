using AdventOfCode;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day14Test
    {
        private static readonly Day14 _day = new Day14();

        [Fact]
        public void TestPart1()
        {
            var part1Solution = 13476250121721UL;
            _day.ExecutePart1().Should().Be(part1Solution);
        }

        [Fact]
        public void TestPart2Example()
        {
            ulong part2Solution = 208;
            string[] input = new string[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };
            _day.ExecutePart2(input).Should().Be(part2Solution);
        }
        
        [Fact]
        public void TestPart2()
        {
            ulong part2Solution = 4463708436768UL;
            _day.ExecutePart2().Should().Be(part2Solution);
        }

        [Fact]
        public void ApplyMask()
        {
            string inputMask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X";
            Day14Extensions.ApplyMask(11, inputMask).Should().Be(73);
            Day14Extensions.ApplyMask(101, inputMask).Should().Be(101);
            Day14Extensions.ApplyMask(0, inputMask).Should().Be(64);

        }

        [Fact]
        public void GetBitAtIndexTest()
        {
            Day14Extensions.GetBitAtIndex(0, 0).Should().Be(0);
            Day14Extensions.GetBitAtIndex(0, 1).Should().Be(0);
            Day14Extensions.GetBitAtIndex(0, 36).Should().Be(0);
            Day14Extensions.GetBitAtIndex(1, 0).Should().Be(1);
            Day14Extensions.GetBitAtIndex(1, 1).Should().Be(0);
            Day14Extensions.GetBitAtIndex(1, 2).Should().Be(0);
            Day14Extensions.GetBitAtIndex(2, 0).Should().Be(0);
            Day14Extensions.GetBitAtIndex(2, 1).Should().Be(1);
            Day14Extensions.GetBitAtIndex(2, 2).Should().Be(0);
        }

        [Fact]
        public void ApplyMask2()
        {
            Day14Extensions.ApplyMask2(42, "000000000000000000000000000000X1001X").Should().BeEquivalentTo(new List<int>() { 26, 27, 58, 59 });
            Day14Extensions.ApplyMask2(26, "00000000000000000000000000000000X0XX")
                .Should()
                .BeEquivalentTo(new List<int>() { 16, 17, 18, 19, 24, 25, 26, 27 });
        }
    }
}