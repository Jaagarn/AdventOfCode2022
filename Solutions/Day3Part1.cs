using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
  public class Day3Part1 : IDay
  {
    private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day3.txt";
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
            var stringLength = ln.Length;
            if (stringLength % 2 != 0)
              throw new Exception("Unequal input");

            var leftCompartment = ln.Substring(0, stringLength / 2);
            var rightCompartment = ln.Substring(stringLength / 2);

            char itemInBoth = ' ';

            foreach (char item in leftCompartment)
            {
              if (rightCompartment.Contains(item))
              {
                itemInBoth = item;
                break;
              }
            }

            totalScore += valueOfItem_(itemInBoth);
          }

          file.Close();

          Console.WriteLine($"The priority value of all items is {totalScore}.");
        }
      }

      Console.ReadKey();
    }
    private int valueOfItem_(char item)
    {
      if (char.IsUpper(item))
        return item - 38;
      else
        return item - 96;
    }
  }
}
