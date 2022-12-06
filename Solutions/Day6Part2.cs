using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class Day6Part2 : IDay
    {
        private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day6.txt";
        public void Run()
        {
            if (File.Exists(textFile))
            {
                using (StreamReader file = new StreamReader(textFile))
                {
                    string ln;

                    StringBuilder sb = new StringBuilder();

                    while ((ln = file.ReadLine()) != null)
                        sb.Append(ln);

                    var message = sb.ToString();

                    bool foundMarker = false;
                    int index = 0;

                    while (!foundMarker)
                    {
                        var testMarker = message.Substring(index, 14);
                        var distinctTestMarker = string.Join("", testMarker.Distinct());

                        if (testMarker.Length != distinctTestMarker.Length)
                            index++;
                        else
                        {
                            foundMarker = true;
                            Console.WriteLine($"Marker is: {testMarker}");
                        }

                    }

                    Console.WriteLine($"Index is is: {index + 14}");

                    file.Close();

                }

            }

            Console.ReadKey();
        }
    }
}
