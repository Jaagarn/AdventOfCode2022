﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
  public class Day7Part2 : IDay
  {
    private int totalSizeOfMemory = 70000000;
    private int spaceNeededForUpdate = 30000000;
    private const string textFile = @"D:\Projects\Repositories\AdventOfCode2022\DataSets\Day7.txt";
    private LeafDir outerMostDir = new LeafDir(null, "/");
    private LeafDir currentDir = null;
    private List<int> dirsBiggerThanSpaceNeeded = new List<int>();
    public void Run()
    {
      if (File.Exists(textFile))
      {
        // Read file using StreamReader. Reads file line by line  
        using (StreamReader file = new StreamReader(textFile))
        {
          string ln;

          while ((ln = file.ReadLine()) != null)
          {

            if (ln == "$ ls")
            {
              string innerLn;
              while ((innerLn = file.ReadLine()) != null)
              {
                if (innerLn[0] == '$')
                {
                  ln = innerLn;
                  break;
                }

                var splitCommands = innerLn.Split(' ');

                if (int.TryParse(splitCommands[0], out int byteSize))
                {
                  if (currentDir == null)
                  {
                    outerMostDir.AddFile(splitCommands[1], byteSize);
                  }
                  else
                  {
                    currentDir.AddFile(splitCommands[1], byteSize);
                  }
                }
                else
                {
                  if (currentDir == null)
                  {
                    outerMostDir.AddChildDir(new LeafDir(null, splitCommands[1]));
                  }
                  else
                  {
                    currentDir.AddChildDir(new LeafDir(currentDir, splitCommands[1]));
                  }
                }
              }
            }

            if (ln[0] == '$')
            {
              handleCommand_(ln);
            }

          }

          file.Close();
        }
      }

      var freeMemoryLeft = totalSizeOfMemory - outerMostDir.TotalSize();

      spaceNeededForUpdate -= freeMemoryLeft;

      goThroughAllDirs_(outerMostDir);

      dirsBiggerThanSpaceNeeded.Sort();

      if (dirsBiggerThanSpaceNeeded.Count == 0)
        Console.WriteLine($"You have to delete root, sorry mate");
      else
        Console.WriteLine($"Smallest size of dir is: {dirsBiggerThanSpaceNeeded[0]}");

      Console.ReadKey();
    }
    private void handleCommand_(string command)
    {
      string[] args = command.Split(' ');

      if (args.Length == 2)
        return;

      if (args[2] == "..")
      {
        if (currentDir != null)
          currentDir = currentDir.Parent;
        return;
      }

      if (args[2] == "/")
      {
        currentDir = null;
        return;
      }

      LeafDir newDir = null;

      if (currentDir == null)
      {
        newDir = outerMostDir.ChildDirs
          .Select(dir => dir)
          .Where(dir => dir.Name == args[2])
          .FirstOrDefault();
      }
      else
      {
        newDir = currentDir.ChildDirs
          .Select(dir => dir)
          .Where(dir => dir.Name == args[2])
          .FirstOrDefault();
      }

      currentDir = newDir;
    }
    private void goThroughAllDirs_(LeafDir inputLeaf)
    {
      foreach(var dir in inputLeaf.ChildDirs)
      {
        if(dir.HasChildDirs)
        {
          if(dir.TotalSize() > spaceNeededForUpdate)
            dirsBiggerThanSpaceNeeded.Add(dir.TotalSize());
          goThroughAllDirs_(dir);
        }
        else
        {
          if (dir.TotalSize() > spaceNeededForUpdate)
            dirsBiggerThanSpaceNeeded.Add(dir.TotalSize());
        }
      }
    }
    internal class LeafDir
    {
      public LeafDir(LeafDir parent, string name)
      {
        Parent = parent;
        Name = name;
        ChildDirs = new List<LeafDir>();
        Files = new List<(string name, int value)>();
      }

      public LeafDir Parent { get; }

      public string Name { get; }

      public List<LeafDir> ChildDirs { get; }

      public List<(string name, int value)> Files { get; }

      public bool HasFiles => Files.Count > 0;

      public bool HasChildDirs => ChildDirs.Count > 0;

      public int TotalSize()
      {
        var totalSize = 0;
        if (HasChildDirs)
          ChildDirs.ForEach(dir => totalSize += dir.TotalSize());
        if (HasFiles)
          Files.ForEach(file => totalSize += file.value);

        return totalSize;
      }

      public void AddChildDir(LeafDir childDir)
      {
        ChildDirs.Add(childDir);
      }

      public void AddFile(string name, int value)
      {
        Files.Add((name, value));
      }
    }
  }

}
