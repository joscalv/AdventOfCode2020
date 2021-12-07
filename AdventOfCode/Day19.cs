using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{

    public class Day19 : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _input;

        public Day19()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input19.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .ToArray();
        }

        public static (Dictionary<int, MonsterRule> rules, IEnumerable<string> lines) ParseInput(string[] input)
        {
            Dictionary<int, MonsterRule> rules = new Dictionary<int, MonsterRule>();
            List<string> lines = new List<string>();

            foreach (var line in input)
            {
                if (line.Contains(":"))
                {
                    MonsterRule rule;
                    //parse ruleIndex
                    var idAndValue = line.Split(':');
                    var id = int.Parse(idAndValue[0]);
                    var valuesStr = idAndValue[1];


                    if (valuesStr.Contains('"'))
                    {
                        var character = valuesStr.Trim().ToCharArray()[1];
                        rule = new MonsterRule(id, character);
                    }
                    else if (valuesStr.Contains('|'))
                    {
                        var rulesOr = valuesStr
                            .Split('|')
                            .Select(v => v.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                            .Select((v => v.Select(int.Parse).ToArray()))
                            .ToList();
                        rule = new MonsterRule(id, rulesOr[0], rulesOr[1]);
                    }
                    else
                    {
                        var values = valuesStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                        rule = new MonsterRule(id, values);
                    }

                    rules.Add(rule.Index, rule);
                }
                else
                {
                    lines.Add(line);
                }
            }

            return (rules, lines);
        }

        public long ExecutePart1()
        {
            var input = ParseInput(_input);
            return input.lines.Count(line => CheckRule(input.rules, line));
        }

        public long ExecutePart2()
        {
            var input = ParseInput(_input);
            input.rules[8] = new MonsterRule(8, new[] { 42 }, new[] { 42, 8 });
            input.rules[11] = new MonsterRule(11, new[] { 42, 31 }, new[] { 42, 11, 31 });

            return input.lines.Count(line => CheckRule(input.rules, line));
        }

        public static bool CheckRule(Dictionary<int, MonsterRule> rules, string word)
        {
            return CheckRuleAtIndex(rules, word).Any(l => l == word.Length);

        }

        public static List<int> CheckRuleAtIndex(Dictionary<int, MonsterRule> rules, string input, int ruleIndex = 0, int index = 0)
        {
            var rule = rules[ruleIndex];
            if (rule.Type == RuleType.Rule || rule.Type == RuleType.OrRules)
            {
                var resultA = CheckRuleList(rules, input, rule.RulesA, index);
                var resultB = CheckRuleList(rules, input, rule.RulesB, index);
                var result = new List<int>();
                result.AddRange(resultA);
                result.AddRange(resultB);
                return result;
            }
            else
            {
                return index < input.Length && input[index] == rule.Value ? new List<int>() { index + 1 } : new List<int>();
            }
        }


        private static List<int> CheckRuleList(Dictionary<int, MonsterRule> rules, string input, int[] rulesIndex, int index)
        {
            if (rulesIndex == null || rulesIndex.Length == 0)
            {
                return new List<int>();
            }

            var possiblePath = new List<int>() { index };
            foreach (var ruleIndex in rulesIndex)
            {
                var solutionsOfRule = new List<int>();
                foreach (var i in possiblePath)
                {
                    var possibleSolutions = CheckRuleAtIndex(rules, input, ruleIndex, i);
                    if (possibleSolutions.Any())
                    {
                        solutionsOfRule.AddRange(possibleSolutions);
                    }
                }

                possiblePath = solutionsOfRule;
            }
            return possiblePath;
        }

    }

    public enum RuleType
    {
        Character,
        Rule,
        OrRules
    }

    public class MonsterRule
    {

        public MonsterRule(int index, char value)
        {
            Index = index;
            Value = value;
            RulesA = null;
            RulesB = null;
            Type = RuleType.Character;
        }
        public MonsterRule(int index, int[] rulesA, int[] rulesB)
        {
            Index = index;
            RulesA = rulesA;
            RulesB = rulesB;
            Type = RuleType.OrRules;
        }

        public MonsterRule(int index, int[] rules)
        {
            Index = index;
            RulesA = rules;
            Type = RuleType.Rule;
        }

        public RuleType Type { get; }
        public int Index { get; }
        public int[] RulesA { get; }
        public int[] RulesB { get; }
        public char Value { get; }


    }
}
