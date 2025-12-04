using AoC2025;

namespace AoC2025Test;

public class Day04Test {
    readonly string[] _grid = [
        "..@@.@@@@.",
        "@@@.@.@.@@",
        "@@@@@.@.@@",
        "@.@@@@..@.",
        "@@.@@@@.@@",
        ".@@@@@@@.@",
        ".@.@.@.@@@",
        "@.@@@.@@@@",
        ".@@@@@@@@.",
        "@.@.@@@.@.",
    ];

    readonly string[] _gridAnswers = [
        "..xx.xx@x.",
        "x@@.@.@.@@",
        "@@@@@.x.@@",
        "@.@@@@..@.",
        "x@.@@@@.@x",
        ".@@@@@@@.@",
        ".@.@.@.@@@",
        "x.@@@.@@@@",
        ".@@@@@@@@.",
        "x.x.@@@.x.",
    ];

    [Fact]
    public void CountAccessibleRolls_Test() {
        var count = Day04.CountAccessibleRolls(_grid);

        Assert.Equal(13, count);
    }
    
    [Fact]
    public void CountAccessibleRollsWithRemove_Test() {
        var count = Day04.CountAccessibleRollsWithRemove(_grid);

        Assert.Equal(43, count);
    }

    [Fact]
    public void IsAccessible_Test() {
        for (var y = 0; y < _grid.Length; y++)
        for (var x = 0; x < _grid[y].Length; x++) {
            if (_grid[y][x] != '@')
                continue;

            var isAccessible = Day04.IsAccessible(_grid, x, y);
            var isAccessibleExpected = _gridAnswers[y][x] == 'x';
            Assert.True(isAccessible == isAccessibleExpected);
        }
    }
}