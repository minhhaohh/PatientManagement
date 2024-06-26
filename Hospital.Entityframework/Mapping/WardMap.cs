﻿using Hospital.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Entityframework.Mapping
{
    public class WardMap : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.ToTable("Wards");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LevelName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.District)
                .WithMany(x => x.Wards)
                .HasForeignKey(x => x.DistrictCode);
        }
    }
}
