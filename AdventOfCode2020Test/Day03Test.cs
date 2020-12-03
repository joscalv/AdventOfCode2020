using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day03Test
    {
        [Fact]
        public void TestTraverseMap()
        {
            var input = new string[] {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"};

            var map = new Map(input);
            Assert.Equal(2, map.TraverseMap(1,1));
            Assert.Equal(7, map.TraverseMap(3,1));
            Assert.Equal(3, map.TraverseMap(5,1));
            Assert.Equal(4, map.TraverseMap(7,1));
            Assert.Equal(2, map.TraverseMap(1,2));
        }
        
        [Fact]
        public void Test1()
        {
            var day3 = new Day03();
            Assert.Equal(164, day3.ExecutePart1());
        }
        
        [Fact]
        public void Test2()
        {
            var day3 = new Day03();
            Assert.Equal(5007658656, actual: day3.ExecutePart2());
        }
    }
}