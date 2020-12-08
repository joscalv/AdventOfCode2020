using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using AdventOfCode.Computer;
using AdventOfCode.Computer.Instructions;

namespace AdventOfCode
{

    public class Day08 : IAdventOfCodeDay<long, long>
    {
        private readonly Instruction[] _instructions;

        public Day08()
        {
            _instructions = File
                  .ReadAllText(Path.Combine("Inputs", "input08.txt"))
                  .Split("\n")
                  .Where(str => !string.IsNullOrWhiteSpace(str))
                  .Select(InstructionParser.Parse)
                  .ToArray();
        }

        public long ExecutePart1()
        {

            Computer.Computer p = new Computer.Computer(_instructions);
            p.ExecuteStopWhenLoop();
            return p.GetAcc();
        }

        public long ExecutePart2()
        {
            return ExecutePart2(_instructions);
        }

        public long ExecutePart2(Instruction[] instructions)
        {
            Computer.Computer computer = null;
            var nextInstructions = instructions;
            int replaced = 0;
            do
            {
                computer = new Computer.Computer(nextInstructions);
                computer.ExecuteStopWhenLoop();
                nextInstructions = SwitchFirstJmpNop(instructions, replaced, out var lastReplaced);
                replaced = lastReplaced + 1;
            } while (computer.IsFinished() != true && replaced < instructions.Length);

            return computer?.IsFinished() == true ? computer.GetAcc() : -1;
        }

        private Instruction[] SwitchFirstJmpNop(Instruction[] instructions, int replaceFrom, out int replaced)
        {
            var result = new Instruction[instructions.Length];
            replaced = -1;
            for (int i = 0; i < instructions.Length; i++)
            {
                if (replaced < 0 && i >= replaceFrom
                              && (instructions[i].GetCode() == "jmp" || instructions[i].GetCode() == "nop"))
                {
                    Instruction instructionToReplace = null;
                    if (instructions[i] is JmpInstruction ins)
                    {
                        instructionToReplace = new NopInstruction(ins.Jump);
                    }
                    else if (instructions[i] is NopInstruction ins2)
                    {
                        instructionToReplace = new JmpInstruction(ins2.Value);
                    }
                    result[i] = instructionToReplace;
                    replaced = i;
                }
                else
                {
                    result[i] = instructions[i];
                }
            }
            return result;
        }

    }
}
