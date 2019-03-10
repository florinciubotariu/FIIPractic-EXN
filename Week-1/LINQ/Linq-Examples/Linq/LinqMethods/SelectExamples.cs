using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Helpers;

namespace Linq.LinqMethods
{
  public static class SelectExamples
  {
    public static void ExampleOne()
    {
      var userList = new List<User>
      {
        new User
        {
          ID = 1,
          Name = "Popescu Ion",
          Age = 18,
          City = "Suceava",
          Country = "Romania",
          University = "Informatica"
        },
        new User
        {
          ID = 2,
          Name = "Miron Paul",
          Age = 23,
          City = "Craiova",
          Country = "Romania",
          University = "Automatica"
        },
        new User
        {
          ID = 3,
          Name = "Balan Andrei",
          Age = 21,
          City = "Cluj-Napoca",
          Country = "Romania",
          University = "Matematica"
        },
        new User
        {
          ID = 4,
          Name = "Covaci Mihai",
          Age = 26,
          City = "Tiraspol",
          Country = "Republica Moldova",
          University = "Informatica"
        }
      };

      var nameOfUsers = userList.Select(user => user.Name);
      var cityOfUsers = userList.Select(user => user.City);
      var ageWithUniversityUsersAnonymousTypes = userList.Select(user => new { user.Age, user.University });
      var ageWithUniversityUsers = userList.Select(user => new AgeWithUniversity { Age = user.Age, University = user.University }).ToList();

      ConsoleHelper.WriteWithGreen("Select - example one");
      foreach (var user in userList)
      {
        Console.WriteLine($"User with ID = {user.ID}, Name = {user.Name}, City = {user.City}, Country = {user.Country}, University = {user.University}, Age = {user.Age}");
      }
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine($"The name of the users: {string.Join(", ", nameOfUsers)} {Environment.NewLine}");
      Console.WriteLine($"The city of the users: {string.Join(", ", cityOfUsers)} {Environment.NewLine}");
      Console.WriteLine("Age with university of the users (anonymous types):");
      foreach (var ageWithUniversityUser in ageWithUniversityUsersAnonymousTypes)
      {
        Console.WriteLine($"Age = {ageWithUniversityUser.Age}, University = {ageWithUniversityUser.University}");
      }
      Console.WriteLine();
      Console.WriteLine("Age with university of the users:" );
      foreach (var ageWithUniversityUser in ageWithUniversityUsers)
      {
        Console.WriteLine($"Age = {ageWithUniversityUser.Age}, University = {ageWithUniversityUser.University}");
      }
      Console.WriteLine(Environment.NewLine);
    }

    public class AgeWithUniversity
    {
      public int Age { get; set; }
      public string University { get; set; }
    }

    public class User
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public string City { get; set; }
      public string Country { get; set; }
      public string University { get; set; }
      public int Age { get; set; }
    }
  }
}
