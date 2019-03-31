using System;
using System.Collections.Generic;
using System.Linq;
using ExpertCars.Data.Entities;
using ExpertCars.Data.Infrastructure;
using ExpertCars.Services.Common.Users.Dto;
using Omu.ValueInjecter;

namespace ExpertCars.Services.Common.Users
{
  public class UserService : IUserService
  {
    private readonly IRepository<User> userRepository;
    private readonly IUnitOfWork unitOfWork;
    public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
      this.userRepository = userRepository;
      this.unitOfWork = unitOfWork;
    }

    public List<UserDto> GetUsers()
    {
      var userEntities = userRepository.Get();

      var userDtos = new List<UserDto>();
      foreach (var userEntity in userEntities)
      {
        var userDto = new UserDto();
        userDto.InjectFrom(userEntity);
        userDtos.Add(userDto);
      }

      return userDtos;
    }

    public void AddUser(CreateUserDto newUser)
    {
      if (newUser == null) throw new ArgumentNullException(nameof(newUser));

      var user = new User
      {
        Name = newUser.Name,
        Email = newUser.Email,
        Birthday = newUser.Birthday
      };

      userRepository.Add(user);
      unitOfWork.Commit();
    }

    public UserDto GetUserByEmail(string email)
    {
      if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException(nameof(email));

      var user = userRepository.Query(x => x.Email.Equals(email)).FirstOrDefault();
      if (user == null) return null;

      var userDto = new UserDto
      {
        Id = user.Id,
        Birthday = user.Birthday,
        Email = user.Email,
        Name = user.Name
      };
      return userDto;
    }

    public UserDto GetUserById(int id)
    {
      if (id < 1) throw new ArgumentException(nameof(id));

      var user = userRepository.Query(x => x.Id == id).FirstOrDefault();
      if (user == null) return null;

      var userDto = new UserDto
      {
        Id = user.Id,
        Birthday = user.Birthday,
        Email = user.Email,
        Name = user.Name
      };
      return userDto;
    }

    public void UpdateUser(UserDto userDto)
    {
      if (userDto == null) throw new ArgumentNullException(nameof(userDto));

      var user = userRepository.Query(x => x.Id == userDto.Id).FirstOrDefault();
      if (user == null) return;

      user.Name = userDto.Name;
      user.Birthday = userDto.Birthday;
      user.Email = userDto.Email;

      userRepository.Update(user);

      unitOfWork.Commit();
    }
  }
}
