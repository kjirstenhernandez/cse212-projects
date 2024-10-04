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
        List<string> symmetricals = new List<string>();
        // string[] symmetricals = new string[(words.Length+1) / 2]; // creating a fixed array to hold the future matches (max space needed is if every word in teh array had a symmetrical match);
        HashSet<string> hash = new(words);
        
        foreach (string word in words) {
            if (word[1] != word[0]) {
                string checkWord = word[1].ToString() + word[0].ToString();
                if (hash.Contains(checkWord)) {
                    symmetricals.Add($"{word} & {checkWord}");
                    hash.Remove(word);
                }   
            }

        }
    
        return symmetricals.ToArray();
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
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string key = fields[3];
            if (degrees.ContainsKey(key)) {
                int value = degrees[key];
                degrees[key] = value +1; 
            } else {
                degrees.Add(key, 1); }
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
    ///


    public static bool IsAnagram(string word1, string word2)
    {
        // Building a dictionary with the first word
        Dictionary<char, int> firstWord = new Dictionary<char,int>();
        string comb1 = word1.ToUpper();  //eliminating need for case
        string result1 = comb1.Replace(" ", "");//combining words into one blob of letters
        foreach(char element in result1){
            if (!firstWord.ContainsKey(element)){ //checking to see if that character is already in teh dictionary
                firstWord[element] = 1;
            } else {
                int value = firstWord[element]; //if it is, increasing instances by 1
                firstWord[element] = value +1;
            }
        }

        // Building a dictionary with the second word
        Dictionary<char, int> secondWord = new Dictionary<char,int>();
        string comb2 = word2.ToUpper(); 
        string result2 = comb2.Replace(" ", ""); 
        foreach(char element in result2){
            if (!secondWord.ContainsKey(element)){
                secondWord[element] = 1;
            } else {
                int value = secondWord[element];
                secondWord[element] = value +1;
            }
        }
        
        if (secondWord.Count != firstWord.Count) {
            return false;
        }

        foreach(var item in firstWord) {
            if (!secondWord.ContainsKey(item.Key)){
                return false;
            } else {
                if (item.Value != secondWord[item.Key]){
                    return false;
                }
                
                } 
        }

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
        List<string> earthquakes = new List<string>();

        foreach (var feature in featureCollection.Features) {
            long time = feature.Properties.Time;
            float mag = feature.Properties.Mag;
            string place = feature.Properties.Place;

            string statement = $"{place}; {mag} - Mag ";
            earthquakes.Add(statement);
        }

        Console.WriteLine(earthquakes);

        return earthquakes.ToArray();
    }
}