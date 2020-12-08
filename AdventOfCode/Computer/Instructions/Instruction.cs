namespace AdventOfCode.Computer.Instructions
{
    public abstract class Instruction
    {
        protected Instruction(string code)
        {
            _code = code;
        }
        private readonly string _code;
        public string GetCode() => _code;
        public abstract State Execute(State previousState);
    }
}