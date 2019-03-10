using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Helpers;

namespace Linq.LinqMethods
{
  public static class OrderByExamples
  {
    public static void ExampleOne()
    {
      var integerList = new List<int> { 5, 6, 7, 8, 9, 4, 3, 2, 1 };

      var orderedIntegerList = integerList.OrderBy(integer => integer);
      var customOrderedIntegerList = integerList.OrderBy(integer => integer * integer % 10);

      ConsoleHelper.WriteWithGreen("OrderBy - example one");
      Console.WriteLine($"Integer list: ({string.Join(",", integerList)})");
      Console.WriteLine($"Ordered integer list: ({string.Join(",", orderedIntegerList)})");
      Console.WriteLine($"Custom ordered integer list: ({string.Join(",", customOrderedIntegerList)})");

      Console.WriteLine(Environment.NewLine);
    }

    public static void ExampleTwo()
    {
      var siteList = new List<Site>
      {
        new Site("https://twitter.com", 48),
        new Site("https://google.ro", 123),
        new Site("https://facebook.com", 54)
      };

      var orderedDescendingByTotalVisitors = siteList.OrderByDescending(site => site.TotalVisitors);

      ConsoleHelper.WriteWithGreen("OrderBy - example two");
      Console.WriteLine("Sites:");
      foreach (var site in siteList)
      {
        Console.WriteLine($"Site: {site.Url} with {site.TotalVisitors} visitors.");
      }

      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Sites ordered descending by number of visitors:");
      foreach (var site in orderedDescendingByTotalVisitors)
      {
        Console.WriteLine($"Site: {site.Url} with {site.TotalVisitors} visitors.");
      }
      Console.WriteLine(Environment.NewLine);
    }

    public class Site
    {
      public string Url { get; set; }
      public int TotalVisitors { get; set; }

      public Site(string url, int totalVisitors)
      {
        Url = url;
        TotalVisitors = totalVisitors;
      }
    }
  }
}
