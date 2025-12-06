namespace AoC2025;

public static class Day06 {
    public static void Part1(string path) {
        var lines = File.ReadAllLines(path);
        var grid = LinesToGrid(lines);
        var count = CalcColumns(grid);
        Console.WriteLine(count);
    }

    public static string[][] LinesToGrid(string[] lines) {
        return lines.Select(r => r.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public static long CalcColumns(string[][] grid) {
        long total = 0;
        for (var col = 0; col < grid[0].Length; ++col) total += CalcColumn(grid, col);

        return total;
    }

    public static long CalcColumn(string[][] grid, int column) {
        var operation = grid[^1][column];
        switch (operation) {
            case "+": {
                long total = 0;
                for (var row = 0; row < grid.Length - 1; ++row)
                    total += long.Parse(grid[row][column]);
                return total;
            }
            case "*": {
                long total = 1;
                for (var row = 0; row < grid.Length - 1; ++row)
                    total *= long.Parse(grid[row][column]);
                return total;
            }
            default:
                throw new ArgumentException($"Unknown operation: {operation}");
        }
    }
}