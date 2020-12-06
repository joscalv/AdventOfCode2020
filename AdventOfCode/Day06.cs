using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AdventOfCode
{

    public class Group
    {
        private readonly string _answers;

        public Group(string answers)
        {
            _answers = answers;
        }

        public int GetNumerOfAnswers()
        {
            HashSet<char> chars = new HashSet<char>();
            foreach (char c in _answers)
            {
                if (c >= 'a' && c <= 'z')
                {
                    chars.Add(c);
                }
            }

            return chars.Count();
        }

        public int GetCommonAnswers()
        {
            var participants = 1;
            Dictionary<char, int> chars = new Dictionary<char, int>();

            foreach (char c in _answers)
            {
                if (c == '\n')
                {
                    participants++;
                }
                else if (!chars.ContainsKey(c))
                {
                    chars.Add(c, 1);
                }
                else
                {
                    chars[c] = chars[c] + 1;
                }
            }

            return chars
                .Count(k => k.Value == participants);
        }
    }

    public class Day06 : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _groupLines;

        public Day06()
        {
            _groupLines = File
                  .ReadAllText(Path.Combine("Inputs", "input06.txt"))
                  .Split("\n\n");
        }

        public long ExecutePart1()
        {
            return _groupLines
                .Select(t => new Group(t))
                .Sum(g => g.GetNumerOfAnswers());

        }

        public long ExecutePart1Linq()
        {
            return _groupLines
                .Select(
                    l => l
                        .Where(c => c != '\n')
                        .GroupBy(c => c)
                        .Count())
                .Sum(v => v);
        }

        public long ExecutePart2()
        {
            return _groupLines
                .Select(t => new Group(t))
                .Sum(g => g.GetCommonAnswers());
        }

        public long ExecutePart2Linq()
        {
            return _groupLines
                .Select(
                    l => l
                        .Where(c => c != '\n')
                        .GroupBy(c => c)
                        .Count(g => g.Count() == 1 + l.Count(c => c == '\n')))
                .Sum();
        }
    }
}
