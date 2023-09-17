using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(b=>b.PhoneNumber).HasColumnName("PhoneNumber");
        builder.HasMany(b => b.Reviews);
        builder.HasMany(b => b.Transportations);
        
    }
}
