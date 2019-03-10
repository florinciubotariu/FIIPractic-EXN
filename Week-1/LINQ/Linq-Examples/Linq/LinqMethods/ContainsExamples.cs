using System;
using System.Collections.Generic;
using Linq.Helpers;

namespace Linq.LinqMethods
{
  public static class ContainsExamples
  {
    public static void ExampleOne()
    {
      var integerList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      var firstInteger = 0;
      var secondInteger = 5;

      var firstIntegerExists = integerList.Contains(firstInteger);
      var secondIntegerExists = integerList.Contains(secondInteger);

      ConsoleHelper.WriteWithGreen("Contains - example one");
      Console.WriteLine($"Integer list: ({string.Join(",", integerList)})");
      Console.WriteLine($"{firstInteger} exists in list: {firstIntegerExists}");
      Console.WriteLine($"{secondInteger} exists in list: {secondIntegerExists}");
      Console.WriteLine(Environment.NewLine);
    }

    public static void ExampleTwo()
    {
      var animalList = new List<string> { "cat", "dog", "elephant" };

      var firstAnimal = "cat";
      var secondAnimal = "dog";
      var thirdAnimal = "ELEPHANT";

      var firstAnimalExists = animalList.Contains(firstAnimal);
      var secondAnimalExists = animalList.Contains(secondAnimal);
      var thirdAnimalExists = animalList.Contains(thirdAnimal);

      ConsoleHelper.WriteWithGreen("Contains - example two");
      Console.WriteLine($"Animal list: ({string.Join(",", animalList)})");
      Console.WriteLine($"{firstAnimal} exists in list: {firstAnimalExists}");
      Console.WriteLine($"{secondAnimal} exists in list: {secondAnimalExists}");
      Console.WriteLine($"{thirdAnimal} exists in list: {thirdAnimalExists}");
      Console.WriteLine(Environment.NewLine);
    }
  }
}
