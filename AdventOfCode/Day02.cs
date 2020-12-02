using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Pattern
    {
        public Pattern(int minRep, int maxRep, char c)
        {
            MinRep = minRep;
            MaxRep = maxRep;
            Character = c;
        }

        public int MinRep { get; }
        public int MaxRep { get; }
        public char Character { get; }

        public bool IsValid(string password)
        {

            int repeats = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == Character)
                {
                    repeats++;
                }
            }
            return repeats >= MinRep && repeats <= MaxRep;

        }

        public bool IsValidPolicy2(string password)
        {
            return (password[MinRep - 1] == Character) ^
                (password[MaxRep - 1] == Character);
        }
    }

    public class Day02
    {

        private List<(Pattern, string)> _values;

        public Day02()
        {
            _values = File
                .ReadAllLines(Path.Combine("Inputs", "input02.txt"))
                .Select(line =>
                {
                    ParsePatternAndPassword(line, out var pattern, out var password);
                    return (pattern, password);
                })
                .ToList();
        }

        public int ExecutePart1()
        {
            return _values.Where(pair => pair.Item1.IsValid(pair.Item2)).Count();
        }

        public int ExecutePart2()
        {
            return _values.Where(pair => pair.Item1.IsValidPolicy2(pair.Item2)).Count();
        }

        public static void ParsePatternAndPassword(string line, out Pattern pattern, out string password)
        {
            var parts = line.Split(':');
            try
            {
                var patternString = parts[0];
                var patternParts = patternString.Split(' ');


                var character = patternParts[1][0];

                var minMax = patternParts[0].Split('-');
                var minRep = int.Parse(minMax[0]);
                var maxRep = int.Parse(minMax[1]);

                pattern = new Pattern(minRep, maxRep, character);
                password = parts[1].Trim();
            }
            catch (Exception e)
            {
                pattern = null;
                password = default(string);
                throw new FormatException($"bad line format {line}", e);
            }
        }






    }
}
