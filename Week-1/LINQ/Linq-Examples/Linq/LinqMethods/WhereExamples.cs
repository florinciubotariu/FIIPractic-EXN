using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Helpers;

namespace Linq.LinqMethods
{
  public static class WhereExamples
  {
    public static void ExampleOne()
    {
      var personList = new List<Person>
      {
        new Person(1, "Popescu", "Ion"),
        new Person(2, "Popescu", "Marcel"),
        new Person(3, "Popa", "Mihai")
      };

      var personsWithSpecificId = personList.Where(person => person.ID == 1);
      var personsHavingFirstnameStartingWithPop = personList.Where(person => person.Firstname.StartsWith("Pop"));
      var personsWithSpecificFirstnameAndLastname = personList.Where(person => person.Firstname == "Popescu" && person.Lastname == "Marcel");

      ConsoleHelper.WriteWithGreen("Where - example one");

      Console.WriteLine("List of persons:");
      foreach (var person in personList)
      {
        Console.WriteLine($"Person with ID = {person.ID}, Firstname = {person.Firstname}, Lastname = {person.Lastname}");
      }

      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Persons with ID = 1");
      foreach (var person in personsWithSpecificId)
      {
        Console.WriteLine($"Person with ID = {person.ID}, Firstname = {person.Firstname}, Lastname = {person.Lastname}");
      }

      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Persons having Firstname starting with Pop");
      foreach (var person in personsHavingFirstnameStartingWithPop)
      {
        Console.WriteLine($"Person with ID = {person.ID}, Firstname = {person.Firstname}, Lastname = {person.Lastname}");
      }

      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Persons having Firstname Popescu and Lastname Marcel");
      foreach (var person in personsWithSpecificFirstnameAndLastname)
      {
        Console.WriteLine($"Person with ID = {person.ID}, Firstname = {person.Firstname}, Lastname = {person.Lastname}");
      }
      Console.WriteLine(Environment.NewLine);
    }

    public class Person
    {
      public int ID { get; set; }
      public string Firstname { get; set; }
      public string Lastname { get; set; }

      public Person(int id, string firstname, string lastname)
      {
        ID = id;
        Firstname = firstname;
        Lastname = lastname;
      }
    }
  }
}
