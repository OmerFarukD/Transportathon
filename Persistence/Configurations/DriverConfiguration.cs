using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("Drivers").HasKey(b=>b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(b => b.Name).HasColumnName("Name");
        builder.Property(b => b.SurName).HasColumnName("SurName");
        builder.Property(b => b.Phone).HasColumnName("Phone");
        builder.Property(b => b.Email).HasColumnName("Email");
        builder.Property(b => b.CompanyId).HasColumnName("CompanyId");
        builder.HasOne(b => b.Company);
    }
}