// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using AoC_2022.Utils;

Console.WriteLine("Day4!");
int fullyContains = 0;
int overlaps = 0;
var sections = FileUtils.GetContent("Sections.txt");

foreach (string section in sections)
{
    var assignments = section.Split(",").Select(s => s.Split("-")).ToList();

    Console.WriteLine($"Left = {string.Join(",", assignments[0])}");
    Console.WriteLine($"Right = {string.Join(",", assignments[1])}");

    //if (int.Parse(assignments[0][0]) <= int.Parse(assignments[1][0]) 
    //    && int.Parse(assignments[0][1]) >= int.Parse(assignments[1][1]))
    //{
    //    Console.WriteLine($"Left = {string.Join(",", assignments[0])} contains Right = {string.Join(",", assignments[1])}");
    //    fullyContains++;
    //    continue;
    //}

    //if (int.Parse(assignments[1][0]) <= int.Parse(assignments[0][0])
    //    && int.Parse(assignments[1][1]) >= int.Parse(assignments[0][1])) {
    //    Console.WriteLine($"Right = {string.Join(",", assignments[1])} contains Left = {string.Join(",", assignments[0])}");
    //    fullyContains++;
    //    continue;
    //}

    if ((int.Parse(assignments[0][0]) <= int.Parse(assignments[1][0]) &&
        int.Parse(assignments[1][0]) <= int.Parse(assignments[0][1]))
        ||
        (int.Parse(assignments[0][0]) <= int.Parse(assignments[1][1]) &&
         int.Parse(assignments[1][1]) <= int.Parse(assignments[0][1])))
    {
        Console.WriteLine($"Left = {string.Join(",", assignments[0])} overlaps Right = {string.Join(",", assignments[1])}");
        overlaps++;
        continue;
    }

    if ((int.Parse(assignments[1][0]) <= int.Parse(assignments[0][0]) &&
         int.Parse(assignments[0][0]) <= int.Parse(assignments[1][1]))
        ||
        (int.Parse(assignments[1][0]) <= int.Parse(assignments[0][1]) &&
         int.Parse(assignments[0][1]) <= int.Parse(assignments[1][1]))) {
        Console.WriteLine($"Left = {string.Join(",", assignments[0])} overlaps Right = {string.Join(",", assignments[1])}");
        overlaps++;
    }
}

Console.WriteLine(overlaps);

