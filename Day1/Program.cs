// See https://aka.ms/new-console-template for more information

using AoC_2022.Utils;

Console.WriteLine("AoC 2022 : Day1");
int elfCounter = 0;
var elvesWithCalories = new Dictionary<int, int>();
var caloriesDefined = FileUtils.GetContent("Calories.txt");
foreach (var calorie in caloriesDefined)
{
    if (string.IsNullOrWhiteSpace(calorie))
    {
        elfCounter++;
    }

    if (elvesWithCalories.ContainsKey(elfCounter))
    {
        elvesWithCalories[elfCounter] += int.Parse(calorie);
    }
    else
    {
        elvesWithCalories[elfCounter] = 0;
    }
    
}

foreach (var elf in elvesWithCalories.OrderByDescending(e => e.Value))
{
    Console.WriteLine($"Elf: {elf.Key} with {elf.Value} calories");
}

var caloriesFromTopElves = elvesWithCalories.OrderByDescending(e => e.Value).Take(3).Sum(e => e.Value);
Console.WriteLine($"Calories by top 3 elves = {caloriesFromTopElves}");