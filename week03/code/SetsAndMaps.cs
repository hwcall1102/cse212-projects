using System.Diagnostics;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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
        // create an emptly hashset, run foreach loop for each x in words reverse() entry, hashset.contains reversed
        // if so note pair together, if not add x to hashset

        var pairsSet = new HashSet<string>();
        var actual = new List<string>();
        foreach (var word in words)
        {
            var reverseWord = string.Concat(word.Reverse());
            if (pairsSet.Contains(reverseWord))
            {
                var result = ($"{word} & {reverseWord}");
                actual.Add(result);
            }
            pairsSet.Add(word);
            
        }

        return actual.ToArray();
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
        // locate degree at index 3,column 4, if degree is found in dictionary add 1 to key value, if not add key with value of 1
        

        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            var degree = fields[3];
            if (degrees.ContainsKey(degree))
                degrees[degree] += 1;
            else
                degrees[degree] = 1;
        }

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
        // compare the frequency characters occured within both words, if equal they are anagrams
        
        // Create a dictionary to store character frequencies
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        
        var lowerWord1 = word1.ToLower();
        var lowerWord2 = word2.ToLower();
        var cleanWord1 = lowerWord1.Replace(" ","");
        var cleanWord2 = lowerWord2.Replace(" ", "");

        
        // Count frequency of each character in string s1
        foreach (char ch in cleanWord1) 
            charCount[ch] = charCount.GetValueOrDefault(ch, 0) + 1;

        // Count frequency of each character in string s2
        foreach (char ch in cleanWord2) 
            charCount[ch] = charCount.GetValueOrDefault(ch, 0) - 1;

        // Check if all frequencies are zero
        foreach (var pair in charCount) {
            if (pair.Value != 0) 
                return false;
        }
        
        // If all conditions satisfied, they are anagrams
        return true;
    }

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