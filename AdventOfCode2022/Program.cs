// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines("InputData.txt");

var dict = new Dictionary<int, int>();
var runningTotal = 0;
var x = 1;

foreach( var line in lines)
{
    if (!string.IsNullOrEmpty(line))
    {
        runningTotal += Int32.Parse(line);
    }
    else
    {
        dict.Add(x, runningTotal);
        x++;
        runningTotal = 0;
    }
}

var maxElf = dict.OrderByDescending(a => a.Value).Take(3).Sum(a => a.Value);

Console.WriteLine(maxElf);
Console.ReadLine();
