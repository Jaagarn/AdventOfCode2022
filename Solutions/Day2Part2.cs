using System;
using System.IO;

namespace AdventOfCode2022.Solutions
{
  public class Day2Part2 : IDay
  {
    // A for rock, B for paper, C for scissors'
    // X needs to lose, Y for draw, Z to win
    // First column is opponent, second is you
    // 3 for scissors, 2 for paper, 1 for rock
    // 6 if win, 3 for draw, 0 if lose
    private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day2.txt";
    public void Run()
    {
      if (File.Exists(textFile))
      {
        // Read file using StreamReader. Reads file line by line  
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
                totalScore += 0;
                break;
              case 'Y':
                totalScore += 3;
                break;
              case 'Z':
                totalScore += 6;
                break;
            }

            youSelection = YouSelection(opponentSelection, youSelection);

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

          }


          file.Close();
          Console.WriteLine($"Your score is {totalScore}.");
        }
      }

      Console.ReadKey();
    }
    private char YouSelection(char opponentSelection, char youSelection)
    {
      switch (opponentSelection)
      {
        case 'A':
          switch (youSelection)
          {
            case 'X':
              return 'Z';
            case 'Y':
              return 'X';
            case 'Z':
              return 'Y';
          }
          break;
        case 'B':
          switch (youSelection)
          {
            case 'X':
              return 'X';
            case 'Y':
              return 'Y';
            case 'Z':
              return 'Z';
          }
          break;
        case 'C':
          switch (youSelection)
          {
            case 'X':
              return 'Y';
            case 'Y':
              return 'Z';
            case 'Z':
              return 'X';
          }
          break;
      }

      return ' ';
    }
  }
}
