namespace AoC2025;

public static class Day01 {
    public static void Part1(string path) {
        var rotations = File.ReadAllLines(path).Select(line =>
            int.Parse(line[1..]) * (line[0] == 'L' ? -1 : 1)
        );

        var count = 0;
        var dial = 50;
        foreach (var rotation in rotations) {
            dial = (dial + rotation) % 100;
            if (dial == 0) count++;
        }

        Console.WriteLine($"count={count}");
    }

    public static void Part2(string path) {
        var rotations = File.ReadAllLines(path).Select(line =>
            int.Parse(line[1..]) * (line[0] == 'L' ? -1 : 1)
        );

        var count = 0;
        var dial = 50;
        foreach (var rotation in rotations) {
            var r = rotation;
            while (r != 0)
                switch (r) {
                    case >= 100:
                        ++count;
                        r -= 100;
                        break;

                    case <= -100:
                        ++count;
                        r += 100;
                        break;

                    case > 0: {
                        dial += r;
                        if (dial >= 100) {
                            dial -= 100;
                            ++count;
                        }

                        r = 0;
                        break;
                    }

                    default: {
                        // r < 0
                        if (dial == 0) {
                            dial += r + 100;
                        } else {
                            dial += r;
                            if (dial == 0) {
                                ++count;
                            } else if (dial < 0) {
                                ++count;
                                dial += 100;
                            }
                        }

                        r = 0;
                        break;
                    }
                }
        }

        Console.WriteLine($"count={count}");
    }
}