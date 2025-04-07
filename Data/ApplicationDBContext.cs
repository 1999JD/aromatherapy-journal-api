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
        modelBuilder.Entity<EssentialOilTag>()
            .HasKey(e => new { e.EssentialOilId, e.TagId });

        modelBuilder.Entity<EssentialOilTag>()
            .HasOne(e => e.EssentialOil)
            .WithMany(e => e.Tags)
            .HasForeignKey(e => e.EssentialOilId);

        // 精油與個人標籤關聯
        modelBuilder.Entity<EssentialOilPersonalTag>()
            .HasKey(e => new { e.EssentialOilId, e.PersonalTagId });

        modelBuilder.Entity<EssentialOilPersonalTag>()
            .HasOne(e => e.EssentialOil)
            .WithMany(e => e.PersonalTags)
            .HasForeignKey(e => e.EssentialOilId);
    }

}