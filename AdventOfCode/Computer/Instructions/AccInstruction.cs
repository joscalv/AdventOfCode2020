namespace AdventOfCode.Computer.Instructions
{
    public class AccInstruction : Instruction
    {
        public const string Code = "acc";
        public int Acc { get; }

        public AccInstruction(int acc) : base(Code)
        {
            Acc = acc;
        }

        public override State Execute(State previousState)
        {
            return new State { Pc = previousState.Pc + 1, Acc = previousState.Acc + Acc };
        }
    }
}