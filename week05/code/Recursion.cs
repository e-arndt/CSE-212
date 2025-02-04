using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
    {
        
        return 0;
    }
    else
    {
        
        return (n * n) + SumSquaresRecursive(n - 1);
    }
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (size == 0)
        {
            results.Add(word);
            return;
        }

        else
        {
            for (int i = 0; i < letters.Length; i++)
            {
                string permLetters = letters.Substring(0, i) + letters.Substring(i + 1);
                PermutationsChoose(results, permLetters, size - 1, word + letters[i]);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // First call of this function checks parameter 'remember', if null, create a new Dictionary
        // Once created, the Dictionary is no longer null, but is an empty Dictionary.
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Check if the result is already in the dictionary.
        // If it is, rather than recalculate, just look up the stored value and return
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3

        // Solve using recursion
        // ways variable hold a count of all the different ways, summing each type of step (a single step, double or triple)
        // s (# of stair steps) - 1 (a single step), s (# of stair steps) - 2 (a double step), and so on.
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        // Save calculated ways to the Dictionary called remember
        remember[s] = ways;
        // return the total number of ways
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    // parameters pass in the pattern (ex. 100*11*0) and an empty 'results' list
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Get the index of the first * character found in the string
        int index = pattern.IndexOf('*');

        // If none are found in the string, then all * chars have been replaced or there where none at start
        if (index == -1)
        {
            // Either way, assume we have a valid binary pattern and save or Add the pattern to the 'results' list
            results.Add(pattern);
            // Return nothing / end
            return;
        }

        // if a * is found, replace it with a '0' at that index in the string called pattern and return the results list too
        WildcardBinary(ReplaceAtIndex(pattern, index, '0'), results);
        // if a * is found, replace it with a '1' at that index in the string called pattern and return the results list too
        WildcardBinary(ReplaceAtIndex(pattern, index, '1'), results);
    }

    // Use a separate function / method to handle the replacing as we need to convert to a character array
    // so we can pick and replace a single character
    // Pass in the pattern string via 'input', the index of the * char and the replacement character (either 0 or 1)
    private static string ReplaceAtIndex(string input, int index, char replacement)
    {
        // change 'input' string to a character array
        char[] chars = input.ToCharArray();
        // Change the * found at 'index' in the chars array to 'replacement' (1 or 0)
        chars[index] = replacement; // ex. '1' '0' '*' '1' '1' '*' '0' -> '1' '0' '0' '1' '1' '*' '0'
        // Convert back to a string and return the newly updated string ex ('10011*0')
        return new string(chars);
    }


    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        currPath.Add((x,y)); // Use this syntax to add to the current path

        // If the current position is at the endpoint, add the position to path results and return
        if (maze.IsEnd(x, y))
        {
            // This was crazy, apparently you have to 'escape' the 'defining' curly braces in order to
            // include 'literal' braces. So rather than <List>{string.Join it has to be <List>{{{string.Join
            results.Add($"<List>{{{string.Join(", ", currPath.Select(pos => $"({pos.Item1}, {pos.Item2})"))}}}");
            return;
        }

        // Define the possible directions to move: right, down, left, up
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        // Iterate through all four possible directions
        for (int i = 0; i < 4; i++)
        {
            // current x or y + a step in a new direction
            int newX = x + dx[i];
            int newY = y + dy[i];

            // Check if the new position is within the maze bounds and is also a valid path
            // Call the provided function called IsValidMove, pass the current path and the new direction we want to go
            // If the new path is not a wall, out of bounds or hasn't been previously visted, True is returned
            if (maze.IsValidMove(currPath, newX, newY))
            {
                // Recursive call of SolveMaze with new valid position
                SolveMaze(results, maze, newX, newY, new List<ValueTuple<int, int>>(currPath));
            }
        }
    }
}