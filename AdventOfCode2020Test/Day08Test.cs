using System.Collections.Generic;
using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day08Test
    {
        private readonly Day08 _day08 = new Day08();
        [Fact]
        public void TestPart1()
        {
            int part1Solution = 0;
            Assert.Equal(part1Solution, _day08.ExecutePart1());
        } 
        
        [Fact]
        public void TestPart2()
        {
            int part2Solution = 0;
            Assert.Equal(part2Solution, actual: _day08.ExecutePart2());
        } 
    }

    
}