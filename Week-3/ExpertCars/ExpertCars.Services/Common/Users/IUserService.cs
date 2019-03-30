using ExpertCars.Services.Common.Users.Dto;
using System.Collections.Generic;

namespace ExpertCars.Services.Common.Users
{
  public interface IUserService
  {
    List<UserDto> GetUsers();
    void AddUser(CreateUserDto newUser);
    UserDto GetUserByEmail(string email);
  }
}
