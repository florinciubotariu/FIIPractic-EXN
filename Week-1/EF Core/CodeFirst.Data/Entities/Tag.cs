using System.Collections.Generic;

namespace CodeFirst.Data.Entities
{
  public class Tag
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
  }
}
