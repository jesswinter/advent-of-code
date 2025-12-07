namespace AoC2025;

public static class Day06 {
    #region Part1

    public static void Part1(string path) {
        var lines = File.ReadAllLines(path);
        var grid = LinesToGrid(lines);
        var count = Part2_CalcColumns(grid);
        Console.WriteLine(count);
    }

    public static string[][] LinesToGrid(string[] lines) {
        return lines.Select(r => r.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public static long Part2_CalcColumns(string[][] grid) {
        long total = 0;
        for (var col = 0; col < grid[0].Length; ++col) total += Part1_CalcColumn(grid, col);

        return total;
    }

    public static long Part1_CalcColumn(string[][] grid, int column) {
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

    #endregion

    #region Part2

    public static void Part2(string path) {
        var lines = File.ReadAllLines(path);
        var columns = GetColumnDataFromOperatorRow(lines[^1]);
        
        var total = columns.Select(cd => Part2_CalcColumn(cd, lines)).Sum();
        Console.WriteLine(total);
    }

    public readonly struct ColumnData(int start, int width) {
        public readonly int Start = start;
        public readonly int Width = width;
    }

    public static List<ColumnData> GetColumnDataFromOperatorRow(string operatorRow) {
        List<ColumnData> widths = [];
        for (var colStart = 0; colStart < operatorRow.Length; ++colStart) {
            var width = 0;
            while (colStart + width < operatorRow.Length
                   && (colStart + width + 1 == operatorRow.Length || operatorRow[colStart + width + 1] == ' '))
                ++width;

            widths.Add(new ColumnData(colStart, width));
            colStart += width;
        }

        return widths;
    }

    public static long Part2_CalcColumn(ColumnData columnData, string[] lines) {
        var operation = lines[^1][columnData.Start];
        long total = operation switch {
            '*' => 1,
            '+' => 0,
            _ => throw new Exception($"Invalid operator {operation}"),
        };

        var nDigits = lines.Length - 1;

        for (var numberIndex = columnData.Start + columnData.Width - 1;
             numberIndex >= columnData.Start;
             --numberIndex) {
            long numberValue = 0;

            long placeValue = 1;
            for (var digitPlace = 1; digitPlace <= nDigits; ++digitPlace) {
                var digitChar = lines[nDigits - digitPlace][numberIndex];
                if (digitChar == ' ') continue;

                numberValue += placeValue * digitChar switch {
                    '0' => 0,
                    '1' => 1,
                    '2' => 2,
                    '3' => 3,
                    '4' => 4,
                    '5' => 5,
                    '6' => 6,
                    '7' => 7,
                    '8' => 8,
                    '9' => 9,
                    _ => throw new Exception($"Invalid digit: {digitChar}"),
                };

                placeValue *= 10;
            }

            if (operation == '*')
                total *= numberValue;
            else
                total += numberValue;
        }

        return total;
    }

    #endregion
}