using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022.Solutions
{
  public class Day8Part2 : IDay
  {
    private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day8.txt";
    private Tree[,] forrest;

    public void Run()
    {
      if (File.Exists(textFile))
      {
        // Read file using StreamReader. Reads file line by line  
        using (StreamReader file = new StreamReader(textFile))
        {
          string ln;

          List<string> xRows = new List<string>();

          while ((ln = file.ReadLine()) != null)
            xRows.Add(ln.Trim());

          var ySize = xRows.Count;
          var xSize = xRows[0].Length;

          forrest = new Tree[ySize, xSize];

          for (int i = 0; i < ySize; i++)
            for (int j = 0; j < xSize; j++)
              forrest[i, j] = new Tree(xRows[i][j] - '0');

          int bestView = 1;
          // No need to count the outer circle. Everyone has a basescore of 1 since they can atleast see 1 tree in each direction
          for (int i = 1; i < ySize - 1; i++)
            for (int j = 1; j < xSize - 1; j++)
            {
              var currentTree = forrest[i, j];

              var yPlusScore = 1;
              var xPlusScore = 1;
              var yMinScore = 1;
              var xMinScore = 1;

              for (int yPlus = i - 1; yPlus > 0; yPlus--)
              {
                if (forrest[yPlus, j].Size < currentTree.Size)
                  yPlusScore++;
                else
                  break;
              }

              for (int xPlus = j - 1; xPlus > 0; xPlus--)
              {
                if (forrest[i, xPlus].Size < currentTree.Size)
                  xPlusScore++;
                else
                  break;
              }

              for (int yMin = i + 1; yMin < ySize - 1; yMin++)
              {
                if (forrest[yMin, j].Size < currentTree.Size)
                  yMinScore++;
                else
                  break;
              }

              for (int xMin = j + 1; xMin < xSize - 1; xMin++)
              {
                if (forrest[i, xMin].Size < currentTree.Size)
                  xMinScore++;
                else
                  break;
              }

              forrest[i, j].Score = yPlusScore * yMinScore * xPlusScore * xMinScore;

              if (forrest[i, j].Score > bestView)
                bestView = forrest[i, j].Score;
            }

          Console.WriteLine($"The best view score is: {bestView}");
          file.Close();
        }
      }

      Console.ReadKey();
    }
    internal class Tree
    {
      private int size;
      public Tree(int size)
      {
        this.size = size;
      }
      public int Size => size;
      public int Score { get; set; }
    }
  }
}
