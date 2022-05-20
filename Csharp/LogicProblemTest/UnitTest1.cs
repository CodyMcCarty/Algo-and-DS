using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicProblems;
using System.Diagnostics;

namespace LogicProblemTest;

[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void DistinctLadderPaths_3()
    {
        int rungs = 3;
        int expected = 3;
        var actual = LogicProblem.DistinctLadderPaths(rungs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DistinctLadderPaths_10()
    {
        int rungs = 10;
        int expected = 89;
        var actual = LogicProblem.DistinctLadderPaths(rungs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DistinctLadderPaths_25()
    {
        int rungs = 25;
        int expected = 121393;
        var actual = LogicProblem.DistinctLadderPaths(rungs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DistinctLadderPaths_100()
    {
        int rungs = 100;
        decimal expected = 573147844013817084101m;
        var actual = LogicProblem.DistinctLadderPaths(rungs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DistinctLadderPaths_100_under5Secs()
    {
        int rungs = 100;
        decimal expected = 573147844013817084101m;
        var timer = new Stopwatch();
        var lowExpected = TimeSpan.FromSeconds(0);
        var highExpected = TimeSpan.FromSeconds(5);

        timer.Start();
        var actual = LogicProblem.DistinctLadderPaths(rungs);
        timer.Stop();

        Assert.AreEqual(expected, actual);
        Assert.IsTrue(timer.Elapsed < highExpected);
    }

    [TestMethod]
    public void DistinctLadderPaths_0()
    {
        int rungs = 0;
        decimal expected = 0;
        var actual = LogicProblem.DistinctLadderPaths(rungs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DistinctLadderPaths_1()
    {
        int rungs = 1;
        decimal expected = 1;
        var actual = LogicProblem.DistinctLadderPaths(rungs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DistinctLadderPaths_Negative()
    {
        int rungs = -1;
        var expected = "ladders can't have negative rungs";
        var actual = Assert.ThrowsException<InvalidOperationException>(() => LogicProblem.DistinctLadderPaths(rungs));
        Assert.AreEqual(expected, actual.Message);
    }


    [TestMethod]
    public void GroupStrings()
    {
        string[] strs = { "arrange", "act", "assert", "ace" };
        var expected = new List<List<string>>()
            {
                new List<string>() { "arrange", "ace" }, new List<string>() { "act", "assert" }
            };
        var actual = LogicProblem.GroupStrings(strs);
        CollectionAssert.AreEqual(expected[0], actual[0]);
        CollectionAssert.AreEqual(expected[1], actual[1]);
        // Note: MSTest can't assert on list of list yet, check https://github.com/microsoft/testfx/issues/711.  
        // FIXME: use another testing platform FluentAssertions, xunit
    }

    [TestMethod]
    public void GroupStrings_2()
    {
        string[] strs =
        {
                "How", "can", "Agenda", "a", "clam", "aeon", "cram", "in", "a",
                "clean", "cream", "can", "atom"
            };
        var expected = new List<List<string>>()
            {
                new List<string>() { "How" },
                new List<string>() { "can", "clean", "can" },
                new List<string>() { "Agenda" },
                new List<string>() { "a", "a" },
                new List<string>() { "clam", "cram", "cream" },
                new List<string>() { "aeon" },
                new List<string>() { "in" },
                new List<string>() { "atom" },
            };
        var actual = LogicProblem.GroupStrings(strs);
        CollectionAssert.AreEqual(expected[0], actual[0]);
        CollectionAssert.AreEqual(expected[1], actual[1]);
    }

    [TestMethod]
    public void GroupStrings_EmptyArray()
    {
        string[] strs = { };
        var expected = new List<List<string>>();
        var actual = LogicProblem.GroupStrings(strs);
        Assert.AreEqual(expected.Count, actual.Count);

    }

    [TestMethod]
    public void GroupStrings_EmptyString_Empty()
    {
        string[] strs = { "arrange", "", "assert", "ace" };
        var expected = "strings must not be empty";
        var actual = Assert.ThrowsException<InvalidOperationException>(() => LogicProblem.GroupStrings(strs));
        Assert.AreEqual(expected, actual.Message);
    }

    [TestMethod]
    public void GroupStrings_EmptyString_WhiteSpace()
    {
        string[] strs = { "arrange", " ", "assert", "ace" };
        var expected = "strings must not be empty";
        var actual = Assert.ThrowsException<InvalidOperationException>(() => LogicProblem.GroupStrings(strs));
        Assert.AreEqual(expected, actual.Message);
    }

    [TestMethod]
    public void GroupStrings_EmptyString_WhiteSpace2()
    {
        string[] strs = { "arrange", "  ", "assert", "ace" };
        var expected = "strings must not be empty";
        var actual = Assert.ThrowsException<InvalidOperationException>(() => LogicProblem.GroupStrings(strs));
        Assert.AreEqual(expected, actual.Message);
    }

    [TestMethod]
    public void GroupStrings_EmptyString_Tab()
    {
        string[] strs = { "arrange", "\t", "assert", "ace" };
        var expected = "strings must not be empty";
        var actual = Assert.ThrowsException<InvalidOperationException>(() => LogicProblem.GroupStrings(strs));
        Assert.AreEqual(expected, actual.Message);
    }



    [TestMethod]
    public void LastWordLength()
    {
        string text = "test this string";
        int expected = 6;
        int actual = LogicProblem.LastWordLength(text);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastWordLength_WhiteSpace()
    {
        string text = " ";
        int expected = 0;
        int actual = LogicProblem.LastWordLength(text);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastWordLength_Tab()
    {
        string text = "\t";
        int expected = 0;
        int actual = LogicProblem.LastWordLength(text);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastWordLength_Empty()
    {
        string text = "";
        var expected = "input must not be an empty string";
        var actual = Assert.ThrowsException<InvalidOperationException>(() => LogicProblem.LastWordLength(text));
        Assert.AreEqual(expected, actual.Message);
    }


    [TestMethod]
    public void TestAverage()
    {
        int[] scores = { 1, 4, 2 };
        double expected = 2.33;
        double actual = LogicProblem.Average(scores);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestAverage_2Decimal()
    {
        int[] scores = { 1, 4, 2 };
        double expected = 2.333;
        double actual = LogicProblem.Average(scores);
        Assert.AreNotEqual(expected, actual);

    }

    [TestMethod]
    public void TestAverage_SingleInt()
    {
        int[] scores = { 10 };
        double expected = 10.00;
        double actual = LogicProblem.Average(scores);
        Assert.AreEqual(expected, actual);

    }

    [TestMethod]
    public void TestAverage_emptyArray()
    {
        int[] scores = { };
        double expected = 0.00;
        double actual = LogicProblem.Average(scores);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestAverage_Negative()
    {
        int[] scores = { 1, -4, 2 };
        var expected = "scores must be positive";
        var actual = Assert.ThrowsException<InvalidOperationException>(() => LogicProblem.Average(scores));
        Assert.AreEqual(expected, actual.Message);
    }


    [TestMethod]
    public void TestStartsWithUpper()
    {
        // Tests that we expect to return true.
        string[] words = { "Alphabet", "Zebra", "ABC", "Αθήνα", "Москва" };
        foreach (var word in words)
        {
            bool result = word.StartsWithUpper();
            Assert.IsTrue(result,
                   string.Format("Expected for '{0}': true; Actual: {1}",
                                 word, result));
        }
    }

    [TestMethod]
    public void TestDoesNotStartWithUpper()
    {
        // Tests that we expect to return false.
        string[] words = { "alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                               "1234", ".", ";", " " };
        foreach (var word in words)
        {
            bool result = word.StartsWithUpper();
            Assert.IsFalse(result,
                   string.Format("Expected for '{0}': false; Actual: {1}",
                                 word, result));
        }
    }

    [TestMethod]
    public void DirectCallWithNullOrEmpty()
    {
        // Tests that we expect to return false.
        string?[] words = { string.Empty, null };
        foreach (var word in words)
        {
            bool result = LogicProblem.StartsWithUpper(word);
            Assert.IsFalse(result,
                   string.Format("Expected for '{0}': false; Actual: {1}",
                                 word == null ? "<null>" : word, result));
        }
    }
}