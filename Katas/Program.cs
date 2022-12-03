// See https://aka.ms/new-console-template for more information

Console.WriteLine("Kata 2022/11/23");

var testString1 = "ugknbfddgicrmpon";
var testString2 = "aaa";
var testString3 = "jchzalrnumimnmhp";
var testString4 = "haegwjzuvuuyypxyu";
var testString5 = "dvszwmarrgswjxmb";

Console.WriteLine(IsStringNice(testString1) ? "nice" : "nasty");
Console.WriteLine(IsStringNice(testString2) ? "nice" : "nasty");
Console.WriteLine(IsStringNice(testString3) ? "nice" : "nasty");
Console.WriteLine(IsStringNice(testString4) ? "nice" : "nasty");
Console.WriteLine(IsStringNice(testString5) ? "nice" : "nasty");

string[] lines = File.ReadAllLines("KataData.txt");

var i = 0;
foreach (string line in lines)
    if (IsStringNice(line))
        i++;

Console.WriteLine(i);

bool IsStringNice(string rawString)
{
    if (occurencesOfChar(rawString) >= 3)
    {
        if (containsOneLetterAppearingTwice(rawString))
        {
            if (!containsDodgyString(rawString))
                return true;
        }
    }
    return false;

    int occurencesOfChar(string s)
    {
        var vowels = "aeiou";
        int numberOfVowels = 0;
        foreach (char c in s)
            if (vowels.Contains(c))
                numberOfVowels++;
        return numberOfVowels;
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