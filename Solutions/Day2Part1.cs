using System;
using System.IO;

namespace AdventOfCode2022.Solutions
{
    public class Day2Part1 : IDay
    {
        // A, X for rock, B, Y for paper, C, Z for scissors
        // First column is opponent, second is you
        // 3 for scissors, 2 for paper, 1 for rock
        // 6 if win, 3 for draw, 0 if lose

        private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day2.txt";

        public void Run()
        {
            if (File.Exists(textFile))
            {
                using (StreamReader file = new StreamReader(textFile))
                {
                    int totalScore = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        var opponentSelection = ln[0];
                        var youSelection = ln[2];

                        switch (youSelection)
                        {
                            case 'X':
                                totalScore += 1;
                                break;
                            case 'Y':
                                totalScore += 2;
                                break;
                            case 'Z':
                                totalScore += 3;
                                break;
                        }

                        totalScore += ScoreOfMatch(opponentSelection, youSelection);
                    }

                    file.Close();
                    Console.WriteLine($"Your score is {totalScore}.");
                }
            }

            Console.ReadKey();

        }

        private int ScoreOfMatch(char opponentSelection, char youSelection)
        {
            switch (opponentSelection)
            {
                case 'A':
                    switch (youSelection)
                    {
                        case 'X':
                            return 3;
                        case 'Y':
                            return 6;
                        case 'Z':
                            return 0;
                    }
                    break;
                case 'B':
                    switch (youSelection)
                    {
                        case 'X':
                            return 0;
                        case 'Y':
                            return 3;
                        case 'Z':
                            return 6;
                    }
                    break;
                case 'C':
                    switch (youSelection)
                    {
                        case 'X':
                            return 6;
                        case 'Y':
                            return 0;
                        case 'Z':
                            return 3;
                    }
                    break;
            }

            return 0;
        }

    }
}
