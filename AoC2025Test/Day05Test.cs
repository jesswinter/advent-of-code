using AoC2025;

namespace AoC2025Test;

public class Day05Test {
    [Fact]
    void CountFresh_Test() {
        string[] db = [
            "3-5",
            "10-14",
            "16-20",
            "12-18",
            "",
            "1",
            "5",
            "8",
            "11",
            "17",
            "32",
        ];

        var count = Day05.CountFresh(db);

        Assert.Equal(3, count);
    }

    [Fact]
    void CountPossibleFresh_Example() {
        string[] db = [
            "3-5",
            "10-14",
            "16-20",
            "12-18",
            "",
            "1",
            "5",
            "8",
            "11",
            "17",
            "32",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(14, count);
    }

    [Fact]
    void CountPossibleFresh_Example2() {
        string[] db = [
            "1-2",
            "2-3",
            "4-5",
            "1-3",
            "",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(5, count);
    }


    [Fact]
    void CountPossibleFresh_OneEntry() {
        string[] db = [
            "3-5",
            "",
            "1",
            "32",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(3, count);
    }

    [Fact]
    void CountPossibleFresh_TwoEntries() {
        string[] db = [
            "3-5",
            "10-14",
            "",
            "1",
            "32",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(8, count);
    }

    [Fact]
    void CountPossibleFresh_TwoEntriesReverse() {
        string[] db = [
            "10-14",
            "3-5",
            "",
            "1",
            "32",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(8, count);
    }

    [Fact]
    void CountPossibleFresh_LeftOverlap() {
        string[] db = [
            "3-5",
            "2-4",
            "",
            "1",
            "32",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(4, count);
    }


    [Fact]
    void CountPossibleFresh_RightOverlap() {
        string[] db = [
            "3-5",
            "4-8",
            "",
            "1",
            "32",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(6, count);
    }

    [Fact]
    void CountPossibleFresh_Wrapped() {
        string[] db = [
            "3-5",
            "2-6",
            "",
            "1",
            "32",
        ];

        var count = Day05.CountPossibleFresh(db);

        Assert.Equal(5, count);
    }
}