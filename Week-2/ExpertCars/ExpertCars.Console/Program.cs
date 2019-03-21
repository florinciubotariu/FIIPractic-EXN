using ExpertCars.Data.Entities;
using ExpertCars.Data.Infrastructure;
using ExpertCars.Services.Users;
using ExpertCars.Services.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpertCars.Console
{
  class Program
  {
    static void Main(string[] args)
    {
      var context = new ExpertCarsContext();

      var unitOfWork = new UnitOfWork(context);

      var userRepository = new Repository<User>(unitOfWork);

      var userService = new UserService(userRepository, unitOfWork);

      var newUser = new UserDto
      {
        Birthday = new DateTime(2019, 3, 17),
        Email = "test1234",
        Name = "FII Practic"
      };
      userService.AddUser(newUser);

      var searchByEmail = userService.GetUserByEmail("test1234");
    }
  }
}
