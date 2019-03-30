using System;
using System.ComponentModel.DataAnnotations;

namespace ExpertCars.Web.Models.Users
{
  public class UserModel
  {
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public DateTime? Birthday { get; set; }
    [Required]
    [StringLength(30)]
    [EmailAddress]
    public string Email { get; set; }
  }
}
