using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day11Test
    {
        private static readonly Day11 _day = new Day11();
        private SeatMap _sample1 = "L.LL.LL.LL\nLLLLLLL.LL\nL.L.L..L..\nLLLL.LL.LL\nL.LL.LL.LL\nL.LLLLL.LL\n..L.L.....\nLLLLLLLLLL\nL.LLLLLL.L\nL.LLLLL.LL".ParseSeatMap();

        private SeatMap _sample1Round1 = "#.##.##.##\n#######.##\n#.#.#..#..\n####.##.##\n#.##.##.##\n#.#####.##\n..#.#.....\n##########\n#.######.#\n#.#####.##".ParseSeatMap();

        private SeatMap _sample1Round2 =
             ("#.LL.L#.##" +
            "\n#LLLLLL.L#" +
            "\nL.L.L..L.." +
            "\n#LLL.LL.L#" +
            "\n#.LL.LL.LL" +
            "\n#.LLLL#.##" +
            "\n..L.L....." +
            "\n#LLLLLLLL#" +
            "\n#.LLLLLL.L" +
            "\n#.#LLLL.##").ParseSeatMap();

        private SeatMap _sample1Round3 = "#.##.L#.##\n#L###LL.L#\nL.#.#..#..\n#L##.##.L#\n#.##.LL.LL\n#.###L#.##\n..#.#.....\n#L######L#\n#.LL###L.L\n#.#L###.##".ParseSeatMap();

        private SeatMap _sample1Round4 = "#.#L.L#.##\n#LLL#LL.L#\nL.L.L..#..\n#LLL.##.L#\n#.LL.LL.LL\n#.LL#L#.##\n..L.L.....\n#L#LLLL#L#\n#.LLLLLL.L\n#.#L#L#.##".ParseSeatMap();

        private SeatMap _sample1Round5 = "#.#L.L#.##\n#LLL#LL.L#\nL.#.L..#..\n#L##.##.L#\n#.#L.LL.LL\n#.#L#L#.##\n..L.L.....\n#L#L##L#L#\n#.LLLLLL.L\n#.#L#L#.##\n".ParseSeatMap();


        private SeatMap _sample1Part2Round2 = "#.##.##.##\n#######.##\n#.#.#..#..\n####.##.##\n#.##.##.##\n#.#####.##\n..#.#.....\n##########\n#.######.#\n#.#####.##".ParseSeatMap();
        private SeatMap _sample1Part2Round3 = "#.LL.LL.L#\n#LLLLLL.LL\nL.L.L..L..\nLLLL.LL.LL\nL.LL.LL.LL\nL.LLLLL.LL\n..L.L.....\nLLLLLLLLL#\n#.LLLLLL.L\n#.LLLLL.L#".ParseSeatMap();
        private SeatMap _sample1Part2Round4 = "#.L#.##.L#\n#L#####.LL\nL.#.#..#..\n##L#.##.##\n#.##.#L.##\n#.#####.#L\n..#.#.....\nLLL####LL#\n#.L#####.L\n#.L####.L#".ParseSeatMap();
        private SeatMap _sample1Part2Round5 = "#.L#.L#.L#\n#LLLLLL.LL\nL.L.L..#..\n##LL.LL.L#\nL.LL.LL.L#\n#.LLLLL.LL\n..L.L.....\nLLLLLLLLL#\n#.LLLLL#.L\n#.L#LL#.L#".ParseSeatMap();
        private SeatMap _sample1Part2Round6 = "#.L#.L#.L#\n#LLLLLL.LL\nL.L.L..#..\n##L#.#L.L#\nL.L#.#L.L#\n#.L####.LL\n..#.#.....\nLLL###LLL#\n#.LLLLL#.L\n#.L#LL#.L#".ParseSeatMap();
        private SeatMap _sample1Part2Round7 = "#.L#.L#.L#\n#LLLLLL.LL\nL.L.L..#..\n##L#.#L.L#\nL.L#.LL.L#\n#.LLLL#.LL\n..#.L.....\nLLL###LLL#\n#.LLLLL#.L\n#.L#LL#.L#".ParseSeatMap();

        [Fact]
        public void Sample1()
        {
            _sample1.ApplyRules();
            _sample1.Map.Should().BeEquivalentTo(_sample1Round1.Map);
            _sample1.ApplyRules();
            _sample1.Map.Should().BeEquivalentTo(_sample1Round2.Map);
            _sample1.ApplyRules();
            _sample1.Map.Should().BeEquivalentTo(_sample1Round3.Map);
            _sample1.ApplyRules();
            _sample1.Map.Should().BeEquivalentTo(_sample1Round4.Map);
            _sample1.ApplyRules();
            _sample1.Map.Should().BeEquivalentTo(_sample1Round5.Map);
        }

        [Fact]
        public void Sample1Result()
        {
            _day.ExecutePart1(_sample1).Should().Be(37);
        }

        [Fact]
        public void Sample1Part2()
        {
            _sample1.ApplyRules2();
            _sample1.Map.Should().BeEquivalentTo(_sample1Part2Round2.Map);
            _sample1.ApplyRules2();
            _sample1.Map.Should().BeEquivalentTo(_sample1Part2Round3.Map);
            _sample1.ApplyRules2();
            _sample1.Map.Should().BeEquivalentTo(_sample1Part2Round4.Map);
            _sample1.ApplyRules2();
            _sample1.Map.Should().BeEquivalentTo(_sample1Part2Round5.Map);
            _sample1.ApplyRules2();
            _sample1.Map.Should().BeEquivalentTo(_sample1Part2Round6.Map);
            _sample1.ApplyRules2();
            _sample1.Map.Should().BeEquivalentTo(_sample1Part2Round7.Map);
            //_day.ExecutePart2(_sample1).Should().Be(0);
        }

        [Fact]
        public void Sample2Result()
        {
            _day.ExecutePart2(_sample1).Should().Be(26);
        }

        [Fact]
        public void TestEquals()
        {
            var map1 = "L.LL.LL.LL\nLLLLLLL.LL".ParseSeatMap();
            var map2 = "L.LL.LL.LL\nLLLLLLL.LL".ParseSeatMap();
            var map3 = "L.LL.LL.LL\nLLLLLLL.L#".ParseSeatMap();
            SeatMap.AreEqual(map1.Map, map2.Map).Should().Be(true);
            SeatMap.AreEqual(map1.Map, map3.Map).Should().Be(false);

        }


        [Fact]
        public void Sample1Test()
        {
            var map = "L.LL.LL.LL".ParseSeatMap();

            var c = SeatMap.EmptyRule(map.Map, 0, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 1, 0);
            c.Should().Be(SeatMap.Floor);
            c = SeatMap.EmptyRule(map.Map, 2, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 3, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 4, 0);
            c.Should().Be(SeatMap.Floor);
            c = SeatMap.EmptyRule(map.Map, 5, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 6, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 7, 0);
            c.Should().Be(SeatMap.Floor);
            c = SeatMap.EmptyRule(map.Map, 8, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 9, 0);
            c.Should().Be(SeatMap.Occupied);

            map.ApplyRules();
            map.Map.Should().BeEquivalentTo(new char[][] { new char[] { '#', '.', '#', '#', '.', '#', '#', '.', '#', '#' } });

        }

        [Fact]
        public void Sample2Test()
        {
            var map = "L.LL.LL.LL".ParseSeatMap();

            var c = SeatMap.EmptyRule(map.Map, 0, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 1, 0);
            c.Should().Be(SeatMap.Floor);
            c = SeatMap.EmptyRule(map.Map, 2, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 3, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 4, 0);
            c.Should().Be(SeatMap.Floor);
            c = SeatMap.EmptyRule(map.Map, 5, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 6, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 7, 0);
            c.Should().Be(SeatMap.Floor);
            c = SeatMap.EmptyRule(map.Map, 8, 0);
            c.Should().Be(SeatMap.Occupied);
            c = SeatMap.EmptyRule(map.Map, 9, 0);
            c.Should().Be(SeatMap.Occupied);

            map.ApplyRules();
            map.Map.Should().BeEquivalentTo(new char[][] { new char[] { '#', '.', '#', '#', '.', '#', '#', '.', '#', '#' } });

        }

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 2164;
            Assert.Equal(part1Solution, _day.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 1974;
            Assert.Equal(part2Solution, actual: _day.ExecutePart2());
        }
    }
}