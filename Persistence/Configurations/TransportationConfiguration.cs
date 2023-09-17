using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class TransportationConfiguration : IEntityTypeConfiguration<Transportation>
{
    public void Configure(EntityTypeBuilder<Transportation> builder)
    {
        builder.ToTable("Transportations").HasKey(b=>b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(b => b.TransportType).HasColumnName("TransportType");
        builder.Property(b => b.AppUserId).HasColumnName("AppUserId");
        builder.Property(b => b.ReservationStatus).HasColumnName("ReservationStatus");
        builder.Property(b => b.TransportDate).HasColumnName("TransportDate");
        builder.HasOne(b => b.AppUser);
        builder.HasMany(b => b.Messages);
    }
}