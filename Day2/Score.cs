using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2 {
    internal class Score {

        private readonly Dictionary<string, int> _scoreMap = new()
        {
            { "A X", 4},
            { "A Y", 8},
            { "A Z", 3},
            { "B X", 1},
            { "B Y", 5},
            { "B Z", 9},
            { "C X", 7},
            { "C Y", 2},
            { "C Z", 6}
        };

        private static readonly Dictionary<string, string> __resultMap = new()
        {//x - loose, y - draw, z - win; a = rock, b = paper, c = scissors
            {"A X", "Z"},
            {"A Y", "X"},
            {"A Z", "Y"},
            {"B X", "X"},
            {"B Y", "Y"},
            {"B Z", "Z"},
            {"C X", "Y"},
            {"C Y", "Z"},
            {"C Z", "X"},
        };

        public int RoundScore { get; }
        
        public Score(string score)
        {
            RoundScore = _scoreMap[score];
        }

        public static string GetRequiredPlay(string score)
        {
            var requiredPlay = __resultMap[score];

            return $"{score.Split(" ")[0]} {requiredPlay}";
        }
    }
}
