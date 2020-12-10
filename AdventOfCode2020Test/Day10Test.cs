using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day10Test
    {
        private static readonly Day10 _day10 = new Day10();
        private int[] sample1 = new int[] { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 };
        private int[] sample2 = new int[] { 28,
33,
18,
42,
31,
14,
46,
20,
48,
47,
24,
23,
49,
45,
19,
38,
39,
11,
1 ,
32,
25,
35,
8 ,
17,
7 ,
9 ,
4 ,
2 ,
34,
10,
3 };

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 1920;
            Assert.Equal(part1Solution, _day10.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            long part2Solution = 1511207993344;
            Assert.Equal(part2Solution, actual: _day10.ExecutePart2());
        }

        [Fact]
        public void Sample1_Part1()
        {
            long sample1Solution = 35;
            Assert.Equal(sample1Solution, actual: _day10.ExecutePart1(sample1));
        }
        
        [Fact]
        public void Sample2_Part1()
        {
            long sample1Solution = 220;
            Assert.Equal(sample1Solution, actual: _day10.ExecutePart1(sample2));
        }
        
        [Fact]
        public void Sample1_Part2()
        {
            long sample1Solution = 8;
            Assert.Equal(sample1Solution, actual: _day10.ExecutePart2(sample1));
        }
        [Fact]
        public void Sample1_Part2B()
        {
            long sample1Solution = 8;
            Assert.Equal(sample1Solution, actual: _day10.ccc((new int[] { 0 }, sample1.OrderBy(x=>x).ToArray())));
        }
        
        [Fact]
        public void Sample1_Part2C()
        {
            long sample1Solution = 8;
            Assert.Equal(sample1Solution, actual: _day10.ExecutePart2Solution3(sample1));
        }
        
        [Fact]
        public void Sample2_Part2C()
        {
            long sample1Solution = 19208;
            Assert.Equal(sample1Solution, actual: _day10.ExecutePart2Solution3(sample2));
        }
        
        [Fact]
        public void Sample2_Part2()
        {
            long sample1Solution = 19208;
            Assert.Equal(sample1Solution, actual: _day10.ExecutePart2(sample2));
        }
        
        [Fact]
        public void Sample2_Part2B()
        {
            long sample1Solution = 19208;
            Assert.Equal(sample1Solution, actual: _day10.ccc((new int[] { 0 }, sample2.OrderBy(x => x).ToArray())));
        }

        [Fact]
        public void AppendToArrayTest()
        {
            int[] array = new int[] {1,2,3,4,5 };
            int[] expected = new int[] {1,2,3,4,5,6 };
            Day10.AppendToArray(array, 6).Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void SubArrayTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Day10.SubArray(array, 0).Should().BeEquivalentTo(new int[] { 1, 2, 3, 4, 5 });
            Day10.SubArray(array, 1).Should().BeEquivalentTo(new int[] { 2, 3, 4, 5 });
            Day10.SubArray(array, 2).Should().BeEquivalentTo(new int[] { 3, 4, 5 });
            Day10.SubArray(array, 3).Should().BeEquivalentTo(new int[] { 4, 5 });
            Day10.SubArray(array, 4).Should().BeEquivalentTo(new int[] { 5 });
            Day10.SubArray(array, 5).Should().BeEquivalentTo(new int[] { });
        }
        
        [Fact]
        public void RemoveIndexTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Day10.RemoveIndex(array, 0).Should().BeEquivalentTo(new int[] { 2, 3, 4, 5 });
            Day10.RemoveIndex(array, 1).Should().BeEquivalentTo(new int[] { 1, 3, 4, 5 });
            Day10.RemoveIndex(array, 2).Should().BeEquivalentTo(new int[] { 1, 2, 4, 5 });
            Day10.RemoveIndex(array, 3).Should().BeEquivalentTo(new int[] { 1, 2, 3, 5 });
            Day10.RemoveIndex(array, 4).Should().BeEquivalentTo(new int[] { 1, 2, 3, 4 });
        }
    }
}