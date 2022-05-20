namespace LogicProblems;

/* TODO: list
[x] average logic
[x] all test for average
[x] the rest of impl
[] impls https://gitlab.ce.catalyte.io/training/cycleworkinggroups/nationwide/associates/cody-mccarty/catalyte-cycle/intermediate-csharp/csharp-intermediate-project/-/blob/main/LogicProblems/LogicProblem.cs  
[] test https://gitlab.ce.catalyte.io/training/cycleworkinggroups/nationwide/associates/cody-mccarty/catalyte-cycle/intermediate-csharp/csharp-intermediate-project/-/blob/main/LogicProblems.Tests/LogicProblemTest.cs  

*/

public static class LogicProblem
{

    /// <summary>
    /// the number of distinct paths to reach the top of the ladder is returned.
    /// e.g. (3) → 3: 
    /// 1. 1 step + 1 step + 1 step 
    /// 2. 1 step + 2 steps 
    /// 3. 2 steps + 1 step
    /// </summary>
    /// <param name="rungs">number of ladder rungs</param>
    /// <returns>number of ways to reach the top</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static decimal DistinctLadderPaths(int rungs)
    {
        if (rungs == 0) return 0;
        if (rungs < 0) throw new InvalidOperationException("ladders can't have negative rungs");

        decimal[] values = new decimal[rungs + 1];
        for (int i = 0; i <= rungs; i++)
        {
            values[i] = (i <= 1) ? 1 : values[i - 1] + values[i - 2];
        }
        return values[rungs];
    }

    /// <summary>
    /// the length of the last word in the string is returned
    /// e.g. "test this string" => 6
    /// </summary>
    /// <param name="text">the string</param>
    /// <returns>the length of the last word</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static int LastWordLength(string text)
    {
        if (text.Length == 0) throw new InvalidOperationException("input must not be an empty string");
        string[] subs = text.Split(' ', '\t', '\n', '\r', '\v');
        var re = subs[subs.Length - 1].Length;
        return re;
    }


    /// <summary>
    /// returns a List of Lists that each contain properly grouped strings. 
    /// All strings within a grouping must share the same first letters and the same last letters.
    /// e.g. ["arrange", "act", "assert", "ace"] → [ ["arrange", "ace"], ["act", "assert"]] 
    /// The first grouping contains strings starting with "a" and ending with "e". 
    /// The second grouping contains strings starting with "a" and ending with "t".
    /// </summary>
    /// <param name="strs">the array of strings to be re-grouped</param>
    /// <returns>a regrouped list of list</returns> 
    public static List<List<string>> GroupStrings(string[] strs)
    {
        return GroupStrings(strs, new List<List<string>>());
    }

    /// <summary>
    /// Overload method.  
    /// returns a List of Lists that each contain properly grouped strings. 
    /// All strings within a grouping must share the same first letters and the same last letters.
    /// e.g. ["arrange", "act", "assert", "ace"] → [ ["arrange", "ace"], ["act", "assert"]] 
    /// The first grouping contains strings starting with "a" and ending with "e". 
    /// The second grouping contains strings starting with "a" and ending with "t".
    /// </summary>
    /// <param name="strs">the array of strings to be re-grouped</param>
    /// <param name="groups"> the list of list to be returned</param>
    /// <returns>a regrouped list of list</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static List<List<string>> GroupStrings(string[] strs, List<List<string>> groups)
    {
        if (strs.Length == 0) return groups;
        var firstWord = strs[0];
        var firstLetter = firstWord[0];
        var lastLetter = firstWord[firstWord.Length - 1];
        strs = strs.Skip(1).ToArray();
        var group = new List<string>();
        group.Add(firstWord);
        foreach (var str in strs)
        {
            if (String.IsNullOrWhiteSpace(str)) throw new InvalidOperationException("strings must not be empty");
            if (str[0] == firstLetter && str[str.Length - 1] == lastLetter)
            {
                group.Add(str);
                strs = strs.Where((val) => val != str).ToArray();
            }
        }
        groups.Add(group);
        return GroupStrings(strs, groups);
    }


    /// <summary>
    /// This function will be used for calculating averages of assessment scores
    /// e.g. [1,4,2] => 2.33
    /// </summary>
    /// <param name="scores">An array of ints to average</param>
    /// <returns>the average of the array</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double Average(int[] scores)
    {
        if (scores.Length == 0) return 0.00;
        double sum = 0;
        foreach (var score in scores)
        {
            if (score < 0) throw new InvalidOperationException("scores must be positive");
            sum += score;
        }
        return Math.Round(sum / scores.Length, 2);
    }



    public static bool StartsWithUpper(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;

        char ch = str[0];
        return char.IsUpper(ch);
    }
}
