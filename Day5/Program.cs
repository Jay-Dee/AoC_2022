// See https://aka.ms/new-console-template for more information

using AoC_2022.Utils;

Console.WriteLine("Day5");
var crates = new Dictionary<int, Stack<string>>();
var initialLayout = FileUtils.GetContent("InitialLayout.txt").Reverse().ToList();
var crateMoves = FileUtils.GetContent("CrateMoves.txt");

var crateConfiguration = initialLayout.First();
var numberOfCrates = crateConfiguration.Split(" ").Count(s => !string.IsNullOrWhiteSpace(s));
for (int i = 1; i <= numberOfCrates; i++)
{
    crates[i] = new Stack<string>();
}

foreach (string layout in initialLayout.Skip(1))
{
    foreach (var crate in crates)
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
    Console.WriteLine($"From {fromCrate} : {string.Join(",", crates[fromCrate])}");
    Console.WriteLine($"To {toCrate} : {string.Join(",", crates[toCrate])}");
    for (int moveItemCounter = 0; moveItemCounter < itemsToMove; moveItemCounter++)
    {
        tempCrate.Push(crates[fromCrate].Pop());
    }
    for (int moveItemCounter = 0; moveItemCounter < itemsToMove; moveItemCounter++) 
    {
        crates[toCrate].Push(tempCrate.Pop());
    }

    Console.WriteLine($"After move {string.Join(",", crates[toCrate])}");
}

Console.WriteLine($"{string.Join("", crates.Values.Select(v => v.Pop()))}");

