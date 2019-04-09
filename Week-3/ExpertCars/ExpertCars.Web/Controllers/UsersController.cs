﻿using ExpertCars.Services.Common.Users;
using ExpertCars.Services.Common.Users.Dto;
using ExpertCars.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    public IActionResult Create()
    {
      return View();
    }//->https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members

    [HttpPost]
    public async Task<IActionResult> Create([FromForm]UserModel userModel) //->https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-2.2
    {
      if (userModel == null) throw new ArgumentNullException(nameof(userModel));
      if (!ModelState.IsValid) { } //?->https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2


      var connectionString = "connString";
      CloudStorageAccount.TryParse(connectionString, out CloudStorageAccount storageAccount);
      var blobStorage = storageAccount.CreateCloudBlobClient();
      var blobContainer = blobStorage.GetContainerReference("avatars");
      var blob = blobContainer.GetBlockBlobReference(userModel.Avatar.FileName);
      await blob.UploadFromStreamAsync(userModel.Avatar.OpenReadStream());
      var avataruri = blob.Uri;

        var newUserDto = new CreateUserDto
        {
          Name = userModel.Name,
          Birthday = userModel.Birthday,
          Email = userModel.Email
        };

      userService.AddUser(newUserDto);

      return RedirectToAction(nameof(Index)); //->https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.redirecttoaction?view=aspnetcore-2.2
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
      if (id < 1) { }// ???

      var userDto = userService.GetUserById(id);
      if (userDto == null)
      {
        //redirect undeva. la 404
        return RedirectToAction(nameof(Index));
      }

      var userModel = new UserModel();
      userModel.InjectFrom(userDto);

      return View(userModel);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      if (id < 1) { }

      var userDto = userService.GetUserById(id);
      if (userDto == null)
      {
        //redirect undeva. la 404
        return RedirectToAction(nameof(Index));
      }

      var userModel = new UserModel();
      userModel.InjectFrom(userDto);

      return View(userModel);
    }

    [HttpPost]
    public IActionResult Edit([FromForm] UserModel userModel)
    {
      if (userModel == null) throw new ArgumentNullException(nameof(userModel));
      if (!ModelState.IsValid)
      {
        return View(userModel);
      } //?->https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2

      var userDto = userService.GetUserById(userModel.Id);
      if (userDto == null)
      {
        return RedirectToAction(nameof(Index));
      }

      userDto.Name = userModel.Name;
      userDto.Birthday = userModel.Birthday;
      userDto.Email = userModel.Email;

      userService.UpdateUser(userDto);

      return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      if (id < 1) { }

      var userDto = userService.GetUserById(id);
      if (userDto == null)
      {
        //redirect undeva. la 404
        return RedirectToAction(nameof(Index));
      }

      var userModel = new UserModel();
      userModel.InjectFrom(userDto);

      return View(userModel);
    }
  }
}
