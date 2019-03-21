using System;

namespace ExpertCars.Data.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? Birthday { get; set; }
    public string Email { get; set; }
  }
}
