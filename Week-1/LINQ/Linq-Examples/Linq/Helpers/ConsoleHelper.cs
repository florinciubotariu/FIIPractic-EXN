using System;

namespace Linq.Helpers
{
  public static class ConsoleHelper
  {
    public static void WriteWithGreen(string text)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(text);
      Console.ResetColor();
    }
  }
}
