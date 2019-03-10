using System.Collections.Generic;

namespace CodeFirst.Data.Entities
{
  public class Article
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; } //EF Core Convention for Foreign Key
    public User User { get; set; }
    public List<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
  }
}
