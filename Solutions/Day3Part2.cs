using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
  public class Day3Part2 : IDay
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
            var firstElf = ln.Distinct();
            var secondElf = file.ReadLine().Distinct();
            var thirdElf = file.ReadLine().Distinct();

            char itemInAllThree = ' ';

            foreach (char item in firstElf)
            {
              if (secondElf.Contains(item) &&
                  thirdElf.Contains(item))
              {
                itemInAllThree = item;
                break;
              }
            }

            totalScore += valueOfItem_(itemInAllThree);
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
