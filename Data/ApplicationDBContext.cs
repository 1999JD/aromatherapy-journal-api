using Microsoft.EntityFrameworkCore;
using api.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<EssentialOil> EssentialOils { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<EssentialOilTag> EssentialOilTags { get; set; }
    public DbSet<PersonalTag> PersonalTags { get; set; }
    public DbSet<EssentialOilPersonalTag> EssentialOilPersonalTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 精油與標籤關聯
        modelBuilder.Entity<EssentialOil>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.EssentialOils)
            .UsingEntity<EssentialOilTag>();

        // 精油與個人標籤關聯
        modelBuilder.Entity<EssentialOil>()
            .HasMany(e => e.PersonalTags)
            .WithMany(e => e.EssentialOils)
            .UsingEntity<EssentialOilPersonalTag>();
    }

}