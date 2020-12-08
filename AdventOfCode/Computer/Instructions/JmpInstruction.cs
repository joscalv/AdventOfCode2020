namespace AdventOfCode.Computer.Instructions
{
    public class JmpInstruction : Instruction
    {
        public const string Code = "jmp";
        public int Jump { get; }

        public JmpInstruction(int jump) : base(Code)
        {
            Jump = jump;
        }

        public override State Execute(State previousState)
        {
            return previousState with { Pc = previousState.Pc + Jump };
        }
    }
}