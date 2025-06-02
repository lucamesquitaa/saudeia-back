using Microsoft.EntityFrameworkCore;
using SaudeIA.Models;

namespace SaudeIA.Data
{
  public class Context : DbContext
  {
    public DbSet<DetalhesModel> Hotel { get; set; }
    public DbSet<FotosDetalhesModel> Photos { get; set; }
    public DbSet<ContatosModel> Contacts { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Relacionamento 1:N entre DetalhesModel e FotosDetalhesModel
      modelBuilder.Entity<DetalhesModel>()
          .HasMany(h => h.Photos)
          .WithOne()
          .HasForeignKey(p => p.DetalhesModelId)
          .OnDelete(DeleteBehavior.Cascade);

      // Relacionamento 1:N entre DetalhesModel e ContatosModel
      modelBuilder.Entity<DetalhesModel>()
          .HasMany(h => h.Contacts)
          .WithOne()
          .HasForeignKey(c => c.DetalhesModelId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
