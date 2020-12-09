using AdventOfCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day09Test
    {
        private static readonly Day09 _day09 = new Day09();
        private static long[] SampleData = new long[] { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 };

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 104054607;
            Assert.Equal(part1Solution, _day09.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 13935797;
            Assert.Equal(part2Solution, actual: _day09.ExecutePart2());
        }

        [Fact]
        public void GetSumPairTest1()
        {
            long[] testData = new long[26];
            for (int i=0; i < 25; i++)
            {
                testData[i] = i + 1;
            }

            testData[25] = 26;
            XmasUtils.ExistSum(testData, 25, 25).Should().Be(true);
            testData[25] = 49;
            XmasUtils.ExistSum(testData, 25, 25).Should().Be(true);
            testData[25] = 100;
            XmasUtils.ExistSum(testData, 25, 25).Should().Be(false);
            testData[25] = 50;
            XmasUtils.ExistSum(testData, 25, 25).Should().Be(false);

        }

        [Fact]
        public void GetSumPairTest2()
        {
            XmasUtils.ExistSum(SampleData, 5, 5).Should().Be(true);
            XmasUtils.ExistSum(SampleData, 5, 6).Should().Be(true);
            XmasUtils.ExistSum(SampleData, 5, 7).Should().Be(true);
            XmasUtils.ExistSum(SampleData, 5, 8).Should().Be(true);
            XmasUtils.ExistSum(SampleData, 5, 14).Should().Be(false);
        }
        
        [Fact]
        public void GetFistNotValdTest()
        {
            XmasUtils.GetFirstNotValid(SampleData, 5).Should().Be(127);
        }
        
        [Fact]
        public void GetRangeThatSumsTest()
        {
            XmasUtils.GetRangeThatSums(SampleData, 127).Should().BeEquivalentTo(new long[] { 15, 25, 47, 40 });
        }
    }


}