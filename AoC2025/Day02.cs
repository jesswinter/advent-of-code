namespace AoC2025;

public static class Day02 {
    public static void Part1(string path) {
        var answer = File.ReadAllText(path).Split(',').Select(rangeStr => {
            long rangeSum = 0;
            var range = rangeStr.Split('-').Select(long.Parse).ToArray();
            for (var id = range[0]; id <= range[1]; ++id) {
                var idStr = id.ToString();
                var halfLength = idStr.Length / 2;
                if (idStr.Length % 2 == 0 && idStr[..halfLength] == idStr[halfLength..]) rangeSum += id;
            }

            return rangeSum;
        }).Sum();

        Console.WriteLine(answer);
    }

    public static void Part2(string path) {
        var answer = File.ReadAllText(path).Split(',').Select(rangeStr => {
            long rangeSum = 0;
            var range = rangeStr.Split('-').Select(long.Parse).ToArray();
            for (var id = range[0]; id <= range[1]; ++id)
                if (!IsValidId(id))
                    rangeSum += id;
            // Console.WriteLine(id);
            return rangeSum;
        }).Sum();

        Console.WriteLine(answer);

        bool IsValidId(long id) {
            var idStr = id.ToString();
            var halfLength = idStr.Length / 2;
            var nPatterns = 0;
            var nValidIds = 0;
            for (var i = 1; i <= halfLength; ++i) {
                nPatterns++;
                if (idStr.Length % i != 0) {
                    nValidIds++;
                    continue;
                }

                var pattern = idStr[..i];
                for (var patternIdx = 1; patternIdx < idStr.Length / pattern.Length; ++patternIdx) {
                    var idStrPatternStart = patternIdx * pattern.Length;
                    var idStrPatternEnd = idStrPatternStart + pattern.Length;
                    if (pattern != idStr[idStrPatternStart..idStrPatternEnd]) {
                        nValidIds++;
                        break;
                    }
                }
            }

            return nPatterns == nValidIds;
        }
    }
}