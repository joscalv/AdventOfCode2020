using System.Collections.Generic;
using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day07Test
    {
        private readonly Day07 _day07 = new Day07();

        [Theory]
        [InlineData("light red bags contain 1 bright white bag, 2 muted yellow bags.")]
        public void CountAnswers1(string ruleString)
        {
            BagRule g = ruleString.ParseLuggageRule();
            g.BagColor.Should().Be("light red");
            g.MustContain.Should().HaveCount(2);
            g.MustContain[0].Quantity.Should().Be(1);
            g.MustContain[0].Color.Should().Be("bright white");
            g.MustContain[1].Quantity.Should().Be(2);
            g.MustContain[1].Color.Should().Be("muted yellow");
        }   
        
        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.")]
        public void CountAnswers2(string ruleString)
        {
            BagRule g = ruleString.ParseLuggageRule();
            g.BagColor.Should().Be("bright white");
            g.MustContain.Should().HaveCount(1);
            g.MustContain[0].Quantity.Should().Be(1);
            g.MustContain[0].Color.Should().Be("shiny gold");
        }       
        
        [Theory]
        [InlineData("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags")]
        public void CountAnswers3(string ruleString)
        {
            BagRule g = ruleString.ParseLuggageRule();
            g.BagColor.Should().Be("muted yellow");
            g.MustContain.Should().HaveCount(2);
            g.MustContain[0].Quantity.Should().Be(2);
            g.MustContain[0].Color.Should().Be("shiny gold");
            g.MustContain[1].Quantity.Should().Be(9);
            g.MustContain[1].Color.Should().Be("faded blue");
        }

        [Fact]
        public void GetPossibleParents()
        {
            var rules = new string[]
            {

                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",

            };
            var result = Day07.GetPossibleParents(rules, "shiny gold");
            result.Should().Be(4);
        } 
        
        [Fact]
        public void GetChildren()
        {
            var rules = new string[]
            {

                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",

            };
            var result = Day07.GetNumberOfChild(rules, "shiny gold");
            result.Should().Be(32);
        }
        
        [Fact]
        public void GetChildren2()
        {
            var rules = new string[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            };
            var result = Day07.GetNumberOfChild(rules, "shiny gold");
            result.Should().Be(126);
        }

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 103;
            
            Assert.Equal(part1Solution, _day07.ExecutePart1());
        } 
        
        [Fact]
        public void TestPart2()
        {
            int part2Solution = 1469;
            Assert.Equal(part2Solution, actual: _day07.ExecutePart2());
        } 
    }

    
}