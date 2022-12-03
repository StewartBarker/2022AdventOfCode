

Console.WriteLine("AoC Day3!");

string[] lines = File.ReadAllLines("InputFile.txt");
//string[] lines = File.ReadAllLines("TestInput.txt");
var totalScore = 0;

foreach(var line in lines)
{
    var compartmentLength = line.Trim().Length / 2;
    var compartment1 = line.Substring(0, compartmentLength);
    var compartment2 = line.Substring(compartmentLength, compartmentLength);

    foreach(char c in compartment1)
    {
        if (compartment2.Contains(c))
        {
            var score = getScore(c);
            totalScore += score;
            Console.WriteLine($"'{c}' = {score}");
            break;
        }
    }
}

Console.WriteLine(totalScore);
Console.WriteLine(EvaluatePart2(lines));

int EvaluatePart2(string[] lines)
{
    var total = 0;
    for(var x = 0; x<lines.Length; x+=3)
    {
        var group1 = lines[x];
        var group2 = lines[x + 1];
        var group3 = lines[x + 2];
        foreach(char c in group1)
        {
            if(group2.Contains(c) && group3.Contains(c))
            {
                var score = getScore(c);
                Console.WriteLine($"Score for {c}: {score}");
                total += score;
                break;
            }
        }
    }
    return total;
}

Console.ReadKey();

int getScore(char c) => Char.IsUpper(c) ? (int)c - 38 : (int)c - 96;

public class RuckSack
{
    List<string> Compartment { get; set; }
}
