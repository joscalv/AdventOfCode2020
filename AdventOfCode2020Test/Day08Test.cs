using System.Collections.Generic;
using AdventOfCode;
using FluentAssertions;
using System.Linq;
using AdventOfCode.Computer;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day08Test
    {
        private readonly Day08 _day08 = new Day08();
        private string _programTest1 = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6
";

        [Fact]
        public void ParseProgram()
        {
            InstructionParser.ParseProgram(_programTest1).Should().HaveCount(9);
        }

        [Fact]
        public void SamplePart1()
        {
            var program = InstructionParser.ParseProgram(_programTest1);
            Computer p = new Computer(program);
            p.ExecuteUntilRepeat();
            p.GetAcc().Should().Be(5);
        }



        [Fact]
        public void TestPart1()
        {
            int part1Solution = 1501;
            Assert.Equal(part1Solution, _day08.ExecutePart1());
        }

        [Fact]
        public void SamplePart2()
        {
            var program = InstructionParser.ParseProgram(_programTest1);
            Day08 day8 = new Day08();
            day8.ExecutePart2(program).Should().Be(8);
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 509;
            Assert.Equal(part2Solution, actual: _day08.ExecutePart2());
        }
    }


}