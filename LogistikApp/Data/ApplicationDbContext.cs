using LogistikApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogistikApp.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<SenderInfo> Senders { get; set; }
    public DbSet<RecipientInfo> Recipients { get; set; }
    public DbSet<PackageInfo> Packages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Treat PackageInfo and RecipientInfo as complex types, not standalone entities
        modelBuilder.Entity<Shipment>().OwnsOne(s => s.Sender);
        modelBuilder.Entity<Shipment>().OwnsOne(s => s.Recipient);
        modelBuilder.Entity<Shipment>().OwnsOne(s => s.Package);
    }
}
