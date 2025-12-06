using AoC2025;

namespace AoC2025Test;

public class Day06Test {
    readonly string[] _exampleLines = [
        "123 328  51 64",
        "45 64  387 23",
        "6 98  215 314",
        "*   +   *   +",
    ];

    [Fact]
    void CalcColumns_Example() {
        var grid = Day06.LinesToGrid(_exampleLines);

        var answer = Day06.CalcColumns(grid);

        Assert.Equal(4277556, answer);
    }

    [Fact]
    void CalcColumn_Example_Column0() {
        var grid = Day06.LinesToGrid(_exampleLines);

        var answer = Day06.CalcColumn(grid, 0);

        Assert.Equal(33210, answer);
    }
}