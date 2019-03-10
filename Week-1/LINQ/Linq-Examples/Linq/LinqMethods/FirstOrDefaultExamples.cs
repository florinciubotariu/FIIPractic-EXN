using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Helpers;

namespace Linq.LinqMethods
{
  public static class FirstOrDefaultExamples
  {
    public static void ExampleOne()
    {
      var integerList = new List<int> { 5, 8, 3, 7, 9, 4 };

      var firstInteger = integerList.FirstOrDefault();

      ConsoleHelper.WriteWithGreen("FirstOrDefault - example one");
      Console.WriteLine($"Integer list: ({string.Join(",", integerList)})");
      Console.WriteLine($"First integer: {firstInteger})");
      Console.WriteLine(Environment.NewLine);
    }

    public static void ExampleTwo()
    {
      var firstList = new List<ComplexNumber>
      {
        new ComplexNumber(1, 1),
        new ComplexNumber(2, 2),
        new ComplexNumber(3, 3),
        new ComplexNumber(3, 4)
      };

      var firstOrDefault3 = firstList.FirstOrDefault(complexNumber => complexNumber.X == 3);
      var firstOrDefault4 = firstList.FirstOrDefault(complexNumber => complexNumber.X == 4);
      ConsoleHelper.WriteWithGreen("FirstOrDefault - example two");
      Console.WriteLine("List of objects:");
      firstList.ForEach(Console.WriteLine);
      Console.WriteLine("FirstOrDefault searching for X = 3 result:");
      Console.WriteLine(firstOrDefault3?.ToString());
      Console.WriteLine("FirstOrDefault searching for X = 4 result:");
      Console.WriteLine(firstOrDefault4?.ToString());
      Console.WriteLine(Environment.NewLine);
    }
  }

  public class ComplexNumber
  {
    public int X { get; set; }
    public int Y { get; set; }

    public ComplexNumber(int x, int y)
    {
      X = x;
      Y = y;
    }
    public override string ToString()
    {
      return $"{X}+i{Y}";
    }
  }
}
