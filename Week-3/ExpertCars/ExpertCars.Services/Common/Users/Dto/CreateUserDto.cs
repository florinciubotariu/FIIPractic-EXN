using System;

namespace ExpertCars.Services.Common.Users.Dto
{
  public class CreateUserDto
  {
    public string Name { get; set; }
    public DateTime? Birthday { get; set; }
    public string Email { get; set; }
  }
}
