using ExpertCars.Services.Common.Users;
using ExpertCars.Services.Common.Users.Dto;
using ExpertCars.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;

namespace ExpertCars.Web.Controllers
{
  public class UsersController : Controller
  {
    private readonly IUserService userService;
    public UsersController(IUserService userService) //->https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2
    {
      this.userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      var userDtos = userService.GetUsers() ?? new List<UserDto>();

      var userModels = new List<UserModel>();
      foreach (var userDto in userDtos)
      {
        var userModel = new UserModel();
        userModel.InjectFrom(userDto);
        userModels.Add(userModel);
      }

      return View(userModels); //->https://docs.microsoft.com/en-us/aspnet/core/mvc/views/overview?view=aspnetcore-2.2
    }

    [HttpGet]
    public IActionResult Create() => View(); //->https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members

    [HttpPost]
    public IActionResult Create([FromForm]UserModel userModel) //->https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-2.2
    {
      if (userModel == null) throw new ArgumentNullException(nameof(userModel));
      if (!ModelState.IsValid) { } //?->https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2

      var newUserDto = new CreateUserDto
      {
        Name = userModel.Name,
        Birthday = userModel.Birthday,
        Email = userModel.Email
      };

      userService.AddUser(newUserDto);

      return RedirectToAction(nameof(Index)); //->https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.redirecttoaction?view=aspnetcore-2.2
    }
  }
}
