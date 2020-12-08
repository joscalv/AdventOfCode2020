using System.Collections.Generic;
using AdventOfCode;
using FluentAssertions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode.Computer;
using AdventOfCode.Computer.Instructions;
using Xunit;

namespace AdventOfCode2020Test
{


    public class ComputerTest
    {


        [Fact]
        public void NopTest()
        {
            State initialState = new State();

            Instruction nopInstruction = new NopInstruction(0);
            var newState = nopInstruction.Execute(initialState);

            newState.Acc.Should().Be(0);
            newState.Pc.Should().Be(1);
        }

        [Fact]
        public void JmpTest()
        {
            State initialState = new State();

            Instruction jmpInstruction = new JmpInstruction(4);
            var newState = jmpInstruction.Execute(initialState);

            newState.Acc.Should().Be(0);
            newState.Pc.Should().Be(4);
        }

        [Fact]
        public void AccTest()
        {
            State initialState = new State();

            Instruction accInstruction = new AccInstruction(1);
            var newState = accInstruction.Execute(initialState);

            newState.Acc.Should().Be(1);
            newState.Pc.Should().Be(1);
        }

        [Fact]
        public void ParseTest()
        {
            InstructionParser.Parse("nop +0").Should().BeEquivalentTo(new NopInstruction(0));
            InstructionParser.Parse("acc +1").Should().BeEquivalentTo(new AccInstruction(1));
            InstructionParser.Parse("jmp +4").Should().BeEquivalentTo(new JmpInstruction(4));
        }
        
        }
}