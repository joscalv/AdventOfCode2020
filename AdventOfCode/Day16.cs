using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public record Rule(string Field, (int, int)[] Ranges)
    {
        public bool IsValid(int value)
        {
            foreach (var range in Ranges)
            {
                if (value >= range.Item1 && value <= range.Item2)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Day16 : IAdventOfCodeDay<long, long>
    {

        private readonly Rule[] _rules;
        private readonly int[] _ticket;
        private readonly List<int[]> _nearbyTickets;

        public Day16()
        {
            var lines = File
                  .ReadAllText(Path.Combine("Inputs", "input16.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .ToArray();
            (_rules, _ticket, _nearbyTickets) = Day16Extensions.ParseInput(lines);
        }

        public long ExecutePart1()
        {
            return ExecutePart1(_rules, _ticket, _nearbyTickets);
        }

        public static long ExecutePart1(Rule[] rules, int[] ticket, List<int[]> nearTickets)
        {
            long accumulator = 0;
            foreach (var nearTicket in nearTickets)
            {
                var invalid = Day16Extensions.GetInvalidValues(rules, nearTicket);

                accumulator += invalid.Sum();
            }
            return accumulator;
        }

        public long ExecutePart2()
        {

            return ExecutePart2(_rules, _ticket, _nearbyTickets);
        }

        public static long ExecutePart2(Rule[] rules, int[] ticket, List<int[]> nearTickets)
        {
            var validTickets = nearTickets.Where(t => !Day16Extensions.GetInvalidValues(rules, t).Any()).ToArray();

            List<List<Rule>> rulesForFiedIndex = new List<List<Rule>>();
            for (int i = 0; i < ticket.Length; i++)
            {
                rulesForFiedIndex.Add(new List<Rule>());
            }


            for (int i = 0; i < ticket.Length; i++)
            {
                int ruleIndex = 0;
                while (ruleIndex < rules.Length)
                {

                    var rule = rules[ruleIndex];

                    var isRuleValid = true;
                    foreach (var nearTicket in validTickets)
                    {
                        isRuleValid &= rule.IsValid(nearTicket[i]);
                    }

                    if (isRuleValid)
                    {
                        rulesForFiedIndex[i].Add(rule);
                    }
                    ruleIndex++;
                }

            }

            while (rulesForFiedIndex.Any(rrr => rrr.Count > 1))
            {
                var unique = rulesForFiedIndex.Where(rrr => rrr.Count == 1).Select(rrr => rrr.First()).ToList();
                for (int i = 0; i < ticket.Length; i++)
                {
                    if (rulesForFiedIndex[i].Count > 1)
                    {
                        var test = rulesForFiedIndex[i].RemoveAll(item =>
                         {
                             return unique.Contains(item);
                         });
                    }
                }

            }

            long result = 0;
            for (int i = 0; i < ticket.Length; i++)
            {
                if (rulesForFiedIndex[i].First().Field.StartsWith("departure"))
                {
                    if (result == 0)
                    {
                        result = 1;
                    }
                    result *= ticket[i];
                }
            }

            return result;
        }
    }

    public static class Day16Extensions
    {
        public static Rule ParseRule(this string line)
        {
            var fields = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
            var ranges = fields[1]
                .Split(" or ")
                .Select(range =>
                     {
                         var values = range.Split('-').Select(int.Parse).ToArray();
                         return (values[0], values[1]);
                     })
                .ToArray();
            return new Rule(fields[0], ranges);
        }

        public static (Rule[] rules, int[] ticket, List<int[]> nearTickes) ParseInput(string[] lines)
        {
            int i = 0;
            var rules = new List<Rule>();

            while (!lines[i].Contains("your ticket"))
            {
                rules.Add(lines[i].ParseRule());
                i++;
            }

            i++;
            var ticket = lines[i].Split(',').Select(int.Parse).ToArray();
            i = i + 2;
            var nearbyTickets = lines.TakeLast(lines.Length - i).Select(line => line.Split(',').Select(int.Parse).ToArray()).ToList();

            return (rules.ToArray(), ticket, nearbyTickets);
        }

        public static List<int> GetInvalidValues(Rule[] rules, int[] ticket)
        {
            var result = new List<int>();
            foreach (var value in ticket)
            {
                if (!rules.Any(r => r.IsValid(value)))
                {
                    result.Add(value);
                }
            }

            return result;
        }
    }
}
