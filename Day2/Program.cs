// See https://aka.ms/new-console-template for more information

using AoC_2022.Utils;
using Day2;

int finalScore = 0;
int expectedScore = 0;
var computedScores = new List<Score>();
var expectedScores = new List<Score>();
Console.WriteLine("AoC 2022 : Day 2");


var scores = FileUtils.GetContent("Scores.txt");

foreach (string score in scores)
{
    var computedScore = new Score(score);

    computedScores.Add(computedScore);
}

Console.WriteLine(computedScores.Sum(s => s.RoundScore));

foreach (string score in scores)
{
    var requiredPlay = Score.GetRequiredPlay(score);

    var requiredScore = new Score(requiredPlay);
    expectedScores.Add(requiredScore);
}

Console.WriteLine(expectedScores.Sum(s => s.RoundScore));
