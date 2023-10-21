﻿namespace DataAccess.Configuration;

public class ManufacturerConfiguration : IEntityTypeConfiguration<ManufacturerModel>
{
    public void Configure(EntityTypeBuilder<ManufacturerModel> builder)
    {
        builder.ToTable("Manufacturer");
        builder.HasKey(nameof(ManufacturerModel.ManufacturerId));
        builder.HasOne(e => e.Status)
            .WithMany(e => e.Manufacturers)
            .HasForeignKey(e => e.StatusId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.Widgets)
            .WithOne(e => e.Manufacturer)
            .HasForeignKey(e => e.ManufacturerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
