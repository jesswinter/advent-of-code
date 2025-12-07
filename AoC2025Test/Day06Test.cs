using AoC2025;
using AwesomeAssertions;

namespace AoC2025Test;

public class Day06Test {
    readonly string[] _exampleLines = [
        "123 328  51 64 ",
        " 45 64  387 23 ",
        "  6 98  215 314",
        "*   +   *   +  ",
    ];

    [Fact]
    void CalcColumns_Example() {
        var grid = Day06.LinesToGrid(_exampleLines);

        var answer = Day06.Part2_CalcColumns(grid);

        Assert.Equal(4277556, answer);
    }

    [Fact]
    void CalcColumn_Example_Column0() {
        var grid = Day06.LinesToGrid(_exampleLines);

        var answer = Day06.Part1_CalcColumn(grid, 0);

        Assert.Equal(33210, answer);
    }

    [Fact]
    void GetColumnDataFromOperatorRow_Test() {
        var columnData = Day06.GetColumnDataFromOperatorRow(
            "*   +   *   +  ");
        columnData.Should().BeEquivalentTo([
            new Day06.ColumnData(0, 3),
            new Day06.ColumnData(4, 3),
            new Day06.ColumnData(8, 3),
            new Day06.ColumnData(12, 3),
        ]);
    }

    [Fact]
    void Part2_CalcColumn_Test() {
        var columnData = Day06.GetColumnDataFromOperatorRow(_exampleLines[^1]);

        var results = columnData.Select(cd => Day06.Part2_CalcColumn(cd, _exampleLines)).ToArray();
        results[0].Should().Be(8544);
        results[1].Should().Be(625);
        results[2].Should().Be(3253600);
        results[3].Should().Be(1058);
    }
}