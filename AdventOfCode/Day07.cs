using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace AdventOfCode
{

    public class Day07 : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _lines;

        public Day07()
        {
            _lines = File
                  .ReadAllText(Path.Combine("Inputs", "input07.txt"))
                  .Split("\n");
        }

        public long ExecutePart1()
        {
            return GetPossibleParents(_lines, "shiny gold");
        }

        public static long GetPossibleParents(string[] rules, string initialColor)
        {
            var bagsRules = rules
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(l => l.ParseLuggageRule());



            var possibleParentsOf = new Dictionary<string, List<string>>();
            foreach (var rule in bagsRules)
            {
                foreach (var contained in rule.MustContain)
                {
                    if (possibleParentsOf.ContainsKey(contained.Color))
                    {
                        possibleParentsOf[contained.Color].Add(rule.BagColor);
                    }
                    else
                    {
                        possibleParentsOf.Add(contained.Color, new List<string>() { rule.BagColor });
                    }
                }
            }

            Queue<string> queuedParents = new Queue<string>();
            queuedParents.Enqueue(initialColor);
            HashSet<string> results = new HashSet<string>();

            while (queuedParents.Any())
            {
                var currentColor = queuedParents.Dequeue();
                if (possibleParentsOf.ContainsKey(currentColor))
                {
                    foreach (var possibleParent in possibleParentsOf[currentColor])
                    {
                        if (!results.Contains(possibleParent))
                        {
                            queuedParents.Enqueue(possibleParent);
                            results.Add(possibleParent);
                        }
                    }
                }
            }

            return results.Count;
        }

        public static long GetNumberOfChild(string[] rules, string initialColor)
        {
            var bagsRules = rules
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(l => l.ParseLuggageRule())
                .ToDictionary(r => r.BagColor, r => r);

            var queuedParents = new Queue<(int, string)>();
            queuedParents.Enqueue((1, initialColor));
            int numberOfChilds = 0;
            while (queuedParents.Any())
            {
                var currentParent = queuedParents.Dequeue();
                if (bagsRules.ContainsKey(currentParent.Item2))
                {
                    foreach (var childRule in (bagsRules[currentParent.Item2].MustContain))
                    {
                        queuedParents.Enqueue((childRule.Quantity * currentParent.Item1, childRule.Color));
                        numberOfChilds += childRule.Quantity*currentParent.Item1;
                    }
                }
            }

            return numberOfChilds;
        }

        public long ExecutePart2()
        {
            return GetNumberOfChild(_lines, "shiny gold");
        }
    }

    public class BagRule
    {
        public BagRule(string ruleString, List<ContainedBags> containedBags)
        {
            BagColor = ruleString;
            MustContain = containedBags;
        }

        public string BagColor { get; private set; }
        public List<ContainedBags> MustContain { get; private set; }

        public class ContainedBags
        {
            public ContainedBags(int quantity, string color)
            {
                Quantity = quantity;
                Color = color;
            }

            public int Quantity { get; }
            public string Color { get; set; }
        }
    }

    public static class Day7Utils
    {
        public static BagRule ParseLuggageRule(this string ruleString)
        {
            var part1 = ruleString.Split("contain");
            if (part1.Length != 2)
            {
                throw new FormatException("Not contain");
            }

            var color = part1[0].Remove(part1[0].IndexOf("bags", StringComparison.Ordinal)).Trim();
            var containedBagsString = part1[1].Split(',');
            if (containedBagsString.Length < 1)
            {
                throw new FormatException("Not contained bags");
            }

            var rules = new List<BagRule.ContainedBags>();
            foreach (var c in containedBagsString)
            {
                var tmp1 = c.Replace("bags.", "")
                    .Replace("bags", "")
                    .Replace("bag.", "")
                    .Replace("bag", "")
                    .Trim();
                int.TryParse($"{tmp1[0]}", out var quantity);
                string containedColor = tmp1.Substring(2);
                rules.Add(new BagRule.ContainedBags(quantity, containedColor));
            }

            return new BagRule(color, rules);
        }
    }
}
