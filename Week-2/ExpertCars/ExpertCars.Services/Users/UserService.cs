using ExpertCars.Data.Entities;
using ExpertCars.Data.Infrastructure;
using ExpertCars.Services.Users.Dto;
using System;
using System.Linq;

namespace ExpertCars.Services.Users
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

    public void AddUser(UserDto newUser)
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

      var user = userRepository
        .Query(x => x.Email.Equals(email))
        .FirstOrDefault();

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
  }
}
