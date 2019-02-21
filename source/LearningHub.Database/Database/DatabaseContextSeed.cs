using LearningHub.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Database.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>().HasData(new StudentEntity
            {
                StudentId = 1,
                Name = "Francois",
                Age = 25
            });
        }
    }
}
