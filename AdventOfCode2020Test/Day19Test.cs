using System.Linq;
using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day19Test
    {


        [Fact]
        public void TestPart1()
        {
            int part1Solution = 279;
            Day19 day = new Day19();
            day.ExecutePart1().Should().Be(part1Solution);
        }

        [Fact]
        public void TestPart2()
        {
            Day19 day = new Day19();
            int part2Solution = 384;
            day.ExecutePart2().Should().Be(part2Solution);
        }

        [Fact]
        public void TestPart1Sample1()
        {
            var input = @"0: 1 2
1: ""a""
2: 1 3 | 3 1
3: ""b""".Split('\n');

            var parsed = Day19.ParseInput(input);
            Day19.CheckRule(parsed.rules, "aab").Should().BeTrue();
            Day19.CheckRule(parsed.rules, "aba").Should().BeTrue();
            Day19.CheckRule(parsed.rules, "abaaaaaaaaaaaaaa").Should().BeFalse();
            Day19.CheckRule(parsed.rules, "a").Should().BeFalse();
        }

        [Fact]
        public void TestPart1Sample2()
        {
            var input = @"0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""

ababbb
bababa
abbbab
aaabbb
aaaabbb".Split('\n');

            var parsed = Day19.ParseInput(input);
            Day19.CheckRuleAtIndex(parsed.rules, "ababbb").Any(c => c == "ababbb".Length).Should().BeTrue();
        }

        [Fact]
        public void TestPart2Sample2()
        {
            var input = @"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1

abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaaaabbaaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
babaaabbbaaabaababbaabababaaab
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba".Split('\n');

            var parsed = Day19.ParseInput(input);
            parsed.lines.Select(l => l.Replace("\r", "")).Count(line => Day19.CheckRule(parsed.rules, line)).Should().Be(3);

            parsed.rules[8] = new MonsterRule(8, new[] { 42 }, new[] { 42, 8 });
            parsed.rules[11] = new MonsterRule(11, new[] { 42, 31 }, new[] { 42, 11, 31 });

            parsed.lines.Select(l => l.Replace("\r", "")).Count(line => Day19.CheckRule(parsed.rules, line)).Should().Be(12);
        }


    }
}