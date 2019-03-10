using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Helpers;

namespace Linq.LinqMethods
{
  public static class ExceptExamples
  {
    public static void ExampleOne()
    {
      var firstList = new List<int> { 1, 2, 3, 4 };
      var secondList = new List<int> { 1, 2, 5 };

      var exceptList = firstList.Except(secondList);

      ConsoleHelper.WriteWithGreen("Except - example one");
      Console.WriteLine($"First list: ({string.Join(",", firstList)})");
      Console.WriteLine($"Second list: ({string.Join(",", secondList)})");
      Console.WriteLine($"Except list: ({string.Join(",", exceptList)})");
      Console.WriteLine(Environment.NewLine);
    }

    public static void ExampleTwo()
    {
      var firstList = new List<ExceptClassExample>
      {
        new ExceptClassExample(1, "Ana"),
        new ExceptClassExample(2, "Andrei"),
        new ExceptClassExample(3, "Elena")
      };

      var secondList = new List<ExceptClassExample>
      {
        new ExceptClassExample(1, "Ana")
      };

      var exceptResult = firstList.Except(secondList).ToList();


      ConsoleHelper.WriteWithGreen("Except - example two");
      Console.WriteLine("First list of objects:");
      firstList.ForEach(Console.WriteLine);
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Second list of objects:");
      secondList.ForEach(Console.WriteLine);
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Except result :");
      exceptResult.ForEach(Console.WriteLine);
      Console.WriteLine(Environment.NewLine);
    }

    public static void ExampleThree()
    {
      var firstList = new List<ExceptClassExample>
      {
        new ExceptClassExample(1, "Ana"),
        new ExceptClassExample(2, "Andrei"),
        new ExceptClassExample(3, "Elena")
      };

      var secondList = firstList.Where(x => x.ID == 1).ToList();

      var exceptResult = firstList.Except(secondList).ToList();

      ConsoleHelper.WriteWithGreen("Except - example three");
      Console.WriteLine("First list of objects:");
      firstList.ForEach(Console.WriteLine);
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Second list of objects:");
      secondList.ForEach(Console.WriteLine);
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Except result :");
      exceptResult.ForEach(Console.WriteLine);
      Console.WriteLine(Environment.NewLine);
    }
  }


  public class ExceptClassExample
  {
    public int ID { get; set; }
    public string Name { get; set; }

    public ExceptClassExample(int id, string name)
    {
      ID = id;
      Name = name;
    }
    public override string ToString()
    {
      return $"Object with ID = {ID} & Name = {Name}";
    }
  }
}
