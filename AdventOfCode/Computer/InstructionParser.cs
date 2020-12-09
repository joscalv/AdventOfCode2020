using System;
using System.Linq;
using AdventOfCode.Computer.Instructions;

namespace AdventOfCode.Computer
{
    public static class InstructionParser
    {
        public static Instruction[] ParseProgram(string program)
        {
            var instructions = program
                .Split('\n')
                .Where(s=> !string.IsNullOrWhiteSpace(s))
                .ToArray();
            return ParseProgram(instructions);
        }

        public static Instruction[] ParseProgram(string[] program)
        {
            return program
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(Parse)
                .ToArray();
        }

        public static Instruction Parse(string instruction) => instruction.Substring(0, 3) switch
        {
            NopInstruction.Code => new NopInstruction(ParseValue(instruction)),
            AccInstruction.Code => new AccInstruction(ParseValue(instruction)),
            JmpInstruction.Code => new JmpInstruction(ParseValue(instruction)),
            _ => throw new NotImplementedException($"Code {instruction} parse not implemented"),
        };

        public static NopInstruction ParseNopInstruction(string str) => new NopInstruction(ParseValue(str));
        

        public static JmpInstruction ParseJmpInstruction(string str)
        {
            //str.MustStartWith(JmpInstruction.Code);
            return new JmpInstruction(ParseValue(str));
        }

        public static AccInstruction ParseAccInstruction(string str)
        {
            //str.MustStartWith(AccInstruction.Code);
            return new AccInstruction(ParseValue(str));
        }

        private static int ParseValue(string str)
        {
            return (str[4] == '+' ? 1 : -1) * int.Parse(str.Substring(5));
        }

        private static void MustStartWith(this string instruction, string code)
        {
            if (!instruction.StartsWith(code))
            {
                throw new FormatException($"{instruction} must start with {code}");
            }
        }
    }
}