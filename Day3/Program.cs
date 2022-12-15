// See https://aka.ms/new-console-template for more information

using AoC_2022.Utils;

Console.WriteLine("Day3");

int priorityAccumulator = 0;
int badgeAccumulator = 0;
var upperCase = Enumerable.Range(0, 26).Select(i => new KeyValuePair<char, int>(Convert.ToChar('A' + i), i + 27));
var lowerCase = Enumerable.Range(0, 26).Select(i => new KeyValuePair<char, int>(Convert.ToChar('a' + i), i  +1));

var priority = lowerCase.Concat(upperCase).ToDictionary(a => a.Key, a => a.Value);

foreach (var c in priority)
{
    Console.WriteLine(c);
}

foreach (string compartment in FileUtils.GetContent("Compartments.txt"))
{
    Console.WriteLine($"{compartment} is of length {compartment.Length}");

    var compartment1 = compartment.Substring(0, compartment.Length / 2).ToHashSet();
    var compartment2 = compartment.Substring(compartment.Length / 2).ToHashSet();

    var overlappingValues = compartment1.Intersect(compartment2);
    overlappingValues.Select(o => priorityAccumulator += priority[o]).ToList();
}

var compartments = FileUtils.GetContent("Compartments.txt").ToList();
var chunks = compartments.Where((c, i) => i % 3 == 0).Select((c, i) => compartments.Skip(i * 3).Take(3));

foreach (IEnumerable<string> chunk in chunks)
{
    var items = chunk.Select(c => c.ToCharArray().ToHashSet()).ToList();
    badgeAccumulator += priority[items[0].Intersect(items[1]).Intersect(items[2]).First()];
}
Console.WriteLine(priorityAccumulator);
Console.WriteLine(badgeAccumulator);