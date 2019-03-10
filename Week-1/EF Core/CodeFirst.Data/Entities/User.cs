using System.Collections.Generic;

namespace CodeFirst.Data.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Article> Articles { get; set; }
    public User()
    {
      Articles = new List<Article>();
    }
  }
}
