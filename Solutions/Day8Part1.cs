using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022.Solutions
{
  public class Day8Part1 : IDay
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
          int y = 0;
          int x = 0;

          List<string> xRows = new List<string>();

          while ((ln = file.ReadLine()) != null)
            xRows.Add(ln.Trim());

          forrest = new Tree[xRows.Count, xRows[0].Length];

          for (int i = 0; i < xRows.Count; i++)
          {
            for (int j = 0; j < xRows[i].Length; j++)
            {
              forrest[i, j] = new Tree(xRows[i][j] - '0');
            }
          }

          for (int i = 1; i < xRows.Count - 1; i++)
          {
            for (int j = 1; j < xRows[i].Length - 1; j++)
            {
              var currentTree = forrest[i, j];

              if (currentTree.Size <= forrest[i - 1, j].TallestTreeYMinus)
                currentTree.TallestTreeYMinus = forrest[i - 1, j].TallestTreeYMinus;

              if (currentTree.Size <= forrest[i, j - 1].TallestTreeXMinus)
                currentTree.TallestTreeXMinus = forrest[i, j - 1].TallestTreeXMinus;
            }
          }

          for (int i = xRows.Count - 2; i > 0; i--)
          {
            for (int j = xRows[i].Length - 2; j > 0; j--)
            {
              var currentTree = forrest[i, j];

              if (currentTree.Size <= forrest[i + 1, j].TallestTreeYPlus)
                currentTree.TallestTreeYPlus = forrest[i + 1, j].TallestTreeYPlus;

              if (currentTree.Size <= forrest[i, j + 1].TallestTreeXPlus)
                currentTree.TallestTreeXPlus = forrest[i, j + 1].TallestTreeXPlus;
            }
          }

          // The outmost rows are always visible
          int howManyVisible = xRows.Count * 2 + xRows[0].Length * 2 - 4;

          for (int i = 1; i < xRows.Count - 1; i++)
          {
            for (int j = 1; j < xRows[i].Length - 1; j++)
            {
              if (forrest[i, j].IsVisable)
              {
                howManyVisible++;
              }
            }
          }

          Console.WriteLine($"Amount of visible trees: {howManyVisible}");

          file.Close();
        }
      }

      Console.ReadKey();
    }
    internal class Tree
    {
      private int size;
      private int tallestTreeYPlus;
      private int tallestTreeYMinus;
      private int tallestTreeXPlus;
      private int tallestTreeXMinus;
      public Tree(int size)
      {
        this.size = size;
      }

      public int Size => size;

      public int TallestTreeYPlus
      {
        get
        {
          if (size > tallestTreeYPlus)
            return size;

          return tallestTreeYPlus;
        }
        set
        {
          tallestTreeYPlus = value;
        }
      }
      public int TallestTreeYMinus
      {
        get
        {
          if (size > tallestTreeYMinus)
            return size;

          return tallestTreeYMinus;
        }
        set
        {
          tallestTreeYMinus = value;
        }
      }
      public int TallestTreeXPlus
      {
        get
        {
          if (size > tallestTreeXPlus)
            return size;

          return tallestTreeXPlus;
        }
        set
        {
          tallestTreeXPlus = value;
        }
      }
      public int TallestTreeXMinus
      {
        get
        {
          if (size > tallestTreeXMinus)
            return size;

          return tallestTreeXMinus;
        }
        set
        {
          tallestTreeXMinus = value;
        }
      }
      public bool IsVisable
      {
        get
        {
          return tallestTreeXMinus < size || tallestTreeXPlus < size
              || tallestTreeYMinus < size || tallestTreeYPlus < size;
        }
      }
    }
  }
}
