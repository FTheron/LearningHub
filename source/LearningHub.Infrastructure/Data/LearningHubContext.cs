using LearningHub.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningHub.Infrastructure.Data
{
    public class LearningHubContext : DbContext
    {
        public LearningHubContext(DbContextOptions<LearningHubContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>(ConfigureCourse);
            builder.Entity<Student>(ConfigureStudent);
            builder.Entity<Lecturer>(ConfigureLecturer);
        }

        private void ConfigureCourse(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(x => x.CourseId);
            builder.Property(x => x.CourseId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Lecturer)
                .WithMany()
                .HasForeignKey(x => x.LecturerId);
        }

        private void ConfigureStudent(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(x => x.StudentId);
            builder.Property(x => x.StudentId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Age)
                .IsRequired();

            builder.HasIndex(x => x.CourseId);
            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId);
        }

        private void ConfigureLecturer(EntityTypeBuilder<Lecturer> builder)
        {
            builder.ToTable("Lecturers");

            builder.HasKey(x => x.LecturerId);
            builder.Property(x => x.LecturerId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
