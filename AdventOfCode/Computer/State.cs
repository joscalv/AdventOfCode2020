namespace AdventOfCode.Computer
{
    
    public record State
    {
        public long Pc { get; init; }
        public long Acc { get; init; }
    }
}