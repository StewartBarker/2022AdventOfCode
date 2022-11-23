// See https://aka.ms/new-console-template for more information

Console.WriteLine("Kata 2022/11/23");

var testString1 = "ugknbfddgicrmpon";
var testString2 = "aaa";
var testString3 = "jchzalrnumimnmhp";
var testString4 = "haegwjzuvuuyypxyu";
var testString5 = "dvszwmarrgswjxmb";

Console.WriteLine(IsStringNiceOrNasty(testString1));
Console.WriteLine(IsStringNiceOrNasty(testString2));
Console.WriteLine(IsStringNiceOrNasty(testString3));
Console.WriteLine(IsStringNiceOrNasty(testString4));
Console.WriteLine(IsStringNiceOrNasty(testString5));

string IsStringNiceOrNasty(string rawString)
{
    
    if (occurencesOfChar(rawString) >= 3)
    {
        if (containsOneLetterAppearingTwice(rawString))
        {
            if (!containsDodgyString(rawString))
                return $"{rawString}: nice";
        }
    }
    return $"{rawString}: nasty";

    int occurencesOfChar(string s)
    {
        var vowels = "aeiou";
        int numberOfVowells = 0;
        foreach (char c in s)
            if (vowels.Contains(c))
                numberOfVowells++;
        return numberOfVowells;
    }

    bool containsOneLetterAppearingTwice(string rawString)
    {
        char? temp = null;
        for (var i = 0; i < rawString.Length; i++)
        {
            if (temp != null & rawString[i] == temp)
                return true;
            temp = rawString[i];
        }
        return false;
    }

    bool containsDodgyString(string rawString)
    {
        var dodgyStrings = new string[] { "ab", "cd", "pq", "xy" };
        foreach (var dodgyString in dodgyStrings)
            if (rawString.Contains(dodgyString))
                return true;
        return false;
    }
}