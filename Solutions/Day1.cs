using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
  public class Day1 : IDay
  {
    private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day1.txt";
    public void Run()
    {
      if (File.Exists(textFile))
      {
        using (StreamReader file = new StreamReader(textFile))
        {
          List<int> caloriesList = new List<int>();
          int currentCalories = 0;
          string ln;

          while ((ln = file.ReadLine()) != null)
          {
            if (string.IsNullOrWhiteSpace(ln))
            {
              caloriesList.Add(currentCalories);
              currentCalories = 0;
            }
            else
            {
              currentCalories += int.Parse(ln);
            }
          }

          caloriesList.Sort();
          caloriesList.Reverse();
          int totalCalories = caloriesList.Take(3).Sum();

          file.Close();
          Console.WriteLine($"Top three elves has {totalCalories}.");
        }
      }

      Console.ReadKey();
    }
  }
}
