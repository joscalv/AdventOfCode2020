namespace AdventOfCode.Computer.Instructions
{
    public class NopInstruction : Instruction
    {
        public const string Code = "nop";
        public int Value { get; }

        public NopInstruction(int value) : base(Code)
        {
            Value = value;
        }
        public override State Execute(State previousState)
        {
            return previousState with { Pc = previousState.Pc + 1 };
        }
    }
}