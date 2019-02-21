using LearningHub.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningHub.Database.Student
{
    public sealed class UserLogEntityConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.ToTable("Students", "dbo");

            builder.HasKey(x => x.StudentId);

            builder.Property(x => x.StudentId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Age).IsRequired();
        }
    }
}
