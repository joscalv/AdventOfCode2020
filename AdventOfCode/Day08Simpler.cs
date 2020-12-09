using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{

    public class Day08Simpler : IAdventOfCodeDay<long, long>
    {
        private readonly SimpleComputer.Instruction[] _instructions;

        public Day08Simpler()
        {
            var text = File
                  .ReadAllText(Path.Combine("Inputs", "input08.txt"));

            _instructions = Parse(text);
        }

        public static SimpleComputer.Instruction[] Parse(string imput)
        {
            int i = 0;
            return imput.Split("\n")
                  .Where(str => !string.IsNullOrWhiteSpace(str))
                  .Select(l => Parse(i++, l))
                  .ToArray();
        }

        public static SimpleComputer.Instruction Parse(int line, string instruction)
        {
            var code = instruction.Substring(0, 3);
            int value = (instruction[4] == '+' ? 1 : -1) * int.Parse(instruction.Substring(5));
            return new SimpleComputer.Instruction(line, code, value);
        }

        public long ExecutePart1()
        {
            return (long)SimpleComputer.ExecuteProgram(_instructions, 1).acc;
        }

        public long ExecutePart2()
        {
            return ExecutePart2(_instructions);
        }

        public static long ExecutePart2(SimpleComputer.Instruction[] input)
        {
            var program = input;

            for (int indexToReplace = 0; indexToReplace < program.Length; indexToReplace++)
            {
                var oldInstruction = input[indexToReplace];
                if (!TryToFixProgram(program, indexToReplace))
                {
                    continue;
                }

                var result = SimpleComputer.ExecuteProgram(program, 1);

                if (result.pc == input.Length)
                {
                    return result.acc;
                }
                program[indexToReplace] = oldInstruction;
            }
            return -1;
        }

        private static bool TryToFixProgram(SimpleComputer.Instruction[] input, int indexToReplace)
        {
            var oldInstruction = input[indexToReplace];
            if (oldInstruction.Code == SimpleComputer.instructionJmp)
            {
                input[indexToReplace] = oldInstruction with { Code = SimpleComputer.instructionNop };
            }
            else if (oldInstruction.Code == SimpleComputer.instructionNop)
            {
                input[indexToReplace] = oldInstruction with { Code = SimpleComputer.instructionJmp };
            }
            else
            {
                return false;
            }
            return true;
        }
    }



    public static class SimpleComputer
    {
        public record Instruction(int Index, string Code, int value);
        public record ComputerStatus(int pc, int acc);

        public const string instructionNop = "nop";
        public const string instructionAcc = "acc";
        public const string instructionJmp = "jmp";

        private static readonly Dictionary<string, Func<Instruction, int, int, ComputerStatus>> _dFunc
            = new Dictionary<string, Func<Instruction, int, int, ComputerStatus>> {
                { instructionNop, ExecuteNop},
                { instructionAcc, ExecuteAcc},
                { instructionJmp, ExecuteJmp}
        };

        public static ComputerStatus ExecuteProgram(Instruction[] program, int loopLimit = -1)
        {
            int pc = 0;
            int acc = 0;
            Dictionary<int, int> executed = new Dictionary<int, int>();

            while (pc < program.Length)
            {
                var instruction = program[pc];
                if (IsLoop(executed, pc, loopLimit))
                {
                    return new ComputerStatus(pc, acc);
                }
                else
                {
                    if (_dFunc.TryGetValue(instruction.Code, out var func))
                    {
                        var newStatus = func.Invoke(instruction, pc, acc);
                        pc = newStatus.pc;
                        acc = newStatus.acc;
                    }
                }
            }

            return new ComputerStatus(pc, acc);
        }

        private static bool IsLoop(Dictionary<int, int> executions, int pc, int limit)
        {
            if (limit < 0)
            {
                return false;
            }

            int n;
            if (executions.ContainsKey(pc))
            {
                n = executions[pc] + 1;
                executions[pc] = n;
            }
            else
            {
                n = 1;
                executions.Add(pc, 1);
            }
            return n > limit;
        }

        private static ComputerStatus ExecuteNop(Instruction instruction, int pc, int acc)
        {
            return new ComputerStatus(pc + 1, acc);
        }

        private static ComputerStatus ExecuteJmp(Instruction instruction, int pc, int acc)
        {
            return new ComputerStatus(pc + instruction.value, acc);
        }

        private static ComputerStatus ExecuteAcc(Instruction instruction, int pc, int acc)
        {
            return new ComputerStatus(pc + 1, acc + instruction.value);
        }
    }
}
