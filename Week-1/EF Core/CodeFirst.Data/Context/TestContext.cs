using CodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data.Context
{
  public class TestContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ArticleTag>().HasKey(t => new { t.ArticleId, t.TagId });
      modelBuilder.Entity<ArticleTag>().ToTable("ArticleTags");
      modelBuilder.Entity<User>().Property(x => x.Name).HasColumnType("nvarchar(30)");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CodeFirstTest1;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
  }
}
