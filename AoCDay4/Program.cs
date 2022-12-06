// See https://aka.ms/new-console-template for more information
Console.WriteLine("AocDay4!");

string[] lines = File.ReadAllLines("InputFile.txt");
var count = 0;

foreach(var line in lines)
{
    var ranges = line.Split(",");
    var firstRange = ranges[0];
    var secondRange = ranges[1];
    if (IsContainedWithinPart2(firstRange, secondRange))
    {
        Console.WriteLine($"True for: {line}");
        count++;
    }
}

Console.WriteLine($"Part 1: {count}");
Console.ReadKey();

bool IsContainedWithin(string firstRange, string secondRange)
{
    var firstVals = firstRange.Split("-").Select(Int32.Parse).ToArray();
    var secondVals = secondRange.Split("-").Select(Int32.Parse).ToArray();
    if ((firstVals[0] >= secondVals[0] &&
        firstVals[1] <= secondVals[1]) ||
        (secondVals[0] >= firstVals[0] &&
        secondVals[1] <= firstVals[1]))
        return true;

    return false;
}

bool IsContainedWithinPart2(string firstRange, string secondRange)
{
    var firstVals = firstRange.Split("-").Select(Int32.Parse).ToArray();
    var secondVals = secondRange.Split("-").Select(Int32.Parse).ToArray();
    if ((firstVals[0] <= secondVals[1] &&
        firstVals[1] >= secondVals[0]) ||
        (secondVals[0] <= firstVals[1] &&
        secondVals[1] >= firstVals[0]))
        return true;

    return false;
}