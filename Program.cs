using AdventOfCode2022.Solutions;
using System;

namespace AdventOfCode2022
{
  public class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(@"Which day do you want to see?");
      int.TryParse(Console.ReadLine(), out int dayInput);
      Console.WriteLine(@"Which part do you want to see?");
      int.TryParse(Console.ReadLine(), out int partInput);

      IDay day;

      switch (dayInput)
      {
        case 1:
          day = new Day1();
          break;
        case 2:
          if (partInput == 1)
            day = new Day2Part1();
          else
            day = new Day2Part2();
          break;
        case 3:
          if (partInput == 1)
            day = new Day3Part1();
          else
            day = new Day3Part2();
          break;
        case 4:
          if (partInput == 1)
            day = new Day4Part1();
          else
            day = new Day4Part2();
          break;
        case 5:
          if (partInput == 1)
            day = new Day5Part1();
          else
            day = new Day5Part2();
          break;
        case 6:
          if (partInput == 1)
            day = new Day6Part1();
          else
            day = new Day6Part2();
          break;
        case 7:
          if (partInput == 1)
            day = new Day7Part1();
          else
            day = new Day7Part2();
          break;
        case 8:
          if (partInput == 1)
            day = new Day8Part1();
          else
            day = new Day8Part2();
          break;
        default:
          Console.WriteLine($@"Weird input, here is day ones result instead");
          day = new Day1();
          break;
      }

      Console.WriteLine(Environment.NewLine);
      day.Run();
    }
  }
}
