using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022.Solutions
{
    public class Day5Part1 : IDay
    {
        private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day5.txt";
        public void Run()
        {

            if (File.Exists(textFile))
            {
                var result = string.Empty;
                using (StreamReader file = new StreamReader(textFile))
                {
                    string ln;
                    int howManyOfColumns = 0;
                    List<string[]> instructions = new List<string[]>();
                    List<string> rows = new List<string>();

                    while ((ln = file.ReadLine()) != null)
                    {
                        var timmedLn = ln.Trim();
                        if (ln.Contains("1"))
                        {
                            var columns = timmedLn.Split(' ');
                            howManyOfColumns = int.Parse(columns[columns.Length - 1]);
                            break;
                        }
                        rows.Add(ln);
                    }

                    var stackArray = buildStackArray_(rows, howManyOfColumns);
                    file.ReadLine();

                    while ((ln = file.ReadLine()) != null)
                    {
                        var trimmedInstructions = ln.Split(' ');
                        instructions.Add(new string[] { trimmedInstructions[1], trimmedInstructions[3], trimmedInstructions[5] });
                    }

                    var sortedStackArray = sortStackArray_(stackArray, instructions);

                    foreach (var stack in sortedStackArray)
                    {
                        if (stack.Count > 0)
                            result += stack.Peek();

                    }
                    file.Close();

                }

                Console.WriteLine($"The sorted stackArray top is: {result}.");
            }

            Console.ReadKey();
        }

        private Stack[] buildStackArray_(List<string> rows, int howManyColumns)
        {
            var stackArray = new Stack[howManyColumns];

            for (int i = 0; i < stackArray.Length; i++)
                stackArray[i] = new Stack();

            for (int i = rows.Count - 1; i >= 0; i--)
            {
                var currentRow = rows[i];
                if (currentRow[1] != ' ')
                    stackArray[0].Push(currentRow[1]);

                int rowValueIndex = 5;

                for (int j = 1; j < howManyColumns; j++)
                {
                    if (currentRow[rowValueIndex] != ' ')
                        stackArray[j].Push(currentRow[rowValueIndex]);
                    rowValueIndex += 4;
                }
            }

            return stackArray;
        }
        private Stack[] sortStackArray_(Stack[] stackToSort, List<string[]> instructions)
        {
            foreach (var instuction in instructions)
            {
                var howManyMoves = int.Parse(instuction[0]);
                var fromStack = int.Parse(instuction[1]) - 1;
                var toStack = int.Parse(instuction[2]) - 1;

                for (int i = 0; i < howManyMoves; i++)
                {
                    if (stackToSort[fromStack].Count > 0)
                        stackToSort[toStack].Push(stackToSort[fromStack].Pop());

                }
            }

            return stackToSort;
        }
    }
}
