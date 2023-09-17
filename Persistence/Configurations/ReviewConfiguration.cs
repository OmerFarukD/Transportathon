using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews").HasKey(b=>b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(b => b.Point).HasColumnName("Point");
        builder.Property(b => b.Comment).HasColumnName("Comment");
        builder.Property(b => b.CompanyId).HasColumnName("CompanyId");
        builder.Property(b => b.AppUserId).HasColumnName("AppUserId");
        builder.HasOne(b => b.Company);
        builder.HasOne(b => b.AppUser);
    }
}