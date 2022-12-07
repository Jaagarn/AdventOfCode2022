using System;
using System.IO;

namespace AdventOfCode2022.Solutions
{
  public class Day4Part2 : IDay
  {
    private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day4.txt";
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
            if (doesOneContain_(ln))
              totalScore++;
          }

          file.Close();

          Console.WriteLine($"The total overlapping assigments is: {totalScore}.");
        }
      }

      Console.ReadKey();
    }
    private bool doesOneContain_(string inputOneLine)
    {

      var assigments = inputOneLine.Split(new char[] { ',' });

      var firstAssigment = assigmentsToInts_(assigments[0]);
      var secondAssigment = assigmentsToInts_(assigments[1]);

      if (firstAssigment.first < secondAssigment.first)
        return intExistInRange(secondAssigment.first, firstAssigment.first, firstAssigment.second);
      else if (firstAssigment.first >= secondAssigment.first)
        return intExistInRange(firstAssigment.first, secondAssigment.first, secondAssigment.second);
      else if (firstAssigment.second < secondAssigment.second)
        return intExistInRange(firstAssigment.second, secondAssigment.first, secondAssigment.second);
      else
        return intExistInRange(secondAssigment.second, firstAssigment.first, firstAssigment.second);

    }
    private (int first, int second) assigmentsToInts_(string assigment)
    {
      var assigments = assigment.Split(new char[] { '-' });

      return (int.Parse(assigments[0]), int.Parse(assigments[1]));

    }
    private bool intExistInRange(int exist, int first, int second)
    {
      return (exist >= first) && (exist <= second);
    }
  }
}
