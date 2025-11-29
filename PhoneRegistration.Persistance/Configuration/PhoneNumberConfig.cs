using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneRegistration.Domain;

namespace PhoneRegistration.Persistence.Configuration;

public class PhoneNumberConfig : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.ToTable("PhoneNumber");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Mobile)
            .IsRequired()
            .HasMaxLength(15);

        builder.HasIndex(p => p.Mobile)
            .IsUnique();
    }
}