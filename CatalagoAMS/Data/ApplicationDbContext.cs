using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Municipio> Municipios { get; set; }
    public DbSet<Escola> Escolas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Escola>()
            .HasOne(e => e.Municipio)
            .WithMany(m => m.Escolas)
            .HasForeignKey(e => e.MunicipioId);
    }
}
