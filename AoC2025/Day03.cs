namespace AoC2025;

public static class Day03 {
    /// <summary>
    /// Each character in the input represents a battery, and it's joltage rating (a value 1-9).
    /// Batteries are grouped into banks. Each line in the input represents a bank.
    ///
    /// - Pick exactly 2 batteries in each bank to maximize the joltage of the bank.
    /// - Joltage of a bank is the number formed by the digits of the selected batteries.
    ///
    /// Print the sum of the joltages of all the banks.
    /// </summary>
    /// <param name="path"></param>
    public static void Part1(string path) {
        var banks = File.ReadAllLines(path);

        var totalJoltage = 0;
        foreach (var bank in banks) {
            var (firstIndex, firstValue) = FindMaxInRange(bank, 0, bank.Length - 1);
            var (_, secondValue) = FindMaxInRange(bank, firstIndex + 1, bank.Length);
            totalJoltage += int.Parse($"{firstValue}{secondValue}");
        }

        Console.WriteLine($"Total joltage: {totalJoltage}");
    }

    /// <summary>
    /// Same as part 1 except you turn on 12 batteries per bank.
    /// </summary>
    /// <param name="path"></param>
    public static void Part2(string path) {
        var banks = File.ReadAllLines(path);

        ulong totalJoltage = 0;
        foreach (var bank in banks) {
            var picks = new char[12];
            var leftMostPick = -1;
            for (var pickIdx = 0; pickIdx < picks.Length; ++pickIdx) {
                var (foundIndex, foundValue) = FindMaxInRange(
                    bank,
                    leftMostPick + 1,
                    bank.Length - (picks.Length - pickIdx)+1);
                picks[pickIdx] = foundValue;
                leftMostPick = foundIndex;
            }

            var joltage = ulong.Parse(new string(picks));
            totalJoltage += joltage;
        }

        Console.WriteLine($"Total joltage: {totalJoltage}");
    }

    /// <summary>
    /// Find the max character value and it's index inbetween start (inclusive) and end (exclusive).
    /// </summary>
    static (int, char) FindMaxInRange(string bank, int start, int end) {
        var selectedIndex = start;
        var selectedValue = bank[start];

        for (var i = start + 1; i < end; ++i) {
            if (bank[i] <= selectedValue) continue;
            selectedIndex = i;
            selectedValue = bank[i];
        }

        return (selectedIndex, selectedValue);
    }
}