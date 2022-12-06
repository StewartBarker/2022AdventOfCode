// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoC Day 6!");

//string[] lines = File.ReadAllLines("TestInput.txt");
string[] lines = File.ReadAllLines("InputFile.txt");
var total = 0;
var packetLength = 14;

foreach(var line in lines)
{
    for(var x=0; x<line.Length-packetLength;x++)
    {
        if (valsAreDistinct(line.Skip(x).Take(packetLength).ToList()))
        {
            Console.WriteLine($"First marker x={x}: marker= line=[{line}]");
            total += (x + packetLength);
            break;
        }     
    }
}

bool valsAreDistinct(List<char> list) =>
    list.Distinct().Count() == list.Count();


Console.WriteLine(total);
Console.ReadKey();