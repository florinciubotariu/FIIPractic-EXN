using System;
using System.Collections.Generic;
using System.Text;

namespace ExpertCars.Services.Users.Dto
{
  public class UserDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? Birthday { get; set; }
    public string Email { get; set; }
  }
}
