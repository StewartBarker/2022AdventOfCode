// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoCDay5!");

string[] lines = File.ReadAllLines("TestInput.txt");
//string[] lines = File.ReadAllLines("InputFile.txt");

var maxStacks = (lines.First().Length + 1) / 4;

var stacks = BuildInitialStacks(lines.Where(l => l.Contains('[')).Reverse());
//var result = ProcessCrateMovements(stacks, lines.Where(l => l.StartsWith("move")));
var part2Result = ProcessPart2CrateMovememnents(stacks, lines.Where(l => l.StartsWith("move")));

//Console.WriteLine(result);
Console.WriteLine(part2Result);

Console.ReadKey();

Stack<char>[] BuildInitialStacks(IEnumerable<string> listOfStacks)
{
    var stacks = new Stack<char>[maxStacks];

    foreach (var line in listOfStacks)
    {
        var cratesForLine = line;

        for (var x = 0; x < maxStacks; x++)
        {
            var crate = cratesForLine[(x * 4) + 1];
            if (crate != ' ')
            {
                if (stacks[x] == null)
                {
                    stacks[x] = new Stack<char>();
                }
                stacks[x].Push(crate);
            }
        }
    }

    return stacks;
}

string ProcessPart2CrateMovememnents(Stack<char>[] stacks, IEnumerable<string> movements)
{
    foreach (var movement in movements)
    {
        var splitMovement = movement.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ",").Split(",");
        var move = int.Parse(splitMovement[0]);
        var from = int.Parse(splitMovement[1]);
        var to = int.Parse(splitMovement[2]);

        Console.WriteLine($"Move {move} from {from} to {to}");
        var popped = new List<char>();
        for (var numberToMove = 1; numberToMove <= move; numberToMove++)
        {
            popped.Add(stacks[from - 1].Pop());
        }
        popped.Reverse();
        foreach(var poppedChar in popped)
            stacks[to - 1].Push(poppedChar);
        //Console.WriteLine($"Stack from: {from - 1}, to: {to - 1}: Popped: {poppedChar}");
    }

    var output = "Crates at top of stacks: ";
    foreach (var stack in stacks)
    {
        output += stack.Pop() + "";
    }
    return output;
}

string ProcessCrateMovements(Stack<char>[] stacks, IEnumerable<string> movements)
{
    foreach(var movement in movements)
    {
        var splitMovement = movement.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ",").Split(",");
        var move = int.Parse(splitMovement[0]);
        var from = int.Parse(splitMovement[1]);
        var to = int.Parse(splitMovement[2]);

        Console.WriteLine($"Move {move} from {from} to {to}");

        for(var numberToMove = 1; numberToMove<=move; numberToMove++)
        { 
            var popped = stacks[from - 1].Pop();
            stacks[to - 1].Push(popped);
            Console.WriteLine($"Stack from: {from - 1}, to: {to - 1}: Popped: {popped}");
        }
    }

    var output = "Crates at top of stacks: ";
    foreach(var stack in stacks)
    {
        output += stack.Pop();  
    }
    return output;
}

