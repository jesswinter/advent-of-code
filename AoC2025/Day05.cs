namespace AoC2025;

public static class Day05 {
    /// <summary>
    /// An open range of IDs
    /// </summary>
    /// <param name="min">Inclusive minimum value</param>
    /// <param name="max">Inclusive maximum value</param>
    readonly struct IdRange(long min, long max) {
        public readonly long Min = min;
        public readonly long Max = max;

        public bool Contains(long id) {
            return id >= Min && id <= Max;
        }

        public long Sum() {
            return Max - Min + 1;
        }
    }

    public static void Part1(string path) {
        var db = File.ReadAllLines(path);
        var count = CountFresh(db);
        Console.WriteLine(count);
    }

    public static int CountFresh(string[] db) {
        List<IdRange> ranges = [];

        var i = 0;
        for (; db[i].Length != 0; ++i) {
            var minMaxStrs = db[i].Split('-');
            ranges.Add(new IdRange(long.Parse(minMaxStrs[0]), long.Parse(minMaxStrs[1])));
        }

        ++i; // skip blank line

        var nFresh = 0;
        for (; i < db.Length; ++i) {
            var id = long.Parse(db[i]);
            if (ranges.Any(r => r.Contains(id))) ++nFresh;
        }

        return nFresh;
    }

    public static void Part2(string path) {
        var db = File.ReadAllLines(path);
        var count = CountPossibleFresh(db);
        Console.WriteLine(count);
    }

    public static long CountPossibleFresh(string[] db) {
        List<IdRange> ranges = [];

        for (var i = 0; db[i].Length != 0; ++i) {
            var minMaxStrs = db[i].Split('-');
            var min = long.Parse(minMaxStrs[0]);
            var max = long.Parse(minMaxStrs[1]);

            ranges.Add(new IdRange(min, max));
        }

        ranges.Sort((left, right) => {
            var comp = left.Min - right.Min;
            return comp switch {
                0 => 0,
                > 0 => 1,
                < 0 => -1,
            };
        });

        for (var i = 0; i < ranges.Count - 1;)
            if (ranges[i + 1].Min <= ranges[i].Max) {
                ranges[i] = new IdRange(
                    ranges[i].Min,
                    Math.Max(ranges[i].Max, ranges[i + 1].Max)
                );
                ranges.RemoveAt(i + 1);
            } else {
                ++i;
            }

        return ranges.Sum(r => r.Sum());
    }
}