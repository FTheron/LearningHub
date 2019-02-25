using LearningHub.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningHub.Database.Lecturer
{
    public sealed class LecturerEntityConfiguration : IEntityTypeConfiguration<LecturerEntity>
    {
        public void Configure(EntityTypeBuilder<LecturerEntity> builder)
        {
            builder.ToTable("Lecturers", "dbo");

            builder.HasKey(x => x.LecturerId);

            builder.Property(x => x.LecturerId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(x => x.Courses).WithOne(x => x.Lecturer).HasForeignKey(x => x.CourseId);
        }
    }
}
