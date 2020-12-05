using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day05Test
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void ParsePassport(string binaryPosition, int expectedRow, int expectedColumn, int expectedSeatId)
        {
            var boardingPass = new BoardingPass(binaryPosition);

            var position= boardingPass.GetSeatPosition();
            position.row.Should().Be(expectedRow);
            position.column.Should().Be(expectedColumn);
            boardingPass.GetSeatId().Should().Be(expectedSeatId);
        }

        [Fact]
        public void BinaryMovements()
        {
            BoardingPass.BinaryMovement((0, 127), false).Should().Be((0, 63));
            BoardingPass.BinaryMovement((0, 63), true).Should().Be((32, 63));
            BoardingPass.BinaryMovement((32, 63), false).Should().Be((32, 47));
            BoardingPass.BinaryMovement((32, 47), true).Should().Be((40, 47));
            BoardingPass.BinaryMovement((40, 47), true).Should().Be((44, 47));
            BoardingPass.BinaryMovement((44, 47), false).Should().Be((44, 45));
            BoardingPass.BinaryMovement((44, 45), false).Should().Be((44, 44));
        }



        [Fact]
        public void TestPart1()
        {
            int part1Solution = 947;
            var day5 = new Day05();
            Assert.Equal(part1Solution, day5.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 636;
            var day5 = new Day05();
            Assert.Equal(part2Solution, actual: day5.ExecutePart2());
        }
    }
}