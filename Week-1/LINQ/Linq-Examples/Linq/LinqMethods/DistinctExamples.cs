using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Helpers;

namespace Linq.LinqMethods
{
  public static class DistinctExamples
  {
    public static void ExampleOne()
    {
      var integerList = new List<int> { 1, 1, 1, 1, 2, 2, 3 };

      var distinctList = integerList.Distinct();
      ConsoleHelper.WriteWithGreen("Distinct - example one");
      Console.WriteLine($"Integer list: ({string.Join(",", integerList)})");
      Console.WriteLine($"Distinct list: ({string.Join(",", distinctList)})");
      Console.WriteLine(Environment.NewLine);
    }

    public static void ExampleTwo()
    {
      var integerList = new List<string> { "a", "b", "b", "b", "c", "c"};

      var distinctList = integerList.Distinct();
      ConsoleHelper.WriteWithGreen("Distinct - example one");
      Console.WriteLine($"Integer list: ({string.Join(",", integerList)})");
      Console.WriteLine($"Distinct list: ({string.Join(",", distinctList)})");
      Console.WriteLine(Environment.NewLine);
    }
  }
}
