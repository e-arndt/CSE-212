using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // Create a HashSet of the parameter words to ensure no duplicates and fast lookups.
        HashSet<string> wordSet = new HashSet<string>(words);
        // Create a list to store the matching pairs
        List<string> wordPairs = new List<string>();

        // interate through all words being passed in via the words parameter
        foreach (string word in words)
        {
            // take the second letter of each two letter word, then take the first letter and store in reverseWord
            string reverseWord = $"{word[1]}{word[0]}";

            // if the original word and reverse word are the same (aa or dd, ect.) then disregard.
            if (word == reverseWord) continue;

            // If the HashSet wordSet contains the reverse of the original word then we have a pair
            if (wordSet.Contains(reverseWord))
            {
                // Add that pair to the wordPairs list
                wordPairs.Add($"{word} & {reverseWord}");

                // We are done with that pair and don't want to reconcider the word or reverse of the word
                // again, so we remove them from the original list of words.
                wordSet.Remove(word);
                wordSet.Remove(reverseWord);
            }
        }

        // Once the process is complete, we convert the completed list to a fixed array and return the found pairs.
        return wordPairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // Dictionary to hold the education catagories as keys and the count of people with that degree as the value.
        // HashSet that holds the degrees that are discovered in the datafile.
        var degrees = new Dictionary<string, int>();
        var degreeFound = new HashSet<string>();
        
        // Iterate through each line in the file
        foreach (var line in File.ReadLines(filename))
        {
            // Assign each line, split at the "," to the variable called fields
            var fields = line.Split(",");
            // Assign to variable education, the contents(degree) of the 4th column aka index 3
            var education = fields[3];  // TODO Problem 2 - ADD YOUR CODE HERE
            // Set the degree counter to 1
            int edCount = 1;
        
            // If the HashSet already has that degree...
            if (degreeFound.Contains(education))
            {
                // Update that particular degree in the dictionary by adding 1 to the current count.
                degrees[education] += edCount;
            }

            else
            {
                // Else if not found in the list of discovered degrees, add this new one to the HashSet
                // and make sure to set the count value in the dictionary to 1.
                degreeFound.Add(education);
                degrees[education] = edCount;
            }

        }

        // var topEdu = degrees.OrderByDescending(p => p.Value).Take(10).ToArray();

        // Console.WriteLine("Top 10 Education:");
        // foreach (var degree in topEdu)
        // {
        //     Console.WriteLine($"Degree: {degree.Key} Count: {degree.Value:N0}");
        // }

        // Once completed, return the Key / Value pairs (Degree Name / Count)
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        
        // Remove spaces and convert both strings to lowercase
        var firstWord  = word1.Replace(" ", "").ToLower();
        var secondWord = word2.Replace(" ", "").ToLower();

        // It's not an Anagram if the letter count is different
        if (firstWord.Length != secondWord.Length)
        {
            return false;
        }

        // Using a fixed length array, just large enough for all ascii chars
        var countLetters = new int[256];

        // Iterate every letter of the fisrtWord aka word1
        foreach (var letter in firstWord)
        {
            // this sets the ascii integer value of a letter as the [index] and adds 1 to the value stored there
            // ex. index of [a] = [97] ++ adds 1 at that index, so index [97] = 1
            countLetters[letter]++;
        }

        // Iterate every letter of the secondWord aka word2
        foreach (var letter in secondWord)
        {
            // while iterating the second word, if a letter is found with a value of 0
            // that means the current letter in the second word has not been seen before
            // therefore this can't be an Anagram.
            if (countLetters[letter] == 0)
            {
                return false;
            }

            // Else the letter has been seen at least once before in firstWord(word1)
            // Therefore subtract the count at the index for that letter, which should be the same
            // ascii index number for the same letter.
            else
            {
                countLetters[letter]--;
            }
            
        }

        // If we got this far then the same letters in the exact same quantity must exist in both words. Return True.
        return true;
    }


    //     First attempt, all good except efficiency was at 9 seconds
    //     My computer is 11 years old and very slow so..... this code might be OK?
    //     Trying to find a faster method........
    //     var firstWord  = word1.Replace(" ", "").ToLower();
    //     var secondWord = word2.Replace(" ", "").ToLower();

    //     if (firstWord.Length != secondWord.Length)
    //     {
    //         return false;
    //     }

    //     var countLetters = new Dictionary<char, int>();

    //     foreach (var letter in firstWord)
    //     {
    //         if (countLetters.ContainsKey(letter))
    //         {
    //             countLetters[letter]++;
    //         }

    //         else
    //         {
    //             countLetters[letter] = 1;
    //         }

    //     }

    //     foreach (var letter in secondWord)
    //     {
    //         if (!countLetters.ContainsKey(letter))
    //         {
    //             return false;
    //         }

    //         countLetters[letter]--;
    //         if (countLetters[letter] == 0)
    //         {
    //             countLetters.Remove(letter);
    //         }


    //     }

    //     return countLetters.Count == 0;
    // }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}