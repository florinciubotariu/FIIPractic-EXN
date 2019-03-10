using Linq.LinqMethods;

namespace Linq
{
  class Program
  {
    static void Main(string[] args)
    {
      ContainsExamples.ExampleOne();
      ContainsExamples.ExampleTwo();

      DistinctExamples.ExampleOne();
      DistinctExamples.ExampleTwo();

      WhereExamples.ExampleOne();

      OrderByExamples.ExampleOne();
      OrderByExamples.ExampleTwo();

      FirstOrDefaultExamples.ExampleOne();
      FirstOrDefaultExamples.ExampleTwo();

      SelectExamples.ExampleOne();

      ExceptExamples.ExampleOne();
      ExceptExamples.ExampleTwo();
      ExceptExamples.ExampleThree();
    }
  }
}
