﻿using LearningHub.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningHub.Database.Course
{
    public sealed class CourseEntityConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.ToTable("Courses", "dbo");

            builder.HasKey(x => x.CourseId);

            builder.Property(x => x.CourseId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Lecturer).WithMany(x => x.Courses).HasForeignKey(x => x.CourseId);
            builder.HasMany(x => x.Students).WithOne(x => x.Course).HasForeignKey(x => x.StudentId);
        }
    }
}
