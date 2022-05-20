using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicProblems;

namespace LogicProblemTest;
/* TODO: list
[x] one test for average
[x] all test for average
[x] way to run just one test?
[] the rest of the test for all things

*/

[TestClass]
public class UnitTest1
{
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