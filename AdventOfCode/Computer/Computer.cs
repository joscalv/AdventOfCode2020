using AdventOfCode.Computer.Instructions;
using System.Collections.Generic;

namespace AdventOfCode.Computer
{
    public class Computer
    {
        private readonly Instruction[] _program;
        private State _currentState;

        public Computer(Instruction[] program)
        {
            _program = program;
            _currentState = new State();
        }

        public void ExecuteUntilRepeat()
        {
            Execute(1);
        }

        readonly Dictionary<long, int> _executed = new Dictionary<long, int>();
        public void Execute(int loopLimit = -1)
        {
            _executed.Clear();

            while (_currentState.Pc < _program.Length &&
                   (loopLimit == -1 || !IsLoop(loopLimit)))
            {
                _currentState = _program[_currentState.Pc].Execute(_currentState);
            }
        }

        public bool IsLoop(int loopLimit)
        {
            if (_executed.ContainsKey(_currentState.Pc))
            {
                _executed[_currentState.Pc] = _executed[_currentState.Pc] + 1;
            }
            else
            {
                _executed.Add(_currentState.Pc, 1);
            }

            return _executed.ContainsKey(_currentState.Pc) && _executed[_currentState.Pc] > loopLimit;
        }

        public bool IsFinished()
        {
            return _currentState.Pc == _program.Length;
        }

        public long GetAcc()
        {
            return _currentState.Acc;
        }
    }
}