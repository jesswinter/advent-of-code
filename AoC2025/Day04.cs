namespace AoC2025;

public static class Day04 {
    public static void Part1(string path) {
        var grid = File.ReadAllLines(path);
        var nAccessible = CountAccessibleRolls(grid);
        Console.WriteLine($"nAccessible: {nAccessible}");
    }

    public static void Part2(string path) {
        var grid = File.ReadAllLines(path);
        var nAccessible = CountAccessibleRollsWithRemove(grid);
        Console.WriteLine($"nAccessible: {nAccessible}");
    }

    public static int CountAccessibleRolls(string[] grid) {
        var nAccessible = 0;

        for (var y = 0; y < grid.Length; y++)
        for (var x = 0; x < grid[y].Length; x++)
            if (grid[y][x] == '@' && IsAccessible(grid, x, y))
                ++nAccessible;

        return nAccessible;
    }

    public static int CountAccessibleRollsWithRemove(string[] grid) {
        var charGrid = grid.Select(row => row.ToCharArray()).ToArray();

        var nRemoved = 0;
        bool wereAnyAccessible;
        do {
            wereAnyAccessible = false;

            for (var y = 0; y < grid.Length; y++)
            for (var x = 0; x < grid[y].Length; x++)
                if (charGrid[y][x] == '@' && IsAccessible(charGrid, x, y)) {
                    charGrid[y][x] = '.';
                    ++nRemoved;
                    wereAnyAccessible = true;
                }
        } while (wereAnyAccessible);

        return nRemoved;
    }

    public static bool IsAccessible(string[] grid, int x, int y) {
        var nAdjacent = 0;

        var isLeftEdge = x - 1 < 0;
        var isRightEdge = x + 1 >= grid[y].Length;

        if (y + 1 < grid.Length) {
            nAdjacent += grid[y + 1][x] == '@' ? 1 : 0;

            if (!isLeftEdge)
                nAdjacent += grid[y + 1][x - 1] == '@' ? 1 : 0;

            if (!isRightEdge)
                nAdjacent += grid[y + 1][x + 1] == '@' ? 1 : 0;
        }

        if (y - 1 >= 0) {
            nAdjacent += grid[y - 1][x] == '@' ? 1 : 0;

            if (!isLeftEdge)
                nAdjacent += grid[y - 1][x - 1] == '@' ? 1 : 0;

            if (!isRightEdge)
                nAdjacent += grid[y - 1][x + 1] == '@' ? 1 : 0;
        }

        if (!isLeftEdge)
            nAdjacent += grid[y][x - 1] == '@' ? 1 : 0;

        if (!isRightEdge)
            nAdjacent += grid[y][x + 1] == '@' ? 1 : 0;

        return nAdjacent < 4;
    }

    public static bool IsAccessible(char[][] grid, int x, int y) {
        var nAdjacent = 0;

        var isLeftEdge = x - 1 < 0;
        var isRightEdge = x + 1 >= grid[y].Length;

        if (y + 1 < grid.Length) {
            nAdjacent += grid[y + 1][x] == '@' ? 1 : 0;

            if (!isLeftEdge)
                nAdjacent += grid[y + 1][x - 1] == '@' ? 1 : 0;

            if (!isRightEdge)
                nAdjacent += grid[y + 1][x + 1] == '@' ? 1 : 0;
        }

        if (y - 1 >= 0) {
            nAdjacent += grid[y - 1][x] == '@' ? 1 : 0;

            if (!isLeftEdge)
                nAdjacent += grid[y - 1][x - 1] == '@' ? 1 : 0;

            if (!isRightEdge)
                nAdjacent += grid[y - 1][x + 1] == '@' ? 1 : 0;
        }

        if (!isLeftEdge)
            nAdjacent += grid[y][x - 1] == '@' ? 1 : 0;

        if (!isRightEdge)
            nAdjacent += grid[y][x + 1] == '@' ? 1 : 0;

        return nAdjacent < 4;
    }
}