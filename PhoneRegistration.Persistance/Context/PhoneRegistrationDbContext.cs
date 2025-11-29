using Microsoft.EntityFrameworkCore;
using PhoneRegistration.Domain;

namespace PhoneRegistration.Persistence.Context;

public class PhoneRegistrationDbContext : DbContext
{
    public PhoneRegistrationDbContext(DbContextOptions<PhoneRegistrationDbContext> options) : base(options)
    {
    }

    public DbSet<PhoneNumber> PhoneNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhoneRegistrationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}