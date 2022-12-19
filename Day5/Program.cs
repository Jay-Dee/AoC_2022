// See https://aka.ms/new-console-template for more information

using AoC_2022.Utils;

Console.WriteLine("Day5");
var singleMoveCrates = new Dictionary<int, Stack<string>>();
var multiMoveCrates = new Dictionary<int, Stack<string>>();
var initialLayout = FileUtils.GetContent("InitialLayout.txt").Reverse().ToList();
var crateMoves = FileUtils.GetContent("CrateMoves.txt");

var crateConfiguration = initialLayout.First();
var numberOfCrates = crateConfiguration.Split(" ").Count(s => !string.IsNullOrWhiteSpace(s));
for (int i = 1; i <= numberOfCrates; i++)
{
    singleMoveCrates[i] = new Stack<string>();
    multiMoveCrates[i] = new Stack<string>();
}

foreach (string layout in initialLayout.Skip(1))
{
    foreach (var crate in multiMoveCrates)
    {
        int startIndex = 0;
        if (crate.Key > 1)
        {
            startIndex = (3 * (crate.Key - 1)) + crate.Key -1;
        }

        var crateValue = layout.Substring(startIndex, 3);
        if (!string.IsNullOrWhiteSpace(crateValue))
        {
            crate.Value.Push(crateValue);
            singleMoveCrates[crate.Key].Push(crateValue);
        }
    }
}

foreach (string move in crateMoves)
{
    var tempCrate = new Stack<string>();
    var moveConfiguration = move.Split(" ");
    var itemsToMove = int.Parse(moveConfiguration[1]);
    var fromCrate = int.Parse(moveConfiguration[3]);
    var toCrate = int.Parse(moveConfiguration[5]);

    Console.WriteLine($"Move {itemsToMove} ");
    Console.WriteLine($"From {fromCrate} : {string.Join(",", multiMoveCrates[fromCrate])}");
    Console.WriteLine($"To {toCrate} : {string.Join(",", multiMoveCrates[toCrate])}");
    for (int moveItemCounter = 0; moveItemCounter < itemsToMove; moveItemCounter++)
    {
        singleMoveCrates[toCrate].Push(singleMoveCrates[fromCrate].Pop());
        tempCrate.Push(multiMoveCrates[fromCrate].Pop());
    }
    for (int moveItemCounter = 0; moveItemCounter < itemsToMove; moveItemCounter++) 
    {
        multiMoveCrates[toCrate].Push(tempCrate.Pop());
    }

    Console.WriteLine($"After move {string.Join(",", multiMoveCrates[toCrate])}");
}

Console.WriteLine($"{string.Join("", singleMoveCrates.Values.Select(v => v.Pop()))}");
Console.WriteLine($"{string.Join("", multiMoveCrates.Values.Select(v => v.Pop()))}");

